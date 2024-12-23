using Infraestrutura.Contexto;
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
    public partial class FrmConsultaEmpresa : Form
    {
        private IEmpresaRepositorio repositorio;
        public int id;
        public FrmConsultaEmpresa(IEmpresaRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //No clique do botão localizar, vamos fazer um select
            var lista = repositorio.Listar(e => e.Descricao.Contains(txtdescricao.Text));

            dgdados.DataSource = lista;

            if (lista.Count > 0)
            {
                dgdados.Columns["id"].HeaderText = "Código";
                dgdados.Columns["descricao"].HeaderText = "Descrição";
                dgdados.Columns["RazaoSocial"].HeaderText = "Razão Social";
                dgdados.Columns["InscricaoEstadual"].HeaderText = "Inscrição Estadual";
                dgdados.Columns["Numero"].HeaderText = "Nº";
                dgdados.Columns["Flats"].Visible = false;
                dgdados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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

        private void FrmConsultaEmpresa_Load(object sender, EventArgs e)
        {
            dgdados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void dgdados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se estamos formatando a coluna CnpjRecebimento
            if (dgdados.Columns[e.ColumnIndex].Name == "Cnpj")
            {
                // Verifica se a célula contém um valor válido
                if (e.Value != null && e.Value is string cnpj)
                {
                    // Aplica a máscara de CNPJ ao valor
                    e.Value = FormatCnpj(cnpj);
                }
            }
        }
        private string FormatCnpj(string cnpj)
        {
            // Remove quaisquer caracteres não numéricos
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            // Verifica se o CNPJ tem o tamanho correto
            if (cnpj.Length == 14)
            {
                return string.Format("{0:00\\.000\\.000\\/0000\\-00}", double.Parse(cnpj));
            }

            return cnpj; // Retorna o valor original caso não seja um CNPJ válido
        }
    }
}
