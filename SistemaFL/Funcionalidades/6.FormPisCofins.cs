using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Infraestrutura.Contexto;
using Infraestrutura.Seguranca;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace SistemaFL.Funcionalidades
{
    public partial class FrmFuncPISeCOFINS : Form
    {
        private IFlatRepositorio repositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        private IFiscalRepositorio fiscalRepositorio;

        decimal valorPis;
        decimal valorCofins;
        public FrmFuncPISeCOFINS(IFlatRepositorio repositorio, ILancamentoRepositorio lancamentoRepositori, IFiscalRepositorio fiscalRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;
            this.fiscalRepositorio = fiscalRepositorio;

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();
        }
        private void FrmFuncPISeCOFINS_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);

            AtribuiValorPadraoDePiseCofins();      
            ckAlterarBases.Checked = false;
            OcultarMostrarAlterarBase();

            var dados = repositorio.ObterDadosPISeCOFINS();
            dgdadosPIS.DataSource = dados;

            AlterarEstilosCabecalho(dgdadosPIS);
            dgdadosPIS.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void AtribuiValorPadraoDePiseCofins()
        {
            Fiscal fiscal = fiscalRepositorio.Recuperar(x => true);

            if (fiscal != null)
            {
                if (!fiscal.basePis.HasValue)
                {
                    fiscal.basePis = 0.0065m;  
                }

                if (!fiscal.baseCofins.HasValue)
                {
                    fiscal.baseCofins = 0.03m;  
                }
                var contexto = Program.serviceProvider.GetRequiredService<ContextoSistema>();
                contexto.SaveChanges();  
            }
            else
            {
                fiscal = new Fiscal
                {
                    basePis = 0.0065m,
                    baseCofins = 0.03m
                };
                var contexto = Program.serviceProvider.GetRequiredService<ContextoSistema>();
                contexto.Fiscal.Add(fiscal);
                contexto.SaveChanges();
            }
            ConcatenaValoresDePisCofinsAosLabels(fiscal);
        }
        private void ConcatenaValoresDePisCofinsAosLabels(Fiscal fiscal)
        {
            if(fiscal != null)
            {
                
                decimal valorLBLpis = (decimal)(fiscal.basePis * 100);
                decimal valorLBLcofins = (decimal)(fiscal.baseCofins * 100);
                lblPisTopo.Text = $"PIS {valorLBLpis:N2} %";
                lblCofinsTopo.Text = $"COFINS {valorLBLcofins:N2} %";
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
            var contexto = Program.serviceProvider.GetRequiredService<ContextoSistema>();

            // Busca o registro existente no banco
            Fiscal fiscal = contexto.Fiscal.Find(1);

            if (fiscal == null)
            {
                MessageBox.Show("Registro fiscal não encontrado!", "Erro");
                return;
            }

            if (ckAlterarBases.Checked)
            {
                if (!decimal.TryParse(txtPis.Text, out decimal novoValorPis) && decimal.TryParse(txtCofins.Text, out decimal novoValorCofins))
                {
                    fiscal.baseCofins = novoValorCofins / 100m;
                }
                else if (decimal.TryParse(txtPis.Text, out novoValorPis) && !decimal.TryParse(txtCofins.Text, out novoValorCofins))
                {
                    fiscal.basePis = novoValorPis / 100m;
                }
                else if (decimal.TryParse(txtPis.Text, out novoValorPis) && decimal.TryParse(txtCofins.Text, out novoValorCofins))
                {
                    // Atualiza ambos os valores
                    fiscal.basePis = novoValorPis / 100m;
                    fiscal.baseCofins = novoValorCofins / 100m;
                }
                else
                {
                    MessageBox.Show("Valores digitados inválidos para os campos Pis e Cofins", "Erro");
                    return;
                }
            }

            valorPis = (decimal)((fiscal.basePis ?? 0.0065m) * 100m);
            valorCofins = (decimal)((fiscal.baseCofins ?? 0.03m) * 100m);

            ConcatenaValoresDePisCofinsAosLabels(fiscal);
            ckAlterarBases.Checked = false;

            fiscalRepositorio.Alterar(fiscal);
            contexto.SaveChanges();

            var dados = repositorio.ObterDadosPISeCOFINS();
            dgdadosPIS.DataSource = dados;
            dgdadosPIS.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela);
        }
    }
}
