using Infraestrutura.Repositorio;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFL.Funcionalidades
{
    public partial class FrmFuncionalidadeRegisto : Form
    {
        private IEmpresaRepositorio repositorio;
        private IFlatRepositorio flatRepositorio;
        public FrmFuncionalidadeRegisto(IEmpresaRepositorio repositorio, IFlatRepositorio flatRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.flatRepositorio = flatRepositorio;
            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();

        }
        private void FrmFuncionalidadeRegisto_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);
            AjustarTamanhoDataGridView();

            CarregarDadosGrid();
            CarregarTotalInvestimento();
            CarregarTotalFlats();

            dgdadosFunRegistro.DataBindingComplete += dgdadosFunRegistro_DataBindingComplete;
            dgdadosFunRegistro.CellFormatting += dgdadosFunRegistro_CellFormatting;
            dgdadosFunRegistro.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void AjustarTamanhoDataGridView()
        {
            int margemDireita = SystemInformation.VerticalResizeBorderThickness;
            int margemInferior = SystemInformation.HorizontalResizeBorderThickness;

            dgdadosFunRegistro.Width = this.ClientSize.Width - dgdadosFunRegistro.Left - margemDireita;
            dgdadosFunRegistro.Top = this.ClientSize.Height - dgdadosFunRegistro.Height - margemInferior;
        }
        private void CarregarDadosGrid()
        {
            var dados = flatRepositorio.ObterDadosInvestimento();
            dgdadosFunRegistro.DataSource = dados;

            Estilos.AlterarEstiloDataGrid(dgdadosFunRegistro);
            AlterarNomesCabecalho();

            foreach (DataGridViewRow row in dgdadosFunRegistro.Rows)
            {
                AplicarFormatacaoLinha(row);
            }
        }     
        private void AlterarNomesCabecalho()
        {
            dgdadosFunRegistro.Columns["IdFlat"].Visible = false;
            dgdadosFunRegistro.Columns["CnpjRecebimento"].HeaderText = "CNPJ(RECEBIMENTO)";
            dgdadosFunRegistro.Columns["DtAquisicao"].HeaderText = "DT AQUISIÇÃO";
            dgdadosFunRegistro.Columns["DtAquisicao"].DefaultCellStyle.Format = "d";
            dgdadosFunRegistro.Columns["Unid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgdadosFunRegistro.Columns["TipoInvestimento"].HeaderText = "TIPO INVESTIMENTO";
            dgdadosFunRegistro.Columns["Investimento"].DefaultCellStyle.Format = "C2";

            foreach (DataGridViewColumn col in dgdadosFunRegistro.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);  // Espaçamento interno
            }

        }     
        private void CarregarTotalInvestimento()
        {
            var totalInvestimento = flatRepositorio.CalcularTotalValorDeCompra();
            lblTotalInvestimento.Text = totalInvestimento.ToString("C");
        }
        private void CarregarTotalFlats()
        {
            var totalFlats = flatRepositorio.CalcularTotalFlats();
            lblTotalFlats.Text = totalFlats.ToString();
        }       
        private string FormatarCnpj(string cnpj)
        {
            // Remove quaisquer caracteres não numéricos
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            // Verifica se o CNPJ tem o tamanho correto
            if (cnpj.Length == 14)
            {
                return string.Format("{0:00\\.000\\.000\\/0000\\-00}", double.Parse(cnpj));
            }

            return cnpj; // Retorna o valor original caso não seja um CNPJ válido
        }      
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {

            var statusValue = row.Cells["Status"].Value?.ToString();

            if (statusValue == "Em Construção" || statusValue == "Em Reforma")
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

            if (statusValue == "Vendido")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(171, 201, 251);
            }
            else
            {
                row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
            }
        }
        private void dgdadosFunRegistro_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgdadosFunRegistro.Rows)
            {
                AplicarFormatacaoLinha(row);
                dgdadosFunRegistro.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }
        private void FrmFuncionalidadeRegisto_Resize(object sender, EventArgs e)
        {
            dgdadosFunRegistro.Width = this.ClientSize.Width - dgdadosFunRegistro.Left - 210;
            pbFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }
        private void dgdadosFunRegistro_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AplicarFormatacaoLinha(dgdadosFunRegistro.Rows[e.RowIndex]);
            }
        }
        private void FrmFuncionalidadeRegisto_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgdadosFunRegistro.DataSource = null;
            dgdadosFunRegistro.Rows.Clear();
        }
        private void dgdadosFunRegistro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgdadosFunRegistro.Columns[e.ColumnIndex].Name == "CnpjRecebimento")
            {
                if (e.Value != null && e.Value is string cnpj)
                {
                    // Aplica a máscara de CNPJ ao valor
                    e.Value = FormatarCnpj(cnpj);
                }
            }
        }
        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela);
            dgdadosFunRegistro.Resize += FrmFuncionalidadeRegisto_Resize;
        }      
        private void pbMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
