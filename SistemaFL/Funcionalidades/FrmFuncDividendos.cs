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
    public partial class FrmFuncDividendos : Form
    {
        private IFlatRepositorio flatRepositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        public FrmFuncDividendos(IFlatRepositorio flatRepositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.flatRepositorio = flatRepositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;
        }

        private void FrmFuncDividendos_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            AjustarPosicaoPictureBox();

            var dados = flatRepositorio.ObterDadosDividendos();
            dgdadosDiv.DataSource = dados;
            AjustarFormataçãoGridDados(dgdadosDiv);

            var totais = flatRepositorio.ObterDadosTotaisDividendos();
            dgtotais.DataSource = totais;
            foreach (DataGridViewColumn coluna in dgtotais.Columns)
            {
                if (coluna.Name != "Descricao")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }
        }
        private void AjustarFormataçãoGridDados(DataGridView grid)
        {
            dgdadosDiv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgdadosDiv.Columns["ValorImovel"].DefaultCellStyle.Format = "C2";
            dgdadosDiv.Columns["ValorImovel"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("pt-BR"); dgdadosDiv.Columns["DividendosJan"].HeaderText = "Dividendos JAN";

            foreach (DataGridViewColumn coluna in dgdadosDiv.Columns)
            {
                if (coluna.Name != "CodFlat")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }
            dgdadosDiv.Columns["ValorImovel"].HeaderText = "Valor Imóvel";
            dgdadosDiv.Columns["DividendosJan"].HeaderText = "Janeiro Dividendos";
            dgdadosDiv.Columns["DividendosFev"].HeaderText = "Fevereiro Dividendos";
            dgdadosDiv.Columns["DividendosMar"].HeaderText = "Março Dividendos";
            dgdadosDiv.Columns["DividendosAbr"].HeaderText = "Abril Dividendos";
            dgdadosDiv.Columns["DividendosMai"].HeaderText = "Maio Dividendos";
            dgdadosDiv.Columns["DividendosJun"].HeaderText = "Junho Dividendos";
            dgdadosDiv.Columns["DividendosJul"].HeaderText = "Julho Dividendos";
            dgdadosDiv.Columns["DividendosAgo"].HeaderText = "Agosto Dividendos";
            dgdadosDiv.Columns["DividendosSet"].HeaderText = "Setembro Dividendos";
            dgdadosDiv.Columns["DividendosOut"].HeaderText = "Outubro Dividendos";
            dgdadosDiv.Columns["DividendosNov"].HeaderText = "Novembro Dividendos";
            dgdadosDiv.Columns["DividendosDez"].HeaderText = "Dezembro Dividendos";
        }

        private void FrmFuncDividendos_Resize(object sender, EventArgs e)
        {
            AjustarPosicaoPictureBox();
            int margemDireita = SystemInformation.VerticalResizeBorderThickness;
            int margemInferior = SystemInformation.HorizontalResizeBorderThickness;

            dgdadosDiv.Width = this.ClientSize.Width - dgdadosDiv.Left - margemDireita;
            dgdadosDiv.Top = this.ClientSize.Height - dgdadosDiv.Height - margemInferior;
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
        //Botão Maximizar
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
        //Botão fechar
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
