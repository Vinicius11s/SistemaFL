using Infraestrutura.Repositorio;
using Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        private bool ordenacaoAscendente = true;
        private IFlatRepositorio flatRepositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        public FrmFuncDividendos(IFlatRepositorio flatRepositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.flatRepositorio = flatRepositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();
        }
        private void FrmFuncDividendos_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);
            CarregarDataGridDados();
            AdicionarLinhaTotal();
            dgdadosDiv.DataBindingComplete += dgdadosDiv_DataBindingComplete;
        }
        private void CarregarDataGridDados()
        {
            var dados = flatRepositorio.ObterDadosDividendos();
            DataTable dt = ConverterDynamicParaDataTable(dados);
            dgdadosDiv.DataSource = dt;

            Estilos.AlterarEstiloDataGrid(dgdadosDiv);
            AlterarNomesDoCabecalho(dgdadosDiv);

        }       
        private void AlterarNomesDoCabecalho(DataGridView grid)
        {               
            if(grid.Rows.Count > 0)
            {
                dgdadosDiv.Columns["CODFLAT"].Visible = false;
                dgdadosDiv.Columns["ValorImovel"].HeaderText = "VALOR IMÓVEL";
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

                grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgdadosDiv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                foreach (DataGridViewColumn col in grid.Columns)
                {
                    if (col.Name != "CODFLAT")
                    {
                        col.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    }
                }
            }
           
        }     
        private void AdicionarLinhaTotal()
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
            dgdadosDiv.Rows[lastRowIndex].Cells["Bandeira"].Style.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // Definindo os valores das células em negrito, se houver valor
            foreach (var coluna in colunasMeses)
            {
                if (novaLinha[coluna] != DBNull.Value)
                {
                    dgdadosDiv.Rows[lastRowIndex].Cells[coluna].Style.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                }
            }

            dgdadosDiv.AllowUserToAddRows = false;
            dgdadosDiv.Refresh();
        }   
        private void AplicarNegritoUltimaLinha()
        {
            // Verifica se há linhas no DataGridView
            if (dgdadosDiv.Rows.Count > 0)
            {
                int ultimaLinhaIndex = dgdadosDiv.Rows.Count - 1;

                if (!dgdadosDiv.Rows[ultimaLinhaIndex].IsNewRow)
                {
                    dgdadosDiv.Rows[ultimaLinhaIndex].DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                }

                int penultimaLinhaIndex = ultimaLinhaIndex - 1;
                if (penultimaLinhaIndex >= 0 && !dgdadosDiv.Rows[penultimaLinhaIndex].IsNewRow)
                {
                    // Se a penúltima linha for formatada, remova o estilo de negrito
                    dgdadosDiv.Rows[penultimaLinhaIndex].DefaultCellStyle.Font = new Font(dgdadosDiv.Font, FontStyle.Regular);
                }
            }
        }
        private void dgdadosDiv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgdadosDiv.Rows)
            {
                Estilos.AplicarFormatacaoLinha(row);
            }
            AplicarNegritoUltimaLinha();
        }
        private void dgdadosDiv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            // Obtendo o DataTable vinculado ao DataGridView
            DataTable dados = (DataTable)dgdadosDiv.DataSource;

            // Verificar se há dados para manipular
            if (dados.Rows.Count == 0) return;

            // Obtendo o nome da coluna clicada
            string nomeColuna = dgdadosDiv.Columns[e.ColumnIndex].Name;

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
            dgdadosDiv.DataSource = dataView.ToTable();  // Atualiza com os dados ordenados

            dados = (DataTable)dgdadosDiv.DataSource;  // Atualiza o DataTable do DataGridView
            dados.ImportRow(ultimaLinha);  // Re-adicionar a última linha no final

            ordenacaoAscendente = !ordenacaoAscendente;
        }
        private void FrmFuncDividendos_Resize(object sender, EventArgs e)
        {
            Estilos.AjustarMargemDataGrid(dgdadosDiv, this);
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
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela);
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
