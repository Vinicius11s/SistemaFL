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
                     
                    }
                    else MessageBox.Show("Digite um mês válido.");
                }
                else MessageBox.Show("Digite apenas numeros.");
            }
            AjustarNomesCabecalho();
            AlterarCorFundoETextoCabecalho();
            foreach (DataGridViewRow row in dgdadoslancamento.Rows)
            {
                AplicarFormatacaoLinha(row);
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
        public void AjustarNomesCabecalho()
        {
            foreach (DataGridViewColumn coluna in dgdadoslancamento.Columns)
            {
                if (coluna.Name != "id" && coluna.Name != "idFlat" && coluna.Name != "DataPagamento")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }
            dgdadoslancamento.Columns["id"].HeaderText = "CÓD";
            dgdadoslancamento.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgdadoslancamento.Columns["DataPagamento"].HeaderText = "DATA PAGAMENTO";
            dgdadoslancamento.Columns["TipoPagamento"].HeaderText = "TIPO INVESTIMENTO";
            dgdadoslancamento.Columns["DescricaoFlat"].HeaderText = "Descrição Flat";
            dgdadoslancamento.Columns["ValorFundoReserva"].HeaderText = "VALOR FUNDO RESERVA";
            dgdadoslancamento.Columns["ValorAluguel"].HeaderText = "VALOR ALUGUEL";
            dgdadoslancamento.Columns["ValorDividendos"].HeaderText = "VALOR DIVIDENDOS";
            dgdadoslancamento.Columns["AluguelVenceslau"].Visible = false;
            dgdadoslancamento.Columns["Flat"].Visible = false;
            dgdadoslancamento.Columns["idUsuario"].Visible = false;
            dgdadoslancamento.Columns["Usuario"].Visible = false;
            dgdadoslancamento.Columns["Ocorrencias"].Visible = false;

            dgdadoslancamento.Columns["idFlat"].HeaderText = "CÓDFLAT";
            dgdadoslancamento.Columns["idFlat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }      
        private void AlterarCorFundoETextoCabecalho()
        {         
            dgdadoslancamento.EnableHeadersVisualStyles = false;
            dgdadoslancamento.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadoslancamento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadoslancamento.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgdadoslancamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
            if (dgdadoslancamento.Columns[e.ColumnIndex].ValueType != typeof(DateTime))
            {
                if (e.Value == null || e.Value == DBNull.Value || string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
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
