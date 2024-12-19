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
    public partial class FrmCadEmpresaFF : Form
    {
        private IEmpresaRepositorio repositorio;
        private IFlatRepositorio flatRepositorio;
        public FrmCadEmpresaFF(IEmpresaRepositorio repositorio, IFlatRepositorio flatRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.flatRepositorio = flatRepositorio;
        }

        private void FrmCadEmpresaFF_Load(object sender, EventArgs e)
        {
            pdados.Enabled = false;
            passociar.Enabled = false;
            btnnovo.Enabled = true;
            btnalterar.Enabled = false;
            btnsalvar.Enabled = false;
            btncancelar.Enabled = false;
            btnexcluir.Enabled = false;
            btnlocalizar.Enabled = true;

        }
        private void btnnovo_Click(object sender, EventArgs e)
        {
            pdados.Enabled = true;
            btnnovo.Enabled = false;
            btnalterar.Enabled = false;
            btnsalvar.Enabled = true;
            btncancelar.Enabled = true;
            btnexcluir.Enabled = false;
            btnlocalizar.Enabled = false;
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
                    if (empresa.id != 0) // Se está atualizando
                    {
                        repositorio.Alterar(empresa);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar" + ex.Message);

                throw;
            }
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            limpar();
            pdados.Enabled = false;
            btnnovo.Enabled = true;
            btnalterar.Enabled = false;
            btnsalvar.Enabled = false;
            btncancelar.Enabled = false;
            btnexcluir.Enabled = false;
            btnlocalizar.Enabled = true;
        }
        private void btnalterar_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                CarregarFlats();
                passociar.Enabled = true;
                pdados.Enabled = true;
                btnnovo.Enabled = false;
                btnalterar.Enabled = false;
                btnsalvar.Enabled = true;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = true;
                btnlocalizar.Enabled = false;
            }
            else MessageBox.Show("Localize a Empresa");
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

            if (form2.id > 0)
            {
                var empresa = repositorio.Recuperar(e => e.id == form2.id);
                if (empresa != null)
                {
                    txtid.Text = empresa.id.ToString();
                    txtdescricao.Text = empresa.Descricao;
                    txtrazaosocial.Text = empresa.RazaoSocial;
                    txtinscricaoestadual.Text = empresa.InscricaoEstadual;
                    txtcnpj.Text = empresa.Cnpj;
                    txtrua.Text = empresa.Rua;
                    txtnumero.Text = empresa.Numero;
                    txtbairro.Text = empresa.Bairro;
                    txtcidade.Text = empresa.Cidade;
                    txtestado.Text = empresa.Estado;
                    txtcep.Text = empresa.Cep;
                }
            }
            btnnovo.Enabled = false;
            btnalterar.Enabled = true;
            btnsalvar.Enabled = false;
            btncancelar.Enabled = true;
            btnexcluir.Enabled = true;
            btnlocalizar.Enabled = false;
        }
        private void CarregarFlats()
        {
            dgAssociarFlat.Rows.Clear();
            var flatsSemEmpresa = flatRepositorio.Listar(f => f.idEmpresa == null);

            if (flatsSemEmpresa != null && flatsSemEmpresa.Any())
            {
                dgAssociarFlat.Columns.Add("id", "Código");
                dgAssociarFlat.Columns["id"].Visible = false;
                dgAssociarFlat.Columns.Add("descricao", "Descrição");
                dgAssociarFlat.Columns.Add("status", "Status");
                dgAssociarFlat.Columns.Add("valorInvestimento", "Valor do Investimento");
                dgAssociarFlat.Columns.Add("tipoInvestimento", "Tipo de Investimento");
                dgAssociarFlat.Columns.Add("dataAquisicao", "Data de Aquisição");

                foreach (var flat in flatsSemEmpresa)
                {
                    dgAssociarFlat.Rows.Add(flat.id, flat.Descricao, flat.Status ? "Ativo" : "Inativo", flat.ValorInvestimento, flat.TipoInvestimento, flat.DataAquisicao);
                }
            }
        }
        public Empresa carregaPropriedades()
        {
            Empresa empresa;
            if (txtid.Text != "")
            {
                empresa = repositorio.Recuperar(c => c.id == int.Parse(txtid.Text));
            }
            else empresa = new Empresa();

            empresa.id = txtid.Text == "" ? 0 : int.Parse(txtid.Text);
            empresa.Descricao = txtdescricao.Text;
            empresa.Cnpj = txtcnpj.Text;
            empresa.RazaoSocial = txtrazaosocial.Text;
            empresa.InscricaoEstadual = txtinscricaoestadual.Text;
            empresa.Cep = txtcep.Text;
            empresa.Rua = txtrua.Text;
            empresa.Numero = txtnumero.Text;
            empresa.Cidade = txtcidade.Text;
            empresa.Estado = txtestado.Text;
            empresa.Bairro = txtbairro.Text;
            return empresa;
        }
        void limpar()
        {
            txtid.Text = "";
            txtdescricao.Text = "";
            txtcnpj.Text = "";
            txtinscricaoestadual.Text = "";
            txtrazaosocial.Text = "";
            txtrua.Text = "";
            txtnumero.Text = "";
            txtbairro.Text = "";
            txtcidade.Text = "";
            txtestado.Text = "";
            txtcep.Text = "";
        }
    }
}
