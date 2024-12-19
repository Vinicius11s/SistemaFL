using Entidades;
using Infraestrutura.Contexto;
using Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        private ContextoSistema _context;

        public FrmCadLancamento(ILancamentoRepositorio repositorio, IFlatRepositorio flatRepositorio, ContextoSistema context)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.flatRepositorio = flatRepositorio;
            this._context = context;
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

            }
            else MessageBox.Show("Localize o Lançamento");
        }
        private void btnsalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txttipoInvestimento.Text != String.Empty)
                {
                    Lancamento lancamento = carregaPropriedades();

                    if (lancamento.id == 0)
                    {
                        repositorio.Inserir(lancamento);
                    }
                    else
                    {
                        repositorio.Alterar(lancamento);
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
                MessageBox.Show("Erro ao salvar, Flat do Tipo Aluguel + Dividendos, Informe valores aos campos" + ex.Message);

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

            // Lógica para definir valores com base no tipo de pagamento
            /*if (txttipoInvestimento.Text == "Aluguel Venceslau")
            {
                if (decimal.TryParse(txtvaloraluguel.Text, out decimal valorAluguelVenceslau)
                {
                    lancamento.AluguelVenceslau = valorAluguelVenceslau;
                }
            }*/

            if(txttipoInvestimento.Text == "Aluguel Venceslau")
            {
                if (decimal.TryParse(txtvaloraluguel.Text, out decimal valorAluguelVenceslau))
                {
                    lancamento.AluguelVenceslau = valorAluguelVenceslau;
                }
            }
            else
            {
                if (decimal.TryParse(txtvaloraluguel.Text, out decimal ValorAluguelFlat))
                {
                    lancamento.ValorAluguel = ValorAluguelFlat;
                }
                if (decimal.TryParse(txtValorDiv.Text, out decimal ValorDividendos))
                {
                    lancamento.ValorDividendos = ValorDividendos;
                }
                if (decimal.TryParse(txtValorFunReserva.Text, out decimal ValorFunReserva))
                {
                    lancamento.ValorFundoReserva = ValorFunReserva;
                }
            }
            

            //validação txtIdFlat
            if (int.TryParse(txtidFlat.Text, out int idFlat))
            {
                Flat flat;
                flat = flatRepositorio.Recuperar(e => e.id == idFlat);
                lancamento.idFlat = idFlat;
                lancamento.TipoPagamento = flat.TipoInvestimento;
                lancamento.DescricaoFlat = txtDescricaoFlat.Text;
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
                CarregarLancamento(form2.id);
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
                txtValorDiv.Text = lancamento.ValorDividendos.ToString();
                txtValorFunReserva.Text = lancamento.ValorFundoReserva.ToString();

                // Acessa o flat associado ao lançamento
                if (lancamento.idFlat != null)
                {
                    txtidFlat.Text = lancamento.idFlat.ToString();
                    txtDescricaoFlat.Text = lancamento.Flat.Descricao;
                    //lancamento.DescricaoFlat = txtDescricaoFlat.Text;
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
                if (txttipoInvestimento.Text != "")
                {
                    verificaInvestimento(txttipoInvestimento.Text);

                }
            }
            else MessageBox.Show("Flat não encontrado.");

        }
        private void verificaInvestimento(string TipoInvestimento)
        {

            if (!string.IsNullOrEmpty(TipoInvestimento))
            {
                switch (TipoInvestimento)
                {
                    case "Aluguel Fixo":
                        labelValorAlguel.Visible = true;
                        txtvaloraluguel.Visible = true;
                        labelFundoRes.Visible = true;
                        txtValorFunReserva.Visible = true;
                        break;
                    case "Dividendos":
                        labelValorDiv.Visible = true;
                        txtValorDiv.Visible = true;
                        labelFundoRes.Visible = true;
                        txtValorFunReserva.Visible = true;
                        break;
                    case "Aluguel Fixo + Dividendos":
                        labelValorAlguel.Visible = true;
                        txtvaloraluguel.Visible = true;
                        labelValorDiv.Visible = true;
                        txtValorDiv.Visible = true;
                        labelFundoRes.Visible = true;
                        txtValorFunReserva.Visible = true;
                        break;
                    case "Aluguel Venceslau":
                        labelValorAlguel.Visible = true;
                        txtvaloraluguel.Visible = true;
                        labelValorDiv.Visible = false;
                        txtValorDiv.Visible = false;
                        labelFundoRes.Visible = false;
                        txtValorFunReserva.Visible = false;
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
        void limpar()
        {
            dtdataLancamento.Value = DateTime.Now;
            txtidFlat.Text = "";
            txtDescricaoFlat.Text = "";
            txttipoInvestimento.Text = "";
            txtid.Text = "";
            txtvaloraluguel.Text = "";
            txtValorDiv.Text = "";
            txtValorFunReserva.Text = "";

        }
    }
}
