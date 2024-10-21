using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace SistemaFL
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = Program.serviceProvider.GetRequiredService<FrmCadEmpresa>();
            form2.ShowDialog();
        }

        private void flatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form3 = Program.serviceProvider.GetRequiredService<FrmCadFlat>();
            form3.ShowDialog();
        }

        private void lançamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form4 = Program.serviceProvider.GetRequiredService<FrmCadLancamento>();
            form4.ShowDialog();
        }
    }
}
