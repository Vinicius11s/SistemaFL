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
            pCarregamento.Visible = false;
        }
        bool menuExpand = false;
        bool sidebarExpand = true;
        bool funcExpand = false;
        bool relatorioExpand = false;
        private async void FrmPrincipalFF_Load(object sender, EventArgs e)
        {
            pMenuOpcoes.Visible = false;
            pCarregamento.Visible = false;

            CentralizarPainel(pCarregamento);
            pCarregamento.Visible = true;

            await CarregarTelaCarregamento();

            pMenuOpcoes.Visible = true;
            pMenuOpcoes.BringToFront();

            GuardaUsuaruioLogado();
        }
        private void CentralizarPainel(Panel painel)
        {
            // Centraliza o painel de carregamento na tela
            painel.Left = (this.ClientSize.Width - painel.Width) / 2;
            painel.Top = (this.ClientSize.Height - painel.Height) / 2;
        }
        private async Task CarregarTelaCarregamento()
        {
            int larguraMaxima = 568;
            pBarraProgresso.Width = 0;
            pBarraProgresso.BackColor = ColorTranslator.FromHtml("#FFFFFF");

            for (int i = 0; i <= 100; i += 5)
            {
                pBarraProgresso.Width = (larguraMaxima * i) / 100;
                label1.Text = "Carregando... " + i.ToString() + "%";

                Application.DoEvents(); // Atualiza a interface durante o carregamento

                await Task.Delay(50); // Simula o tempo de carregamento
            }

            await Task.Delay(2000);

            pCarregamento.Visible = false;
        }
        private void GuardaUsuaruioLogado()
        {
            var form8 = Program.serviceProvider.GetRequiredService<FrmFuncLogin>();
            form8.ShowDialog();

            if (Sessao.idUsuarioLogado > 0)
            {
                var usuario = repositorioFunc.Recuperar(u => u.id == form8.idUsuario);
            }
            else this.Close();
    }
        //Transições
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                pMenuOpcoes.Width -= 10;
                if (pMenuOpcoes.Width <= 47)
                {
                    sidebarTransition.Stop();
                    sidebarExpand = false; // Atualiza corretamente o estado para "recolhido"
                }
            }
            else
            {
                pMenuOpcoes.Width += 10;
                if (pMenuOpcoes.Width >= 205)
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
                if (funcContainer.Height >= 400)
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
        private void relatoriosTransition_Tick(object sender, EventArgs e)
        {
            if (!relatorioExpand)
            {
                relatContainer.Height += 10;
                if (relatContainer.Height >= 171)
                {
                    relatoriosTransition.Stop();
                    relatorioExpand = true;
                }
            }
            else
            {
                relatContainer.Height -= 10;
                if (relatContainer.Height <= 55)
                {
                    relatoriosTransition.Stop();
                    relatorioExpand = false;
                }
            }
        }
        private void btnEsconderPalavrasMenu_Click_1(object sender, EventArgs e)
        {
            //sidebarTransition.Start();

        }
        //Ocorrências
        private void btnocorrencias_Click(object sender, EventArgs e)
        {
            EsconderControlesAbrirForm();
            var form = Program.serviceProvider.GetRequiredService<FrmConsultaOcorrencia>();
            form.FormClosed += (s, args) => MostrarBotoes();
            form.ShowDialog();
        }
        //Cadastros
        private void cadastros_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }
        private void btnempresas_Click(object sender, EventArgs e)
        {
            EsconderControlesAbrirForm();
            var form = Program.serviceProvider.GetRequiredService<FrmCadEmpresaFF>();
            form.FormClosed += (s, args) => MostrarBotoes();
            form.ShowDialog();
        }
        private void btnflats_Click(object sender, EventArgs e)
        {
            EsconderControlesAbrirForm();
            var form = Program.serviceProvider.GetRequiredService<FrmCadFlat>();
            form.FormClosed += (s, args) => MostrarBotoes();
            form.ShowDialog();
        }
        private void btnlancamentos_Click(object sender, EventArgs e)
        {
            EsconderControlesAbrirForm();
            var form = Program.serviceProvider.GetRequiredService<FrmCadLancamento>();
            form.FormClosed += (s, args) => MostrarBotoes();
            form.ShowDialog();
        }
        private void btnusuarios_Click(object sender, EventArgs e)
        {
            EsconderControlesAbrirForm();
            var form = Program.serviceProvider.GetRequiredService<FrmCadUsuario>();
            form.FormClosed += (s, args) => MostrarBotoes();
            form.ShowDialog();
        }
        //Funcionalidades
        private void btnregistros_Click(object sender, EventArgs e)
        {
            EsconderControlesAbrirForm();
            var form = Program.serviceProvider.GetRequiredService<FrmFuncionalidadeRegisto>();
            form.FormClosed += (s, args) => MostrarBotoes();
            form.ShowDialog();
        }
        private void btnalugueldividendos_Click(object sender, EventArgs e)
        {
            EsconderControlesAbrirForm();
            var form = Program.serviceProvider.GetRequiredService<FrmFuncAluguelDividendo>();
            form.FormClosed += (s, args) => MostrarBotoes();
            form.ShowDialog();
        }
        private void btndividendos_Click(object sender, EventArgs e)
        {
            EsconderControlesAbrirForm();
            var form = Program.serviceProvider.GetRequiredService<FrmFuncDividendos>();
            form.FormClosed += (s, args) => MostrarBotoes();
            form.ShowDialog();
        }
        private void btnfundoreserva_Click(object sender, EventArgs e)
        {
            EsconderControlesAbrirForm();
            var form = Program.serviceProvider.GetRequiredService<FrmFuncFundoReserva>();
            form.FormClosed += (s, args) => MostrarBotoes();
            form.ShowDialog();
        }
        private void btnrendimentos_Click(object sender, EventArgs e)
        {
            EsconderControlesAbrirForm();
            var form = Program.serviceProvider.GetRequiredService<FrmFuncRendimentoscs>();
            form.FormClosed += (s, args) => MostrarBotoes();
            form.ShowDialog();
        }
        private void btnpiscofins_Click(object sender, EventArgs e)
        {
            EsconderControlesAbrirForm();
            var form = Program.serviceProvider.GetRequiredService<FrmFuncPISeCOFINS>();
            form.FormClosed += (s, args) => MostrarBotoes();
            form.ShowDialog();
        }
        //     
        private void btnFuncionalidad_Click(object sender, EventArgs e)
        {
            funcTransition.Start();
        }
        private void brnRelatorios_Click_1(object sender, EventArgs e)
        {
            relatoriosTransition.Start();
        }
        private void btnRelatorioFiscalAnual_Click(object sender, EventArgs e)
        {
            EsconderControlesAbrirForm();
            var form = Program.serviceProvider.GetRequiredService<RelatorioTributacaoAnual>();
            form.FormClosed += (s, args) => MostrarBotoes();
            form.ShowDialog();
        }
        private void btnflatindividual_Click(object sender, EventArgs e)
        {
            EsconderControlesAbrirForm();
            var form = Program.serviceProvider.GetRequiredService<RelatorioFlatIndividual>();
            form.FormClosed += (s, args) => MostrarBotoes();
            form.ShowDialog();
        }
        //
        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pbMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void EsconderControlesAbrirForm()
        {
            pbMinimizar.Visible = false;
            pbFechar.Visible = false;
            pMenuOpcoes.Visible = false;
            pEnsconderBotoes.Visible = true;
        }
        private void MostrarBotoes()
        {
            pbMinimizar.Visible = true;
            pbFechar.Visible = true;
            pMenuOpcoes.Visible = true;
            pEnsconderBotoes.Visible = true;
        }
    }
}

