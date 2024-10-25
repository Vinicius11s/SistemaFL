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
        public FrmCadEmpresa(IEmpresaRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }

        private void FrmCadEmpresa_Load(object sender, EventArgs e)
        {
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
            btnassociar.Enabled = false;
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
            cbbflatsassociados.Enabled = false;
            limpar();
            txtdescricao.Focus();
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
            if (dgAssociarFlat.Rows.Count > 0)
            {
                dgAssociarFlat.Rows.Clear(); // Limpa o DataGridView
            }


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
            dgAssociarFlat.Enabled = true;
            using (var contexto = new ContextoSistema())
            {
                var flatsDisponiveis = contexto.Flats
                    .Where(Flat => Flat.idEmpresa == null)
                    .ToList();

                dgAssociarFlat.DataSource = flatsDisponiveis;
            }
        }
        private void btnassociar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgAssociarFlat.CurrentRow != null)
                {
                    // Obtém o ID do flat selecionado no DataGrid
                    int flatId = (int)dgAssociarFlat.CurrentRow.Cells["id"].Value;

                    // Recupera o flat diretamente usando o contexto
                    var contexto = Program.serviceProvider.GetRequiredService<ContextoSistema>();
                    var flat = contexto.Flats.SingleOrDefault(f => f.id == flatId);

                    // Verifica se o flat foi encontrado e não está associado a nenhuma empresa
                    if (flat != null && flat.idEmpresa == null)
                    {
                        // Atribui o ID da empresa ao flat
                        flat.idEmpresa = int.Parse(txtid.Text);

                        // Atualiza o flat no banco de dados
                        contexto.SaveChanges();

                        // Adiciona a descrição do flat no ComboBox
                        cbbflatsassociados.Items.Add(flat.Descricao);

                        AtualizarComboBoxFlatsAssociados();

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
        private void AtualizarComboBoxFlatsAssociados()
        {
            cbbflatsassociados.Items.Clear(); // Limpa os itens atuais do ComboBox

            using (var contexto = new ContextoSistema())
            {
                var flatsAssociados = contexto.Flats
                    .Where(f => f.idEmpresa == int.Parse(txtid.Text)) // Filtra os flats pela empresa atual
                    .ToList();

                foreach (var flat in flatsAssociados)
                {
                    cbbflatsassociados.Items.Add(flat.Descricao); // Adiciona as descrições dos flats associados ao ComboBox
                }
            }
        }

        private void btndesassociar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgAssociarFlat.CurrentRow != null)
                {
                    // Obtém o ID do flat selecionado no DataGrid
                    int flatId = (int)dgAssociarFlat.CurrentRow.Cells["id"].Value;

                    // Recupera o flat diretamente usando o contexto
                    var contexto = Program.serviceProvider.GetRequiredService<ContextoSistema>();
                    var flat = contexto.Flats.SingleOrDefault(f => f.id == flatId);

                    // Verifica se o flat foi encontrado e está associado a uma empresa
                    if (flat != null && flat.idEmpresa != null)
                    {
                        // Remove a associação do flat com a empresa
                        flat.idEmpresa = null;

                        // Atualiza o flat no banco de dados
                        contexto.SaveChanges();

                        // Remove a descrição do flat do ComboBox
                        cbbflatsassociados.Items.Remove(flat.Descricao);
                        AtualizarComboBoxFlatsAssociados();

                        MessageBox.Show("Flat desassociado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Flat não está disponível para desassociação ou já não está associado a uma empresa.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }


        }
    }
}
