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
        }

        private void FrmFuncionalidadeRegisto_Load(object sender, EventArgs e)
        {
            AlterarCorFundoETextoCabecalho();
            AjustarPosicaoPictureBox();
            this.Resize += FrmFuncionalidadeRegisto_Resize;

            CarregarDadosGrid();

            dgdadosFunRegistro.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            var totalInvestimento = flatRepositorio.CalcularTotalValorInvestimento();
            txtTotalInvestimento.Text = totalInvestimento.ToString("C");

            dgdadosFunRegistro.CellFormatting += dgdadosFunRegistro_CellFormatting;

        }
        private void CarregarDadosGrid()
        {
            var dados = flatRepositorio.ObterDadosInvestimento();
            dgdadosFunRegistro.DataSource = dados;

            AjustarNomesDoCabecalhoDoGrid();

            dgdadosFunRegistro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Realiza um redimensionamento adicional após o carregamento dos dados
            dgdadosFunRegistro.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgdadosFunRegistro.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);


            foreach (DataGridViewRow row in dgdadosFunRegistro.Rows)
            {
                AplicarFormatacaoLinha(row);
            }
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
            if (dgdadosFunRegistro.Columns[e.ColumnIndex].Name == "Status")
            {
                string statusValue = e.Value?.ToString();

                if (statusValue == "Em Construção" || statusValue == "Em Reforma")
                {
                    dgdadosFunRegistro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dgdadosFunRegistro.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
                // Verifica se o status é "Vendido" e pinta a linha de verde
                if (statusValue == "Vendido")
                {
                    dgdadosFunRegistro.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(171, 201, 251);
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
        private void AlterarCorFundoETextoCabecalho()
        {
            dgdadosFunRegistro.RowTemplate.Height = 29;  // Define a altura de todas as linhas

            foreach (DataGridViewColumn col in dgdadosFunRegistro.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 10, 5, 10);  // Espaçamento interno
            }
            // Desativa o estilo visual para permitir personalização
            dgdadosFunRegistro.EnableHeadersVisualStyles = false;

            dgdadosFunRegistro.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadosFunRegistro.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadosFunRegistro.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        }
        private void AjustarNomesDoCabecalhoDoGrid()
        {
            dgdadosFunRegistro.Columns["IdFlat"].HeaderText = "CODFLAT";
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
        private void dgdadosFunRegistro_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                AplicarFormatacaoLinha(dgdadosFunRegistro.Rows[e.RowIndex]);
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
        private void FrmFuncionalidadeRegisto_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgdadosFunRegistro.DataSource = null;
            dgdadosFunRegistro.Rows.Clear();
        }
        //
        //Ajustar botões fechar e maximizar
        private void FrmFuncionalidadeRegisto_Resize(object sender, EventArgs e)
        {
            AjustarPosicaoPictureBox();
        }
        private void AjustarPosicaoPictureBox()
        {
            int margem = 10;

            // Posição do PictureBox1 (no canto superior direito)
            int x1 = this.ClientSize.Width - pictureBox1.Width - margem;
            int y1 = margem;

            pictureBox2.Location = new Point(x1, y1);

            // Posição do PictureBox2 (ao lado esquerdo de PictureBox1)
            int x2 = x1 - pictureBox2.Width - margem;
            int y2 = margem;

            pictureBox1.Location = new Point(x2, y2);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
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
        //      
    }
}
