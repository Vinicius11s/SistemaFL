﻿using Infraestrutura.Repositorio;
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
        private void dgdadosFunRegistro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgdadosFunRegistro.Columns[e.ColumnIndex].Name == "CnpjRecebimento")
            {
                if (e.Value != null && e.Value is string cnpj)
                {
                    // Aplica a máscara de CNPJ ao valor
                    e.Value = FormatCnpj(cnpj);
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
            }
        }
        private string FormatCnpj(string cnpj)
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
        private void AlterarCorFundoETextoCabecalho()
        {
            dgdadosFunRegistro.RowTemplate.Height = 29;  // Define a altura de todas as linhas

            foreach (DataGridViewColumn col in dgdadosFunRegistro.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 10, 5, 10);  // Espaçamento interno
            }
            // Desativa o estilo visual para permitir personalização
            dgdadosFunRegistro.EnableHeadersVisualStyles = false;

            // Define a cor de fundo do cabeçalho
            dgdadosFunRegistro.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);

            // Define a cor do texto do cabeçalho
            dgdadosFunRegistro.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Deixa o texto do cabeçalho em negrito
            dgdadosFunRegistro.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        }
        private void AjustarGridDadods()
        {
            dgdadosFunRegistro.Columns["IdFlat"].HeaderText = "CODFLAT";
            dgdadosFunRegistro.Columns["CnpjRecebimento"].HeaderText = "CNPJ(RECEBIMENTO)";
            dgdadosFunRegistro.Columns["Empresa"].HeaderText = "EMPRESA";
            dgdadosFunRegistro.Columns["DtAquisicao"].HeaderText = "DT AQUISIÇÃO";
            dgdadosFunRegistro.Columns["Flat"].HeaderText = "FLAT";
            dgdadosFunRegistro.Columns["Unid"].HeaderText = "UNID";
            dgdadosFunRegistro.Columns["TipoInvestimento"].HeaderText = "TIPO INVESTIMENTO";
            dgdadosFunRegistro.Columns["Cidade"].HeaderText = "CIDADE";
            dgdadosFunRegistro.Columns["Endereco"].HeaderText = "ENDEREÇO";

            dgdadosFunRegistro.Columns["Investimento"].HeaderText = "INVESTIMENTO";
            dgdadosFunRegistro.Columns["Investimento"].DefaultCellStyle.Format = "C2";

            dgdadosFunRegistro.Columns["Status"].HeaderText = "STATUS";
        }
        private void dgdadosFunRegistro_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Alternar cor de fundo: linhas ímpares em cinza claro, linhas pares em branco
            if (e.RowIndex % 2 == 0)
            {
                dgdadosFunRegistro.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                dgdadosFunRegistro.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gainsboro;
            }
        }
        private void FrmFuncionalidadeRegisto_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgdadosFunRegistro.DataSource = null;
            dgdadosFunRegistro.Rows.Clear();
        }
        private void CarregarDadosGrid()
        {
            var dados = flatRepositorio.ObterDadosInvestimento();
            dgdadosFunRegistro.DataSource = dados;
            AjustarGridDadods();
        }
    }
}
