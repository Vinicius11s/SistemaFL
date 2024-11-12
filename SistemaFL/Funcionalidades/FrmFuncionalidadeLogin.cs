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
            // Cria um novo objeto de usuário ADMIN
            var usuarioAdmin = new Usuario()
            {
                Nome = "ADMIN",
                Login = "ADMIN",
                Senha = "123456789",  // Considerar usar uma senha criptografada!
                DataCriacao = DateTime.Now
            };

            // Inserir o ADMIN no banco de dados
            repositorio.Inserir(usuarioAdmin);  // Aqui você deve ter o método Inserir no seu repositório.

            // Mensagem de confirmação
            MessageBox.Show("Usuário ADMIN criado com sucesso.");
            Program.serviceProvider.
                        GetRequiredService<ContextoSistema>().SaveChanges();
        }
    }
}
