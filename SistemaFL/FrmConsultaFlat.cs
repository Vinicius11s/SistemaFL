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
        public int id;
        public FrmConsultaFlat(IFlatRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //No clique do botão localizar, vamos fazer um select            
            var lista = repositorio.Listar(e => e.Descricao.Contains(txtdescricao.Text));


            dgdadosFlats.DataSource = lista;

            if (lista.Count > 0)
            {
                dgdadosFlats.Columns["id"].HeaderText = "Código";
                dgdadosFlats.Columns["descricao"].HeaderText = "Descrição";
                dgdadosFlats.Columns["DataAquisicao"].HeaderText = "Data Aquisição";
                dgdadosFlats.Columns["TipoInvestimento"].HeaderText = "Tipo Investimento";

                //configuração para mostrar coluna em reais
                dgdadosFlats.Columns["ValorAluguel"].DefaultCellStyle.Format = "C2";
                dgdadosFlats.Columns["ValorAluguel"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("pt-BR");

                dgdadosFlats.Columns["Empresa"].HeaderText = "Descrição";

                dgdadosFlats.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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

        private void FrmConsultaFlat_Load(object sender, EventArgs e)
        {
            txtdescricao.Text = "Digite aqui o número do mês";
            txtdescricao.ForeColor = Color.Gray;
        }
    }
} 
