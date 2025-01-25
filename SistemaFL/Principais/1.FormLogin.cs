using Interfaces;
using Infraestrutura.Seguranca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InfraEstrutura;
using Entidades;
using Microsoft.EntityFrameworkCore.Metadata;
using Infraestrutura.Contexto;
using Infraestrutura.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace SistemaFL.Funcionalidades
{
    public partial class FrmFuncLogin : Form
    {
        private IUsuarioRepositorio repositorio;
        public int idUsuario = 0;
        public FrmFuncLogin(IUsuarioRepositorio repositorio)
        {
            InitializeComponent();
            this.AcceptButton = btnentrar;
            this.repositorio = repositorio;
        }
        private void FrmFuncionalidadeLogin_Load(object sender, EventArgs e)
        {
            VerificaUsuarioAdminCriado();
            
        }
        private void VerificaUsuarioAdminCriado()
        {
            var admin = repositorio.Recuperar(u => u.id == 1);
            if (admin == null) // Se não encontrar um usuário com id 1
            {
                CriarUsuarioAdmin();
            }
        }
        private void CriarUsuarioAdmin()
        {
            var usuarioAdmin = new Usuario()
            {
                Login = "ADMIN",
                Senha = "123456789",
                DataCriacao = DateTime.Now
            };

            var contexto = Program.serviceProvider.GetRequiredService<ContextoSistema>();
            contexto.Usuario.Add(usuarioAdmin); // Aqui você adiciona o novo usuário

            Program.serviceProvider.
                        GetRequiredService<ContextoSistema>().SaveChanges();
        }
        //
        //Eventos
        private void btnentrar_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;  // Evita que o Enter ative o botão e feche o formulário de forma indesejada
                e.SuppressKeyPress = true;

                // Aqui, você chama a lógica de validação de login manualmente
                btnentrar_Click(sender, e);
            }
        }
        private void btnentrar_Click(object sender, EventArgs e)
        {
            if (txtlogin.Text != "" && txtsenha.Text != "")
            {
                var usuario = repositorio.Recuperar(u => u.Login == txtlogin.Text &&
                                                         u.Senha == txtsenha.Text);

                if (usuario != null)
                {
                    Sessao.idUsuarioLogado = usuario.id;
                    Sessao.nomeUsuarioLogado = usuario.Login;
                    this.Close();  // Fecha o formulário apenas se o login for bem-sucedido
                }
                else
                {
                    MessageBox.Show("Dados Incorretos.");
                }
            }
            else
            {
                MessageBox.Show("Por favor informar Login e Senha.");
            }
        }
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
