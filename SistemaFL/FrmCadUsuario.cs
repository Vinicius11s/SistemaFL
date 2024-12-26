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
            txtnome.Focus();
            pdados.Enabled = false;
            btnnovo.Enabled = true;
            btnlocalizar.Enabled = true;
            btnalterar.Enabled = false;
            btncancelar.Enabled = false;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = false;
        }
        private void btnnovo_Click(object sender, EventArgs e)
        {
            pdados.Enabled = true;
            btnnovo.Enabled = false;
            btnlocalizar.Enabled = false;
            btnalterar.Enabled = false;
            btncancelar.Enabled = true;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = true;
            limpar();
            txtnome.Focus();
        }
        private void btnalterar_Click(object sender, EventArgs e)
        {
            if (txtnome.Text != "")
            {
                pdados.Enabled = true;
                btnnovo.Enabled = false;
                btnlocalizar.Enabled = false;
                btnalterar.Enabled = false;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = true;
                txtnome.Focus();
            }
            else MessageBox.Show("Localize o Usuário");
        }
        private void btnsalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtnome.Text != String.Empty)
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
                    pdados.Enabled = false;
                    btnnovo.Enabled = true;
                    btnlocalizar.Enabled = true;
                    btnalterar.Enabled = false;
                    btncancelar.Enabled = false;
                    btnexcluir.Enabled = false;
                    btnsalvar.Enabled = false;
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
            pdados.Enabled = false;
            btnnovo.Enabled = true;
            btnlocalizar.Enabled = true;
            btnalterar.Enabled = false;
            btncancelar.Enabled = false;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = false;
        }
        private void btnexcluir_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                var empresa = carregaPropriedades();
                repositorio.Excluir(empresa);
                Program.serviceProvider.
                    GetRequiredService<ContextoSistema>().SaveChanges();

                MessageBox.Show("Usuário excluído com sucesso");
                limpar();
                pdados.Enabled = false;
                btnnovo.Enabled = true;
                btnlocalizar.Enabled = true;
                btnalterar.Enabled = false;
                btncancelar.Enabled = false;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Localize o Usuário");
            }
        }
        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            var form2 = Program.serviceProvider.GetRequiredService<FrmConsultaUsuario>();
            form2.ShowDialog();

            if(form2.id >= 0) {
                var usuario = repositorio.Recuperar(u => u.id == form2.id);
                if(usuario != null)
                {

                    txtid.Text = usuario.id.ToString();
                    txtnome.Text = usuario.Nome;
                    txtlogin.Text = usuario.Login;
                    txtsenha.Text = usuario.Senha;

                    pdados.Enabled = true;
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
        public Usuario carregaPropriedades()
        {
            Usuario usuario;
            if (txtid.Text != "")
            {
                usuario = repositorio.Recuperar(u => u.id == int.Parse(txtid.Text));
            }
            else usuario = new Usuario(); //inserir

            usuario.id = txtid.Text == "" ? 0 : int.Parse(txtid.Text);
            usuario.Nome = txtnome.Text;
            usuario.Login = txtlogin.Text;
            usuario.Senha = txtsenha.Text;
            usuario.DataCriacao = dtDataCriacao.Value;

            return usuario;
        }
        void limpar()
        {
            txtid.Text = "";
            txtnome.Text = "";
            txtlogin.Text = "";
            txtsenha.Text = "";
            dtDataCriacao.Value = DateTime.Now;
        }
    }
}
