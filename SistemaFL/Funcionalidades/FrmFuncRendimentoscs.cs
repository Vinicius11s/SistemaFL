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
            AjustarLayoutFormulario();
            CarregarGridDados();
            CarregarGridTotais();
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



            dgdadosRendimentos.Top = 50; // Exemplo de valor fixo ou calculado de acordo com o layout da interface
        }

        //
        //DataGrid Dados (1)
        private void CarregarGridDados()
        {
            var dadosRendimentos = repositorio.ObterDadosRendimentos();
            dgdadosRendimentos.DataSource = dadosRendimentos;
            AplicarFormatacaoGridDados();
            dgdadosRendimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        private void AplicarFormatacaoGridDados()
        {
            AlterarEstilosCabecalho(dgdadosRendimentos);
            AlterarEstilosCelulasGridDados(dgdadosRendimentos);
        }
        private void AlterarEstilosCabecalho(DataGridView grid)
        {

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Regular);

            if (grid == dgdadosRendimentos)
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
            }
        }
        private void AlterarEstilosCelulasGridDados(DataGridView grid)
        {


            foreach (var coluna in grid.Columns.Cast<DataGridViewColumn>())
            {
                if (coluna.Name.StartsWith("Porcentagem"))
                {
                    coluna.DefaultCellStyle.Format = "N2";//DUAS CASAS
                    coluna.HeaderText = "%";
                }
            }
            dgdadosRendimentos.Columns["RendimentoAnual"].HeaderText = "RENDIMENTO ANUAL";
            dgdadosRendimentos.Columns["PorcentagemAnual"].HeaderText = "MÉDIA(%) ANUAL";
            dgdadosRendimentos.Columns["PorcentagemAnual"].DefaultCellStyle.Format = "N2";

            foreach (DataGridViewColumn coluna in dgdadosRendimentos.Columns)
            {
                if (!coluna.Name.StartsWith("Porcentagem") && coluna.Name != "CODFLAT" && coluna.Name != "MediaAnual")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }


        }
        //
        //Após o carregamento do Grid 1
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
        //
        //DataGrid Totais
        private void CarregarGridTotais()
        {
            var dadosTotais = repositorio.ObterDadosTotais();
            dgdadosTotais.DataSource = dadosTotais;

            AlterarEstilosCabecalho(dgdadosTotais);
            AlterarEstiloCelulasGridTotais(dgdadosTotais);
        }
        private void AlterarEstiloCelulasGridTotais(DataGridView grid)
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
        //
        //Eventos
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

        private void FrmFuncRendimentoscs_Resize(object sender, EventArgs e)
        {
            AjustarTamanhoDataGridView();
        }
    }
}


