using Infraestrutura.Repositorio;
using Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
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
    public partial class FrmFuncAluguelDividendo : Form
    {
        private IFlatRepositorio flatRepositório;
        private ILancamentoRepositorio lançamentoRepositório;
        public FrmFuncAluguelDividendo(IFlatRepositorio flatRepositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.flatRepositório = flatRepositorio;
            this.lançamentoRepositório = lancamentoRepositorio;
        }

        private void FrmFuncAluguelDividendo_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            AjustarPosicaoPictureBox();
            AlterarCorFundoETextoCabecalho();
            this.Resize += FrmFuncAluguelDividendo_Resize;

            //Grid Aluguel + Dividendos
            CarregarGridDados();
            //
            //Grid Totais 1
            var dadosTotaisInd = flatRepositório.ObterDadosTotaisALDIV(1);
            dgtotaisindividual.DataSource = dadosTotaisInd;
            AjustaTamanhodosGrids();
            AjustarFormataçãoGridIndividual(dgtotaisindividual);

            //Grid Totais 2
            var dadosTotais = flatRepositório.ObterDadosTotaisALDIV(2);
            dgtotalmes.DataSource = dadosTotais;
            AjustarFormataçãoGridTotal(dgtotalmes);
        }

        private void CarregarGridDados()
        {
            var dados = flatRepositório.ObterDadosAluguelDividendos();
            dgdadosAlugDiv.DataSource = dados;

            AjustarNomesDoCabecalhoDoGrid(dgdadosAlugDiv);
            dgdadosAlugDiv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgdadosAlugDiv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgdadosAlugDiv.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

        }
        private void AlterarCorFundoETextoCabecalho()
        {
            dgdadosAlugDiv.RowTemplate.Height = 29;  // Define a altura de todas as linhas

            foreach (DataGridViewColumn col in dgdadosAlugDiv.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 10, 5, 10);  // Espaçamento interno
            }
            // Desativa o estilo visual para permitir personalização
            dgdadosAlugDiv.EnableHeadersVisualStyles = false;

            dgdadosAlugDiv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadosAlugDiv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadosAlugDiv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        }
        //
        //Formatação dos grids
        private void AjustarNomesDoCabecalhoDoGrid(DataGridView grid)
        {
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgdadosAlugDiv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            foreach (DataGridViewColumn coluna in dgdadosAlugDiv.Columns)
            {
                if (coluna.Name.StartsWith("Aluguel") || coluna.Name.StartsWith("Dividendos"))
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                    coluna.Width = 144;
                }
            }

            dgdadosAlugDiv.Columns["ValorImovel"].HeaderText = "VALOR DO IMÓVEL";
            dgdadosAlugDiv.Columns["ValorImovel"].DefaultCellStyle.Format = "C2";

            dgdadosAlugDiv.Columns["AluguelJan"].HeaderText = "ALUGUEL JAN";
            dgdadosAlugDiv.Columns["DividendosJan"].HeaderText = "DIVIDENDOS JAN";

            dgdadosAlugDiv.Columns["AluguelFev"].HeaderText = "ALUGUEL FEV";
            dgdadosAlugDiv.Columns["DividendosFev"].HeaderText = "DIVIDENDOS FEV";

            dgdadosAlugDiv.Columns["AluguelMar"].HeaderText = "ALUGUEL MAR";
            dgdadosAlugDiv.Columns["DividendosMar"].HeaderText = "DIVIDENDOS MAR";

            /*dgdadosAlugDiv.Columns["AluguelAbr"].HeaderText = "ALUGUEL ABR";
            dgdadosAlugDiv.Columns["DividendosAbr"].HeaderText = "DIVIDENDOS ABR";

            dgdadosAlugDiv.Columns["AluguelMai"].HeaderText = "ALUGUEL MAI";
            dgdadosAlugDiv.Columns["DividendosMai"].HeaderText = "DIVIDENDOS MAI";

            dgdadosAlugDiv.Columns["AluguelJun"].HeaderText = "ALUGUEL JUN";
            dgdadosAlugDiv.Columns["DividendosJun"].HeaderText = "DIVIDENDOS JUN";

            dgdadosAlugDiv.Columns["AluguelJul"].HeaderText = "ALUGUEL JUL";
            dgdadosAlugDiv.Columns["DividendosJul"].HeaderText = "DIVIDENDOS JUL";

            dgdadosAlugDiv.Columns["AluguelAgo"].HeaderText = "ALUGUEL AGO";
            dgdadosAlugDiv.Columns["DividendosAgo"].HeaderText = "DIVIDENDOS AGO";

            dgdadosAlugDiv.Columns["AluguelSet"].HeaderText = "ALUGUEL SET";
            dgdadosAlugDiv.Columns["DividendosSet"].HeaderText = "DIVIDENDOS SET";

            dgdadosAlugDiv.Columns["AluguelOut"].HeaderText = "ALUGUEL OUT";
            dgdadosAlugDiv.Columns["DividendosOut"].HeaderText = "DIVIDENDOS OUT";

            dgdadosAlugDiv.Columns["AluguelNov"].HeaderText = "ALUGUEL NOV";
            dgdadosAlugDiv.Columns["DividendosNov"].HeaderText = "DIVIDENDOS NOV";

            dgdadosAlugDiv.Columns["AluguelDez"].HeaderText = "ALUGUEL DEZ";
            dgdadosAlugDiv.Columns["DividendosDez"].HeaderText = "DIVIDENDOS DEZ";*/
        }
        private void AjustaTamanhodosGrids()
        {
            dgtotaisindividual.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgtotaisindividual.Left = 390;  // Margem fixa à esquerda
            dgtotaisindividual.Width = this.ClientSize.Width - dgtotaisindividual.Left - 20;  // Cresce para a direita
            dgtotaisindividual.Height = 129;  // Altura fixa no rodapé
            dgtotaisindividual.Top = this.ClientSize.Height - dgtotaisindividual.Height - 20;  // Fica no rodapé
            int margemDireita = 0;
            int margemInferior = 0;

            // Verifica se há uma borda no formulário
            if (this.FormBorderStyle != FormBorderStyle.None)
            {
                margemDireita = SystemInformation.VerticalResizeBorderThickness;
                margemInferior = SystemInformation.HorizontalResizeBorderThickness;
            }

            // Ajusta a largura e a posição do grid
            dgtotaisindividual.Width = this.ClientSize.Width - dgtotaisindividual.Left - margemDireita;
            dgtotaisindividual.Top = this.ClientSize.Height - dgtotaisindividual.Height - margemInferior;

        }
        private void AjustarFormataçãoGridIndividual(DataGridView grid)
        {
            foreach (DataGridViewColumn coluna in dgtotaisindividual.Columns)
            {
                coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                coluna.Width = 144;
            }

        }
        private void AjustarFormataçãoGridTotal(DataGridView grid)
        {
            dgtotalmes.Columns["Descricao"].HeaderText = "Descrição";
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn coluna in dgtotalmes.Columns)
            {
                if (coluna.Name != "Descricao")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                    coluna.Width = 288;
                    coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                }

            }
        }
        //
        //Ajuste dos botões fechar e maximizar
        private void FrmFuncAluguelDividendo_Resize(object sender, EventArgs e)
        {
            AjustarPosicaoPictureBox();
            int margemDireita = SystemInformation.VerticalResizeBorderThickness;
            int margemInferior = SystemInformation.HorizontalResizeBorderThickness;

            dgtotaisindividual.Width = this.ClientSize.Width - dgtotaisindividual.Left - margemDireita;
            dgtotaisindividual.Top = this.ClientSize.Height - dgtotaisindividual.Height - margemInferior;
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
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

