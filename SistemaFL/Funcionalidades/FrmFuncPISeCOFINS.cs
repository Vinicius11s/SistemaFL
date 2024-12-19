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
        private void dgdadosPIS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se a célula contém um valor numérico
            if (e.Value != null && e.Value is decimal or double or int)
            {
                // Formata o valor para incluir separador de milhar e duas casas decimais
                e.Value = string.Format("{0:N2}", e.Value);
                e.FormattingApplied = true;
            }
        }

        private void dgdadosPIS_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgdadosPIS.CellFormatting += dgdadosPIS_CellFormatting;

        }
    }
}
