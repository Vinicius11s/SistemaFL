using Entidades;
using Infraestrutura.Contexto;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
            limpar();
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
            txtdescricao.Focus();

        }
        private void btnsalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtdescricao.Text != String.Empty)
                {
                    Empresa empresa = carregaPropriedades();
                    var empresaExistente = repositorio.RecuperarPorCnpj(empresa.Cnpj);
                    if (empresaExistente != null && empresaExistente.id != empresa.id)
                    {
                        MessageBox.Show("Este CNPJ já está cadastrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Impede o salvamento
                    }

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
                    pdados.Enabled = false;
                    passociar.Enabled = false;
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
            passociar.Enabled = false;
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
                var empresa = repositorio.Recuperar(e => e.id == int.Parse(txtid.Text));

                if (empresa != null)
                {
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

                    AtualizarDataGridFlatsNaoAssociados();
                    CarregarFlats(); // Carrega os flats associados ao ComboBox
                    passociar.Enabled = true;
                    pdados.Enabled = true;
                    btnnovo.Enabled = false;
                    btnalterar.Enabled = false;
                    btnsalvar.Enabled = true;
                    btncancelar.Enabled = true;
                    btnexcluir.Enabled = true;
                    btnlocalizar.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Localize a Empresa");
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
                btnnovo.Enabled = false;
                btnalterar.Enabled = true;
                btnsalvar.Enabled = false;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = true;
                btnlocalizar.Enabled = false;

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

                    // Carregar os flats associados à empresa
                    CarregarFlats(); // Carrega os flats da empresa no ComboBox
                }
            }
            else
            {
                btnnovo.Enabled = true;
                btnalterar.Enabled = false;
                btnsalvar.Enabled = false;
                btncancelar.Enabled = false;
                btnexcluir.Enabled = false;
                btnlocalizar.Enabled = true;
            }

        }

        private void CarregarFlats()
        {
            // Carregar os flats associados à empresa
            var flatsAssociados = flatRepositorio.Listar(f => f.idEmpresa == int.Parse(txtid.Text));
            cbbflatsassociados.DataSource = flatsAssociados;
            cbbflatsassociados.DisplayMember = "Descricao"; // Exibe a descrição do flat
            cbbflatsassociados.ValueMember = "id"; // Usado para o valor do item

            // Se houver pelo menos um flat associado, seleciona o primeiro
            if (cbbflatsassociados.Items.Count > 0)
            {
                cbbflatsassociados.SelectedIndex = 0; // Seleciona o primeiro flat
            }
            else
            {
                cbbflatsassociados.SelectedIndex = -1; // Nenhum item será selecionado
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
            ValidarCnpj(empresa);
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
            if (cbbflatsassociados.Items.Count > 0)
            {
                // Remover o DataSource antes de manipular os itens
                cbbflatsassociados.DataSource = null;
                cbbflatsassociados.Items.Clear();
            }
            else


                dgAssociarFlat.DataSource = null; // Desvincula a fonte de dados
            dgAssociarFlat.Columns.Clear();   // Remove as colunas
            if (dgAssociarFlat.Rows.Count > 0)
            {
                dgAssociarFlat.Rows.Clear();  // Limpa as linhas
            }

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
        private void btnassociar_Click(object sender, EventArgs e)
        {
            if (dgAssociarFlat.SelectedRows.Count > 0)
            {
                var selectedRow = dgAssociarFlat.SelectedRows[0];
                var flatId = (int)selectedRow.Cells["id"].Value;  // Supondo que a coluna do Id seja chamada "id"

                var flat = flatRepositorio.Recuperar(f => f.id == flatId);

                if (flat != null)
                {
                    flat.idEmpresa = int.Parse(txtid.Text);  // O id da empresa atual do formulário

                    flatRepositorio.Alterar(flat);
                    Program.serviceProvider.GetRequiredService<ContextoSistema>().SaveChanges();

                    MessageBox.Show("Flat associado à empresa com sucesso!");

                    AtualizarDataGridFlatsNaoAssociados();
                    CarregarFlats(); // Recarrega os flats no ComboBox
                }
                else
                {
                    MessageBox.Show("Flat não encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Selecione um flat para associar.");
            }
        }
        private void btnremover_Click(object sender, EventArgs e)
        {
            // Verifica se há algum flat selecionado no ComboBox
            if (cbbflatsassociados.SelectedItem != null)
            {
                // Obtém o flat selecionado
                var flatId = (int)cbbflatsassociados.SelectedValue; // Usa o ValueMember para obter o ID
                var flat = flatRepositorio.Recuperar(f => f.id == flatId);

                if (flat != null)
                {
                    // Remove a associação com a empresa
                    flat.idEmpresa = null; // Remove a associação com a empresa
                    flatRepositorio.Alterar(flat);
                    Program.serviceProvider.GetRequiredService<ContextoSistema>().SaveChanges();

                    MessageBox.Show("Flat desassociado com sucesso!");

                    AtualizarDataGridFlatsNaoAssociados();
                    CarregarFlats();
                    AvancarParaProximoItem();// Recarrega os flats no ComboBox

                }
                else
                {
                    MessageBox.Show("Flat não encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Selecione um flat para remover.");
            }
        }
        private void AtualizarDataGridFlatsNaoAssociados()
        {
            // Recupera os flats que não têm empresa associada
            var flatsNaoAssociados = flatRepositorio.Listar(f => f.idEmpresa == null).ToList();

            // Atualiza o DataGridView com esses flats
            dgAssociarFlat.DataSource = flatsNaoAssociados;

            // Se necessário, configurar as colunas do DataGridView para exibir apenas as informações desejadas
            dgAssociarFlat.Columns["id"].Visible = false; // Ocultar a coluna id, caso não queira exibi-la
            dgAssociarFlat.Columns["Descricao"].HeaderText = "Descrição do Flat"; // Ajustar o nome da coluna
        }
        private void AvancarParaProximoItem()
        {
            if (cbbflatsassociados.Items.Count > 0)
            {
                // Verifica se há um próximo item
                if (cbbflatsassociados.SelectedIndex < cbbflatsassociados.Items.Count - 1)
                {
                    // Avança para o próximo item
                    cbbflatsassociados.SelectedIndex++;
                }
                else
                {
                    // Se não houver próximo item, limpa o texto do ComboBox
                    cbbflatsassociados.SelectedIndex = -1; // Isso remove a seleção atual
                    cbbflatsassociados.Text = ""; // Limpa o texto
                }
            }
            else
            {
                // Se não houver itens, limpa o texto
                cbbflatsassociados.Text = "";
            }
        }
        private void ValidarCnpj(Empresa empresa)
        {
            string cnpj = txtcnpj.Text;

            // Remove quaisquer caracteres não numéricos, como pontuação (ponto, barra, etc.)
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            // Verifica se o CNPJ tem 13 dígitos
            if (cnpj.Length != 14)
            {
                MessageBox.Show("O CNPJ digitado não contém 14 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            empresa.Cnpj = cnpj;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
