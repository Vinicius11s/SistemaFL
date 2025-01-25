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
        }
        private void FrmConsultaEmpresa_Load(object sender, EventArgs e)
        {
            dgdados.DataSource = null;
            dgdados.Rows.Clear();
        }     
        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            var lista = repositorio.Listar(e => e.Descricao.Contains(txtdescricao.Text))
                        .OrderBy(e => e.Descricao) // Ordena alfabeticamente pela Descricao
                        .ToList();

            dgdados.DataSource = lista;


            AlterarEstilosCabecalho(dgdados);
            dgdados.RowTemplate.Height = 28;  // Define a altura fixa desejada (ajuste conforme necessário)
            

            foreach (DataGridViewRow row in dgdados.Rows)
            {
                AplicarFormatacaoLinha(row);
                dgdados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }


        }
        private void AlterarEstilosCabecalho(DataGridView grid)
        {
            dgdados.EnableHeadersVisualStyles = false;
            dgdados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Regular);

            dgdados.Columns["id"].Visible = false;
            dgdados.Columns["Cnpj"].HeaderText = "CNPJ";
            dgdados.Columns["descricao"].HeaderText = "DESCRIÇÃO";
            dgdados.Columns["RazaoSocial"].HeaderText = "RAZÃO SOCIAL";
            dgdados.Columns["InscricaoEstadual"].HeaderText = "INSC. ESTADUAL";
            dgdados.Columns["Rua"].HeaderText = "RUA";
            dgdados.Columns["Cidade"].HeaderText = "CIDADE";
            dgdados.Columns["Cep"].HeaderText = "CEP";
            dgdados.Columns["Bairro"].HeaderText = "BAIRRO";
            dgdados.Columns["Flats"].Visible = false;

            dgdados.Columns["Numero"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgdados.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgdados.Columns["Numero"].HeaderText = "Nº";

            dgdados.Columns["Estado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgdados.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgdados.Columns["Estado"].HeaderText = "ESTADO";

        }       
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
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
        private string FormatInscricaoEstadual(string ie)
        {
            ie = new string(ie.Where(char.IsDigit).ToArray());

            if (ie.Length == 12)
            {
                return string.Format("{0:000\\.000\\.000\\.000}", double.Parse(ie));
            }

            return ie;
        }
        private string FormatCep(string cep)
        {
            cep = new string(cep.Where(char.IsDigit).ToArray());

            if (cep.Length == 8)
            {
                return string.Format("{0:00000\\-000}", double.Parse(cep));
            }

            return cep;
        }       
        //
        //Eventos
        private void FrmConsultaEmpresa_Resize(object sender, EventArgs e)
        {
            AjustarPosicaoPictureBox();
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
                    e.Value = FormatCnpj(cnpj);
                }
            }
            if (dgdados.Columns[e.ColumnIndex].Name == "InscricaoEstadual")
            {
                if (e.Value != null && e.Value is string ie)
                {
                    e.Value = FormatInscricaoEstadual(ie);
                }
            }
            if (dgdados.Columns[e.ColumnIndex].Name == "Cep")
            {
                if (e.Value != null && e.Value is string cep)
                {
                    e.Value = FormatCep(cep);
                }
            }
        }
        private void AjustarPosicaoPictureBox()
        {
            int margem = 10;

            // Posição do PictureBox1 (no canto superior direito)
            int x1 = this.ClientSize.Width - pbMaximizar.Width - margem;
            int y1 = margem;

            pbFechar.Location = new Point(x1, y1);

            // Posição do PictureBox2 (ao lado esquerdo de PictureBox1)
            int x2 = x1 - pbFechar.Width - margem;
            int y2 = margem;

            pbMaximizar.Location = new Point(x2, y2);
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
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
        
    }
}
