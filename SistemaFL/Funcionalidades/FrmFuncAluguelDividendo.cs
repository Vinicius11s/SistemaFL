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
            AjustarPosicaoPictureBox();
            this.Resize += FrmFuncAluguelDividendo_Resize;

            CarregarGridDados();
            AdicionarLinhaTotalALDIV();

            CarregarGridDadosTotais();
            FormatarUltimaLinhaEmNegrito(dgdadosAlugDiv);
        }
        //Datagrid Dados
        private void CarregarGridDados()
        {

            var dados = flatRepositório.ObterDadosAluguelDividendos();
            DataTable dt = ConverterDynamicParaDataTable(dados);
            dgdadosAlugDiv.DataSource = dt;



            AlterarCorFundoETextoCabecalho();
            AjustarNomesDoCabecalhoDoGrid(dgdadosAlugDiv);
            dgdadosAlugDiv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Realiza um redimensionamento adicional após o carregamento dos dados
            dgdadosAlugDiv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgdadosAlugDiv.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);


            foreach (DataGridViewRow row in dgdadosAlugDiv.Rows)
            {
                AplicarFormatacaoLinha(row);
            }


        }
        private void FormatarUltimaLinhaEmNegrito(DataGridView grid)
        {
            int lastRowIndex = grid.Rows.Count - 1;

            // Verifica se há pelo menos uma linha
            if (lastRowIndex >= 0)
            {
                DataGridViewRow ultimaLinha = grid.Rows[lastRowIndex];

                // Aplica negrito a todas as células da última linha
                foreach (DataGridViewCell cell in ultimaLinha.Cells)
                {
                    cell.Style.Font = new Font(grid.Font, FontStyle.Bold);
                }
            }
        }
        private void AlterarCorFundoETextoCabecalho()
        {
            foreach (DataGridViewColumn col in dgdadosAlugDiv.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);  // Espaçamento interno
            }
            // Desativa o estilo visual para permitir personalização
            dgdadosAlugDiv.EnableHeadersVisualStyles = false;
            dgdadosAlugDiv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadosAlugDiv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadosAlugDiv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgtotalmes.EnableHeadersVisualStyles = false;
            dgtotalmes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgtotalmes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgtotalmes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        }
        private void AjustarNomesDoCabecalhoDoGrid(DataGridView grid)
        {
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgdadosAlugDiv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            foreach (DataGridViewColumn coluna in dgdadosAlugDiv.Columns)
            {
                if (coluna.Name != "CODFLAT")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
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

            dgdadosAlugDiv.Columns["AluguelAbr"].HeaderText = "ALUGUEL ABR";
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
            dgdadosAlugDiv.Columns["DividendosDez"].HeaderText = "DIVIDENDOS DEZ";


        }
        private void AdicionarLinhaTotalALDIV()
        {
            DataTable dt = (DataTable)dgdadosAlugDiv.DataSource;

            if (dt == null || dt.Rows.Count == 0) return;

            // Listando os nomes das colunas de meses
            var colunasMeses = new List<string>
            {
                "AluguelJan", "AluguelFev", "AluguelMar", "AluguelAbr", "AluguelMai",
                "AluguelJun", "AluguelJul", "AluguelAgo", "AluguelSet", "AluguelOut",
                "AluguelNov", "AluguelDez",
                "DividendosJan", "DividendosFev", "DividendosMar", "DividendosAbr", "DividendosMai",
                "DividendosJun", "DividendosJul", "DividendosAgo", "DividendosSet", "DividendosOut",
                "DividendosNov", "DividendosDez"
            };

            // Criando uma nova linha para os totais
            DataRow novaLinha = dt.NewRow();

            // Iterando sobre todas as colunas de meses e somando os valores
            foreach (var coluna in colunasMeses)
            {
                decimal somaMes = dt.AsEnumerable().Sum(row =>
                    row.Field<decimal?>(coluna) ?? 0);

                // Se a soma for diferente de zero, exibe o valor; caso contrário, deixa a célula vazia
                novaLinha[coluna] = somaMes != 0 ? somaMes : DBNull.Value;
            }

            // Adicionando a nova linha de totais
            dt.Rows.Add(novaLinha);

            // Acessando a última linha da tabela (total)
            int lastRowIndex = dt.Rows.Count - 1;

            // Definindo o texto "TOTAL" na coluna Bandeira
            dgdadosAlugDiv.Rows[lastRowIndex].Cells["Bandeira"].Value = "TOTAL";
            dgdadosAlugDiv.Rows[lastRowIndex].Cells["Bandeira"].Style.Font = new Font(dgdadosAlugDiv.Font, FontStyle.Bold);

            // Definindo os valores das células em negrito, se houver valor
            foreach (var coluna in colunasMeses)
            {
                if (novaLinha[coluna] != DBNull.Value)
                {
                    dgdadosAlugDiv.Rows[lastRowIndex].Cells[coluna].Style.Font = new Font(dgdadosAlugDiv.Font, FontStyle.Bold);
                }
            }

            dgdadosAlugDiv.AllowUserToAddRows = false;
            dgdadosAlugDiv.Refresh();
        }

        public DataTable ConverterDynamicParaDataTable(IEnumerable<dynamic> lista)
        {
            DataTable tabela = new DataTable();

            if (lista == null || !lista.Any())
                return tabela;

            var primeiroItem = lista.First();
            var propriedades = primeiroItem.GetType().GetProperties();

            foreach (var propriedade in propriedades)
            {
                Type tipo = Nullable.GetUnderlyingType(propriedade.PropertyType) ?? propriedade.PropertyType;
                tabela.Columns.Add(propriedade.Name, tipo);
            }

            foreach (var item in lista)
            {
                DataRow novaLinha = tabela.NewRow();

                foreach (var propriedade in propriedades)
                {
                    var valor = propriedade.GetValue(item);
                    novaLinha[propriedade.Name] = valor ?? DBNull.Value;
                }

                tabela.Rows.Add(novaLinha);
            }

            return tabela;
        }
        //
        //Datagrid Totais 
        private void CarregarGridDadosTotais()
        {
            var dadosTotais = flatRepositório.ObterDadosTotaisALDIV();
            dgtotalmes.DataSource = dadosTotais;
            AlterarCorFundoETextoCabecalho();
            AjustarFormataçãoGridTotal(dgtotalmes);
        }
        private void AjustarFormataçãoGridTotal(DataGridView grid)
        {
            dgtotalmes.Columns["Descricao"].HeaderText = "Descrição";
            dgtotalmes.Columns["Descricao"].DefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn coluna in dgtotalmes.Columns)
            {
                coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (coluna.Name != "Descricao")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                    coluna.Width = 288;
                    coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                }

            }
        }
        //
        //Formatação e tamanho dos grids
        private void AjustaTamanhodosGrids()
        {
            dgtotalmes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgtotalmes.Left = 390;  // Margem fixa à esquerda
            dgtotalmes.Width = this.ClientSize.Width - dgtotalmes.Left - 20;  // Cresce para a direita
            dgtotalmes.Height = 129;  // Altura fixa no rodapé
            dgtotalmes.Top = this.ClientSize.Height - dgtotalmes.Height - 20;  // Fica no rodapé
            int margemDireita = 0;
            int margemInferior = 0;

            // Verifica se há uma borda no formulário
            if (this.FormBorderStyle != FormBorderStyle.None)
            {
                margemDireita = SystemInformation.VerticalResizeBorderThickness;
                margemInferior = SystemInformation.HorizontalResizeBorderThickness;
            }

            // Ajusta a largura e a posição do grid
            dgtotalmes.Width = this.ClientSize.Width - dgtotalmes.Left - margemDireita;
            dgtotalmes.Top = this.ClientSize.Height - dgtotalmes.Height - margemInferior;

        }
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
        }

        //
        //Ajuste dos botões fechar e maximizar
        private void FrmFuncAluguelDividendo_Resize(object sender, EventArgs e)
        {
            AjustarPosicaoPictureBox();
            int margemDireita = SystemInformation.VerticalResizeBorderThickness;
            int margemInferior = SystemInformation.HorizontalResizeBorderThickness;

            dgtotalmes.Width = this.ClientSize.Width - dgtotalmes.Left - margemDireita;
            dgtotalmes.Top = this.ClientSize.Height - dgtotalmes.Height - margemInferior;
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

