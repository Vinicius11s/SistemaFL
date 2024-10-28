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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaFL
{
    public partial class FrmCadLancamento : Form
    {
        private ILancamentoRepositorio repositorio;
        private IFlatRepositorio flatRepositorio;
        public FrmCadLancamento(ILancamentoRepositorio repositorio, IFlatRepositorio flatRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.flatRepositorio = flatRepositorio;
        }
        private void FrmCadLancamento_Load(object sender, EventArgs e)
        {
            btnnovo.Enabled = true;
            btnalterar.Enabled = false;
            btncancelar.Enabled = false;
            btnsalvar.Enabled = false;
            btnexcluir.Enabled = false;
            btnlocalizar.Enabled = true;
            btnLocFlatLancamento.Enabled = false;

            dtdataLancamento.Enabled = false;
            cbbtipoPagamento.Enabled = false;
            labelValorAlguel.Visible = false;
            txtvaloraluguel.Visible = false;
            labelValorDiv.Visible = false;
            txtValorDiv.Visible = false;
            labelFundoRes.Visible = false;
            txtValorFunReserva.Visible = false;
        }
        private void btnnovo_Click(object sender, EventArgs e)
        {
            limpar();
            btnnovo.Enabled = false;
            btnalterar.Enabled = false;
            btncancelar.Enabled = true;
            btnsalvar.Enabled = true;
            btnexcluir.Enabled = true;
            btnlocalizar.Enabled = false;
            btnLocFlatLancamento.Enabled = true;

            labelValorAlguel.Visible = false;
            txtvaloraluguel.Visible = false;
            labelValorDiv.Visible = false;
            txtValorDiv.Visible = false;
            labelFundoRes.Visible = false;
            txtValorFunReserva.Visible = false;

        }
        private void btnalterar_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                btnnovo.Enabled = false;
                btnalterar.Enabled = false;
                btncancelar.Enabled = true;
                btnsalvar.Enabled = true;
                btnexcluir.Enabled = false;
                btnlocalizar.Enabled = false;
                btnLocFlatLancamento.Enabled = true;

                /*
                labelValorPag.Visible = false;
                txtvalorPagamento.Visible = false;
                labelValorDiv.Visible = false;
                txtValorDiv.Visible = false;
                labelFundoRes.Visible = false;
                txtValorFunReserva.Visible = false;
                txtvalorPagamento.Focus();*/
            }
            else MessageBox.Show("Localize o Lançamento");
        }
        private void btnsalvar_Click(object sender, EventArgs e)
        {

            try
            {
                if(cbbtipoPagamento.SelectedItem != null)
                {
                    Lancamento lancamento = carregaPropriedades();

                    if(lancamento.id == 0)
                    {
                        repositorio.Inserir(lancamento);
                    }
                    else
                    {
                        repositorio.Alterar(lancamento);
                    }
                    Program.serviceProvider.GetRequiredService<ContextoSistema>().SaveChanges();
                    MessageBox.Show("Lançamento Salvo com sucesso!");
                    limpar();
                    btnnovo.Enabled = true;
                    btnalterar.Enabled = false;
                    btncancelar.Enabled = false;
                    btnsalvar.Enabled = false;
                    btnexcluir.Enabled = false;
                    btnlocalizar.Enabled = true;
                    btnLocFlatLancamento.Enabled = false;

                    dtdataLancamento.Enabled = false;
                    cbbtipoPagamento.Enabled = false;
                    labelValorAlguel.Visible = false;
                    txtvaloraluguel.Visible = false;
                    labelValorDiv.Visible = false;
                    txtValorDiv.Visible = false;
                    labelFundoRes.Visible = false;
                    txtValorFunReserva.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar lançamento tente novamente." + ex);
                throw;
            }
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            limpar();
            btnnovo.Enabled = true;
            btnalterar.Enabled = false;
            btncancelar.Enabled = false;
            btnsalvar.Enabled = false;
            btnexcluir.Enabled = false;
            btnlocalizar.Enabled = true;
            btnLocFlatLancamento.Enabled = false;

            labelValorAlguel.Visible = false;
            txtvaloraluguel.Visible = false;
            labelValorDiv.Visible = false;
            txtValorDiv.Visible = false;
            labelFundoRes.Visible = false;
            txtValorFunReserva.Visible = false;
        }
        private void btnexcluir_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                var lancamento = carregaPropriedades();
                repositorio.Excluir(lancamento);
                Program.serviceProvider.
                  GetRequiredService<ContextoSistema>().SaveChanges();

                MessageBox.Show("Registro excluído com sucesso!");
                limpar();
                btnnovo.Enabled = true;
                btnalterar.Enabled = false;
                btncancelar.Enabled = false;
                btnsalvar.Enabled = false;
                btnexcluir.Enabled = false;
                btnlocalizar.Enabled = true;
                btnLocFlatLancamento.Enabled = false;

                labelValorAlguel.Visible = false;
                txtvaloraluguel.Visible = false;
                labelValorDiv.Visible = false;
                txtValorDiv.Visible = false;
                labelFundoRes.Visible = false;
                txtValorFunReserva.Visible = false;
            }
        }
        void limpar()
        {
            txtidFlat.Text = "";
            txtDescricaoFlat.Text = "";
            txttipoInvestimento.Text = "";
            txtid.Text = "";
            dtdataLancamento.Value = DateTime.Now;
            txtvaloraluguel.Text = "";
            cbbtipoPagamento.Text = "";

        }
        public Lancamento carregaPropriedades()
        {
            Lancamento lancamento;

            // Verifica se o id do lançamento já existe
            if (!string.IsNullOrWhiteSpace(txtid.Text) && int.TryParse(txtid.Text, out int id))
            {
                lancamento = repositorio.Recuperar(c => c.id == id) ?? new Lancamento();
            }
            else lancamento = new Lancamento();

            lancamento.id = txtid.Text == "" ? 0 : int.Parse(txtid.Text);


            // Atribui as propriedades ao lançamento
            lancamento.DataPagamento = dtdataLancamento.Value;

            // Atribui o tipo de pagamento usando o valor selecionado
            if (cbbtipoPagamento.SelectedItem != null)
            {
                lancamento.TipoPagamento = cbbtipoPagamento.SelectedItem.ToString();
            }

            // Lógica para definir valores com base no tipo de pagamento
            if (decimal.TryParse(txtvaloraluguel.Text, out decimal valorAluguel))
            {
                lancamento.ValorAluguel = valorAluguel;
            }

            if (decimal.TryParse(txtValorDiv.Text, out decimal valorDividendos))
            {
                lancamento.ValorDividendos = valorDividendos;
            }

            if (decimal.TryParse(txtValorFunReserva.Text, out decimal valorFunReserva))
            {
                lancamento.ValorFundoReserva = valorFunReserva;
            }

            //validação txtIdFlat
            if (int.TryParse(txtidFlat.Text, out int idFlat))
            {
                lancamento.idFlat = idFlat;
            }
            else MessageBox.Show("Não foi possível localizar o Flat.");
            
            return lancamento;
        }
        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            var form2 = Program.serviceProvider.GetRequiredService<FrmConsultaLancamento>();
            form2.ShowDialog();

            if (form2.id > 0)
            {
                var lancamento = repositorio.Recuperar(l => l.id == form2.id);
                if (lancamento != null)
                {
                    txtid.Text = lancamento.id.ToString();
                    dtdataLancamento.Value = lancamento.DataPagamento;
                    txtvaloraluguel.Text = lancamento.ValorAluguel.ToString();
                    txtValorDiv.Text = lancamento.ValorDividendos.ToString();
                    txtValorFunReserva.Text = lancamento.ValorFundoReserva.ToString();
                }
                else
                {
                    MessageBox.Show("Lançamento não encontrado.");
                }
            }
        }
        private void CarregarLancamento(int idLancamento)
        {
            var lancamento = repositorio.Recuperar(l => l.id == idLancamento);

            if (lancamento != null)
            {
                txtid.Text = lancamento.id.ToString();
                dtdataLancamento.Value = lancamento.DataPagamento;
                txtvaloraluguel.Text = lancamento.ValorAluguel.ToString();

                // Acessa o flat associado ao lançamento
                if (lancamento.Flat != null)
                {
                    txtidFlat.Text = lancamento.Flat.id.ToString();
                    txtDescricaoFlat.Text = lancamento.Flat.Descricao;
                }
            }
        }
        private bool TryParseDecimal(System.Windows.Forms.TextBox textBox, out decimal result)
        {
            if (decimal.TryParse(textBox.Text, out result))
            {
                return true;
            }
            else
            {
                MessageBox.Show($"Por favor, informe um valor válido no campo {textBox.Name}");
                return false;
            }
        }
        private void btnLocFlatLancamento_Click_1(object sender, EventArgs e)
        {
            var form2 = Program.serviceProvider.GetRequiredService<FrmConsultaFlat>();
            form2.ShowDialog();

            var flat = flatRepositorio.Recuperar(f => f.id == form2.id); // Aqui o repositório está usando a entidade Flat
            int flatId = form2.id;

            if (flatId >= 0)
            {
                txtidFlat.Text = flatId.ToString();
                txtDescricaoFlat.Text = flat.Descricao;
                txttipoInvestimento.Text = flat.TipoInvestimento;
                MessageBox.Show("Flat selecionado com sucesso!");

                dtdataLancamento.Enabled = true;
                cbbtipoPagamento.Enabled = true;
            }
            else MessageBox.Show("Flat não encontrado.");


            /*
            if (cbbtipoPagamento.SelectedItem != null) // Verifica a opção desejada do ComboBox
            {
                switch (cbbtipoPagamento.SelectedItem.ToString())
                {
                    case "Aluguel Fixo":
                        labelValorPag.Visible = true;
                        txtvaloraluguel.Visible = true;
                        break;
                    case "Dividendos":
                        labelValorDiv.Visible = true;
                        txtValorDiv.Visible = true;
                        break;
                    case "Aluguel Fixo + Dividendos":
                        labelValorPag.Visible = true;
                        txtvaloraluguel.Visible = true;
                        labelValorDiv.Visible = true;
                        txtValorDiv.Visible = true;
                        break;
                    case "Fundo de Reserva":
                        labelFundoRes.Visible = true;
                        txtValorFunReserva.Visible = true;
                        break;
                    default:
                        labelValorPag.Visible = false;
                        txtvaloraluguel.Visible = false;
                        labelValorDiv.Visible = false;
                        txtValorDiv.Visible = false;
                        labelFundoRes.Visible = false;
                        txtValorFunReserva.Visible = false;
                        break;
                }
            }
            else MessageBox.Show("Informe um Tipo de Pagamento");*/
        }
        private void cbbtipoPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtipoPagamento.SelectedItem != null)
            {
                verificaComboBox(cbbtipoPagamento.SelectedItem);

            }
        }
        private void verificaComboBox(object selectedItem)
        {

            if (selectedItem != null)
            {
                switch (selectedItem.ToString())
                {
                    case "Aluguel Fixo":
                        labelValorAlguel.Visible = true;
                        txtvaloraluguel.Visible = true;
                        break;
                    case "Dividendos":
                        labelValorDiv.Visible = true;
                        txtValorDiv.Visible = true;
                        break;
                    case "Aluguel Fixo + Dividendos":
                        labelValorAlguel.Visible = true;
                        txtvaloraluguel.Visible = true;
                        labelValorDiv.Visible = true;
                        txtValorDiv.Visible = true;
                        break;
                    case "Fundo de Reserva":
                        labelFundoRes.Visible = true;
                        txtValorFunReserva.Visible = true;
                        break;
                }
            }
            else
            {
                labelValorAlguel.Visible = false;
                txtvaloraluguel.Visible = false;
                labelValorDiv.Visible = false;
                txtValorDiv.Visible = false;
                labelFundoRes.Visible = false;
                txtValorFunReserva.Visible = false;
            }
        }
    }
}
