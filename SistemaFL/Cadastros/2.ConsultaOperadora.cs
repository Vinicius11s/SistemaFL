using Infraestrutura.Contexto;
using Interfaces;
using System;
using System.Collections;
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
    public partial class FrmConsultaEmpresa : Form
    {
        private IEmpresaRepositorio repositorio;
        public int id;
        public FrmConsultaEmpresa(IEmpresaRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();

        }
        private void FrmConsultaEmpresa_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);

            txtdescricao.Text = "Digite aqui a descrição da Operadora";
            txtdescricao.ForeColor = Color.Gray;

            dgdados.SuspendLayout(); // Suspende o layout do DataGridView
            dgdados.DataSource = null;
            dgdados.ResumeLayout();  // Retoma o layout após a alteração
            dgdados.Rows.Clear();
        }
        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            if (txtdescricao.Text == "Digite aqui a descrição da Operadora")
            {
                txtdescricao.Text = "";
            }

            CarregarDados();
            AlterarNomesCabecalho(dgdados);

            dgdados.DataBindingComplete += dgdados_DataBindingComplete;

        }
        private void CarregarDados()
        {
            var lista = repositorio.Listar(e => e.Descricao.Contains(txtdescricao.Text))
                        .OrderBy(e => e.Descricao) // Ordena alfabeticamente pela Descricao
                        .ToList();
            dgdados.DataSource = lista;

        }
        private void AlterarNomesCabecalho(DataGridView grid)
        {
            grid.Columns["id"].Visible = false;
            grid.Columns["Flats"].Visible = false;

            grid.Columns["descricao"].HeaderText = "DESCRIÇÃO";
            grid.Columns["RazaoSocial"].HeaderText = "RAZÃO SOCIAL";
            grid.Columns["InscricaoEstadual"].HeaderText = "INSC. ESTADUAL";
            grid.Columns["Numero"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns["Numero"].HeaderText = "Nº";
            grid.Columns["Estado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        //Eventos
        private void dgdados_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Estilos.AlterarEstiloDataGrid(dgdados);

            foreach (DataGridViewRow row in dgdados.Rows)
            {
                Estilos.AplicarFormatacaoLinha(row);
            }
        }
        private void dgdados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = (int)dgdados.Rows[e.RowIndex].Cells[0].Value; // Armazena o ID
                this.Close(); // Fecha o formulário
            }
        }
        private void dgdados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgdados.Columns[e.ColumnIndex].Name == "Cnpj")
            {
                // Verifica se a célula contém um valor válido
                if (e.Value != null && e.Value is string cnpj)
                {
                    // Aplica a máscara de CNPJ ao valor
                    e.Value = Estilos.FormatCnpj(cnpj);
                }
            }
            if (dgdados.Columns[e.ColumnIndex].Name == "InscricaoEstadual")
            {
                if (e.Value != null && e.Value is string ie)
                {
                    e.Value = Estilos.FormatInscricaoEstadual(ie);
                }
            }
            if (dgdados.Columns[e.ColumnIndex].Name == "Cep")
            {
                if (e.Value != null && e.Value is string cep)
                {
                    e.Value = Estilos.FormatCep(cep);
                }
            }
        }
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela);
        }
        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmConsultaEmpresa_Resize(object sender, EventArgs e)
        {
            dgdados.Width = this.ClientSize.Width - dgdados.Left - 210;
        }
        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
