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
    public partial class FrmFuncFundoReserva : Form
    {
        private IFlatRepositorio flatRepositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        public FrmFuncFundoReserva(IFlatRepositorio flatRepositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.flatRepositorio = flatRepositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;
            this.Resize += FrmFuncFundoReserva_Resize;

        }
        private void FrmFuncFundoReserva_Load(object sender, EventArgs e)
        {
            AjustarLayoutFormulario();
            CarregarDataGridDados();
            AdicionarLinhaTotal();

            dgdadosFunRes.DataBindingComplete += dgdadosFunRes_DataBindingComplete;

            foreach (DataGridViewRow row in dgdadosFunRes.Rows)
            {
                dgdadosFunRes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }
        //
        //Ajustar Layout do Formulário
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

            // Posição do pbMinimizar (ao lado esquerdo de pbFechar)
            int x3 = x2 - pbMinimizar.Width - margem;
            int y3 = margem;

            pbMinimizar.Location = new Point(x3, y3);

        }
        private void AjustarTamanhoDataGridView()
        {
            int margemDireita = SystemInformation.VerticalResizeBorderThickness;
            int margemInferior = SystemInformation.HorizontalResizeBorderThickness;

            dgdadosFunRes.Width = this.ClientSize.Width - dgdadosFunRes.Left - margemDireita;
            dgdadosFunRes.Top = this.ClientSize.Height - dgdadosFunRes.Height - margemInferior;
        }
        //
        //DataGrid Dados
        private void CarregarDataGridDados()
        {
            var dados = flatRepositorio.ObterDadosFunReserva();
            DataTable dt = ConverterDynamicParaDataTable(dados);
            dgdadosFunRes.DataSource = dt;

            AplicarFormatacaoGridDados();

        }
        private void AplicarFormatacaoGridDados()
        {
            AlterarEstilosCabecalho();
            AlterarEstilosCelulas(dgdadosFunRes);
        }
        private void AlterarEstilosCabecalho()
        {

            // Desativa o estilo visual para permitir personalização
            dgdadosFunRes.EnableHeadersVisualStyles = false;
            dgdadosFunRes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadosFunRes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadosFunRes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Regular);


        }
        private void AlterarEstilosCelulas(DataGridView grid)
        {

            foreach (DataGridViewColumn col in dgdadosFunRes.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);  // Espaçamento interno
            }

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
        //
        //Após o carregamento
        private void dgdadosFunRes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgdadosFunRes.Rows)
            {
                AplicarFormatacaoLinha(row);
            }
        }
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
        }
        private void AplicarNegritoUltimaLinha()
        {
            // Verifica se há linhas no DataGridView
            if (dgdadosFunRes.Rows.Count > 0)
            {
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
        //
        //Eventos
        private bool ordenacaoAscendente = true; // Variável para controlar a alternância da ordenação
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
        private void FrmFuncFundoReserva_Resize(object sender, EventArgs e)
        {
            AjustaPictureBox_MaxMinFechar();
        }
        //
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
        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
