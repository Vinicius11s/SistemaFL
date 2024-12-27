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
        }

        private void FrmConsultaOcorrencia_Load(object sender, EventArgs e)
        {
            var lista = repositorio.ListarComFlat(e => true).ToList();  // Executa a consulta e converte para lista

            dgdadosocorrencias.DataSource = lista;
            dgdadosocorrencias.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgdadosocorrencias.Columns["id"].HeaderText = "Cód.";
            dgdadosocorrencias.Columns["oco_valorAntigo"].HeaderText = "Valor Ant";
            dgdadosocorrencias.Columns["oco_valorAlteracao"].HeaderText = "Valor Alteração";
            dgdadosocorrencias.Columns["oco_dataAlteracao"].HeaderText = "Data Alteração";
            dgdadosocorrencias.Columns["oco_Tabela"].HeaderText = "Entidade";
            dgdadosocorrencias.Columns["oco_Descricao"].HeaderText = "Descrição";
            dgdadosocorrencias.Columns["idLancamento"].Visible = false;
            dgdadosocorrencias.Columns["Lancamento"].Visible = false;
            dgdadosocorrencias.Columns["Flat"].Visible = false;

            // Adicionando uma coluna extra para o nome do Flat
            dgdadosocorrencias.Columns.Add("NomeFlat", "Nome do Flat");

            // Preencher a nova coluna com o nome do Flat
            /*foreach (DataGridViewRow row in dgdadosocorrencias.Rows)
            {
                var ocorrencia = (Ocorrencia)row.DataBoundItem;
                row.Cells["NomeFlat"].Value = ocorrencia.Flat?.Descricao;  // Exibe o nome do Flat
            }*/

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
