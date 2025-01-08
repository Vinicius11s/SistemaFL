using Infraestrutura.Repositorio;
using Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFL.Funcionalidades
{
    public partial class FrmFuncRendimentoscs : Form
    {
        private IFlatRepositorio repositorio;
        private ILancamentoRepositorio LancamentoRepositorio;
        public FrmFuncRendimentoscs(IFlatRepositorio repositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.LancamentoRepositorio = lancamentoRepositorio;
        }

        private void FrmFuncRendimentoscs_Load(object sender, EventArgs e)
        {          
            AjustarPosicaoPictureBox();
            this.Resize += FrmFuncRendimentoscs_Resize;

            CarregarGridDados();
            var dadosTotais = repositorio.ObterDadosTotais();
            dgdadosTotais.DataSource = dadosTotais;
            AjustarColunasGridTotais(dgdadosTotais);
            
        }
        private void CarregarGridDados()
        {

            var dadosRendimentos = repositorio.ObterDadosRendimentos();
            dgdadosRendimentos.DataSource = dadosRendimentos;



            AlterarCorFundoETextoCabecalho();
            AjustarNomesCabecalhoGridDados(dgdadosRendimentos);
            dgdadosRendimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgdadosRendimentos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgdadosRendimentos.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);


            foreach (DataGridViewRow row in dgdadosRendimentos.Rows)
            {
                AplicarFormatacaoLinha(row);
            }


        }
        
        private void AjustarNomesCabecalhoGridDados(DataGridView grid)
        {
            dgdadosRendimentos.Columns["RendimentoAnual"].HeaderText = "Rendimento Anual";
            dgdadosRendimentos.Columns["PorceAnual"].HeaderText = "Média(%) Anual";
            dgdadosRendimentos.Columns["PorceAnual"].DefaultCellStyle.Format = "N2";

            foreach (var coluna in grid.Columns.Cast<DataGridViewColumn>())
            {
                if (coluna.Name.StartsWith("Porcentagem"))
                {
                    coluna.DefaultCellStyle.Format = "N2";
                    coluna.HeaderText = "%";
                }
            }
            foreach (DataGridViewColumn coluna in dgdadosRendimentos.Columns)
            {
                if (!coluna.Name.StartsWith("Porcentagem") && coluna.Name != "CodFlat")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }
            
        }
        private void AlterarCorFundoETextoCabecalho()
        {
            dgdadosRendimentos.RowTemplate.Height = 29;  // Define a altura de todas as linhas

            foreach (DataGridViewColumn col in dgdadosRendimentos.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 10, 5, 10);  // Espaçamento interno
            }
            // Desativa o estilo visual para permitir personalização
            dgdadosRendimentos.EnableHeadersVisualStyles = false;

            dgdadosRendimentos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadosRendimentos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadosRendimentos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgdadosTotais.EnableHeadersVisualStyles = false;
            dgdadosTotais.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadosTotais.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadosTotais.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        }
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
        }
        private void AjustarColunasGridTotais(DataGridView grid)
        {
            foreach (var coluna in grid.Columns.Cast<DataGridViewColumn>())
            {
                if (coluna.Name.StartsWith("Porcentagem"))
                {
                    coluna.DefaultCellStyle.Format = "N2";
                    coluna.HeaderText = "%";
                }
            }
            foreach (DataGridViewColumn coluna in dgdadosTotais.Columns)
            {

                if (!coluna.Name.StartsWith("Porcentagem"))
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }
        }
        private void dgdadosRendimentos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgdadosRendimentos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                dgdadosRendimentos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gainsboro;

            }
        }
        //
        //Botões fechar e maximizar
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
        private void FrmFuncRendimentoscs_Resize(object sender, EventArgs e)
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

        /**/
       
    }
}
