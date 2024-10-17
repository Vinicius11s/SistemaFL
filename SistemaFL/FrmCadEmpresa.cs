using Entidades;
using Infraestrutura.Contexto;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class FrmCadEmpresa : Form
    {
        private IEmpresaRepositorio repositorio;
        public FrmCadEmpresa(IEmpresaRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }

        private void FrmCadEmpresa_Load(object sender, EventArgs e)
        {
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
            txtdescricao.Focus();
        }

        void limpar()
        {
            txtid.Text = "";
            txtcnpj.Text = "";
            txtinscricaoestadual.Text = "";
            txtrazaosocial.Text = "";
        }
        private void btnalterar_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                pdados.Enabled = true;
                btnnovo.Enabled = false;
                btnlocalizar.Enabled = false;
                btnalterar.Enabled = false;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = true;
                txtdescricao.Focus();
            }
            else MessageBox.Show("Localize a Empresa");
        }

        public Empresa carregaPropriedades()
        {
            Empresa empresa;
            if (txtid.Text != "")
            {
                //alterar , estou recuperando o registro antigo
                //para manter a referencia do objeto do entity
                empresa = repositorio.Recuperar(c => c.id ==
                                int.Parse(txtid.Text));
            }
            else empresa = new Empresa(); //inserir

            empresa.id = txtid.Text == "" ? 0 : int.Parse(txtid.Text);
            empresa.Descricao = txtdescricao.Text;

            return empresa;
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

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtdescricao.Text != String.Empty)
                {
                    Empresa empresa = carregaPropriedades();

                    if (empresa.id == 0)
                    {
                        repositorio.Inserir(empresa);
                    }
                    else
                    {
                        repositorio.Alterar(empresa);
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
                MessageBox.Show("Erro ao salvar" + ex.Message);

                throw;
            }
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                var empresa = carregaPropriedades();
                repositorio.Excluir(empresa);
                Program.serviceProvider.
                    GetRequiredService<ContextoSistema>().SaveChanges();

                MessageBox.Show("Registro excluído com sucesso!");
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
                MessageBox.Show("Localize a Empresa.");
            }
        }

        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            var form2 = Program.serviceProvider.GetRequiredService<FrmConsultaEmpresa>();
            form2.ShowDialog();

            if(form2.id > 0)
            {
                //no clique do botão localizar vamos fazer um select * from empresa where id
                var empresa = repositorio.Recuperar(e => e.id == form2.id);
                txtid.Text = empresa.id.ToString();
                txtdescricao.Text = empresa.Descricao;

                pdados.Enabled = false;
                btnnovo.Enabled = false;
                btnlocalizar.Enabled = false;
                btnalterar.Enabled = true;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = true;
                btnsalvar.Enabled = false;
            }
        }
    }
}
