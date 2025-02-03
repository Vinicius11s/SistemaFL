using Entidades;
using Infraestrutura.Seguranca;
using Infraestrutura.Contexto;
using Infraestrutura.Repositorio;
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
using InfraEstrutura.Repositorio;

namespace SistemaFL
{
    public partial class FrmCadLancamento : Form
    {
        private ILancamentoRepositorio repositorio;
        private IFlatRepositorio flatRepositorio;
        private IOutrosLancamentosRepos outrosLancamentosRepos;
        private ContextoSistema _context;

        public FrmCadLancamento(ILancamentoRepositorio repositorio, IFlatRepositorio flatRepositorio, IOutrosLancamentosRepos outrosLancamentosRepos, ContextoSistema context)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.flatRepositorio = flatRepositorio;
            this.outrosLancamentosRepos = outrosLancamentosRepos;
            this._context = context;

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();
        }
        private void FrmCadLancamento_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);

            Estilos.LimparTextBoxes(plocalizar);
            Estilos.LimparTextBoxes(plancamento);
            btnnovo.Enabled = true;
            btnalterar.Enabled = false;
            btncancelar.Enabled = false;
            btnsalvar.Enabled = false;
            btnexcluir.Enabled = false;
            btnlocalizar.Enabled = true;
            btnLocFlatLancamento.Enabled = false;

            dtdataLancamento.Enabled = false;
            txtvaloraluguel.Enabled = false;
            txtValorDiv.Enabled = false;
            txtValorFunReserva.Enabled = false;

            pOutrosLancamentos.Enabled = false;
        }
        //
        //CRUD
        private void btnnovo_Click(object sender, EventArgs e)
        {
            if (ckOutrosLancamentos.Checked)
            {
                Estilos.LimparTextBoxes(plocalizar);
                Estilos.LimparTextBoxes(plancamento);
                btnnovo.Enabled = false;
                btnalterar.Enabled = false;
                btncancelar.Enabled = true;
                btnsalvar.Enabled = true;
                btnexcluir.Enabled = true;
                btnlocalizar.Enabled = false;
                btnLocFlatLancamento.Enabled = true;

                plocalizar.Enabled = false;
                plancamento.Enabled = false;
                pOutrosLancamentos.Enabled = true;
            }
            else
            {
                Estilos.LimparTextBoxes(plocalizar);
                Estilos.LimparTextBoxes(plancamento);
                btnnovo.Enabled = false;
                btnalterar.Enabled = false;
                btncancelar.Enabled = true;
                btnsalvar.Enabled = true;
                btnexcluir.Enabled = true;
                btnlocalizar.Enabled = false;
                btnLocFlatLancamento.Enabled = true;

                pOutrosLancamentos.Enabled = false;
            }


        }
        private void btnalterar_Click(object sender, EventArgs e)
        {
            if (ckOutrosLancamentos.Checked)
            {
                if (txtidOutrosLanc.Text != "")
                {
                    btnnovo.Enabled = false;
                    btnalterar.Enabled = false;
                    btncancelar.Enabled = true;
                    btnsalvar.Enabled = true;
                    btnexcluir.Enabled = false;
                    btnlocalizar.Enabled = false;
                    btnLocFlatLancamento.Enabled = false;

                    plocalizar.Enabled = false;
                    plancamento.Enabled = false;
                }
                else MessageBox.Show("Localize o Lançamento");
            }
            else
            {
                if (txtid.Text != "")
                {
                    btnnovo.Enabled = false;
                    btnalterar.Enabled = false;
                    btncancelar.Enabled = true;
                    btnsalvar.Enabled = true;
                    btnexcluir.Enabled = false;
                    btnlocalizar.Enabled = false;
                    btnLocFlatLancamento.Enabled = false;

                    int idFlat;
                    if (int.TryParse(txtidFlat.Text, out idFlat))
                    {
                        var flat = flatRepositorio.Recuperar(f => f.id == idFlat);

                        verificaInvestimento(flat.TipoInvestimento);
                    }
                }
                else MessageBox.Show("Localize o Lançamento");
            }
        }
        private void btnsalvar_Click(object sender, EventArgs e)
        {
            bool lancamentoExistenteMes = false;
            try
            {
                if (ckOutrosLancamentos.Checked)
                {
                    if (txtidOutrosLanc.Text != String.Empty)
                    {
                        OutrosLancamentos outros = carregaPropriedadesOutrosLancamentos();

                        if (outros.id == 0)
                        {
                            if (int.TryParse(txtidOutrosLanc.Text, out int idOutroLanc))
                            {
                                var mesSelecionado = dtdataLancamento.Value.Month;
                                var anoelecionado = dtdataLancamento.Value.Year;

                                var lancamentoExistente = outrosLancamentosRepos.Recuperar(l => l.DataLancamento.Month == dtdataLancamento.Value.Month
                                    && l.DataLancamento.Month == mesSelecionado
                                    && l.DataLancamento.Year == anoelecionado);

                                if (lancamentoExistente != null)
                                {
                                    MessageBox.Show("Já existe um lançamento neste mês!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    lancamentoExistenteMes = true; // Retorna sem fazer a inserção
                                }
                                else outrosLancamentosRepos.Inserir(outros);
                            }
                        }
                        else outrosLancamentosRepos.Alterar(outros);
                    }
                }
                else
                {
                    if (txtidFlat.Text != String.Empty)
                    {
                        Lancamento lancamento = carregaPropriedades();

                        if (lancamento.id == 0)
                        {
                            if (int.TryParse(txtidFlat.Text, out int idFlat))
                            {
                                var mesSelecionado = dtdataLancamento.Value.Month;
                                var anoelecionado = dtdataLancamento.Value.Year;

                                var lancamentoExistente = repositorio.Recuperar(l => l.idFlat == idFlat
                                    && l.DataPagamento.Month == mesSelecionado
                                    && l.DataPagamento.Year == anoelecionado);

                                if (lancamentoExistente != null)
                                {
                                    MessageBox.Show("Já existe um lançamento para este flat neste mês!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    lancamentoExistenteMes = true; // Retorna sem fazer a inserção
                                }
                                else repositorio.Inserir(lancamento);
                            }
                        }
                        else repositorio.Alterar(lancamento);
                    }

                    if (lancamentoExistenteMes == false)
                    {
                        Program.serviceProvider.
                                                GetRequiredService<ContextoSistema>().SaveChanges();
                        MessageBox.Show("Salvo com sucesso");

                        Estilos.LimparTextBoxes(plocalizar);
                        Estilos.LimparTextBoxes(plancamento);
                        btnnovo.Enabled = true;
                        btnlocalizar.Enabled = true;
                        btnalterar.Enabled = false;
                        btncancelar.Enabled = false;
                        btnexcluir.Enabled = false;
                        btnsalvar.Enabled = false;

                        txtvaloraluguel.Enabled = false;
                        txtValorFunReserva.Enabled = false;
                        txtValorDiv.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                if (txtTipoInvestimento.Text == "Aluguel + Dividendos")
                {
                    MessageBox.Show("Erro ao salvar, Flat do Tipo Aluguel + Dividendos, Informe valores aos campos");
                }
                MessageBox.Show("Erro ao salvar");
                throw;
            }
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            Estilos.LimparTextBoxes(plocalizar);
            Estilos.LimparTextBoxes(pOutrosLancamentos);
            Estilos.LimparTextBoxes(plancamento);

            ckOutrosLancamentos.Checked = false;
            btnnovo.Enabled = true;
            btnalterar.Enabled = false;
            btncancelar.Enabled = false;
            btnsalvar.Enabled = false;
            btnexcluir.Enabled = false;
            btnlocalizar.Enabled = true;
            btnLocFlatLancamento.Enabled = false;

            plancamento.Enabled = false;
            plocalizar.Enabled = false;
            pOutrosLancamentos.Enabled = false;
        }
        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            var form2 = Program.serviceProvider.GetRequiredService<FrmConsultaLancamento>();
            form2.ShowDialog();

            if (form2.id > 0)
            {
                //no clique do botão localizar vamos fazer um select * from empresa where id
                var lancamento = repositorio.Recuperar(e => e.id == form2.id);
                if (lancamento != null)
                {
                    txtid.Text = lancamento.id.ToString();
                    dtdataLancamento.Value = lancamento.DataPagamento;
                    txtvaloraluguel.Text = lancamento.ValorAluguel.ToString();
                    txtValorDiv.Text = lancamento.ValorDividendos.ToString();
                    txtValorFunReserva.Text = lancamento.ValorFundoReserva.ToString();

                    if (lancamento.idFlat >= 0)
                    {
                        var flat = flatRepositorio.Recuperar(e => e.id == lancamento.idFlat);
                        if (flat != null)
                        {
                            txtidFlat.Text = lancamento.idFlat.ToString();
                            txtDescricaoFlat.Text = lancamento.DescricaoFlat;
                            txtTipoInvestimento.Text = lancamento.TipoPagamento;
                        }
                        else MessageBox.Show("Flat nao localizado");
                    }
                    else
                        btnnovo.Enabled = false;
                    btnlocalizar.Enabled = false;
                    btnalterar.Enabled = true;
                    btncancelar.Enabled = true;
                    btnexcluir.Enabled = true;
                    btnsalvar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Lancamento não encontrado.");
                }
            }
        }
        private void btnexcluir_Click(object sender, EventArgs e)
        {
            if (ckOutrosLancamentos.Checked == false)
            {
                if (txtid.Text != "")
                {
                    DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var lancamento = carregaPropriedades();
                        var contexto = Program.serviceProvider.GetRequiredService<ContextoSistema>();

                        // Verifica se existem ocorrências relacionadas ao lançamento
                        var temOcorrencias = contexto.Ocorrencia.Any(o => o.idLancamento == lancamento.id);

                        if (temOcorrencias)
                        {
                            MessageBox.Show("Não é possível excluir o lançamento. Existem ocorrências associadas.");
                        }
                        else
                        {
                            repositorio.Excluir(lancamento);
                            contexto.SaveChanges();

                            MessageBox.Show("Registro excluído com sucesso!");
                            Estilos.LimparTextBoxes(plocalizar);
                            Estilos.LimparTextBoxes(plancamento);
                            btnnovo.Enabled = true;
                            btnalterar.Enabled = false;
                            btncancelar.Enabled = false;
                            btnsalvar.Enabled = false;
                            btnexcluir.Enabled = false;
                            btnlocalizar.Enabled = true;
                            btnLocFlatLancamento.Enabled = false;
                        }
                    }
                }
                else MessageBox.Show("Localize o Lançamento");
            }
            else
            {
                if (txtidOutrosLanc.Text != "")
                {
                    DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var outroslancamentos = carregaPropriedadesOutrosLancamentos();
                        var contexto = Program.serviceProvider.GetRequiredService<ContextoSistema>();

                        // Verifica se existem ocorrências relacionadas ao lançamento
                        var temOcorrencias = contexto.Ocorrencia.Any(o => o.idOutrosLancamentos == outroslancamentos.id);

                        if (temOcorrencias)
                        {
                            MessageBox.Show("Não é possível excluir o lançamento. Existem ocorrências associadas.");
                        }
                        else
                        {
                            outrosLancamentosRepos.Excluir(outroslancamentos);
                            contexto.SaveChanges();

                            MessageBox.Show("Registro excluído com sucesso!");
                            Estilos.LimparTextBoxes(plocalizar);
                            Estilos.LimparTextBoxes(plancamento);
                            btnnovo.Enabled = true;
                            btnalterar.Enabled = false;
                            btncancelar.Enabled = false;
                            btnsalvar.Enabled = false;
                            btnexcluir.Enabled = false;
                            btnlocalizar.Enabled = true;
                            btnLocFlatLancamento.Enabled = false;
                        }
                    }
                }
            }
        }
        //
        //
        public Lancamento carregaPropriedades()
        {
            Lancamento lancamento;

            // Verifica se o id do lançamento já existe
            if (!string.IsNullOrWhiteSpace(txtid.Text) && int.TryParse(txtid.Text, out int id))
            {
                lancamento = repositorio.Recuperar(c => c.id == id) ?? new Lancamento();

            }
            else lancamento = new Lancamento();

            if (Sessao.idUsuarioLogado > 0)
            {
                lancamento.idUsuario = Sessao.idUsuarioLogado;
            }
            lancamento.id = txtid.Text == "" ? 0 : int.Parse(txtid.Text);
            lancamento.DataPagamento = dtdataLancamento.Value;

            if (txtTipoInvestimento.Text == "Aluguel Venceslau")
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
        public OutrosLancamentos carregaPropriedadesOutrosLancamentos()
        {
            OutrosLancamentos outrosLancamentos;

            // Verifica se o id do lançamento já existe
            if (!string.IsNullOrWhiteSpace(txtidOutrosLanc.Text) && int.TryParse(txtidOutrosLanc.Text, out int id))
            {
                outrosLancamentos = outrosLancamentosRepos.Recuperar(c => c.id == id) ?? new OutrosLancamentos();

            }
            else outrosLancamentos = new OutrosLancamentos();

            if (Sessao.idUsuarioLogado > 0)
            {
                outrosLancamentos.idUsuario = Sessao.idUsuarioLogado;
            }
            outrosLancamentos.id = txtid.Text == "" ? 0 : int.Parse(txtid.Text);
            outrosLancamentos.DataLancamento = dtdataLancamento.Value;
            outrosLancamentos.OutrosRecebimentos = txtOutrosReceb.Text == "" ? 0 : decimal.Parse(txtOutrosReceb.Text);
            outrosLancamentos.GanhoDeCapital = txtGanhoCapital.Text == "" ? 0 : decimal.Parse(txtGanhoCapital.Text);
            outrosLancamentos.ValorRetidoNaFonte = txtRetidoFonte.Text == "" ? 0 : decimal.Parse(txtRetidoFonte.Text);

            return outrosLancamentos;
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
                if (flat != null)
                {
                    btncancelar.Enabled = true;

                    txtidFlat.Text = flatId.ToString();
                    txtDescricaoFlat.Text = flat.Descricao;
                    txtTipoInvestimento.Text = flat.TipoInvestimento;
                    txtStatus.Text = flat.Status;
                    txtNumMatriculaImovel.Text = flat.NumMatriculaImovel.ToString();
                    txtValoDeCompra.Text = flat.ValorDeCompra.ToString();

                    MessageBox.Show("Flat selecionado com sucesso!");
                    dtdataLancamento.Enabled = true;

                    if (txtTipoInvestimento.Text != "")
                    {
                        verificaInvestimento(txtTipoInvestimento.Text);
                    }
                }
                else
                {
                    plancamento.Enabled = false;
                }
            }
            else MessageBox.Show("Flat não encontrado.");


        }
        private void verificaInvestimento(string TipoInvestimento)
        {

            if (!string.IsNullOrEmpty(TipoInvestimento))
            {
                txtValorFunReserva.Enabled = true;

                switch (TipoInvestimento)
                {
                    case "Aluguel Fixo":
                        txtvaloraluguel.Enabled = true;
                        txtValorDiv.Enabled = false;
                        break;
                    case "Dividendos":
                        txtvaloraluguel.Enabled = false;
                        txtValorDiv.Enabled = true;
                        break;
                    case "Aluguel Fixo + Dividendos":
                        txtvaloraluguel.Enabled = true;
                        txtValorDiv.Enabled = true;
                        break;
                    case "Aluguel Venceslau":
                        txtvaloraluguel.Enabled = true;
                        txtValorDiv.Enabled = false;
                        break;
                }
            }
            else
            {
                txtvaloraluguel.Enabled = false;
                txtValorDiv.Enabled = false;
                txtValorFunReserva.Enabled = false;
            }
        }
        private void pbfechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela, 10);
        }
        private void ckOutrosLancamentos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOutrosLancamentos.Checked)
            {
                ckOutrosLancamentos.Checked = true;
                pOutrosLancamentos.Enabled = true;

            }
            else
            {
                ckOutrosLancamentos.Checked = false;
                pOutrosLancamentos.Enabled = false;
            }
        }
    }
}
