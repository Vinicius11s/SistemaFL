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
                          : "Não Associado" // Verificando se o idEmpresa é válido
            })
                .OrderBy(flat => flat.Descricao)
                .ToList();

            dgdadosFlats.DataSource = listaFlats;
            AlterarFormatacaoGrid(dgdadosFlats);
            AlterarCorFundoETextoCabecalho();

       
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
        private void AlterarFormatacaoGrid(DataGridView grid)
        {
            
            dgdadosFlats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgdadosFlats.Columns["id"].HeaderText = "CÓD";
            dgdadosFlats.Columns["Descricao"].HeaderText = "DESCRIÇÃO";

            dgdadosFlats.Columns["DataAquisicao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgdadosFlats.Columns["DataAquisicao"].HeaderText = "DATA AQUISIÇÃO";
            dgdadosFlats.Columns["DataAquisicao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgdadosFlats.Columns["DataAquisicao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgdadosFlats.Columns["TipoInvestimento"].HeaderText = "TIPO INVESTIMENTO";
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

            foreach (DataGridViewRow row in dgdadosFlats.Rows)
            {
                AplicarFormatacaoLinha(row);
            }
            dgdadosFlats.RowTemplate.Height = 35;

            foreach (DataGridViewRow row in dgdadosFlats.Rows)
            {
                row.Height = 35;
            }

            dgdadosFlats.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            
        }
        private void AlterarCorFundoETextoCabecalho()
        {
            foreach (DataGridViewColumn col in dgdadosFlats.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);  // Espaçamento interno
            }
            // Desativa o estilo visual para permitir personalização
            dgdadosFlats.EnableHeadersVisualStyles = false;
            dgdadosFlats.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdadosFlats.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdadosFlats.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);



        }
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
        }
    }
} 
