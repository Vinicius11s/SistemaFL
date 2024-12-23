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
            var dados = flatRepositorio.ObterDadosFunReserva();
            dgdadosFunRes.DataSource = dados;
            dgdadosFunRes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            var totais = flatRepositorio.ObterDadosTotaisFundoReserva();
            dgtotais.DataSource = totais;
            dgtotais.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);



        }
    }
}
