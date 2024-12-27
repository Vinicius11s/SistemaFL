using Infraestrutura.Repositorio;
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

namespace SistemaFL.Funcionalidades
{
    public partial class FrmFuncionalidadeRegisto : Form
    {
        private IEmpresaRepositorio repositorio;
        private IFlatRepositorio flatRepositorio;
        public FrmFuncionalidadeRegisto(IEmpresaRepositorio repositorio, IFlatRepositorio flatRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.flatRepositorio = flatRepositorio;
        }

        private void FrmFuncionalidadeRegisto_Load(object sender, EventArgs e)
        {
            AjustarPosicaoPictureBox();
            this.Resize += FrmFuncionalidadeRegisto_Resize;

            var dados = flatRepositorio.ObterDadosInvestimento();
            dgdadosFunRegistro.DataSource = dados;

            dgdadosFunRegistro.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


            var totalInvestimento = flatRepositorio.CalcularTotalValorInvestimento();
            txtTotalInvestimento.Text = totalInvestimento.ToString("C");

            dgdadosFunRegistro.CellFormatting += dgdadosFunRegistro_CellFormatting;

        }
        private void dgdadosFunRegistro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            // Verifica se estamos formatando a coluna CnpjRecebimento
            if (dgdadosFunRegistro.Columns[e.ColumnIndex].Name == "CnpjRecebimento")
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
        private void FrmFuncionalidadeRegisto_Resize(object sender, EventArgs e)
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
        private void pictureBox2_Click(object sender, EventArgs e)
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
