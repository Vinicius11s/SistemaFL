using Entidades;
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
        private void dgdadosRendimentos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Verifica se o índice da coluna está dentro do intervalo válido
            if (e.ColumnIndex >= 0 && e.ColumnIndex < dgdadosRendimentos.Columns.Count)
            {
                List<string> colunasRendimento = new List<string>
                {
                    "JANEIRO", "FEVEREIRO", "MARÇO", "ABRIL", "MAIO", "JUNHO", "JULHO", "AGOSTO",
                    "SETEMBRO", "OUTUBRO", "NOVEMBRO", "DEZEMBRO"
                };

                if (colunasRendimento.Contains(dgdadosRendimentos.Columns[e.ColumnIndex].Name) && e.RowIndex >= 0)
                {
                    // Identificar a linha atual sendo processada
                    int rowIndex = e.RowIndex;

                    // Recuperar o valor de CODFLAT da célula correspondente na linha
                    var codFlatValue = dgdadosRendimentos.Rows[rowIndex].Cells["CODFLAT"].Value;

                    if (codFlatValue != null)
                    {
                        // Converter para o tipo apropriado (supondo que seja um inteiro)
                        int codFlat = Convert.ToInt32(codFlatValue);

                        // Usar o repositório para recuperar o objeto flat com base no CODFLAT
                        var flat = repositorio.Recuperar(f => f.id == codFlat);

                        // Calcular o valor estipulado, passando o objeto flat como parâmetro
                        decimal valorEstipulado = flat.ValorInvestimento * 0.02m;

                        // Pinte o fundo da célula primeiro (garante que a célula tem o fundo correto)
                        e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.CellBounds);

                        // Obtenha o valor da célula
                        decimal valorColuna = Convert.ToDecimal(dgdadosRendimentos.Rows[rowIndex].Cells[e.ColumnIndex].Value);

                        // Calcule a largura da barra com base no valor da célula
                        float porcentagem = (float)(valorColuna / valorEstipulado);
                        int larguraBarra = (int)(e.CellBounds.Width * porcentagem);

                        // Se o valor for maior que zero, desenhe a barra
                        if (valorColuna > 0)
                        {
                            using (SolidBrush brush = new SolidBrush(Color.LightGreen)) // Barra verde clara
                            {
                                // Desenha a barra na célula (sem modificar a largura da célula)
                                e.Graphics.FillRectangle(brush, e.CellBounds.X, e.CellBounds.Y, larguraBarra, e.CellBounds.Height);
                            }
                        }

                        // Desenha o texto sobre a barra (valor da coluna), ajustado para exibir no topo da célula
                        using (SolidBrush brushText = new SolidBrush(Color.Black))
                        {
                            string texto = valorColuna.ToString("C"); // Formata como moeda
                            e.Graphics.DrawString(texto, e.CellStyle.Font, brushText, e.CellBounds.X + 5, e.CellBounds.Y + 5);
                        }

                        // Desenha a borda ao redor da célula (somente borda, não sobrescreve o conteúdo)
                        e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);

                        e.Handled = true;
                    }               
                }
            }
        }        
    }
}


