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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SistemaFL
{
    public partial class FrmCadFlat : Form
    {
        bool avisoMostrado = false;
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
            ckPool.Enabled = false;
            ckPlataforma.Enabled = false;
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
            ckPool.Enabled = true;
            ckPlataforma.Enabled = true;
            ckPool.Focus();

            pdados.Enabled = false;
            btnnovo.Enabled = false;
            btnlocalizar.Enabled = false;
            btnalterar.Enabled = false;
            btncancelar.Enabled = true;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = false;
        }
        private void btnalterar_Click_1(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                ckPool.Enabled = true;
                ckPlataforma.Enabled = true;
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

                    if (avisoMostrado == false)
                    {
                        if (flat.id == 0)
                        {
                            repositorio.Inserir(flat);
                        }
                        else repositorio.Alterar(flat);

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
                        ckPool.Enabled = false;
                        ckPlataforma.Enabled = false;
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
            ckPool.Enabled = false;
            ckPlataforma.Enabled = false;
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
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
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

                    if (flat.TipoCadastro == 1)
                    {
                        ckPool.Checked = true;
                    }
                    else if (flat.TipoCadastro == 2)
                    {
                        ckPlataforma.Checked = true;
                    }

                    txtid.Text = flat.id.ToString();
                    txtdescricao.Text = flat.Descricao;
                    txtunidade.Text = flat.Unidade.ToString();
                    txtTipoUnidade.Text = flat.TipoUnidade.ToString();
                    cbbTipoInvestimento.SelectedItem = flat.TipoInvestimento;
                    cbbStatus.Text = flat.Status.ToString();
                    dtdataaquisicao.Value = flat.DataAquisicao;


                    txtCep.Text = flat.Cep;
                    txtrua.Text = flat.Rua;
                    txtNum.Text = flat.Numero;
                    txtbairro.Text = flat.Bairro;
                    txtestado.Text = flat.Estado;
                    txtcidade.Text = flat.Cidade;


                    txtNumMatriculaImovel.Text = flat.NumMatriculaImovel.ToString();
                    txtNumUCEnergia.Text = flat.NumUCEnergia.ToString();
                    txtNumCadastroPref.Text = flat.NumCadastroPrefeitura.ToString();
                    txTamanhoM2.Text = flat.TamanhoUnM2.ToString();
                    ckPossuiGaragemSim.Checked = flat.PossuiGaragem;
                    ckPossuiGaragemNao.Checked = !flat.PossuiGaragem;
                    ckEscrituradoSim.Checked = flat.Escriturado;
                    ckEscrituradoNao.Checked = !flat.Escriturado;
                    ckRegistradoSim.Checked = flat.Registrado;
                    ckRegistradoNao.Checked = !flat.Registrado;
                    txtValorComissao.Text = flat.valorComissao.ToString();
                    ckNotaComissao.Checked = flat.NotaComissao;

                    txtValorEscritura.Text = flat.ValorEscritura.ToString();
                    txtValorITBI.Text = flat.ValorITBI.ToString();
                    ckLaudemioSim.Checked = flat.Laudemio;
                    ckLaudemioNao.Checked = !flat.Laudemio;
                    txtValorLaudemio.Text = flat.ValorLaudemio.ToString();
                    txtValorAforamento.Text = flat.ValorAforamento.ToString();
                    txtValorDeRegistro.Text = flat.ValorRegistro.ToString();
                    txtValoDeCompra.Text = flat.ValorDeCompra.ToString();

                    txtMesReajuste.Text = flat.MesReajusteAluguel.ToString();
                    if (flat.IPTU == "Locador")
                    {
                        ckLocador.Checked = true;
                    }
                    else if (flat.IPTU == "Locatário")
                    {
                        ckLocatario.Checked = true;
                    }

                    txtValorTotalImovel.Text = flat.ValorTotalImovel.ToString();
                    if (flat.idEmpresa != null)
                    {
                        var empresa = empresaRepositorio.Recuperar(e => e.id == flat.idEmpresa);
                        if (empresa != null)
                        {
                            txtempresaAss.Text = empresa.Descricao; // Define a descrição da empresa no TextBox
                        }
                    }
                    else txtempresaAss.Text = "Sem empresa associada"; // Caso o flat não tenha empresa associada

                    pdados.Enabled = false;
                    btnnovo.Enabled = false;
                    btnlocalizar.Enabled = false;
                    btnalterar.Enabled = true;
                    btncancelar.Enabled = true;
                    btnexcluir.Enabled = true;
                    btnsalvar.Enabled = false;
                }
                else MessageBox.Show("Empresa não encontrada.");
            }
        }
        //Atribuições
        void AtribuiStatusDoFlat(Flat flat)
        {
            if (cbbStatus == null || cbbStatus.SelectedItem == null)
            {
                if (!avisoMostrado)
                {
                    MessageBox.Show("Selecione um status para o flat.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    avisoMostrado = true;
                }
                return;
            }

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
                    if (!avisoMostrado)
                    {
                        MessageBox.Show("Status inválido. Por favor, selecione um status válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        avisoMostrado = true;
                    }
                    break;
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
            if (ckPool.Checked)
            {
                flat.TipoCadastro = 1;
            }
            else if (ckPlataforma.Checked)
            {
                flat.TipoCadastro = 2;
            }
            flat.id = txtid.Text == "" ? 0 : int.Parse(txtid.Text);
            AtribuiTipoCadastro(flat);

            flat.Descricao = txtdescricao.Text;
            flat.Unidade = ValidaInteiros(flat, txtunidade);
            flat.TipoUnidade = txtTipoUnidade.Text;
            flat.TipoInvestimento = cbbTipoInvestimento.SelectedItem?.ToString() ?? "Indefinido";
            AtribuiStatusDoFlat(flat);
            flat.DataAquisicao = dtdataaquisicao.Value;


            flat.Cep = txtCep.Text;
            flat.Rua = txtrua.Text;
            flat.Numero = txtNum.Text;
            flat.Bairro = txtbairro.Text;
            flat.Estado = txtestado.Text;
            flat.Cidade = txtcidade.Text;


            flat.NumMatriculaImovel = ValidaInteiros(flat, txtNumMatriculaImovel);
            flat.NumUCEnergia = txtNumUCEnergia.Text;
            flat.NumCadastroPrefeitura = txtNumCadastroPref.Text;
            flat.TamanhoUnM2 = ValidaDecimais(flat, txTamanhoM2);
            ValidaCheckBox(flat);
            valorTotalImovel += flat.valorComissao;
            flat.valorComissao = ValidaDecimais(flat, txtValorComissao);
            flat.NotaComissao = ckNotaComissao.Checked ? true : false;

            flat.ValorEscritura = ValidaDecimais(flat, txtValorEscritura); valorTotalImovel += flat.ValorEscritura;
            flat.ValorITBI = ValidaDecimais(flat, txtValorITBI); valorTotalImovel += flat.ValorITBI;
            flat.Laudemio = ckLaudemioSim.Checked ? true : (ckLaudemioNao.Checked ? false : false);
            flat.ValorLaudemio = ValidaDecimais(flat, txtValorLaudemio); valorTotalImovel += flat.ValorLaudemio;
            flat.ValorAforamento = ValidaDecimais(flat, txtValorAforamento); valorTotalImovel += flat.ValorAforamento;
            flat.ValorRegistro = ValidaDecimais(flat, txtValorDeRegistro); valorTotalImovel += flat.ValorRegistro;
            flat.ValorDeCompra = ValidaDecimais(flat, txtValoDeCompra); valorTotalImovel += flat.ValorDeCompra;


            flat.MesReajusteAluguel = txtMesReajuste.Text;
            AtribuiIPTU(flat);
            flat.ValorTotalImovel = valorTotalImovel;
            flat.idEmpresa = flat.idEmpresa;
            return flat;
        }
        void limpar()
        {
            cbbTipoInvestimento.Text = "";
            cbbStatus.Text = "";
            foreach (Control controle in pdados.Controls)
            {
                // Verifica se o controle é um TextBox
                if (controle is TextBox textBox)
                {
                    // Limpa o conteúdo do TextBox
                    textBox.Clear();
                }

                if (controle is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
            ckPool.Checked = false;
            ckPlataforma.Checked = false;
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
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela);
        }
        private void ckLaudemioSim_CheckedChanged(object sender, EventArgs e)
        {
            if (ckLaudemioSim.Checked)
            {
                txtValorLaudemio.Enabled = true;
            }
            else txtValorLaudemio.Enabled = false;
        }
        //Validações
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
            if (avisoMostrado == false)
            {
                // Validação para "Possui Garagem"
                if (ckPossuiGaragemSim.Checked && ckPossuiGaragemNao.Checked)
                {
                    MessageBox.Show("Por favor, selecione apenas uma opção para 'Possui Garagem'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    avisoMostrado = true;
                    return;
                }
                else if (!ckPossuiGaragemSim.Checked && !ckPossuiGaragemNao.Checked)
                {
                    MessageBox.Show("Por favor, selecione se possui garagem.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    avisoMostrado = true;
                    return;
                }
                else
                {
                    flat.PossuiGaragem = ckPossuiGaragemSim.Checked;
                }

                // Validação para "Está Escriturado"
                if (ckEscrituradoSim.Checked && ckEscrituradoNao.Checked)
                {
                    MessageBox.Show("Por favor, selecione apenas uma opção para 'Está Escriturado'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    avisoMostrado = true;
                    return;
                }
                else if (!ckEscrituradoSim.Checked && !ckEscrituradoNao.Checked)
                {
                    MessageBox.Show("Por favor, selecione se está escriturado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    avisoMostrado = true;
                    return;
                }
                else
                {
                    flat.Escriturado = ckEscrituradoSim.Checked;
                }

                // Validação para "Está Registrado"
                if (ckRegistradoSim.Checked && ckRegistradoNao.Checked)
                {
                    MessageBox.Show("Por favor, selecione apenas uma opção para 'Está Registrado'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    avisoMostrado = true;
                    return;
                }
                else if (!ckRegistradoSim.Checked && !ckRegistradoNao.Checked)
                {
                    MessageBox.Show("Por favor, selecione se está registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    avisoMostrado = true;
                    return;
                }
                else
                {
                    flat.Registrado = ckRegistradoSim.Checked;
                }
            }
        }
        void AtribuiIPTU(Flat flat)
        {
            if (avisoMostrado == false)
            {
                if (ckLocador.Checked)
                {
                    flat.IPTU = "Locador";
                }
                else if (ckLocatario.Checked)
                {
                    flat.IPTU = "Locatário";
                }
            }
        }
        void AtribuiTipoCadastro(Flat flat)
        {
            if (avisoMostrado == false)
            {
                if (ckPool.Checked)
                {
                    flat.TipoCadastro = 1;
                }
                else if (ckPlataforma.Checked)
                {
                    flat.TipoCadastro = 2;
                }
            }
        }
        private async void btnBuscaCep_Click(object sender, EventArgs e)
        {
            string cep = txtCep.Text.Trim(); // Pega o CEP digitado no TextBox

            if (string.IsNullOrEmpty(cep) || cep.Length != 8)
            {
                MessageBox.Show("Por favor, insira um CEP válido.");
                return;
            }

            string url = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                // Chama a API ViaCEP de forma assíncrona
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(url);

                    // Deserializa a resposta JSON em um objeto
                    var endereco = Newtonsoft.Json.JsonConvert.DeserializeObject<ViaCepResponse>(response);

                    // Preenche os campos com os dados retornados
                    if (endereco != null && endereco.Erro == null)
                    {
                        txtrua.Text = endereco.Logradouro;
                        txtbairro.Text = endereco.Bairro;
                        txtcidade.Text = endereco.Localidade;
                        txtestado.Text = endereco.Uf;
                        txtNum.Focus();
                    }
                    else
                    {
                        MessageBox.Show("CEP não encontrado ou inválido.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar o CEP: {ex.Message}");
            }
        }
        private void ckPool_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPool.Checked)
            {
                ckPlataforma.Enabled = false;
                pdados.Enabled = true;
                btnnovo.Enabled = false;
                btnlocalizar.Enabled = false;
                btnalterar.Enabled = false;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = true;
            }
            else
            {
                ckPlataforma.Enabled = true;
                pdados.Enabled = false;
                btnnovo.Enabled = false;
                btnlocalizar.Enabled = false;
                btnalterar.Enabled = false;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = true;
            }
        }
        private void ckPlataforma_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPlataforma.Checked)
            {
                ckPool.Enabled = false;
                pdados.Enabled = true;
                btnnovo.Enabled = false;
                btnlocalizar.Enabled = false;
                btnalterar.Enabled = false;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = true;
            }
            else
            {
                ckPool.Enabled = true;
                pdados.Enabled = false;
                btnnovo.Enabled = false;
                btnlocalizar.Enabled = false;
                btnalterar.Enabled = false;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = true;
            }
        }
        private void ckLaudemioNao_CheckedChanged(object sender, EventArgs e)
        {
            if (ckLaudemioNao.Checked)
            {
                txtValorLaudemio.Enabled = false;
            }
        }
    }
}
