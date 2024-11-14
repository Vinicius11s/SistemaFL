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
    public partial class FrmFuncAluguel_Dividendos : Form
    {
        private IFlatRepositorio repositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        public FrmFuncAluguel_Dividendos(IFlatRepositorio repositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;
        }

        private void FrmFuncAluguel_Dividendos_Load(object sender, EventArgs e)
        {
           // var dados = FlatRepositorio.ObterDadosAluguelDividendos();
        }
    }
}
