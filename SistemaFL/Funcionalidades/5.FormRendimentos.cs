﻿using Entidades;
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

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();
        }
        private void FrmFuncRendimentoscs_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);                   
        }
        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtano.Text, out int ano))
            {
                var dadosRendimentos = repositorio.ObterDadosRendimentos(ano);
                dgdadosRendimentos.DataSource = dadosRendimentos;

                AplicarFormatacaoGridDados();
                dgdadosRendimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                CarregarGridTotais(ano);
            }
            else MessageBox.Show("Informe um número válido para Ano.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void AplicarFormatacaoGridDados()
        {
            Estilos.AlterarEstiloDataGrid(dgdadosRendimentos);
            AlterarNomesCabecalho(dgdadosRendimentos);
            AlterarEstilosCelulasGridDados(dgdadosRendimentos);
        }
        private void AlterarNomesCabecalho(DataGridView grid)
        {
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 35;  // Ajuste o valor conforme necessário


            grid.Columns["CODFLAT"].Visible = false;
            grid.Columns["ValorImovel"].HeaderText = "VALOR DO IMÓVEL";
            grid.Columns["JANEIRO"].HeaderText = "RENDIMENTO JAN";
            grid.Columns["FEVEREIRO"].HeaderText = "RENDIMENTO FEV";
            grid.Columns["MARÇO"].HeaderText = "RENDIMENTO MAR";
            grid.Columns["ABRIL"].HeaderText = "RENDIMENTO ABR";
            grid.Columns["MAIO"].HeaderText = "RENDIMENTO MAI";
            grid.Columns["JUNHO"].HeaderText = "RENDIMENTO JUN";
            grid.Columns["JULHO"].HeaderText = "RENDIMENTO JUL";
            grid.Columns["AGOSTO"].HeaderText = "RENDIMENTO AGO";
            grid.Columns["SETEMBRO"].HeaderText = "RENDIMENTO SET";
            grid.Columns["OUTUBRO"].HeaderText = "RENDIMENTO OUT";
            grid.Columns["NOVEMBRO"].HeaderText = "RENDIMENTO NOV";
            grid.Columns["DEZEMBRO"].HeaderText = "RENDIMENTO DEZ";

            

        }
        private void AlterarEstilosCelulasGridDados(DataGridView grid)
        {
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);  // Espaçamento interno
            }

            foreach (var coluna in grid.Columns.Cast<DataGridViewColumn>())
            {
                if (coluna.Name.StartsWith("Porcentagem"))
                {
                    coluna.DefaultCellStyle.Format = "N2"; // Duas casas decimais
                    coluna.HeaderText = "%";
                }
                else if (coluna.Name != "PorcentagemAnual") // Aplica o formato de moeda somente em colunas que não sejam de porcentagem
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }

            grid.Columns["RendimentoAnual"].HeaderText = "RENDIMENTO ANUAL";
            grid.Columns["PorcentagemAnual"].HeaderText = "MÉDIA(%) ANUAL";
            grid.Columns["PorcentagemAnual"].DefaultCellStyle.Format = "N2";
        }
        private void dgdadosRendimentos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgdadosRendimentos.Rows)
            {
                AplicarFormatacaoLinha(row);
            }
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
        private void CarregarGridTotais(int ano)
        {
            var dadosTotais = repositorio.ObterDadosTotais(ano);
            dgdadosTotais.DataSource = dadosTotais;

            AlterarEstiloCabecalhoGridTotais(dgdadosTotais);
            AlterarEstiloCelulasGridTotais(dgdadosTotais);
        }
        private void AlterarEstiloCabecalhoGridTotais(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        }
        private void AlterarEstiloCelulasGridTotais(DataGridView grid)
        {
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (var coluna in grid.Columns.Cast<DataGridViewColumn>())
            {
                if (coluna.Name.StartsWith("Porcentagem"))
                {
                    coluna.DefaultCellStyle.Format = "N2";
                    coluna.HeaderText = "%";
                }
            }
            foreach (DataGridViewColumn coluna in grid.Columns)
            {
                grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                if (!coluna.Name.StartsWith("Porcentagem"))
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }
        }
        private void dgdadosRendimentos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Verifica se o índice da coluna está dentro do intervalo válido
            if (e.ColumnIndex >= 0 && e.ColumnIndex < dgdadosRendimentos.Columns.Count)
            {
                List<string> colunasRendimento = new List<string>
            {
                "JANEIRO", "FEVEREIRO", "MARÇO", "ABRIL", "MAIO", "JUNHO",
                "JULHO", "AGOSTO", "SETEMBRO", "OUTUBRO", "NOVEMBRO", "DEZEMBRO"
            };

                if (colunasRendimento.Contains(dgdadosRendimentos.Columns[e.ColumnIndex].Name) && e.RowIndex >= 0)
                {
                    int rowIndex = e.RowIndex;

                    var codFlatValue = dgdadosRendimentos.Rows[rowIndex].Cells["CODFLAT"].Value;

                    if (codFlatValue != null)
                    {
                        int codFlat = Convert.ToInt32(codFlatValue);

                        var flat = repositorio.Recuperar(f => f.id == codFlat);

                        decimal valorEstipulado = flat.ValorDeCompra * 0.01m;

                        e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.CellBounds);

                        decimal valorColuna = Convert.ToDecimal(dgdadosRendimentos.Rows[rowIndex].Cells[e.ColumnIndex].Value);

                        float porcentagem = (float)(valorColuna / valorEstipulado);
                        int larguraBarra = (int)(e.CellBounds.Width * Math.Min(porcentagem, 1)); // Máximo 100%

                        Color corBarra = (valorColuna > valorEstipulado) ? Color.LightGreen : Color.LightGreen;

                        if (valorColuna > 0)
                        {
                            using (SolidBrush brush = new SolidBrush(corBarra))
                            {
                                e.Graphics.FillRectangle(brush, e.CellBounds.X, e.CellBounds.Y, larguraBarra, e.CellBounds.Height);
                            }
                        }

                        using (SolidBrush brushText = new SolidBrush(Color.Black))
                        {
                            string texto = valorColuna.ToString("C"); // Formata como moeda

                            SizeF tamanhoTexto = e.Graphics.MeasureString(texto, e.CellStyle.Font);
                            float xTexto = e.CellBounds.X + (e.CellBounds.Width - tamanhoTexto.Width) / 2;
                            float yTexto = e.CellBounds.Y + (e.CellBounds.Height - tamanhoTexto.Height) / 2;

                            e.Graphics.DrawString(texto, e.CellStyle.Font, brushText, xTexto, yTexto);
                        }

                        e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);

                        e.Handled = true;
                    }
                }
            }

        }
        private void FrmFuncRendimentoscs_Resize(object sender, EventArgs e)
        {
            dgdadosRendimentos.Width = this.ClientSize.Width - dgdadosRendimentos.Left - 215; // Mantém a largura ajustada às bordas laterais
            dgdadosTotais.Width = this.ClientSize.Width - dgdadosTotais.Left - 215; // Mantém a largura ajustada às bordas laterais

            
        }
        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela);
        }
        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}


