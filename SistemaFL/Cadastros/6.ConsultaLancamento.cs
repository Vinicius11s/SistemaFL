using Entidades;
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFL
{
    public partial class FrmConsultaLancamento : Form
    {
        private ILancamentoRepositorio repositorio;
        private IOutrosLancamentosRepos outrosLancamentos;
        public int id { get; set; }
        public string tipoLancamento { get; set; }  // "L" para Lançamento, "O" para Outros Lançamentos
        public FrmConsultaLancamento(ILancamentoRepositorio repositorio, IOutrosLancamentosRepos outrosLancamentos)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.outrosLancamentos = outrosLancamentos;

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();
        }
        private void FrmConsultaLancamento_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);
        }
        private void btnlocalizar_Click(object sender, EventArgs e)
        {

            if (txtdescricao.Text == "Digite o número do mês" || txtdescricao.Text == "")
            {
                Estilos.AlterarEstiloDataGrid(dgdadoslancamento);
                foreach (DataGridViewRow row in dgdadoslancamento.Rows)          
                    Estilos.AplicarFormatacaoLinha(row);
                
                if (ckOutrosLanc.Checked)
                {
                    var outros = outrosLancamentos.Listar(e => true);
                    dgdadoslancamento.DataSource = outros;
                    AlterarNomesCabecalhoOutrosLancamentos(dgdadoslancamento);
                }
                else
                {
                    var lista = repositorio.Listar(e => true);
                    dgdadoslancamento.DataSource = lista;
                    AlterarNomesCabecalhoLancamentos(dgdadoslancamento);
                }               
            }
            else
            {
                if (int.TryParse(txtdescricao.Text, out int mes))
                {
                    mes = int.Parse(txtdescricao.Text);
                    if (ckOutrosLanc.Checked)
                    {
                        Estilos.AlterarEstiloDataGrid(dgdadoslancamento);
                        foreach (DataGridViewRow row in dgdadoslancamento.Rows)
                            Estilos.AplicarFormatacaoLinha(row);
                        if (mes > 0 && mes <= 12)
                        {
                            var outros = outrosLancamentos.Listar(l => l.DataLancamento.Month == mes && l.DataLancamento.Year == DateTime.Now.Year);
                            dgdadoslancamento.DataSource = outros;
                            AlterarNomesCabecalhoOutrosLancamentos(dgdadoslancamento);

                        }
                        else MessageBox.Show("Digite um mês válido.");
                    }
                    else
                    {
                        if (mes > 0 && mes <= 12)
                        {
                            Estilos.AlterarEstiloDataGrid(dgdadoslancamento);
                            foreach (DataGridViewRow row in dgdadoslancamento.Rows)
                                Estilos.AplicarFormatacaoLinha(row);
                            
                            var lista = repositorio.Listar(l => l.DataPagamento.Month == mes && l.DataPagamento.Year == DateTime.Now.Year);
                            dgdadoslancamento.DataSource = lista;
                            AlterarNomesCabecalhoLancamentos(dgdadoslancamento);

                            dgdadoslancamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                            if (dgdadoslancamento.Columns.Contains("DescricaoFlat"))
                            {
                                dgdadoslancamento.Columns["DescricaoFlat"].DisplayIndex = 0;
                            }
                        }
                        else MessageBox.Show("Digite um mês válido.");
                    }
                    
                }
                else MessageBox.Show("Digite apenas numeros.");
            }

           
        }
        private void AlterarNomesCabecalhoOutrosLancamentos(DataGridView grid)
        {
            dgdadoslancamento.Columns["id"].Visible = false;
            dgdadoslancamento.Columns["idUsuario"].Visible = false;
            dgdadoslancamento.Columns["Usuario"].Visible = false;
            dgdadoslancamento.Columns["Ocorrencias"].Visible = false;

            dgdadoslancamento.Columns["DataLancamento"].HeaderText = "DATA LANÇAMENTO";
            dgdadoslancamento.Columns["OutrosRecebimentos"].HeaderText = "OUTROS RECEBIMENTOS   ";
            dgdadoslancamento.Columns["GanhoDeCapital"].HeaderText = "GANHO DE CAPITAL";
            dgdadoslancamento.Columns["ValorRetidoNaFonte"].HeaderText = "RETIDO NA FONTE";

            foreach (DataGridViewColumn column in grid.Columns)
            {
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if(column.Name != "DataLancamento")                
                   column.DefaultCellStyle.Format = "C2";             
            }
        }
        private void AlterarNomesCabecalhoLancamentos(DataGridView grid)
        {

            dgdadoslancamento.Columns["id"].Visible = false;
            dgdadoslancamento.Columns["idFlat"].Visible = false;
            dgdadoslancamento.Columns["AluguelVenceslau"].Visible = false;
            dgdadoslancamento.Columns["Flat"].Visible = false;
            dgdadoslancamento.Columns["idUsuario"].Visible = false;
            dgdadoslancamento.Columns["Usuario"].Visible = false;
            dgdadoslancamento.Columns["Ocorrencias"].Visible = false;

            dgdadoslancamento.Columns["DataPagamento"].HeaderText = "DATA PAGAMENTO";
            dgdadoslancamento.Columns["TipoPagamento"].HeaderText = "TIPO INVESTIMENTO";
            dgdadoslancamento.Columns["ValorAluguel"].HeaderText = "VALOR ALUGUEL";
            dgdadoslancamento.Columns["ValorDividendos"].HeaderText = "VALOR DIVIDENDOS";
            dgdadoslancamento.Columns["ValorFundoReserva"].HeaderText = "FUNDO RESERVA";
            dgdadoslancamento.Columns["DescricaoFlat"].HeaderText = "DESCRIÇÃO FLAT";

            foreach (DataGridViewColumn column in grid.Columns)
            {
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (column.Name != "DataPagamento" && column.Name != "TipoPagamento")
                    column.DefaultCellStyle.Format = "C2";
            }

        }
        private void AlterarEstilosCelulas(DataGridView grid)
        {
            foreach (DataGridViewColumn coluna in grid.Columns)
            {
                if (coluna.Name != "id" && coluna.Name != "idFlat" && coluna.Name != "DataPagamento")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }
        }
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
        }
        //
        //Eventos     
        private void dgdadoslancamento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgdadoslancamento.SelectedRows.Count > 0)
            {
                id = Convert.ToInt32(dgdadoslancamento.SelectedRows[0].Cells["id"].Value);

                // Aqui, você define o tipo com base na origem do dado (Lançamento ou Outros Lançamentos)
                if (ckOutrosLanc.Checked == false)
                {
                    tipoLancamento = "L";
                }
                else if (ckOutrosLanc.Checked)
                {
                    tipoLancamento = "O";
                }

                this.Close(); // Fecha o formulário após a seleção
            }
            else
            {
                MessageBox.Show("Selecione um lançamento.");
            }
        }  
        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pbMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else this.WindowState = FormWindowState.Maximized;
        }       
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela, 10);
        }

        
    }
}
