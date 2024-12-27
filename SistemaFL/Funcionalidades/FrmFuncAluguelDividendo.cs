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
            this.Resize += FrmFuncAluguelDividendo_Resize;

            var dados = flatRepositório.ObterDadosAluguelDividendos();
            dgdadosAlugDiv.DataSource = dados;
            AjustarFormataçãoGridDados(dgdadosAlugDiv);

            var dadosTotaisInd = flatRepositório.ObterDadosTotaisALDIV(1);
            dgtotaisindividual.DataSource = dadosTotaisInd;
            //tamanho do grid
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



            AjustarFormataçãoGridIndividual(dgtotaisindividual);

            var dadosTotais = flatRepositório.ObterDadosTotaisALDIV(2);
            dgtotalmes.DataSource = dadosTotais;
            AjustarFormataçãoGridTotal(dgtotalmes);
        }

        private void AjustarFormataçãoGridDados(DataGridView grid)
        {
            dgdadosAlugDiv.Columns["ValorImovel"].DefaultCellStyle.Format = "C2";
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

            dgdadosAlugDiv.Columns["AluguelJan"].HeaderText = "Aluguel JAN";
            dgdadosAlugDiv.Columns["DividendosJan"].HeaderText = "Dividendos JAN";

            dgdadosAlugDiv.Columns["AluguelFev"].HeaderText = "Aluguel FEV";
            dgdadosAlugDiv.Columns["DividendosFev"].HeaderText = "Dividendos FEV";

            dgdadosAlugDiv.Columns["AluguelMar"].HeaderText = "Aluguel MAR";
            dgdadosAlugDiv.Columns["DividendosMar"].HeaderText = "Dividendos MAR";

            dgdadosAlugDiv.Columns["AluguelAbr"].HeaderText = "Aluguel ABR";
            dgdadosAlugDiv.Columns["DividendosAbr"].HeaderText = "Dividendos ABR";

            dgdadosAlugDiv.Columns["AluguelMai"].HeaderText = "Aluguel MAI";
            dgdadosAlugDiv.Columns["DividendosMai"].HeaderText = "Dividendos MAI";

            dgdadosAlugDiv.Columns["AluguelJun"].HeaderText = "Aluguel JUN";
            dgdadosAlugDiv.Columns["DividendosJun"].HeaderText = "Dividendos JUN";

            dgdadosAlugDiv.Columns["AluguelJul"].HeaderText = "Aluguel JUL";
            dgdadosAlugDiv.Columns["DividendosJul"].HeaderText = "Dividendos JUL";

            dgdadosAlugDiv.Columns["AluguelAgo"].HeaderText = "Aluguel AGO";
            dgdadosAlugDiv.Columns["DividendosAgo"].HeaderText = "Dividendos AGO";

            dgdadosAlugDiv.Columns["AluguelSet"].HeaderText = "Aluguel SET";
            dgdadosAlugDiv.Columns["DividendosSet"].HeaderText = "Dividendos SET";

            dgdadosAlugDiv.Columns["AluguelOut"].HeaderText = "Aluguel OUT";
            dgdadosAlugDiv.Columns["DividendosOut"].HeaderText = "Dividendos OUT";

            dgdadosAlugDiv.Columns["AluguelNov"].HeaderText = "Aluguel NOV";
            dgdadosAlugDiv.Columns["DividendosNov"].HeaderText = "Dividendos NOV";

            dgdadosAlugDiv.Columns["AluguelDez"].HeaderText = "Aluguel DEZ";
            dgdadosAlugDiv.Columns["DividendosDez"].HeaderText = "Dividendos DEZ";
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

