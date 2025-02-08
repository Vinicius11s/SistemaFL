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
using System.Net.Http.Headers;

namespace SistemaFL
{
    public partial class FrmCadLancamento : Form
    {
        private ILancamentoRepositorio repositorio;
        private IFlatRepositorio flatRepositorio;
        private IOutrosLancamentosRepos outrosRepositorio;
        private ContextoSistema _context;
        
        public FrmCadLancamento(ILancamentoRepositorio repositorio, IFlatRepositorio flatRepositorio, IOutrosLancamentosRepos outrosRepositorio, ContextoSistema context)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.flatRepositorio = flatRepositorio;
            this.outrosRepositorio = outrosRepositorio;
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

            ckOutrosLancamentos.Enabled = false;
            pOutrosLancamentos.Enabled = false;
        }
        //
        //CRUD
        private void btnnovo_Click(object sender, EventArgs e)
        {
            ckOutrosLancamentos.Enabled = true;

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
            pOutrosLancamentos.Enabled = false;

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
        bool avisoMostrado = false;
        bool lancamentoExistente = false;
        private void btnsalvar_Click(object sender, EventArgs e)
        {
            avisoMostrado = false;
            lancamentoExistente = false;

            if (ckOutrosLancamentos.Checked)
            {
                if (decimal.TryParse(txtOutrosReceb.Text, out decimal aluguel) && aluguel > 0 ||
                     decimal.TryParse(txtGanhoCapital.Text, out decimal fundoReserva) && fundoReserva > 0 ||
                     decimal.TryParse(txtRetidoFonte.Text, out decimal dividendos) && dividendos > 0)
                {
                    OutrosLancamentos outrosLancamentos = carregaPropriedadesOutrosLancamentos();

                    var mesSelecionado = dtdataLancamento.Value.Month;
                    var anoSelecionado = dtdataLancamento.Value.Year;

                    var lancamentoExistente = outrosRepositorio.Recuperar(l =>
                           l.DataLancamento.Month == mesSelecionado &&
                           l.DataLancamento.Year == anoSelecionado);

                    if (lancamentoExistente != null)
                    {
                        MessageBox.Show("Já existe um lançamento neste mês!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        avisoMostrado = true;
                    }
                    else
                    {
                        if (outrosLancamentos.id == 0)
                        {
                            outrosRepositorio.Inserir(outrosLancamentos);
                        }
                        else
                        {
                            outrosRepositorio.Alterar(outrosLancamentos);
                        }
                    }
                }
                else MessageBox.Show("Preencha ao menos 1 campo com valores!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtidFlat.Text))
                {
                    Lancamento lancamento = carregaPropriedades();

                    if (lancamento.id == 0)
                    {
                        if (int.TryParse(txtidFlat.Text, out int idFlat))
                        {
                            var mesSelecionado = dtdataLancamento.Value.Month;
                            var anoSelecionado = dtdataLancamento.Value.Year;

                            var lancamentoExistente = repositorio.Recuperar(l =>
                                l.idFlat == idFlat &&
                                l.DataPagamento.Month == mesSelecionado &&
                                l.DataPagamento.Year == anoSelecionado);

                            if (lancamentoExistente != null && lancamentoExistente.id != lancamento.id)
                            {
                                MessageBox.Show("Já existe um lançamento para este flat neste mês!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                avisoMostrado = true;
                            }
                            else
                            {
                                if (lancamento.id == 0)
                                {
                                    repositorio.Inserir(lancamento);
                                }
                                else
                                {
                                    repositorio.Alterar(lancamento);
                                }
                            }
                        }
                    }
                }

            }
            if (avisoMostrado == false)
            {
                // Se não houver erro, salva as alterações
                Program.serviceProvider.GetRequiredService<ContextoSistema>().SaveChanges();
                MessageBox.Show("Salvo com sucesso");

                // Limpar campos e resetar botões
                Estilos.LimparTextBoxes(plocalizar);
                Estilos.LimparTextBoxes(plancamento);
                Estilos.LimparTextBoxes(pOutrosLancamentos);

                btnnovo.Enabled = true;
                btnlocalizar.Enabled = true;
                btnalterar.Enabled = false;
                btncancelar.Enabled = false;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = false;
                btnLocFlatLancamento.Enabled = false;

                pOutrosLancamentos.Enabled = false;
                ckOutrosLancamentos.Checked = false;
                ckOutrosLancamentos.Enabled = false;
                dtdataLancamento.Enabled = false;

                txtvaloraluguel.Enabled = false;
                txtValorFunReserva.Enabled = false;
                txtValorDiv.Enabled = false;
            }
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            Estilos.LimparTextBoxes(plocalizar);
            Estilos.LimparTextBoxes(pOutrosLancamentos);
            Estilos.LimparTextBoxes(plancamento);

            ckOutrosLancamentos.Checked = false;
            ckOutrosLancamentos.Enabled = false;
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
                if (form2.tipoLancamento == "L")
                {
                    // É um Lançamento
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
                            else MessageBox.Show("Flat não localizado.");
                        }
                    }
                }
                else if (form2.tipoLancamento == "O")
                {
                    // É um Outro Lançamento
                    var outros = outrosRepositorio.Recuperar(o => o.id == form2.id);
                    if (outros != null)
                    {
                        dtdataLancamento.Value = outros.DataLancamento;
                        ckOutrosLancamentos.Checked = true;
                        txtidOutrosLanc.Text = outros.id.ToString();
                        txtOutrosReceb.Text = outros.OutrosRecebimentos.ToString();
                        txtGanhoCapital.Text = outros.GanhoDeCapital.ToString();
                        txtRetidoFonte.Text = outros.ValorRetidoNaFonte.ToString();
                    }
                }
                btnnovo.Enabled = false;
                btnlocalizar.Enabled = false;
                btnalterar.Enabled = true;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = true;
                btnsalvar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lançamento não localizado.");
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
                            outrosRepositorio.Excluir(outroslancamentos);
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
                outrosLancamentos = outrosRepositorio.Recuperar(c => c.id == id) ?? new OutrosLancamentos();

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
            ckOutrosLancamentos.Enabled = false;
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
                    plancamento.Enabled = true;

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
        }
        private void pbfechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela);
        }
        private void ckOutrosLancamentos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOutrosLancamentos.Checked)
            {
                ckOutrosLancamentos.Checked = true;
                pOutrosLancamentos.Enabled = true;
                dtdataLancamento.Enabled = true;

            }
            else
            {
                ckOutrosLancamentos.Checked = false;
                pOutrosLancamentos.Enabled = false;
                dtdataLancamento.Enabled = false;

            }
        }

       
    }
}
