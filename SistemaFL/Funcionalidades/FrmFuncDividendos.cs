using Infraestrutura.Repositorio;
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
    public partial class FrmFuncDividendos : Form
    {
        private IFlatRepositorio flatRepositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        public FrmFuncDividendos(IFlatRepositorio flatRepositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.flatRepositorio = flatRepositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;
        }
        private void btncalcular_Click(object sender, EventArgs e)
        {
            if (cbbmesDiv.SelectedIndex >= 0)
            {
                decimal somaDividendos = 0;

                if (cbbmesDiv.SelectedIndex < 12) // Um mês específico foi selecionado
                {
                    int numeroMes = cbbmesDiv.SelectedIndex + 1;
                    var lancamentoMes = lancamentoRepositorio.Listar(e => e.DataPagamento.Month == numeroMes);

                    somaDividendos = lancamentoMes.Sum(l => l.ValorDividendos ?? 0);
                }
                else if (cbbmesDiv.SelectedIndex == 12) // "Todos" foi selecionado
                {
                    var lancamentoTodos = lancamentoRepositorio.Listar(e => true);
                    somaDividendos = lancamentoTodos.Sum(l => l.ValorDividendos ?? 0);
                }               
                txtTotalmes.Text = somaDividendos.ToString();
            }
            else txtTotalmes.Text = string.Empty;
        }

        private void FrmFuncDividendos_Load(object sender, EventArgs e)
        {
            var dados = flatRepositorio.ObterDadosDividendos();
            dgdadosDiv.DataSource = dados;

            dgdadosDiv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgdadosDiv.Columns["ValorImovel"].DefaultCellStyle.Format = "C2";
            dgdadosDiv.Columns["ValorImovel"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("pt-BR"); dgdadosDiv.Columns["DividendosJan"].HeaderText = "Dividendos JAN";

            dgdadosDiv.Columns["DividendosJan"].HeaderText = "Dividendos JAN";
            dgdadosDiv.Columns["DividendosFev"].HeaderText = "Dividendos FEV";
            dgdadosDiv.Columns["DividendosMar"].HeaderText = "Dividendos MAR";
            dgdadosDiv.Columns["DividendosAbr"].HeaderText = "Dividendos ABR";
            dgdadosDiv.Columns["DividendosMai"].HeaderText = "Dividendos MAI";
            dgdadosDiv.Columns["DividendosJun"].HeaderText = "Dividendos JUN";
            dgdadosDiv.Columns["DividendosJul"].HeaderText = "Dividendos JUL";
            dgdadosDiv.Columns["DividendosAgo"].HeaderText = "Dividendos AGO";
            dgdadosDiv.Columns["DividendosSet"].HeaderText = "Dividendos SET";
            dgdadosDiv.Columns["DividendosOut"].HeaderText = "Dividendos OUT";
            dgdadosDiv.Columns["DividendosNov"].HeaderText = "Dividendos NOV";
            dgdadosDiv.Columns["DividendosDez"].HeaderText = "Dividendos DEZ";


            cbbmesDiv.Items.Clear();
            cbbmesDiv.Items.AddRange(new string[]
            {
                "Janeiro",
                "Fevereiro",
                "Março",
                "Abril",
                "Maio",
                "Junho",
                "Julho",
                "Agosto",
                "Setembro",
                "Outubro",
                "Novembro",
                "Dezembro",
                "Todos"
            });
        }
    }
}
