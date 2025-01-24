using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infraestrutura.Seguranca;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SistemaFL.Funcionalidades;

namespace SistemaFL
{
    public partial class FrmPrincipalFF : Form
    {
        private IUsuarioRepositorio repositorioFunc;
        public FrmPrincipalFF(IUsuarioRepositorio repositorioFunc)
        {
            InitializeComponent();
            this.repositorioFunc = repositorioFunc;
        }
        bool menuExpand = false;
        bool sidebarExpand = true;
        bool funcExpand = false;
        private void FrmPrincipalFF_Load(object sender, EventArgs e)
        {
            AjustaPictureBox_MaxMinFechar();
            sidebar.BringToFront();

            var form8 = Program.serviceProvider.GetRequiredService<FrmFuncLogin>();
            form8.ShowDialog();  // Aguarda o login ser fechado

            if (Sessao.idUsuarioLogado > 0)
            {
                var usuario = repositorioFunc.Recuperar(u => u.id == form8.idUsuario);
            }
            else
            {
                this.Close();
            }

        }
        private void AjustaPictureBox_MaxMinFechar()
        {
            int margem = 10;

            int x1 = this.ClientSize.Width - pbFechar.Width - margem;
            int y1 = margem;
            pbFechar.Location = new Point(x1, y1);

            int x2 = x1 - pbMinimizar.Width - margem;
            int y2 = margem;
            pbMinimizar.Location = new Point(x2, y2);

        }
        //
        //Transições
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 47)
                {
                    sidebarTransition.Stop();
                    sidebarExpand = false; // Atualiza corretamente o estado para "recolhido"
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 205)
                {
                    sidebarTransition.Stop();
                    sidebarExpand = true; // Atualiza corretamente o estado para "expandido"
                }
            }
        }
        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (!menuExpand)
            {
                menuContainer.Height += 10;
                if (menuContainer.Height >= 265)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuContainer.Height -= 10;
                if (menuContainer.Height <= 50)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
        }
        private void funcTransition_Tick_1(object sender, EventArgs e)
        {
            if (!funcExpand)
            {
                funcContainer.Height += 10;
                if (funcContainer.Height >= 403)
                {
                    funcTransition.Stop();
                    funcExpand = true;
                }
            }
            else
            {
                funcContainer.Height -= 10;
                if (funcContainer.Height <= 50)
                {
                    funcTransition.Stop();
                    funcExpand = false;
                }
            }
        }
        private void btnHam_Click_1(object sender, EventArgs e)
        {
            sidebarTransition.Start();

        }
        //
        //Ocorrências
        private void btnocorrencias_Click(object sender, EventArgs e)
        {
            var form = Program.serviceProvider.GetRequiredService<FrmConsultaOcorrencia>();
            form.ShowDialog();
        }
        //
        //Cadastros
        private void cadastros_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }
        private void btnempresas_Click(object sender, EventArgs e)
        {
            var form = Program.serviceProvider.GetRequiredService<FrmCadEmpresaFF>();
            form.ShowDialog();
        }
        private void btnflats_Click(object sender, EventArgs e)
        {
            var form = Program.serviceProvider.GetRequiredService<FrmCadFlat>();
            form.ShowDialog();
        }
        private void btnlancamentos_Click(object sender, EventArgs e)
        {
            var form = Program.serviceProvider.GetRequiredService<FrmCadLancamento>();
            form.ShowDialog();
        }
        private void btnusuarios_Click(object sender, EventArgs e)
        {
            var form = Program.serviceProvider.GetRequiredService<FrmCadUsuario>();
            form.ShowDialog();
        }
        //
        //Funcionalidades
        private void btnFuncionalidades_Click(object sender, EventArgs e)
        {
            funcTransition.Start();
        }      
        private void btnregistros_Click(object sender, EventArgs e)
        {
            var form = Program.serviceProvider.GetRequiredService<FrmFuncionalidadeRegisto>();
            form.ShowDialog();
        }
        private void btnalugueldividendos_Click(object sender, EventArgs e)
        {
            var form = Program.serviceProvider.GetRequiredService<FrmFuncAluguelDividendo>();
            form.ShowDialog();
        }
        private void btndividendos_Click(object sender, EventArgs e)
        {
            var form = Program.serviceProvider.GetRequiredService<FrmFuncDividendos>();
            form.ShowDialog();
        }
        private void btnfundoreserva_Click(object sender, EventArgs e)
        {
            var form = Program.serviceProvider.GetRequiredService<FrmFuncFundoReserva>();
            form.ShowDialog();
        }
        private void btnrendimentos_Click(object sender, EventArgs e)
        {
            var form = Program.serviceProvider.GetRequiredService<FrmFuncRendimentoscs>();
            form.ShowDialog();
        }
        private void btnpiscofins_Click(object sender, EventArgs e)
        {
            var form = Program.serviceProvider.GetRequiredService<FrmFuncPISeCOFINS>();
            form.ShowDialog();
        }
        //
        //
        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        
    }
}

