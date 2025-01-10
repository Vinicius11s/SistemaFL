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
            var lista = repositorio.Listar(u => u.Login.Contains(txtdescricao.Text));
            dgdadosusuario.DataSource = lista;


            dgdadosusuario.Columns["id"].HeaderText = "CÓD";
            dgdadosusuario.Columns["DataCriacao"].HeaderText = "DATA ALTERAÇÃO";
            dgdadosusuario.Columns["DataCriacao"].HeaderText = "DATA ALTERAÇÃO";
            dgdadosusuario.Columns["DataCriacao"].HeaderText = "DATA ALTERAÇÃO";
            dgdadosusuario.Columns["Lancamentos"].Visible = false;

        }

        private void dgdadosusuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = (int)dgdadosusuario.Rows[e.RowIndex].Cells[0].Value;
                this.Close();
            }
        }
        private void dgdadosusuario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dgdadosusuario.Columns[e.ColumnIndex].Name == "Senha" && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
                e.FormattingApplied = true;
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
