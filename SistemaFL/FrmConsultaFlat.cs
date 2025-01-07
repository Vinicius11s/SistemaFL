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
    public partial class FrmConsultaFlat : Form
    {
        private IFlatRepositorio repositorio;
        private IEmpresaRepositorio empresaRepositorio;
        public int id;
        public FrmConsultaFlat(IFlatRepositorio repositorio, IEmpresaRepositorio empresaRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.empresaRepositorio = empresaRepositorio;
        }
        private void FrmConsultaFlat_Load_1(object sender, EventArgs e)
        {
            txtdescricao.Text = "Digite aqui a descrição do Flat";
            txtdescricao.ForeColor = Color.Gray;

            dgdadosFlats.DataSource = null;
            dgdadosFlats.Rows.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AlterarCorFundoETextoCabecalho();

            if (txtdescricao.Text == "Digite aqui a descrição do Flat")
            {
                txtdescricao.Text = "";
            }

            var listaFlats = repositorio.Listar(f => f.Descricao.Contains(txtdescricao.Text))
                .Select(f => new
                {
                    f.id,
                    f.Descricao,
                    f.DataAquisicao,
                    f.Status,
                    f.TipoInvestimento,
                    f.ValorInvestimento,
                    f.Rua,
                    f.Unidade,
                    f.Bairro,
                    f.Cidade,
                    f.Estado,
                    Empresa = f.idEmpresa.HasValue
                          ? empresaRepositorio.BuscarPorId(f.idEmpresa.Value)?.Descricao
                          : "Não Associado" // Verificando se o idEmpresa é válido
                })
                .OrderBy(flat => flat.Descricao)
                .ToList();
            dgdadosFlats.DataSource = listaFlats;


            AjustarNomesCabecalho(dgdadosFlats);

            foreach (DataGridViewRow row in dgdadosFlats.Rows)
            {
                AplicarFormatacaoLinha(row);
            }

        }
        private void dgdadosFlats_CellDoubleClic(object sender, DataGridViewCellEventArgs e)
        {
            dgdadosFlats.Focus();

            if (e.RowIndex >= 0)
            {
                id = (int)dgdadosFlats.Rows[e.RowIndex].Cells[0].Value; // Armazena o ID
                this.Close(); // Fecha o formulário
            };
        }
        private void AjustarNomesCabecalho(DataGridView grid)
        {

            dgdadosFlats.Columns["id"].HeaderText = "CÓD";
            dgdadosFlats.Columns["Descricao"].HeaderText = "DESCRIÇÃO";

            dgdadosFlats.Columns["DataAquisicao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgdadosFlats.Columns["DataAquisicao"].HeaderText = "DATA AQUISIÇÃO";
            dgdadosFlats.Columns["DataAquisicao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgdadosFlats.Columns["DataAquisicao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgdadosFlats.Columns["TipoInvestimento"].HeaderText = "TIPO INVESTIMENTO";
            dgdadosFlats.Columns["Status"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgdadosFlats.Columns["Status"].HeaderText = "STATUS";
            dgdadosFlats.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgdadosFlats.Columns["Empresa"].HeaderText = "EMPRESA";
            dgdadosFlats.Columns["Rua"].HeaderText = "RUA";
            dgdadosFlats.Columns["Unidade"].HeaderText = "UN";
            dgdadosFlats.Columns["Unidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgdadosFlats.Columns["Cidade"].HeaderText = "CIDADE";
            dgdadosFlats.Columns["Estado"].HeaderText = "ESTADO";
            dgdadosFlats.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgdadosFlats.Columns["Bairro"].HeaderText = "BAIRRO";

            dgdadosFlats.Columns["ValorInvestimento"].HeaderText = "VALOR INVESTIMENTO";
            dgdadosFlats.Columns["ValorInvestimento"].DefaultCellStyle.Format = "C2";
            dgdadosFlats.Columns["ValorInvestimento"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("pt-BR");
        }
        private void AlterarCorFundoETextoCabecalho()
        {
            dgdadosFlats.EnableHeadersVisualStyles = false;
            dgdadosFlats.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadosFlats.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadosFlats.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgdadosFlats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {
            var statusValue = row.Cells["Status"].Value?.ToString();

            if (statusValue == "Em Construção" || statusValue == "Em Reforma")
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

            if (statusValue == "Vendido")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(171, 201, 251);
            }
            else
            {
                row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
            }
        }

        //BOTOES FECHAR E MAXIMIZAR
        private void FrmConsultaFlat_Resize(object sender, EventArgs e)
        {
            AjustarPosicaoPictureBox();
        }
        private void AjustarPosicaoPictureBox()
        {
            int margem = 10;

            // Posição do PictureBox1 (no canto superior direito)
            int x1 = this.ClientSize.Width - pictureBox1.Width - margem;
            int y1 = margem;

            pictureBox2.Location = new Point(x1, y1);

            // Posição do PictureBox2 (ao lado esquerdo de PictureBox1)
            int x2 = x1 - pictureBox2.Width - margem;
            int y2 = margem;

            pictureBox1.Location = new Point(x2, y2);
        }
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
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
