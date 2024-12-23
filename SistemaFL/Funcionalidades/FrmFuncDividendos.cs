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

        private void FrmFuncDividendos_Load(object sender, EventArgs e)
        {
            var dados = flatRepositorio.ObterDadosDividendos();
            dgdadosDiv.DataSource = dados;
            AjustarFormataçãoGridDados(dgdadosDiv);

            var totais = flatRepositorio.ObterDadosTotaisDividendos();
            dgtotais.DataSource = totais;
        }
        private void AjustarFormataçãoGridDados(DataGridView grid)
        {
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
        }
    }
}
