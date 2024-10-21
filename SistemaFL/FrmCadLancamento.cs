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
    public partial class FrmCadLancamento : Form
    {
        private ILancamentoRepositorio repositorio;
        public FrmCadLancamento(ILancamentoRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }

        private void FrmCadLancamento_Load(object sender, EventArgs e)
        {
            btnLocFlatLancamento.Enabled = false;
            txtid.Enabled = false;
            dtdataLancamento.Enabled = false;
            txtvalorPagamento.Enabled = false;
            txtidFlat.Enabled = false;
            txttipoInvestimento.Enabled = false;
            txtvalorPagamento.Enabled = false;
            btnnovo.Enabled = true;
            btnalterar.Enabled = false;
            btnsalvar.Enabled = false;
            btncancelar.Enabled = false;
            btnexcluir.Enabled = false;
            btnlocalizar.Enabled = true;
        }
        private void btnnovo_Click(object sender, EventArgs e)
        {
            if(txtidFlat.Text == "")
            {
                limpar();
                btnLocFlatLancamento.Enabled = true;
                txtid.Enabled = false;
                dtdataLancamento.Enabled = false;
                txtvalorPagamento.Enabled = false;
                txtidFlat.Enabled = false;
                txttipoInvestimento.Enabled = false;
                txtvalorPagamento.Enabled = false;
                btnnovo.Enabled = false;
                btnalterar.Enabled = false;
                btnsalvar.Enabled = false;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = false;
                btnlocalizar.Enabled = false;
            }
            else
            {
                limpar();
                btnLocFlatLancamento.Enabled = false;
                txtid.Enabled = true;
                dtdataLancamento.Enabled = true;
                txtvalorPagamento.Enabled = true;
                txtidFlat.Enabled = true;
                txttipoInvestimento.Enabled = true;
                txtvalorPagamento.Enabled = true;
                btnnovo.Enabled = false;
                btnalterar.Enabled = true;
                btnsalvar.Enabled = true;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = false;
                btnlocalizar.Enabled = false;
            }           
        }
        private void btnalterar_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                btnLocFlatLancamento.Enabled = false;
                btnnovo.Enabled = false;
                btnlocalizar.Enabled = false;
                btnalterar.Enabled = false;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = true;
                txtvalorPagamento.Focus();
            }
            else MessageBox.Show("Localize o Lançamento");
        }
        private void btnsalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtvalorPagamento.Text != string.Empty)
                {
                    carregaPropriedades();
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
            btnLocFlatLancamento.Enabled = false;
            dtdataLancamento.Enabled = false;
            txtvalorPagamento.Enabled = false;
            txtDescricaoFlat.Enabled = false;
            btnnovo.Enabled = true;
            btnalterar.Enabled = false;
            btnsalvar.Enabled = false;
            btncancelar.Enabled = false;
            btnexcluir.Enabled = false;
            btnlocalizar.Enabled = true;
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
                btnLocFlatLancamento.Enabled = false;
                dtdataLancamento.Enabled = false;
                txtvalorPagamento.Enabled = false;
                btnnovo.Enabled = true;
                btnalterar.Enabled = false;
                btnsalvar.Enabled = false;
                btncancelar.Enabled = false;
                btnexcluir.Enabled = false;
                btnlocalizar.Enabled = true;
            }
        }
        void limpar()
        {
            txtidFlat.Text = "";
            txtDescricaoFlat.Text = "";
            txttipoInvestimento.Text = "";
            txtid.Text = "";
            dtdataLancamento.Value = DateTime.Now;
            txtvalorPagamento.Text = "";

        }
        public Lancamento carregaPropriedades()
        {
            Lancamento lancamento;
            if (txtid.Text != "")
            {
                lancamento = repositorio.Recuperar(c => c.id == int.Parse(txtid.Text));
            }
            else lancamento = new Lancamento();

            lancamento.id = txtid.Text == "" ? 0 : int.Parse(txtid.Text);
            lancamento.DataPagamento = dtdataLancamento.Value;
            decimal valorPagamento;
            if (decimal.TryParse(txtvalorPagamento.Text, out valorPagamento))
            {
                lancamento.ValorPagamento = valorPagamento;
            }
            else MessageBox.Show("Por Favor informe um valor válido");

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
                    txtvalorPagamento.Text = lancamento.ValorPagamento.ToString();
                }
                else
                {
                    MessageBox.Show("Lançamento não encontrado.");
                }
            }
        }
        private void btnLocFlatLancamento_Click(object sender, EventArgs e)
        {
            var form2 = Program.serviceProvider.GetRequiredService<FrmConsultaFlat>();
            form2.ShowDialog();
            pdados.Focus();

           var repositorioFlat = Program.serviceProvider.GetRequiredService<IFlatRepositorio>();
           var flat = repositorioFlat.Recuperar(f => f.id == form2.id); // Aqui o repositório está usando a entidade Flat

           int flatId = form2.id;
                
           if (flatId >= 0)
           {
                if (flat != null)
                {
                    txtidFlat.Text = flatId.ToString();
                    txtDescricaoFlat.Text = flat.Descricao;
                    txttipoInvestimento.Text = flat.TipoInvestimento;
                    MessageBox.Show("Flat selecionado com sucesso!");
                }
                else MessageBox.Show("Flat não localizado.");
            }
            else MessageBox.Show("Flat não encontrado.");
                
            
        }
        private void CarregarLancamento(int idLancamento)
        {
            var lancamento = repositorio.Recuperar(l => l.id == idLancamento);

            if (lancamento != null)
            {
                txtid.Text = lancamento.id.ToString();
                dtdataLancamento.Value = lancamento.DataPagamento;
                txtvalorPagamento.Text = lancamento.ValorPagamento.ToString();

                // Acessa o flat associado ao lançamento
                if (lancamento.Flat != null)
                {
                    txtidFlat.Text = lancamento.Flat.id.ToString();
                    txtDescricaoFlat.Text = lancamento.Flat.Descricao;
                }
            }
        }

    }
}
