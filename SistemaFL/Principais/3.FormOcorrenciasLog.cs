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
        public int id;
        public FrmConsultaOcorrencia(IOcorrenciaRepositorio repositorio, ILancamentoRepositorio lancamentoRepositorio, IFlatRepositorio flatRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;
            this.flatRepositorio = flatRepositorio;

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();
        }
        private void FrmConsultaOcorrencia_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);
            dgdadosocorrencias.ReadOnly = true;
            CarregarDados();
        }
        
        //
        //DataGrid Últimos Lançamentos
        private void CarregarDados()
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
        }
        private void AjustarFormatacaoDataGrid()
        {
            AlterarEstilosCabecalho(dgdadosocorrencias);
            AlterarEstilosCelulas(dgdadosocorrencias);
            foreach (DataGridViewRow row in dgdadosocorrencias.Rows)
            {
                AplicarFormatacaoLinha(row);
            }
        }
        private void AlterarEstilosCabecalho(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Regular);

            grid.Columns["id"].Visible = false;
            grid.Columns["idFlat"].Visible = false;
            grid.Columns["oco_Descricao"].Visible = false;
            grid.Columns["idLancamento"].Visible = false;
            grid.Columns["Lancamento"].Visible = false;
            grid.Columns["Flat"].Visible = false;
            grid.Columns["IdUsuario"].Visible = false;
            grid.Columns["Usuario"].Visible = false;

            grid.Columns["oco_DataLancamentoAntigo"].HeaderText = "DATA MÊS ANTERIOR";
            grid.Columns["oco_valorAntigo"].HeaderText = "VALOR MÊS ANTERIOR";

            grid.Columns["oco_valorAlteracao"].HeaderText = "VALOR MÊS VIGENTE";
            //DATA DO PAGAMENTO ?
            grid.Columns["oco_dataAlteracao"].HeaderText = "DATA ALTERAÇÃO";
            grid.Columns["oco_Tabela"].HeaderText = "ENTIDADE";
            grid.Columns["DescricaoFlat"].HeaderText = "DESCRIÇÃO FLAT";
            grid.Columns["DescricaoUsuario"].HeaderText = "USUÁRIO";
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
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela, 10);
        }
    }
}
