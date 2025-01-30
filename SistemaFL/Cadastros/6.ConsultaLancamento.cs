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

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();
        }
        private void FrmConsultaLancamento_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);
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
                        var lista = repositorio.Listar(l => l.DataPagamento.Month == mes && l.DataPagamento.Year == DateTime.Now.Year);
                        dgdadoslancamento.DataSource = lista;

                    }
                    else MessageBox.Show("Digite um mês válido.");
                }
                else MessageBox.Show("Digite apenas numeros.");
            }

            AlterarEstilosCabecalho(dgdadoslancamento);
            AlterarEstilosCelulas(dgdadoslancamento);

            foreach (DataGridViewRow row in dgdadoslancamento.Rows)
            {
                AplicarFormatacaoLinha(row);
                dgdadoslancamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            if (dgdadoslancamento.Columns.Contains("DescricaoFlat"))
            {
                dgdadoslancamento.Columns["DescricaoFlat"].DisplayIndex = 0;
            }
        }
        private void AlterarEstilosCabecalho(DataGridView grid)
        {
            dgdadoslancamento.EnableHeadersVisualStyles = false;
            dgdadoslancamento.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadoslancamento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadoslancamento.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Regular);


            dgdadoslancamento.Columns["id"].Visible = false;
            dgdadoslancamento.Columns["idFlat"].Visible = false;
            dgdadoslancamento.Columns["AluguelVenceslau"].Visible = false;
            dgdadoslancamento.Columns["Flat"].Visible = false;
            dgdadoslancamento.Columns["idUsuario"].Visible = false;
            dgdadoslancamento.Columns["Usuario"].Visible = false;
            dgdadoslancamento.Columns["Ocorrencias"].Visible = false;

            dgdadoslancamento.Columns["DataPagamento"].HeaderText = "DATA PAGAMENTO";
            dgdadoslancamento.Columns["TipoPagamento"].HeaderText = "TIPO INVESTIMENTO";
            dgdadoslancamento.Columns["ValorAluguel"].HeaderText = "VALOR ALUGUEL";
            dgdadoslancamento.Columns["ValorDividendos"].HeaderText = "VALOR DIVIDENDOS";
            dgdadoslancamento.Columns["ValorFundoReserva"].HeaderText = "FUNDO RESERVA";
            dgdadoslancamento.Columns["DescricaoFlat"].HeaderText = "DESCRIÇÃO FLAT";

        }
        private void AlterarEstilosCelulas(DataGridView grid)
        {
            foreach (DataGridViewColumn coluna in grid.Columns)
            {
                if (coluna.Name != "id" && coluna.Name != "idFlat" && coluna.Name != "DataPagamento")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }
        }
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
        }
        //
        //Eventos     
        private void dgdadoslancamento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = (int)dgdadoslancamento.Rows[e.RowIndex].Cells[0].Value;
                this.Close();
            }
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
            else this.WindowState = FormWindowState.Maximized;
        }       
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela, 10);
        }

        
    }
}
