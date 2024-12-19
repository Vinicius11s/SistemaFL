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

namespace SistemaFL
{
    public partial class FrmConsultaOcorrencia : Form
    {
        private IOcorrenciaRepositorio repositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        public int id;
        public FrmConsultaOcorrencia(IOcorrenciaRepositorio repositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;
        }

        private void FrmConsultaOcorrencia_Load(object sender, EventArgs e)
        {
            var lista = repositorio.Listar(e => true);
            dgdadosocorrencias.DataSource = lista.ToList();

            dgdadosocorrencias.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgdadosocorrencias.Columns["Lancamento"].Visible = false;
            dgdadosocorrencias.Columns["idFlat"].Visible = false;

            dgdadosocorrencias.Columns["id"].HeaderText = "Cód.";
            dgdadosocorrencias.Columns["oco_valorAntigo"].HeaderText = "Valor Antigo";
            dgdadosocorrencias.Columns["oco_valorAlteracao"].HeaderText = "Valor Alteração";
            dgdadosocorrencias.Columns["oco_dataAlteracao"].HeaderText = "Data Alteração";
            dgdadosocorrencias.Columns["oco_Tabela"].HeaderText = "Entidade";
            dgdadosocorrencias.Columns["oco_Descricao"].HeaderText = "Descrição";
            dgdadosocorrencias.Columns["idLancamento"].Visible = false;          
        }

        private void fecharjanela_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
