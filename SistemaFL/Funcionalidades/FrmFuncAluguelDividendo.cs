using Infraestrutura.Repositorio;
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

namespace SistemaFL.Funcionalidades
{
    public partial class FrmFuncAluguelDividendo : Form
    {
        private IFlatRepositorio flatRepositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        public FrmFuncAluguelDividendo(IFlatRepositorio flatRepositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.flatRepositorio = flatRepositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;
        }

        private void FrmFuncAluguelDividendo_Load(object sender, EventArgs e)
        {
            var dados = flatRepositorio.ObterDadosAluguelDividendos();
            dgdadosAlugDiv.DataSource = dados;

            AjustarFormatacaoGrid(dgdadosAlugDiv);

            var dadosTotaisInd = flatRepositorio.ObterDadosTotaisALDIV(1);
            dgtotaisindividual.DataSource = dadosTotaisInd;

            var dadosTotais = flatRepositorio.ObterDadosTotaisALDIV(2);
            dgtotalmes.DataSource = dadosTotais;
        }

        private void AjustarFormatacaoGrid(DataGridView grid)
        {
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            dgdadosAlugDiv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgdadosAlugDiv.Columns["ValorImovel"].DefaultCellStyle.Format = "C2";
            dgdadosAlugDiv.Columns["ValorImovel"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("pt-BR"); dgdadosAlugDiv.Columns["AluguelJan"].HeaderText = "Aluguel JAN";

            dgdadosAlugDiv.Columns["AluguelJan"].HeaderText = "Aluguel JAN";
            dgdadosAlugDiv.Columns["DividendosJan"].HeaderText = "Dividendos JAN";

            dgdadosAlugDiv.Columns["AluguelFev"].HeaderText = "Aluguel FEV";
            dgdadosAlugDiv.Columns["DividendosFev"].HeaderText = "Dividendos FEV";

            dgdadosAlugDiv.Columns["AluguelMar"].HeaderText = "Aluguel MAR";
            dgdadosAlugDiv.Columns["DividendosMar"].HeaderText = "Dividendos MAR";

            dgdadosAlugDiv.Columns["AluguelAbr"].HeaderText = "Aluguel ABR";
            dgdadosAlugDiv.Columns["DividendosAbr"].HeaderText = "Dividendos ABR";

            dgdadosAlugDiv.Columns["AluguelMai"].HeaderText = "Aluguel MAI";
            dgdadosAlugDiv.Columns["DividendosMai"].HeaderText = "Dividendos MAI";

            dgdadosAlugDiv.Columns["AluguelJun"].HeaderText = "Aluguel JUN";
            dgdadosAlugDiv.Columns["DividendosJun"].HeaderText = "Dividendos JUN";

            dgdadosAlugDiv.Columns["AluguelJul"].HeaderText = "Aluguel JUL";
            dgdadosAlugDiv.Columns["DividendosJul"].HeaderText = "Dividendos JUL";

            dgdadosAlugDiv.Columns["AluguelAgo"].HeaderText = "Aluguel AGO";
            dgdadosAlugDiv.Columns["DividendosAgo"].HeaderText = "Dividendos AGO";

            dgdadosAlugDiv.Columns["AluguelSet"].HeaderText = "Aluguel SET";
            dgdadosAlugDiv.Columns["DividendosSet"].HeaderText = "Dividendos SET";

            dgdadosAlugDiv.Columns["AluguelOut"].HeaderText = "Aluguel OUT";
            dgdadosAlugDiv.Columns["DividendosOut"].HeaderText = "Dividendos OUT";

            dgdadosAlugDiv.Columns["AluguelNov"].HeaderText = "Aluguel NOV";
            dgdadosAlugDiv.Columns["DividendosNov"].HeaderText = "Dividendos NOV";

            dgdadosAlugDiv.Columns["AluguelDez"].HeaderText = "Aluguel DEZ";
            dgdadosAlugDiv.Columns["DividendosDez"].HeaderText = "Dividendos DEZ";

        }
    }
}
