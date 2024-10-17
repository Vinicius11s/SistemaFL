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
            var lista = repositorio.Listar(e=>e.Descricao.Contains(txtdescricao.Text));

            dgdados.DataSource = lista;

            if (lista.Count > 0)
            {
                dgdados.Columns["descricao"].HeaderText = "Descrição";

            }
        }
        private void gdDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dgdados.Rows[e.RowIndex].Cells[0].Value;
            this.Close();
        }
    }
}
