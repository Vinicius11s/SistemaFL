using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;

namespace SistemaFL.Funcionalidades
{
    public partial class FrmFuncPISeCOFINS : Form
    {
        private IFlatRepositorio repositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        public FrmFuncPISeCOFINS(IFlatRepositorio repositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;
        }

        private void FrmFuncPISeCOFINS_Load(object sender, EventArgs e)
        {
            var dados = repositorio.ObterDadosAluguelVenceslau();
            dgdadosPIS.DataSource = dados;

            dgdadosPIS.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


        }
    }
}
