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
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace SistemaFL
{
    public partial class FrmCadFlat : Form
    {
        private IFlatRepositorio repositorio;
        private IEmpresaRepositorio empresaRepositorio;
        decimal valorTotalImovel;
        public FrmCadFlat(IFlatRepositorio repositorio, IEmpresaRepositorio empresaRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.empresaRepositorio = empresaRepositorio;

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();
        }

        private void FrmCadFlat_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);
            limpar();
            pdados.Enabled = false;
            btnnovo.Enabled = true;
            btnlocalizar.Enabled = true;
            btnalterar.Enabled = false;
            btncancelar.Enabled = false;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = false;
        }
        private void btnnovo_Click_1(object sender, EventArgs e)
        {
            limpar();
            txtdescricao.Focus();

            pdados.Enabled = true;
            btnnovo.Enabled = false;
            btnlocalizar.Enabled = false;
            btnalterar.Enabled = false;
            btncancelar.Enabled = true;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = true;
        }
        private void btnalterar_Click_1(object sender, EventArgs e)
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
            else MessageBox.Show("Localize o Flat");
        }
        private void btnsalvar_Click_1(object sender, EventArgs e)
        {
            avisoMostrado = false;

            try
            {
                if (txtdescricao.Text != String.Empty)
                {
                    Flat flat = carregaPropriedades();

                    if (flat.id == 0)
                    {
                        repositorio.Inserir(flat);
                    }
                    else
                    {
                        repositorio.Alterar(flat);
                    }

                    if(avisoMostrado == false)
                    {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar" + ex.Message);

                throw;
            }
        }
        private void btncancelar_Click_1(object sender, EventArgs e)
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
        private void btnexcluir_Click_1(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                var flat = carregaPropriedades();
                repositorio.Excluir(flat);
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
        private void btnlocalizar_Click_1(object sender, EventArgs e)
        {
            var form2 = Program.serviceProvider.GetRequiredService<FrmConsultaFlat>();
            form2.ShowDialog();

            if (form2.id > 0)
            {
                //no clique do botão localizar vamos fazer um select * from empresa where id
                var flat = repositorio.Recuperar(e => e.id == form2.id);
                if (flat != null)
                {
                    txtid.Text = flat.id.ToString();
                    txtdescricao.Text = flat.Descricao;
                    cbbStatus.Text = flat.Status.ToString();
                    txtValoDeCompra.Text = flat.ValorDeCompra.ToString();
                    cbbTipoInvestimento.Text = flat.TipoInvestimento;
                    dtdataaquisicao.Value = flat.DataAquisicao;
                    txtrua.Text = flat.Rua;
                    txtunidade.Text = flat.Unidade.ToString();
                    txtbairro.Text = flat.Bairro;
                    txtcidade.Text = flat.Cidade;
                    txtestado.Text = flat.Estado;
                    if (flat.idEmpresa != null)
                    {
                        var empresa = empresaRepositorio.Recuperar(e => e.id == flat.idEmpresa);
                        if (empresa != null)
                        {
                            txtempresaAss.Text = empresa.Descricao; // Define a descrição da empresa no TextBox
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        txtempresaAss.Text = "Sem empresa associada"; // Caso o flat não tenha empresa associada
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
        //
        //Atribuições
        void AtribuiStatusDoFlat(Flat flat)
        {
            if (cbbStatus != null && cbbStatus.SelectedItem != null)
            {
                string status = cbbStatus.Text;

                switch (status)
                {
                    case "Ativo":
                        flat.Status = status;
                        flat.Ativo = true;
                        break;

                    case "Em Construção":
                        flat.Status = status;
                        flat.Ativo = true;

                        if (!flat.Descricao.EndsWith(" - EM CONSTRUÇÃO"))
                        {
                            flat.Descricao += " - EM CONSTRUÇÃO";
                        }
                        break;

                    case "Em Reforma":
                        flat.Status = status;
                        flat.Ativo = true;
                        break;

                    case "Vendido":
                        flat.Status = status;
                        flat.Ativo = false;

                        if (!flat.Descricao.EndsWith(" - VENDIDO"))
                        {
                            flat.Descricao += " - VENDIDO";
                        }
                        break;

                    default:
                        // Caso o status não seja nenhum dos listados
                        break;
                }
            }
        }
        void AtribuiValorDeCompraUnidade(Flat flat)
        {
            decimal valorInvestimento;
            if (decimal.TryParse(txtValoDeCompra.Text, out valorInvestimento))
            {
                flat.ValorDeCompra = valorInvestimento;
            }
        }
        //
        //
        public Flat carregaPropriedades()
        {
            Flat flat;
            if (txtid.Text != "")
            {
                //alterar , estou recuperando o registro antigo
                //para manter a referencia do objeto do entity
                flat = repositorio.Recuperar(c => c.id ==
                                int.Parse(txtid.Text));

            }
            else flat = new Flat();//inserir

            valorTotalImovel = 0;

            flat.id = txtid.Text == "" ? 0 : int.Parse(txtid.Text);
            flat.Descricao = txtdescricao.Text;
            flat.TipoInvestimento = cbbTipoInvestimento.SelectedItem?.ToString() ?? "Indefinido";
            AtribuiStatusDoFlat(flat);
            flat.DataAquisicao = dtdataaquisicao.Value;
            flat.TamanhoUnidadeM2 = ValidaDecimais(flat, txTamanhoM2);
            flat.Rua = txtrua.Text;
            flat.Unidade = ValidaInteiros(flat, txtunidade);
            flat.Bairro = txtbairro.Text;
            flat.Estado = txtestado.Text;
            flat.Cidade = txtcidade.Text;
            flat.NumMatriculaImovel = ValidaInteiros(flat, txtNumMatriculaImovel);
            flat.ValorDeCompra = ValidaDecimais(flat, txtValoDeCompra);
            valorTotalImovel += flat.ValorDeCompra;
            ValidaCheckBox(flat);
            flat.valorComissao = ValidaDecimais(flat, txtValorComissao);
            valorTotalImovel += flat.valorComissao;
            flat.NotaComissao = ckNotaComissao.Checked ? true : false;

            flat.ValorITBI = ValidaDecimais(flat, txtValorITBI);
            valorTotalImovel += flat.ValorITBI;
            flat.ValorEscritura = ValidaDecimais(flat, txtValorEscritura);
            valorTotalImovel += flat.ValorEscritura;
            flat.ValorRegistro = ValidaDecimais(flat, txtValorDeRegistro);
            valorTotalImovel += flat.ValorRegistro;

            flat.Laudemio = ckLaudemioSim.Checked ? true : (ckLaudemioNao.Checked ? false : false);
            flat.ValorLaudemio = ValidaDecimais(flat, txtValorLaudemio);
            valorTotalImovel += flat.ValorLaudemio;

            flat.ValorAforamento = ValidaDecimais(flat, txtValorAforamento);
            valorTotalImovel += flat.ValorAforamento;

            flat.ValorTotalImovel = valorTotalImovel;

            flat.idEmpresa = flat.idEmpresa;
            return flat;
        }
        void limpar()
        {
            foreach (Control controle in pdados.Controls)
            {
                // Verifica se o controle é um TextBox
                if (controle is TextBox textBox)
                {
                    // Limpa o conteúdo do TextBox
                    textBox.Clear();
                }
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
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela, 10);
        }
        private void ckLaudemioSim_CheckedChanged(object sender, EventArgs e)
        {
            txtValorLaudemio.Enabled = true;
        }
        //
        //Validações
        bool avisoMostrado = false;
        public decimal ValidaDecimais(Flat flat, TextBox textBox)
        {
            decimal valor;
            if (decimal.TryParse(textBox.Text, out valor))
            {
                return valor;
            }
            return 0m;
        }
        public int ValidaInteiros(Flat flat, TextBox textBox)
        {
            int valor;
            if (int.TryParse(textBox.Text, out valor))
            {
                return valor;
            }
            return 0;
        }      
        void ValidaCheckBox(Flat flat)
        {           
            // Validação para "Possui Garagem"
            if (ckPossuiGaragemSim.Checked && ckPossuiGaragemNao.Checked)
            {
                if (!avisoMostrado)
                {
                    MessageBox.Show("Por favor, selecione apenas uma opção para 'Possui Garagem'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    avisoMostrado = true;  // Garante que o aviso seja mostrado apenas uma vez
                }
            }
            else if (!ckPossuiGaragemSim.Checked && !ckPossuiGaragemNao.Checked)
            {
                if (!avisoMostrado)
                {
                    MessageBox.Show("Por favor, selecione se possui garagem.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    avisoMostrado = true;  // Garante que o aviso seja mostrado apenas uma vez
                }
            }
            else
            {
                flat.PossuiGaragem = ckPossuiGaragemSim.Checked;
            }

            // Validação para "Está Escriturado"
            if (ckEscrituradoSim.Checked && ckEscrituradoNao.Checked)
            {
                if (!avisoMostrado)
                {
                    MessageBox.Show("Por favor, selecione apenas uma opção para 'Está Escriturado'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    avisoMostrado = true;  // Garante que o aviso seja mostrado apenas uma vez
                }
            }
            else if (!ckEscrituradoSim.Checked && !ckEscrituradoNao.Checked)
            {
                if (!avisoMostrado)
                {
                    MessageBox.Show("Por favor, selecione se está escriturado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    avisoMostrado = true;  // Garante que o aviso seja mostrado apenas uma vez
                }
            }
            else
            {
                flat.Escriturado = ckEscrituradoSim.Checked;
            }

            // Validação para "Está Registrado"
            if (ckRegistradoSim.Checked && ckRegistradoNao.Checked)
            {
                if (!avisoMostrado)
                {
                    MessageBox.Show("Por favor, selecione apenas uma opção para 'Está Registrado'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    avisoMostrado = true;  // Garante que o aviso seja mostrado apenas uma vez
                }
            }
            else if (!ckRegistradoSim.Checked && !ckRegistradoNao.Checked)
            {
                if (!avisoMostrado)
                {
                    MessageBox.Show("Por favor, selecione se está registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    avisoMostrado = true;  // Garante que o aviso seja mostrado apenas uma vez
                }
            }
            else
            {
                flat.Registrado = ckRegistradoSim.Checked;
            }
        }
    }
}
