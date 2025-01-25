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
            this.Resize += FrmFuncionalidadeRegisto_Resize;

        }
        private void FrmFuncionalidadeRegisto_Load(object sender, EventArgs e)
        {
            AjustarLayoutFormulario();

            CarregarDadosGrid();
            CarregarTotalInvestimento();
            CarregarTotalFlats();

            dgdadosFunRegistro.DataBindingComplete += dgdadosFunRegistro_DataBindingComplete;
            dgdadosFunRegistro.CellFormatting += dgdadosFunRegistro_CellFormatting;
            dgdadosFunRegistro.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void AjustarLayoutFormulario()
        {
            AjustaPictureBox_MaxMinFechar();
            AjustarTamanhoDataGridView();
        }
        private void AjustaPictureBox_MaxMinFechar()
        {
            int margem = 10;

            // Posição do pbMaximizar (no canto superior direito)
            int x1 = this.ClientSize.Width - pbFechar.Width - margem;
            int y1 = margem;
            pbFechar.Location = new Point(x1, y1);

            // Posição do pbFechar (ao lado esquerdo de pbMaximizar)
            int x2 = x1 - pbMaximizar.Width - margem;
            int y2 = margem;
            pbMaximizar.Location = new Point(x2, y2);
        }
        private void AjustarTamanhoDataGridView()
        {
            int margemDireita = SystemInformation.VerticalResizeBorderThickness;
            int margemInferior = SystemInformation.HorizontalResizeBorderThickness;

            dgdadosFunRegistro.Width = this.ClientSize.Width - dgdadosFunRegistro.Left - margemDireita;
            dgdadosFunRegistro.Top = this.ClientSize.Height - dgdadosFunRegistro.Height - margemInferior;
        }
        //
        //DataGrid Dados
        private void CarregarDadosGrid()
        {
            var dados = flatRepositorio.ObterDadosInvestimento();
            dgdadosFunRegistro.DataSource = dados;
            AplicarFormatacaoGridDados();
        }
        private void AplicarFormatacaoGridDados()
        {
            AlterarEstilosCabecalho();
            AlterarEstilosCelulas();
        }
        private void AlterarEstilosCabecalho()
        {
            dgdadosFunRegistro.EnableHeadersVisualStyles = false;
            dgdadosFunRegistro.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadosFunRegistro.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadosFunRegistro.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Regular);

            dgdadosFunRegistro.Columns["IdFlat"].Visible = false;
            dgdadosFunRegistro.Columns["CnpjRecebimento"].HeaderText = "CNPJ(RECEBIMENTO)";
            dgdadosFunRegistro.Columns["Empresa"].HeaderText = "EMPRESA";

            dgdadosFunRegistro.Columns["DtAquisicao"].HeaderText = "DT AQUISIÇÃO";
            dgdadosFunRegistro.Columns["DtAquisicao"].DefaultCellStyle.Format = "d";

            dgdadosFunRegistro.Columns["Flat"].HeaderText = "FLAT";

            dgdadosFunRegistro.Columns["Unid"].HeaderText = "UNID";
            dgdadosFunRegistro.Columns["Unid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgdadosFunRegistro.Columns["TipoInvestimento"].HeaderText = "TIPO INVESTIMENTO";
            dgdadosFunRegistro.Columns["Cidade"].HeaderText = "CIDADE";
            dgdadosFunRegistro.Columns["Endereco"].HeaderText = "ENDEREÇO";

            dgdadosFunRegistro.Columns["Investimento"].HeaderText = "INVESTIMENTO";
            dgdadosFunRegistro.Columns["Investimento"].DefaultCellStyle.Format = "C2";

            dgdadosFunRegistro.Columns["Status"].HeaderText = "STATUS";
        }
        private void AlterarEstilosCelulas()
        {
            foreach (DataGridViewColumn col in dgdadosFunRegistro.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);  // Espaçamento interno
            }
        }
        private void CarregarTotalInvestimento()
        {
            var totalInvestimento = flatRepositorio.CalcularTotalValorInvestimento();
            lblTotalInvestimento.Text = totalInvestimento.ToString("C");
        }
        private void CarregarTotalFlats()
        {
            var totalFlats = flatRepositorio.CalcularTotalFlats();
            lblTotalFlats.Text = totalFlats.ToString();
        }
        //
        //Formatações do grid
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
        //
        //Após o carregamento
        private void dgdadosFunRegistro_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgdadosFunRegistro.Rows)
            {
                AplicarFormatacaoLinha(row);
                dgdadosFunRegistro.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
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
        //
        //Eventos
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
        private void FrmFuncionalidadeRegisto_Resize(object sender, EventArgs e)
        {
            AjustarLayoutFormulario();
        }
        //
        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pbMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
