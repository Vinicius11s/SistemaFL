using Interfaces;
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
                AjustaColunas();
            }
            else
            {
                if(int.TryParse(txtdescricao.Text, out int mes))    
                {
                    mes = int.Parse(txtdescricao.Text);
                    if (mes > 0 && mes <= 12)
                    {
                        var lista = repositorio.Listar(l => l.DataPagamento.Month == mes);
                        dgdadoslancamento.DataSource = lista;

                        if (lista.Count > 0)
                        {
                            AjustaColunas();
                        }
                    }
                    else MessageBox.Show("Digite um mês válido.");
                }else MessageBox.Show("Digite apenas numeros.");
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
        private void FrmConsultaLancamento_Load(object sender, EventArgs e)
        {
            txtdescricao.Text = "Digite o número do mês";
            txtdescricao.ForeColor = Color.Gray;
        }

        public void AjustaColunas()
        {
            dgdadoslancamento.Columns["id"].HeaderText = "Código";
            dgdadoslancamento.Columns["TipoPagamento"].HeaderText = "Tipo Investimento";
            dgdadoslancamento.Columns["DescricaoFlat"].HeaderText = "Descrição Flat";
            dgdadoslancamento.Columns["idFlat"].HeaderText = "Código Flat";
            dgdadoslancamento.Columns["Flat"].Visible = false;
            dgdadoslancamento.Columns["idUsuario"].Visible = false;
            dgdadoslancamento.Columns["Usuario"].Visible = false;
            dgdadoslancamento.Columns["Ocorrencias"].Visible = false;
            dgdadoslancamento.Columns["DataPagamento"].HeaderText = "Data Pagamento";
            dgdadoslancamento.Columns["ValorFundoReserva"].HeaderText = "Fundo de Reserva";
            dgdadoslancamento.Columns["ValorFundoReserva"].DefaultCellStyle.Format = "C2";
            dgdadoslancamento.Columns["ValorFundoReserva"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("pt-BR");
            dgdadoslancamento.Columns["ValorAluguel"].HeaderText = "Valor Aluguel";
            dgdadoslancamento.Columns["ValorAluguel"].DefaultCellStyle.Format = "C2";
            dgdadoslancamento.Columns["ValorAluguel"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("pt-BR");
            dgdadoslancamento.Columns["ValorDividendos"].HeaderText = "Valor Dividendos";
            dgdadoslancamento.Columns["ValorDividendos"].DefaultCellStyle.Format = "C2";
            dgdadoslancamento.Columns["ValorDividendos"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("pt-BR");
            dgdadoslancamento.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
