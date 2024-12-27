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
    public partial class FrmFuncFundoReserva : Form
    {
        private IFlatRepositorio flatRepositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        public FrmFuncFundoReserva(IFlatRepositorio flatRepositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.flatRepositorio = flatRepositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;
        }

        private void FrmFuncFundoReserva_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            AjustarPosicaoPictureBox();
            this.Resize += FrmFuncFundoReserva_Resize;

            var dados = flatRepositorio.ObterDadosFunReserva();
            dgdadosFunRes.DataSource = dados;
            AjustaGridDados(dgdadosFunRes);
            
            var totais = flatRepositorio.ObterDadosTotaisFundoReserva();
            dgtotais.DataSource = totais;
            AjustaGridTotais(dgtotais);
        }
        private void AjustaGridDados(DataGridView grid)
        {
            dgdadosFunRes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            foreach (DataGridViewColumn coluna in dgdadosFunRes.Columns)
            {
                if (coluna.Name == "idFlat")
                {
                    coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)
                }
            }

        }
        private void AjustaGridTotais(DataGridView grid)
        {
            dgdadosFunRes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            foreach (DataGridViewColumn coluna in dgtotais.Columns)
            {               
                coluna.DefaultCellStyle.Format = "C2";  // Formato de moeda (R$)               
            }

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
        private void FrmFuncFundoReserva_Resize(object sender, EventArgs e)
        {
            AjustarPosicaoPictureBox();
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
