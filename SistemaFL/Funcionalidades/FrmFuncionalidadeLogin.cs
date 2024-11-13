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
using InfraEstrutura;
using Entidades;
using Microsoft.EntityFrameworkCore.Metadata;
using Infraestrutura.Contexto;
using Infraestrutura.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace SistemaFL.Funcionalidades
{
    public partial class FrmFuncionalidadeLogin : Form
    {
        private IUsuarioRepositorio repositorio;
        public int idUsuario = 0;
        public FrmFuncionalidadeLogin(IUsuarioRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }
        private void btnentrar_Click(object sender, EventArgs e)
        {
            if (txtlogin.Text != "" && txtsenha.Text != "")
            {
                var usuario = repositorio.Recuperar(u => u.Login == txtlogin.Text &&
                                                            u.Senha == txtsenha.Text);

                if (usuario != null)
                {
                    idUsuario = usuario.id;
                    this.Close();
                }
                else MessageBox.Show("Dados Incorretos.");
            }
            else MessageBox.Show("Por favor informar Login e Senha.");
        }

        private void FrmFuncionalidadeLogin_Load(object sender, EventArgs e)
        {
            var admin = repositorio.Recuperar(u => u.id == 1);

            if (admin == null) // Se não encontrar um usuário com id 1
            {
                // Criar o usuário ADMIN
                CriarUsuarioAdmin();
            }
        }
        private void CriarUsuarioAdmin()
        {
            var usuarioAdmin = new Usuario()
            {
                Nome = "ADMIN",
                Login = "ADMIN",
                Senha = "123456789",
                DataCriacao = DateTime.Now
            };

            var contexto = Program.serviceProvider.GetRequiredService<ContextoSistema>();
            contexto.Usuario.Add(usuarioAdmin); // Aqui você adiciona o novo usuário

            Program.serviceProvider.
                        GetRequiredService<ContextoSistema>().SaveChanges();
        }
    }
}
