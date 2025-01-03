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
            AjustarPosicaoPictureBox();

            var dados = flatRepositorio.ObterDadosDividendos();
            DataTable dt = ConverterDynamicParaDataTable(dados);
            dgdadosDiv.DataSource = dt;

            AlterarCorFundoETextoCabecalho();
            AjustarFormataçãoGridDados(dgdadosDiv);         
            AdicionarLinhaTotalDiv();            
        }
        private void AlterarCorFundoETextoCabecalho()
        {
            foreach (DataGridViewColumn col in dgdadosDiv.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);  // Espaçamento interno
            }
            // Desativa o estilo visual para permitir personalização
            dgdadosDiv.EnableHeadersVisualStyles = false;
            dgdadosDiv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadosDiv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadosDiv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);


        }
        private void AjustarFormataçãoGridDados(DataGridView grid)
        {
            dgdadosDiv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            foreach (DataGridViewColumn coluna in dgdadosDiv.Columns)
            {
                if (coluna.Name != "CODFLAT")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }
            dgdadosDiv.Columns["ValorImovel"].HeaderText = "VALOR DO IMÓVEL";
            dgdadosDiv.Columns["DividendosJan"].HeaderText = "JANEIRO DIVIDENDOS";
            dgdadosDiv.Columns["DividendosFev"].HeaderText = "FEVEREIRO DIVIDENDOS";
            dgdadosDiv.Columns["DividendosMar"].HeaderText = "MARÇO DIVIDENDOS";
            dgdadosDiv.Columns["DividendosAbr"].HeaderText = "ABRIL DIVIDENDOS";
            dgdadosDiv.Columns["DividendosMai"].HeaderText = "MAIO DIVIDENDOS";
            dgdadosDiv.Columns["DividendosJun"].HeaderText = "JUNHO DIVIDENDOS";
            dgdadosDiv.Columns["DividendosJul"].HeaderText = "JULHO DIVIDENDOS";
            dgdadosDiv.Columns["DividendosAgo"].HeaderText = "AGOSTO DIVIDENDOS";
            dgdadosDiv.Columns["DividendosSet"].HeaderText = "SETEMBRO DIVIDENDOS";
            dgdadosDiv.Columns["DividendosOut"].HeaderText = "OUTUBRO DIVIDENDOS";
            dgdadosDiv.Columns["DividendosNov"].HeaderText = "NOVEMBRO DIVIDENDOS";
            dgdadosDiv.Columns["DividendosDez"].HeaderText = "DEZEMBRO DIVIDENDOS";
        }
        private void FrmFuncDividendos_Resize(object sender, EventArgs e)
        {
            AjustarPosicaoPictureBox();
            int margemDireita = SystemInformation.VerticalResizeBorderThickness;
            int margemInferior = SystemInformation.HorizontalResizeBorderThickness;

            dgdadosDiv.Width = this.ClientSize.Width - dgdadosDiv.Left - margemDireita;
            dgdadosDiv.Top = this.ClientSize.Height - dgdadosDiv.Height - margemInferior;
        }
        private void AdicionarLinhaTotalDiv()
        {
            DataTable dt = (DataTable)dgdadosDiv.DataSource;

            if (dt == null || dt.Rows.Count == 0) return;

            // Listando os nomes das colunas de meses
            var colunasMeses = new List<string>
            {
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
            dgdadosDiv.Rows[lastRowIndex].Cells["Bandeira"].Value = "TOTAL";
            dgdadosDiv.Rows[lastRowIndex].Cells["Bandeira"].Style.Font = new Font(dgdadosDiv.Font, FontStyle.Bold);

            // Definindo os valores das células em negrito, se houver valor
            foreach (var coluna in colunasMeses)
            {
                if (novaLinha[coluna] != DBNull.Value)
                {
                    dgdadosDiv.Rows[lastRowIndex].Cells[coluna].Style.Font = new Font(dgdadosDiv.Font, FontStyle.Bold);
                }
            }

            dgdadosDiv.AllowUserToAddRows = false;
            dgdadosDiv.Refresh();
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
        //Botões Maximizar e fechar
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
