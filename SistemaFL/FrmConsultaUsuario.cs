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
    public partial class FrmConsultaUsuario : Form
    {
        private IUsuarioRepositorio repositorio;
        public int id;
        public FrmConsultaUsuario(IUsuarioRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }

        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            var lista = repositorio.Listar(u => u.Nome.Contains(txtdescricao.Text));
            dgdadosusuario.DataSource = lista;

            if (lista.Count > 0)
            {
                dgdadosusuario.Columns["id"].HeaderText = "Código";
                dgdadosusuario.Columns["DataCriacao"].HeaderText = "Data Alteração";
            }
            else MessageBox.Show("Nenhum usuário foi encontrado.");
        }

        private void dgdadosusuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = (int)dgdadosusuario.Rows[e.RowIndex].Cells[0].Value;
                this.Close();
            }
        }
    }
}
