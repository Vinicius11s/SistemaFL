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
    public partial class FrmFuncRendimentos : Form
    {
        private IFlatRepositorio repositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        public FrmFuncRendimentos(IFlatRepositorio repositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;
        }

        private void FrmFuncRendimentos_Load(object sender, EventArgs e)
        {
            var dadosR = repositorio.ObterDadosRendimentos();
            dgdadosRend.DataSource = dadosR;

            dgdadosRend.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgdadosRend.Columns["ValorImovel"].DefaultCellStyle.Format = "C2";
            dgdadosRend.Columns["ValorImovel"].DefaultCellStyle.FormatProvider =new System.Globalization.CultureInfo("pt-BR");

            dgdadosRend.Columns["PorcentagemJan"].HeaderText = " % ";
            dgdadosRend.Columns["PorcentagemJan"].DefaultCellStyle.Format = "N2"; 
            dgdadosRend.Columns["PorcentagemFev"].HeaderText = " % ";
            dgdadosRend.Columns["PorcentagemFev"].DefaultCellStyle.Format = "N2";
            dgdadosRend.Columns["PorcentagemAbr"].HeaderText = " % ";
            dgdadosRend.Columns["PorcentagemAbr"].DefaultCellStyle.Format = "N2";
            dgdadosRend.Columns["PorcentagemMai"].HeaderText = " % ";
            dgdadosRend.Columns["PorcentagemMai"].DefaultCellStyle.Format = "N2";
            dgdadosRend.Columns["PorcentagemJun"].HeaderText = " % ";
            dgdadosRend.Columns["PorcentagemJun"].DefaultCellStyle.Format = "N2";
            dgdadosRend.Columns["PorcentagemJul"].HeaderText = " % ";
            dgdadosRend.Columns["PorcentagemJul"].DefaultCellStyle.Format = "N2";
            dgdadosRend.Columns["PorcentagemAgo"].HeaderText = " % ";
            dgdadosRend.Columns["PorcentagemAgo"].DefaultCellStyle.Format = "N2";
            dgdadosRend.Columns["PorcentagemSet"].HeaderText = " % ";
            dgdadosRend.Columns["PorcentagemSet"].DefaultCellStyle.Format = "N2";
            dgdadosRend.Columns["PorcentagemOut"].HeaderText = " % ";
            dgdadosRend.Columns["PorcentagemOut"].DefaultCellStyle.Format = "N2";
            dgdadosRend.Columns["PorcentagemNov"].HeaderText = " % ";
            dgdadosRend.Columns["PorcentagemNov"].DefaultCellStyle.Format = "N2";
            dgdadosRend.Columns["PorcentagemDez"].HeaderText = " % ";
            dgdadosRend.Columns["PorcentagemDez"].DefaultCellStyle.Format = "N2";

        }
    }
}
