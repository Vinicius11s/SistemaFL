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
        private bool ordenacaoAscendente = true; // Variável para controlar a alternância da ordenação
        private IFlatRepositorio flatRepositório;
        private ILancamentoRepositorio lançamentoRepositório;
        public FrmFuncAluguelDividendo(IFlatRepositorio flatRepositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.flatRepositório = flatRepositorio;
            this.lançamentoRepositório = lancamentoRepositorio;

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();

        }
        private void FrmFuncAluguelDividendo_Load(object sender, EventArgs e)

        {
            this.Location = new System.Drawing.Point(205, 41);
            CarregarGridDados();
            AdicionarLinhaTotal();
            dgdadosAlugDiv.DataBindingComplete += dgdadosAlugDiv_DataBindingComplete;
            CarregarGridTotais();
        }
        private void CarregarGridDados()
        {
            var dados = flatRepositório.ObterDadosAluguelDividendos();
            DataTable dt = ConverterDynamicParaDataTable(dados);
            dgdadosAlugDiv.DataSource = dt;

            Estilos.AlterarEstiloDataGrid(dgdadosAlugDiv);
            AlterarNomesCabecalho();

           
        }      
        private void AlterarNomesCabecalho()
        {          
            dgdadosAlugDiv.Columns["CODFLAT"].Visible = false;

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

            foreach (DataGridViewColumn col in dgdadosAlugDiv.Columns)
            {
                if (col.Name != "CODFLAT")
                {
                    col.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }          
        }    
        private void AdicionarLinhaTotal()
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
            dgdadosAlugDiv.Rows[lastRowIndex].Cells["Bandeira"].Style.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // Definindo os valores das células em negrito, se houver valor
            foreach (var coluna in colunasMeses)
            {
                if (novaLinha[coluna] != DBNull.Value)
                {
                    dgdadosAlugDiv.Rows[lastRowIndex].Cells[coluna].Style.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                }
            }

            dgdadosAlugDiv.AllowUserToAddRows = false;
            dgdadosAlugDiv.Refresh();
        }      
        private void AplicarNegritoUltimaLinha()
        {
            // Verifica se há linhas no DataGridView
            if (dgdadosAlugDiv.Rows.Count > 0)
            {
                int ultimaLinhaIndex = dgdadosAlugDiv.Rows.Count - 1;

                if (!dgdadosAlugDiv.Rows[ultimaLinhaIndex].IsNewRow)
                {
                    dgdadosAlugDiv.Rows[ultimaLinhaIndex].DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                }

                int penultimaLinhaIndex = ultimaLinhaIndex - 1;
                if (penultimaLinhaIndex >= 0 && !dgdadosAlugDiv.Rows[penultimaLinhaIndex].IsNewRow)
                {
                    // Se a penúltima linha for formatada, remova o estilo de negrito
                    dgdadosAlugDiv.Rows[penultimaLinhaIndex].DefaultCellStyle.Font = new Font(dgdadosAlugDiv.Font, FontStyle.Regular);
                }
            }
        }
        private void CarregarGridTotais()
        {
            var dadosTotais = flatRepositório.ObterDadosTotaisALDIV();
            dgtotalmes.DataSource = dadosTotais;

            AplicarFormatacaoGridTotais();
        }
        private void AplicarFormatacaoGridTotais()
        {
            AlterarEstilosCabecalhoGridTotais();
            AlterarEstilosCelulasGridTotais(dgtotalmes);
        }
        private void AlterarEstilosCabecalhoGridTotais()
        {
            dgtotalmes.EnableHeadersVisualStyles = false;
            dgtotalmes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgtotalmes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgtotalmes.Columns["Descricao"].HeaderText = "DESCRIÇÃO";
            dgtotalmes.Columns["Descricao"].HeaderCell.Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }
        private void AlterarEstilosCelulasGridTotais(DataGridView grid)
        {
            dgtotalmes.Columns["Descricao"].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn coluna in dgtotalmes.Columns)
            {
                coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (coluna.Name != "Descricao")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                    coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                }

            }
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
        private void dgdadosAlugDiv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgdadosAlugDiv.Rows)
            {
                Estilos.AplicarFormatacaoLinha(row);
            }
            AplicarNegritoUltimaLinha();
            this.Resize += FrmFuncAluguelDividendo_Resize;

        }
        private void dgdadosAlugDiv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Obtendo o DataTable vinculado ao DataGridView
            DataTable dados = (DataTable)dgdadosAlugDiv.DataSource;

            // Verificar se há dados para manipular
            if (dados.Rows.Count == 0) return;

            // Obtendo o nome da coluna clicada
            string nomeColuna = dgdadosAlugDiv.Columns[e.ColumnIndex].Name;

            // Remover a última linha antes de ordenar
            DataRow ultimaLinha = dados.Rows[dados.Rows.Count - 1];

            // Criando uma nova DataTable sem a última linha
            DataTable dadosSemUltimaLinha = dados.Clone(); // Clona a estrutura do DataTable

            // Adicionar todas as linhas, exceto a última
            foreach (DataRow row in dados.Rows.Cast<DataRow>().Take(dados.Rows.Count - 1))
            {
                dadosSemUltimaLinha.ImportRow(row);
            }

            // Criando um DataView a partir do DataTable sem a última linha
            DataView dataView = dadosSemUltimaLinha.DefaultView;

            // Alternando a ordenação
            if (ordenacaoAscendente)
            {
                dataView.Sort = nomeColuna + " ASC"; // Ordena de forma crescente
            }
            else
            {
                dataView.Sort = nomeColuna + " DESC"; // Ordena de forma decrescente
            }

            // Atualizando a fonte de dados do DataGridView com os dados ordenados (sem a última linha)
            dgdadosAlugDiv.DataSource = dataView.ToTable();  // Atualiza com os dados ordenados

            dados = (DataTable)dgdadosAlugDiv.DataSource;  // Atualiza o DataTable do DataGridView
            dados.ImportRow(ultimaLinha);  // Re-adicionar a última linha no final

            ordenacaoAscendente = !ordenacaoAscendente;
        }
        private void FrmFuncAluguelDividendo_Resize(object sender, EventArgs e)
        {
            Estilos.AjustarMargemDataGrid(dgdadosAlugDiv, this);
            dgtotalmes.Width = this.ClientSize.Width - dgtotalmes.Left - 215; // Mantém a largura ajustada às bordas laterais
            dgtotalmes.Top = this.ClientSize.Height - dgtotalmes.Height - 10;
        }
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela);

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
        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }             
    }
}

