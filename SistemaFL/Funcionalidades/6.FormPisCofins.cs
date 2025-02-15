using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infraestrutura.Seguranca;
using Interfaces;

namespace SistemaFL.Funcionalidades
{
    public partial class FrmFuncPISeCOFINS : Form
    {
        private IFlatRepositorio repositorio;
        private ILancamentoRepositorio lancamentoRepositorio;

        decimal valorPis;
        decimal valorCofins;
        public FrmFuncPISeCOFINS(IFlatRepositorio repositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;


        }
        private void FrmFuncPISeCOFINS_Load(object sender, EventArgs e)
        {
            AtribuiValorPadraoDePiseCofins();
            ConcatenaValoresDePisCofinsAosLabels();
            ckAlterarBases.Checked = false;
            OcultarMostrarAlterarBase();
            var dados = repositorio.ObterDadosPISeCOFINS();
            dgdadosPIS.DataSource = dados;

            AlterarEstilosCabecalho(dgdadosPIS);
            dgdadosPIS.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void ConcatenaValoresDePisCofinsAosLabels()
        {
            lblPisTopo.Text = $"PIS {valorPis:N2} %";
            lblCofinsTopo.Text = $"COFINS {valorCofins:N2} %";
        }
        private void AtribuiValorPadraoDePiseCofins()
        {
            if (Sessao.basePis == null)
            {
                Sessao.basePis = 0.0065m;
                valorPis = (decimal)(Sessao.basePis * 100m);
            }
            if (Sessao.baseCofins == null)
            {
                Sessao.baseCofins = 0.03m;
                valorCofins = (decimal)(Sessao.baseCofins * 100m);
            }
        }
        private void OcultarMostrarAlterarBase()
        {
            if (ckAlterarBases.Checked)
            {
                lblpis.Visible = true;
                txtPis.Visible = true;

                lblcofins.Visible = true;
                txtCofins.Visible = true;

                btnSalvar.Visible = true;
            }
            else
            {
                lblpis.Visible = false;
                txtPis.Visible = false;

                lblcofins.Visible = false;
                txtCofins.Visible = false;

                btnSalvar.Visible = false;
            }
        }
        private void AlterarEstilosCabecalho(DataGridView grid)
        {

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Regular);

            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 35;  // Ajuste o valor conforme necessário
        }
        private void dgdadosPIS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value is decimal or double or int)
            {
                e.Value = string.Format("{0:N2}", e.Value);
                e.FormattingApplied = true;
            }
        }
        private void dgdadosPIS_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgdadosPIS.CellFormatting += dgdadosPIS_CellFormatting;

            if ((dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value != null &&
                     dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value.ToString() == "Aluguel Venceslau") ||
                    (dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value != null &&
                     dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value.ToString() == "Aluguel Flats") ||
                    (dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value != null &&
                     dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value.ToString() == "Fundo de Reserva Flats") ||
                    (dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value != null &&
                     dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value.ToString() == "Base de Cálculo (PIS/COFINS)"))
            {
                e.CellStyle.ForeColor = Color.Green;
            }

            if ((dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value != null &&
                     dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value.ToString() == "PIS") ||
                    (dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value != null &&
                     dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value.ToString() == "COFINS"))
            {
                e.CellStyle.ForeColor = Color.Red;
            }
        }
        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ckAlterarBases_CheckedChanged(object sender, EventArgs e)
        {
            OcultarMostrarAlterarBase();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ckAlterarBases.Checked)
            {
                if (decimal.TryParse(txtPis.Text, out decimal novoValorPis))
                {
                    Sessao.basePis = novoValorPis / 100m;
                }
                else
                {
                    MessageBox.Show("Valor digitado para o campo Pis inválido", "Erro");
                    return;
                }

                if (decimal.TryParse(txtCofins.Text, out decimal novoValorCofins))
                {
                    Sessao.baseCofins = novoValorCofins / 100m;
                }
                else
                {
                    MessageBox.Show("Valor digitado para o campo Cofins inválido", "Erro");
                    return;
                }
            }

            valorPis = (decimal)(Sessao.basePis ?? 0.0065m * 100m);
            valorCofins = (decimal)(Sessao.baseCofins ?? 0.03m * 100m);
            ConcatenaValoresDePisCofinsAosLabels();

            ckAlterarBases.Checked = false;

            var dados = repositorio.ObterDadosPISeCOFINS();
            dgdadosPIS.DataSource = dados;
            dgdadosPIS.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            //Estilos.ReAjustarTamanhoFormulario();
        }
    }
}
