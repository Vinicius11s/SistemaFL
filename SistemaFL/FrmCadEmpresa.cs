using Entidades;
using Infraestrutura.Contexto;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFL
{
    public partial class FrmCadEmpresa : Form
    {
        private IEmpresaRepositorio repositorio;
        private IFlatRepositorio flatRepositorio;
        public FrmCadEmpresa(IEmpresaRepositorio repositorio, IFlatRepositorio flatRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.flatRepositorio = flatRepositorio;
        }

        private void FrmCadEmpresa_Load(object sender, EventArgs e)
        {
            limpar();
            dgAssociarFlat.Enabled = false;
            pdados.Enabled = false;
            btnnovo.Enabled = true;
            btnlocalizar.Enabled = true;
            btnalterar.Enabled = false;
            btncancelar.Enabled = false;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = false;
            btnassociar.Enabled = false;
            btndesassociar.Enabled = false;
        }
        private void btnnovo_Click(object sender, EventArgs e)
        {
            dgAssociarFlat.Enabled = false;
            btnassociar.Enabled = false;
            pdados.Enabled = true;
            btnnovo.Enabled = false;
            btnlocalizar.Enabled = false;
            btnalterar.Enabled = false;
            btncancelar.Enabled = true;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = true;
            btndesassociar.Enabled = false;
            cbbflatsassociados.Enabled = false;
            limpar();
            txtdescricao.Focus();
        }
        private void btnalterar_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                CarregarFlats();
                dgAssociarFlat.Enabled = true;
                btnassociar.Enabled = true;
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
            if (cbbflatsassociados.Items.Count > 0)
                btndesassociar.Enabled = true;
            else btndesassociar.Enabled = false;


        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            limpar();
            dgAssociarFlat.Enabled = false;
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
                    if (empresa.id != 0) // Se está atualizando
                    {
                        repositorio.Alterar(empresa);
                    }
                    Program.serviceProvider.
                        GetRequiredService<ContextoSistema>().SaveChanges();
                    MessageBox.Show("Salvo com sucesso");

                    limpar();
                    dgAssociarFlat.Enabled = false;
                    btnassociar.Enabled = false;
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
                dgAssociarFlat.Enabled = false;
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
            form2.ShowDialog();//abre o formulario de consulta

            if (form2.id > 0)
            {
                // Faz um select para encontrar a empresa pelo ID
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

                    AtualizarComboBoxFlatsAssociados();

                    if (cbbflatsassociados.Items.Count > 0)
                    {
                        cbbflatsassociados.SelectedIndex = 0; // Seleciona o primeiro item
                    }
                    else
                    {
                        cbbflatsassociados.Items.Add("Não há nenhum Flat associado e esta empresa.");
                    }
                    pdados.Enabled = false;
                    btnnovo.Enabled = false;
                    btnlocalizar.Enabled = false;
                    btnalterar.Enabled = true;
                    btncancelar.Enabled = true;
                    btnexcluir.Enabled = true;
                    btnsalvar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Empresa não encontrada.");
                }
            }
        }
        private void CarregarFlats()
        {
            dgAssociarFlat.Rows.Clear();
            dgAssociarFlat.Columns.Clear(); // Limpa as colunas previamente adicionadas
            dgAssociarFlat.AllowUserToAddRows = false; // Desabilita a adição de linhas por padrão

            var flatsSemEmpresa = flatRepositorio.Listar(f => f.idEmpresa == null);

            // Verifica se há flats sem empresa
            if (flatsSemEmpresa != null && flatsSemEmpresa.Any())
            {
                // Adiciona as colunas ao DataGridView apenas se houver dados
                dgAssociarFlat.Columns.Add("id", "Código");
                dgAssociarFlat.Columns.Add("descricao", "Descrição");
                dgAssociarFlat.Columns.Add("status", "Status");
                dgAssociarFlat.Columns.Add("valorInvestimento", "Valor do Investimento");
                dgAssociarFlat.Columns.Add("tipoInvestimento", "Tipo de Investimento");
                dgAssociarFlat.Columns.Add("dataAquisicao", "Data de Aquisição");

                // Popula o DataGridView com os dados dos flats
                foreach (var flat in flatsSemEmpresa)
                {
                    dgAssociarFlat.Rows.Add(flat.id, flat.Descricao, flat.Status ? "Ativo" : "Inativo", flat.ValorInvestimento, flat.TipoInvestimento, flat.DataAquisicao);
                }

                // Permite adicionar linhas se houver flats (caso seja necessário)
                dgAssociarFlat.AllowUserToAddRows = true;
            }
        }

        private void AtualizarComboBoxFlatsAssociados()
        {
            cbbflatsassociados.Items.Clear();
            cbbflatsassociados.Text = string.Empty;// Limpa os itens atuais do ComboBox

            var flatsAssociados = flatRepositorio.Listar(f => f.idEmpresa == int.Parse(txtid.Text));
            foreach (var flat in flatsAssociados)
            {
                cbbflatsassociados.Items.Add(flat.Descricao);
            }
        }
        private void btndesassociar_Click(object sender, EventArgs e)
        {
            if (cbbflatsassociados.SelectedItem != null)
            {
                // Obtém a descrição do flat selecionado
                string descricaoSelecionada = cbbflatsassociados.SelectedItem.ToString();

                // Recupera o flat pelo repositório com base na descrição
                var flat = flatRepositorio.Recuperar(f => f.Descricao == descricaoSelecionada && f.idEmpresa == int.Parse(txtid.Text));

                if (flat != null)
                {
                    // Desassocia o flat da empresa
                    flat.idEmpresa = null;

                    // Atualiza o flat no banco de dados
                    flatRepositorio.Alterar(flat);
                    Program.serviceProvider.
                        GetRequiredService<ContextoSistema>().SaveChanges();

                    // Atualiza o ComboBox e o DataGridView
                    cbbflatsassociados.Items.Clear();
                    AtualizarComboBoxFlatsAssociados();
                    CarregarFlats();

                    MessageBox.Show("Flat desassociado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Flat não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um flat para desassociar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnassociar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgAssociarFlat.CurrentRow != null)
                {
                    int flatId = (int)dgAssociarFlat.CurrentRow.Cells["id"].Value;
                    var flat = flatRepositorio.Recuperar(f => f.id == flatId);

                    if (flat != null && flat.idEmpresa == null)
                    {
                        // Associa o flat à empresa
                        flat.idEmpresa = int.Parse(txtid.Text);
                        flatRepositorio.Alterar(flat);
                        Program.serviceProvider.
                        GetRequiredService<ContextoSistema>().SaveChanges();

                        // Atualiza o ComboBox com a descrição do flat associado
                        cbbflatsassociados.Items.Add(flat.Descricao);
                        cbbflatsassociados.SelectedIndex = cbbflatsassociados.Items.Count - 1; // Seleciona o último item adicionado

                        // Atualiza o DataGridView para refletir a alteração
                        CarregarFlats();

                        MessageBox.Show("Flat associado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Flat não está disponível para associação ou já está associado a uma empresa.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao associar o flat: " + ex.Message);
            }
        }
        public Empresa carregaPropriedades()
        {
            Empresa empresa;
            if (txtid.Text != "")
            {
                empresa = repositorio.Recuperar(c => c.id == int.Parse(txtid.Text));
            }
            else empresa = new Empresa(); //inserir

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
            foreach (var item in cbbflatsassociados.Items)
            {
                if (item is Flat flatSelecionado)
                {
                    empresa.Flats.Add(flatSelecionado); // Adiciona o flat à coleção                                   
                }
            }

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
            cbbflatsassociados.Items.Clear();
            cbbflatsassociados.Text = string.Empty;
            if (dgAssociarFlat.Rows.Count > 0)
            {
                dgAssociarFlat.Rows.Clear(); // Limpa o DataGridView
            }


        }

 
    }
}

