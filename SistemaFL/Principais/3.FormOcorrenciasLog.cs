using Entidades;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;


namespace SistemaFL
{
    public partial class FrmConsultaOcorrencia : Form
    {
        private IFlatRepositorio flatRepositorio;
        private IOcorrenciaRepositorio repositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        private IOutrosLancamentosRepos outrosLancRepositorio;
        public int id;

        public FrmConsultaOcorrencia(IOcorrenciaRepositorio repositorio, ILancamentoRepositorio lancamentoRepositorio,
            IFlatRepositorio flatRepositorio, IOutrosLancamentosRepos outrosLancRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;
            this.flatRepositorio = flatRepositorio;
            this.outrosLancRepositorio = outrosLancRepositorio;

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();
        }
        private void FrmConsultaOcorrencia_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);
            dgdadosocorrencias.ReadOnly = true;
        }
        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            int anoAtual = DateTime.Now.Year;

            if (ckOutrosLanc.Checked)
            {
                var lista = outrosLancRepositorio.ObterDadosOutrosLancamentos(anoAtual);
                dgdadosocorrencias.DataSource = lista;
                Estilos.AlterarEstiloDataGrid(dgdadosocorrencias);
                AlterarNomesCabecalhoOutrosLancamentos(dgdadosocorrencias);
            }
            else
            {
                CarregarDadosOcorrenciaNormais();
            }
        }
        //DataGrid Últimos Lançamentos
        private void CarregarDadosOcorrenciaNormais()
        {
            var lista = repositorio.ListarComFlat(e => true)
                .AsNoTracking()
                .ToList();  // Executa a consulta e converte para lista
            dgdadosocorrencias.DataSource = lista;

            AjustarFormatacaoDataGrid();

            if (dgdadosocorrencias.Columns.Contains("DescricaoFlat"))
            {
                dgdadosocorrencias.Columns["DescricaoFlat"].DisplayIndex = 0;
                dgdadosocorrencias.Columns["oco_valorAntigo"].DisplayIndex = 1;
                dgdadosocorrencias.Columns["oco_DataLancamentoAntigo"].DisplayIndex = 2;
                dgdadosocorrencias.Columns["oco_valorAlteracao"].DisplayIndex = 3;
                dgdadosocorrencias.Columns["oco_DataAlteracao"].DisplayIndex = 4;
            }
            AlterarNomesCabecalho(dgdadosocorrencias);
        }
        private void AjustarFormatacaoDataGrid()
        {
            Estilos.AlterarEstiloDataGrid(dgdadosocorrencias);
            foreach (DataGridViewRow row in dgdadosocorrencias.Rows)
            {
                Estilos.AplicarFormatacaoLinha(row);
            }
        }
        private void AlterarNomesCabecalho(DataGridView grid)
        {         
            grid.Columns["id"].Visible = false;
            grid.Columns["idFlat"].Visible = false;
            grid.Columns["oco_Descricao"].Visible = false;
            grid.Columns["idLancamento"].Visible = false;
            grid.Columns["Lancamento"].Visible = false;
            grid.Columns["Flat"].Visible = false;
            grid.Columns["IdUsuario"].Visible = false;
            grid.Columns["Usuario"].Visible = false;
            grid.Columns["idOutrosLancamentos"].Visible = false;
            grid.Columns["OutrosLancamentos"].Visible = false;

            grid.Columns["oco_DataLancamentoAntigo"].HeaderText = "DATA MÊS ANTERIOR";
            grid.Columns["oco_valorAntigo"].HeaderText = "VALOR MÊS ANTERIOR";

            grid.Columns["oco_valorAlteracao"].HeaderText = "VALOR MÊS VIGENTE";
            //DATA DO PAGAMENTO ?
            grid.Columns["oco_dataAlteracao"].HeaderText = "DATA ALTERAÇÃO";
            grid.Columns["oco_Tabela"].HeaderText = "ENTIDADE";
            grid.Columns["DescricaoFlat"].HeaderText = "DESCRIÇÃO FLAT";
            grid.Columns["DescricaoUsuario"].HeaderText = "USUÁRIO";

            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if(column.Name == "oco_valorAntigo" || column.Name == "oco_valorAlteracao")
                {
                    column.DefaultCellStyle.Format = "C2";
                }
            }

        }
        private void AlterarNomesCabecalhoOutrosLancamentos(DataGridView grid)
        {
            grid.Columns["id"].Visible = false;
            grid.Columns["idUsuario"].Visible = false;
            grid.Columns["Usuario"].Visible = false;
            grid.Columns["Ocorrencias"].Visible = false;

            grid.Columns["DataLancamento"].HeaderText = "DATA LANÇAMENTO";
            grid.Columns["OutrosRecebimentos"].HeaderText = "OUTROS RECEBIMENTOS   ";
            grid.Columns["GanhoDeCapital"].HeaderText = "GANHO DE CAPITAL";
            grid.Columns["ValorRetidoNaFonte"].HeaderText = "RETIDO NA FONTE";

            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (column.Name != "DataLancamento")
                    column.DefaultCellStyle.Format = "C2";
            }
        }
        private void AlterarEstilosCelulas(DataGridView grid)
        {
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.Name == "oco_valorAntigo" || col.Name == "oco_valorAlteracao")
                {
                    col.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }
        }
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
        }
        //
        //Eventos
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


    }
}
