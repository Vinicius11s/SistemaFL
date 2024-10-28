﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using SistemaFL.Funcionalidades;

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

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form5 = Program.serviceProvider.GetRequiredService<FrmCadUsuario>();
            form5.ShowDialog();
        }

        private void ocorrênciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form6 = Program.serviceProvider.GetRequiredService<FrmConsultaOcorrencia>();
            form6.ShowDialog();
        }

        private void registrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form7 = Program.serviceProvider.GetRequiredService<FrmFuncionalidadeRegisto>();
            form7.ShowDialog();
        }
    }
}
