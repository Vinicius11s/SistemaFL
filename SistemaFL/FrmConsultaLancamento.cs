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

            if (txtdescricao.Text == "")
            {
                var lista = repositorio.Listar(e => true);
                dgdadoslancamento.DataSource = lista;
            }
            else
            {
                int mes = int.Parse(txtdescricao.Text);
                if (mes > 0 && mes < 12)
                {
                    var lista = repositorio.Listar(l => l.DataPagamento.Month == mes);
                    dgdadoslancamento.DataSource = lista;

                    if (lista.Count > 0)
                    {
                        dgdadoslancamento.Columns["DataPagamento"].HeaderText = "Data Pagamento";
                        dgdadoslancamento.Columns["ValorPagamento"].HeaderText = "Valor Pagamento";
                        dgdadoslancamento.Columns["ValorFundoReserva"].DefaultCellStyle.Format = "C2";
                        dgdadoslancamento.Columns["ValorFundoReserva"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("pt-BR");

                        dgdadoslancamento.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


                    }
                    else MessageBox.Show("Digite um mês válido.");
                }
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
    }
}
