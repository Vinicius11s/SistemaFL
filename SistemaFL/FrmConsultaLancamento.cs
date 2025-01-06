using Entidades;
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFL
{
    public partial class FrmConsultaLancamento : Form
    {
        private ILancamentoRepositorio repositorio;
        public int id;
        public FrmConsultaLancamento(ILancamentoRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }

        private void btnlocalizar_Click(object sender, EventArgs e)
        {


            if (txtdescricao.Text == "Digite o número do mês" || txtdescricao.Text == "")
            {
                var lista = repositorio.Listar(e => true);
                dgdadoslancamento.DataSource = lista;
                AjustarGrid();
            }
            else
            {
                if (int.TryParse(txtdescricao.Text, out int mes))
                {
                    mes = int.Parse(txtdescricao.Text);
                    if (mes > 0 && mes <= 12)
                    {
                        var lista = repositorio.Listar(l => l.DataPagamento.Month == mes);
                        dgdadoslancamento.DataSource = lista;

                        if (lista.Count > 0)
                        {
                            AjustarGrid();
                        }
                    }
                    else MessageBox.Show("Digite um mês válido.");
                }
                else MessageBox.Show("Digite apenas numeros.");
            }
        }
        private void dgdadoslancamento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = (int)dgdadoslancamento.Rows[e.RowIndex].Cells[0].Value;
                this.Close();
            }
        }
        public void AjustarGrid()
        {
            foreach (DataGridViewColumn coluna in dgdadoslancamento.Columns)
            {
                if (coluna.Name != "id" && coluna.Name != "idFlat" && coluna.Name != "DataPagamento")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }
            dgdadoslancamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgdadoslancamento.Columns["id"].HeaderText = "CÓD";
            dgdadoslancamento.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgdadoslancamento.Columns["DataPagamento"].HeaderText = "DATA PAGAMENTO";
            dgdadoslancamento.Columns["TipoPagamento"].HeaderText = "TIPO INVESTIMENTO";
            dgdadoslancamento.Columns["DescricaoFlat"].HeaderText = "Descrição Flat";
            dgdadoslancamento.Columns["idFlat"].HeaderText = "CÓDFLAT";
            dgdadoslancamento.Columns["idFlat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            dgdadoslancamento.Columns["ValorFundoReserva"].HeaderText = "VALOR FUNDO RESERVA";
            dgdadoslancamento.Columns["ValorAluguel"].HeaderText = "VALOR ALUGUEL";
            dgdadoslancamento.Columns["ValorDividendos"].HeaderText = "VALOR DIVIDENDOS";
            dgdadoslancamento.Columns["AluguelVenceslau"].HeaderText = "VALOR ALUGUEL VENCESLAU";



            dgdadoslancamento.Columns["Flat"].Visible = false;
            dgdadoslancamento.Columns["idUsuario"].Visible = false;
            dgdadoslancamento.Columns["Usuario"].Visible = false;
            dgdadoslancamento.Columns["Ocorrencias"].Visible = false;

            AlterarCorFundoETextoCabecalho();

            foreach (DataGridViewRow row in dgdadoslancamento.Rows)
            {
                AplicarFormatacaoLinha(row);
            }
            dgdadoslancamento.RowTemplate.Height = 35;

            foreach (DataGridViewRow row in dgdadoslancamento.Rows)
            {
                row.Height = 35;
            }

            dgdadoslancamento.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }
        private void AlterarCorFundoETextoCabecalho()
        {
            foreach (DataGridViewColumn col in dgdadoslancamento.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);  // Espaçamento interno
            }
            // Desativa o estilo visual para permitir personalização
            dgdadoslancamento.EnableHeadersVisualStyles = false;
            dgdadoslancamento.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadoslancamento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadoslancamento.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            foreach (DataGridViewRow row in dgdadoslancamento.Rows)
            {
                AplicarFormatacaoLinha(row);
            }


        }
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
        }

        private void FrmConsultaLancamento_Load(object sender, EventArgs e)
        {
            dgdadoslancamento.CellFormatting += dgdadoslancamento_CellFormatting;
        }

        private void dgdadoslancamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se a célula está vazia
            if (dgdadoslancamento.Columns[e.ColumnIndex].ValueType != typeof(DateTime))
            {

                if (e.Value == null || e.Value == DBNull.Value || string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    // Define o valor da célula como um hífen "-"
                    e.Value = "-";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }             
            }
        }
    }
}
