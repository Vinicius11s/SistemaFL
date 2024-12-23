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

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtdescricao.Text == "Digite aqui a descrição do Flat")
            {
                txtdescricao.Text = "";
            }

            var listaFlats = repositorio.Listar(f => f.Descricao.Contains(txtdescricao.Text)).Select(f => new
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
                          : "Não Associada" // Verificando se o idEmpresa é válido
            }).ToList();

            dgdadosFlats.DataSource = listaFlats;

            if (listaFlats.Count > 0)
            {
                dgdadosFlats.Columns["id"].HeaderText = "Código";
                dgdadosFlats.Columns["Descricao"].HeaderText = "Descrição";
                dgdadosFlats.Columns["DataAquisicao"].HeaderText = "Data Aquisição";
                dgdadosFlats.Columns["TipoInvestimento"].HeaderText = "Tipo Investimento";
                dgdadosFlats.Columns["Empresa"].HeaderText = "Empresa";  // Nome da empresa
                dgdadosFlats.Columns["ValorInvestimento"].HeaderText = "Valor Investimento";

                // Configuração para mostrar coluna em reais
                dgdadosFlats.Columns["ValorInvestimento"].DefaultCellStyle.Format = "C2";
                dgdadosFlats.Columns["ValorInvestimento"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("pt-BR");

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
        private void FrmConsultaFlat_Load_1(object sender, EventArgs e)
        {
            txtdescricao.Text = "Digite aqui a descrição do Flat";
            txtdescricao.ForeColor = Color.Gray;
        }
    }
} 
