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
            AlterarCorFundoETextoCabecalho();


            var dadosTotais = repositorio.ObterDadosTotais();
            dgdadosTotais.DataSource = dadosTotais;
            AjustarColunasGridTotais(dgdadosTotais);
            
        }
        private void CarregarGridDados()
        {

            var dadosRendimentos = repositorio.ObterDadosRendimentos();
            dgdadosRendimentos.DataSource = dadosRendimentos;

            AjustarNomesCabecalhoGridDados(dgdadosRendimentos);
            dgdadosRendimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

             foreach (DataGridViewRow row in dgdadosRendimentos.Rows)
            {
                AplicarFormatacaoLinha(row);
            }

        }
        
        private void AjustarNomesCabecalhoGridDados(DataGridView grid)
        {
            dgdadosRendimentos.Columns["ValorImovel"].HeaderText = "VALOR DO IMÓVEL";
            dgdadosRendimentos.Columns["JANEIRO"].HeaderText = "RENDIMENTO JAN";
            dgdadosRendimentos.Columns["FEVEREIRO"].HeaderText = "RENDIMENTO FEV";
            dgdadosRendimentos.Columns["MARÇO"].HeaderText = "RENDIMENTO MAR";
            dgdadosRendimentos.Columns["ABRIL"].HeaderText = "RENDIMENTO ABR";
            dgdadosRendimentos.Columns["MAIO"].HeaderText = "RENDIMENTO MAI";
            dgdadosRendimentos.Columns["JUNHO"].HeaderText = "RENDIMENTO JUN";
            dgdadosRendimentos.Columns["JULHO"].HeaderText = "RENDIMENTO JUL";
            dgdadosRendimentos.Columns["AGOSTO"].HeaderText = "RENDIMENTO AGO";
            dgdadosRendimentos.Columns["SETEMBRO"].HeaderText = "RENDIMENTO SET";
            dgdadosRendimentos.Columns["OUTUBRO"].HeaderText = "RENDIMENTO OUT";
            dgdadosRendimentos.Columns["NOVEMBRO"].HeaderText = "RENDIMENTO NOV";
            dgdadosRendimentos.Columns["DEZEMBRO"].HeaderText = "RENDIMENTO DEZ";
           
            foreach (var coluna in grid.Columns.Cast<DataGridViewColumn>())
            {
                if (coluna.Name.StartsWith("Porcentagem"))
                {
                    coluna.DefaultCellStyle.Format = "N2";//DUAS CASAS
                    coluna.HeaderText = "%";
                }
            }
            dgdadosRendimentos.Columns["RendimentoAnual"].HeaderText = "RENDIMENTO ANUAL";
            dgdadosRendimentos.Columns["PorceAnual"].HeaderText = "MÉDIA(%) ANUAL";
            dgdadosRendimentos.Columns["PorceAnual"].DefaultCellStyle.Format = "N2";

            foreach (DataGridViewColumn coluna in dgdadosRendimentos.Columns)
            {
                if (!coluna.Name.StartsWith("Porcentagem") && coluna.Name != "CODFLAT" && coluna.Name != "MediaAnual")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }


        }
        private void AlterarCorFundoETextoCabecalho()
        {
            foreach (DataGridViewColumn col in dgdadosRendimentos.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);  // Espaçamento interno
            }
            // Desativa o estilo visual para permitir personalização
            dgdadosRendimentos.EnableHeadersVisualStyles = false;
            dgdadosRendimentos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadosRendimentos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadosRendimentos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

        }
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {
            string statusValue = string.Empty;

            foreach (DataGridViewRow rows in dgdadosRendimentos.Rows)
            {
                if (rows.Cells["CODFLAT"].Value != null)
                {
                    int idFlat = Convert.ToInt32(row.Cells["CODFLAT"].Value);
                    var flat = repositorio.Recuperar(f => f.id == idFlat);

                    statusValue = flat.Status;
                }

                // Aplica a formatação apenas nas colunas desejadas
                if (statusValue == "Em Construção" || statusValue == "Em Reforma")
                {
                    row.Cells["EMPREENDIMENTO"].Style.ForeColor = Color.Red;
                    row.Cells["CODFLAT"].Style.ForeColor = Color.Red;
                    row.Cells["ValorImovel"].Style.ForeColor = Color.Red;
                }
                else
                {
                    row.Cells["EMPREENDIMENTO"].Style.ForeColor = Color.Black;
                    row.Cells["CODFLAT"].Style.ForeColor = Color.Black;
                    row.Cells["ValorImovel"].Style.ForeColor = Color.Black;
                }

                if (statusValue == "Vendido")
                {
                    row.Cells["EMPREENDIMENTO"].Style.BackColor = Color.FromArgb(171, 201, 251);
                    row.Cells["CODFLAT"].Style.BackColor = Color.FromArgb(171, 201, 251);
                    row.Cells["ValorImovel"].Style.BackColor = Color.FromArgb(171, 201, 251);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
                }
            }
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
            if (e.RowIndex >= 0)
            {
                AplicarFormatacaoLinha(dgdadosRendimentos.Rows[e.RowIndex]);
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
