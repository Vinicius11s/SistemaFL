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
            var dados = repositorio.ObterDadosPISeCOFINS();
            dgdadosPIS.DataSource = dados;

            dgdadosPIS.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void dgdadosPIS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
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
            if ((dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value != null &&
                     dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value.ToString() == "Aluguel Venceslau") ||
                    (dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value != null &&
                     dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value.ToString() == "Aluguel Flats") ||
                    (dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value != null &&
                     dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value.ToString() == "Fundo de Reserva Flats") ||
                    (dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value != null &&
                     dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value.ToString() == "Base de Cálculo (PIS/COFINS)"))
            {
                // Defina a cor do texto para verde para essa linha
                e.CellStyle.ForeColor = Color.Green;
            }

            if ((dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value != null &&
                     dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value.ToString() == "PIS") ||
                    (dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value != null &&
                     dgdadosPIS.Rows[e.RowIndex].Cells["Descricao"].Value.ToString() == "COFINS"))
            {
                // Defina a cor do texto para verde para essa linha
                e.CellStyle.ForeColor = Color.Red;
            }
        }

    }
}
