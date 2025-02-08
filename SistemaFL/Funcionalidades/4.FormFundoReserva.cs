using Interfaces;
using Microsoft.Web.WebView2.Core;
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
    public partial class FrmFuncFundoReserva : Form
    {
        private bool ordenacaoAscendente = true;
        private IFlatRepositorio flatRepositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        public FrmFuncFundoReserva(IFlatRepositorio flatRepositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.flatRepositorio = flatRepositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();

        }
        private void FrmFuncFundoReserva_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);
            CarregarDataGridDados();
            AdicionarLinhaTotal();

            dgdadosFunRes.DataBindingComplete += dgdadosFunRes_DataBindingComplete;

            foreach (DataGridViewRow row in dgdadosFunRes.Rows)
            {
                dgdadosFunRes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }       
        private void CarregarDataGridDados()
        {
            var dados = flatRepositorio.ObterDadosFunReserva();
            DataTable dt = ConverterDynamicParaDataTable(dados);
            dgdadosFunRes.DataSource = dt;

            Estilos.AlterarEstiloDataGrid(dgdadosFunRes);
            foreach (DataGridViewColumn coluna in dgdadosFunRes.Columns)
            {
                if (coluna.Name != "CODFLAT")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }


        }       
        private void AdicionarLinhaTotal()
        {
            DataTable dt = (DataTable)dgdadosFunRes.DataSource;

            if (dt == null || dt.Rows.Count == 0) return;

            // Listando os nomes das colunas de meses
            var colunasMeses = new List<string>
            {
                "JANEIRO", "FEVEREIRO", "MARÇO", "ABRIL", "MAIO",
                "JUNHO", "JULHO", "AGOSTO", "SETEMBRO", "OUTUBRO",
                "NOVEMBRO", "DEZEMBRO"
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
            dgdadosFunRes.Rows[lastRowIndex].Cells["EMPREENDIMENTO"].Value = "TOTAL";
            dgdadosFunRes.Rows[lastRowIndex].Cells["EMPREENDIMENTO"].Style.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // Definindo os valores das células em negrito, se houver valor
            foreach (var coluna in colunasMeses)
            {
                if (novaLinha[coluna] != DBNull.Value)
                {
                    dgdadosFunRes.Rows[lastRowIndex].Cells[coluna].Style.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                }
            }

            dgdadosFunRes.AllowUserToAddRows = false;
            dgdadosFunRes.Refresh();
        }      
        private void AplicarNegritoUltimaLinha()
        {
            // Verifica se há linhas no DataGridView
            if (dgdadosFunRes.Rows.Count > 0)
            {
                dgdadosFunRes.Columns["CODFLAT"].Visible = false;
                int ultimaLinhaIndex = dgdadosFunRes.Rows.Count - 1;

                if (!dgdadosFunRes.Rows[ultimaLinhaIndex].IsNewRow)
                {
                    dgdadosFunRes.Rows[ultimaLinhaIndex].DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                }

                int penultimaLinhaIndex = ultimaLinhaIndex - 1;
                if (penultimaLinhaIndex >= 0 && !dgdadosFunRes.Rows[penultimaLinhaIndex].IsNewRow)
                {
                    // Se a penúltima linha for formatada, remova o estilo de negrito
                    dgdadosFunRes.Rows[penultimaLinhaIndex].DefaultCellStyle.Font = new Font(dgdadosFunRes.Font, FontStyle.Regular);
                }
            }
        }
        private void dgdadosFunRes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgdadosFunRes.Rows)
            {
                Estilos.AplicarFormatacaoLinha(row);
            }
        }
        private void dgdadosFunRes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Obtendo o DataTable vinculado ao DataGridView
            DataTable dados = (DataTable)dgdadosFunRes.DataSource;

            if (dados.Rows.Count == 0) return;

            // Obtendo o nome da coluna clicada
            string nomeColuna = dgdadosFunRes.Columns[e.ColumnIndex].Name;

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

            if (ordenacaoAscendente)
            {
                dataView.Sort = nomeColuna + " ASC"; // Ordena de forma crescente
            }
            else
            {
                dataView.Sort = nomeColuna + " DESC"; // Ordena de forma decrescente
            }

            // Atualizando a fonte de dados do DataGridView com os dados ordenados (sem a última linha)
            dgdadosFunRes.DataSource = dataView.ToTable();  // Atualiza com os dados ordenados

            dados = (DataTable)dgdadosFunRes.DataSource;  // Atualiza o DataTable do DataGridView
            dados.ImportRow(ultimaLinha);  // Re-adicionar a última linha no final

            ordenacaoAscendente = !ordenacaoAscendente;
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
        private void FrmFuncFundoReserva_Resize(object sender, EventArgs e)
        {
            Estilos.AjustarMargemDataGrid(dgdadosFunRes, this);
        }            
        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela);
        }
    }
}
