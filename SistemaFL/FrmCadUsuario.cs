using Entidades;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFL
{
    public partial class FrmCadUsuario : Form
    {
        private IUsuarioRepositorio repositorio;
        public FrmCadUsuario(IUsuarioRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }

        private void FrmCadUsuario_Load(object sender, EventArgs e)
        {
            txtsenha.PasswordChar = '*';
            txtlogin.Focus();
            btnnovo.Enabled = true;
            btnlocalizar.Enabled = true;
            btnalterar.Enabled = false;
            btncancelar.Enabled = false;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = false;
            txtlogin.Enabled = false;
            txtsenha.Enabled = false;
        }
        private void btnsalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtlogin.Text != String.Empty)
                {
                    Usuario usuario = carregaPropriedades();

                    if (usuario.id == 0)
                    {
                        repositorio.Inserir(usuario);
                    }
                    else
                    {
                        repositorio.Alterar(usuario);
                    }
                    Program.serviceProvider.
                        GetRequiredService<ContextoSistema>().SaveChanges();
                    MessageBox.Show("Salvo com sucesso");

                    limpar();
                    btnnovo.Enabled = true;
                    btnlocalizar.Enabled = true;
                    btnalterar.Enabled = false;
                    btncancelar.Enabled = false;
                    btnexcluir.Enabled = false;
                    btnsalvar.Enabled = false;
                    txtlogin.Enabled = false;
                    txtsenha.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Salvar" + ex);
                throw;
            }
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            limpar();
            btnnovo.Enabled = true;
            btnlocalizar.Enabled = true;
            btnalterar.Enabled = false;
            btncancelar.Enabled = false;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = false;
            txtlogin.Enabled = false;
            txtsenha.Enabled = false;
        }
        public Usuario carregaPropriedades()
        {
            Usuario usuario;
            if (txtid.Text != "")
            {
                usuario = repositorio.Recuperar(u => u.id == int.Parse(txtid.Text));
            }
            else usuario = new Usuario(); //inserir

            usuario.id = txtid.Text == "" ? 0 : int.Parse(txtid.Text);
            usuario.Login = txtlogin.Text;
            usuario.Senha = txtsenha.Text;
            usuario.DataCriacao = dtDataCriacao.Value;

            return usuario;
        }        
        private void btnnovo_Click_1(object sender, EventArgs e)
        {
            btnnovo.Enabled = false;
            btnlocalizar.Enabled = false;
            btnalterar.Enabled = false;
            btncancelar.Enabled = true;
            btnexcluir.Enabled = false;
            txtlogin.Enabled = true;
            txtsenha.Enabled = true;
            btnsalvar.Enabled = true;
            limpar();
            txtlogin.Focus();
        }
        private void btnexcluir_Click_1(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                var empresa = carregaPropriedades();
                repositorio.Excluir(empresa);
                Program.serviceProvider.
                    GetRequiredService<ContextoSistema>().SaveChanges();

                MessageBox.Show("Usuário excluído com sucesso");
                limpar();
                btnnovo.Enabled = true;
                btnlocalizar.Enabled = true;
                btnalterar.Enabled = false;
                btncancelar.Enabled = false;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = false;
                txtlogin.Enabled = false;
                txtsenha.Enabled = false;
            }
            else
            {
                MessageBox.Show("Localize o Usuário");
            }
        }
        private void btnalterar_Click_1(object sender, EventArgs e)
        {
            if (txtlogin.Text != "")
            {
                btnnovo.Enabled = false;
                btnlocalizar.Enabled = false;
                btnalterar.Enabled = false;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = true;
                txtlogin.Enabled = true;
                txtsenha.Enabled = true;


                txtlogin.Focus();
            }
            else MessageBox.Show("Localize o Usuário");
        }
        private void btnlocalizar_Click_1(object sender, EventArgs e)
        {
            var form2 = Program.serviceProvider.GetRequiredService<FrmConsultaUsuario>();
            form2.ShowDialog();

            if (form2.id >= 0)
            {
                var usuario = repositorio.Recuperar(u => u.id == form2.id);
                if (usuario != null)
                {

                    txtid.Text = usuario.id.ToString();
                    txtlogin.Text = usuario.Login;
                    txtsenha.Text = usuario.Senha;

                    btnnovo.Enabled = false;
                    btnlocalizar.Enabled = false;
                    btnalterar.Enabled = true;
                    btncancelar.Enabled = true;
                    btnexcluir.Enabled = true;
                    btnsalvar.Enabled = false;
                }
            }
            else
            {
                pdados.Enabled = false;
                btnnovo.Enabled = true;
                btnlocalizar.Enabled = true;
                btnalterar.Enabled = false;
                btncancelar.Enabled = false;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = false;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void limpar()
        {
            txtid.Text = "";
            txtlogin.Text = "";
            txtsenha.Text = "";
            dtDataCriacao.Value = DateTime.Now;
        }
    }
}
