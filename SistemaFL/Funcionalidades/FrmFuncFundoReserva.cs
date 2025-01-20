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
        }
        private void FrmFuncFundoReserva_Load(object sender, EventArgs e)
        {
            AjustarPosicaoPictureBox();
            this.Resize += FrmFuncFundoReserva_Resize;

            var dados = flatRepositorio.ObterDadosFunReserva();
            DataTable dt = ConverterDynamicParaDataTable(dados);
            dgdadosFunRes.DataSource = dt;

            AlterarCorFundoETextoCabecalho();
            AjustaGridDados(dgdadosFunRes);
            AdicionarLinhaTotal();

            foreach (DataGridViewRow row in dgdadosFunRes.Rows)
            {
                AplicarFormatacaoLinha(row);
            }

        }
        private void AjustaGridDados(DataGridView grid)
        {
            dgdadosFunRes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            foreach (DataGridViewColumn coluna in dgdadosFunRes.Columns)
            {
                if (coluna.Name != "CODFLAT")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }

        }
        private void AlterarCorFundoETextoCabecalho()
        {
            foreach (DataGridViewColumn col in dgdadosFunRes.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);  // Espaçamento interno
            }
            // Desativa o estilo visual para permitir personalização
            dgdadosFunRes.EnableHeadersVisualStyles = false;
            dgdadosFunRes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadosFunRes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadosFunRes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);


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
            dgdadosFunRes.Rows[lastRowIndex].Cells["EMPREENDIMENTO"].Style.Font = new Font(dgdadosFunRes.Font, FontStyle.Bold);

            // Definindo os valores das células em negrito, se houver valor
            foreach (var coluna in colunasMeses)
            {
                if (novaLinha[coluna] != DBNull.Value)
                {
                    dgdadosFunRes.Rows[lastRowIndex].Cells[coluna].Style.Font = new Font(dgdadosFunRes.Font, FontStyle.Bold);
                }
            }

            dgdadosFunRes.AllowUserToAddRows = false;
            dgdadosFunRes.Refresh();
        }
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
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
        //Ajustar botões fechar e maximizar
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
        private void FrmFuncFundoReserva_Resize(object sender, EventArgs e)
        {
            AjustarPosicaoPictureBox();
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
    }
}
