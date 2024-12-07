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
using Microsoft.Extensions.DependencyInjection;
using SistemaFL.Funcionalidades;

namespace SistemaFL
{
    public partial class FrmPrincipal : Form
    {
        private IUsuarioRepositorio repositorioFunc;
        public FrmPrincipal(IUsuarioRepositorio repositorioFunc)
        {
            InitializeComponent();
            this.repositorioFunc = repositorioFunc;
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

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            var form8 = Program.serviceProvider.GetRequiredService<FrmFuncionalidadeLogin>();
            form8.ShowDialog();

            if (form8.idUsuario > 0)
            {
                var usuario = repositorioFunc.Recuperar(u => u.id == form8.idUsuario);
                lbllogin.Text = "Bem-Vindo " + usuario.Nome;

            }
            else this.Close();
        }

        private void aluguelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form9 = Program.serviceProvider.GetRequiredService<FrmFuncAluguelDividendo>();
            form9.ShowDialog();
        }

        private void dividendosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form10 = Program.serviceProvider.GetRequiredService<FrmFuncDividendos>();
            form10.ShowDialog();
        }

        private void fundoDeReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form11 = Program.serviceProvider.GetRequiredService<FrmFuncFundoReserva>();
            form11.ShowDialog();
        }

        private void rendimentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form12 = Program.serviceProvider.GetRequiredService<FrmFuncRendimentoscs>();
            form12.ShowDialog();
        }
    }
}
