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
        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            CarregarDadosDataGrid();

            Estilos.AlterarEstilosCabecalho(dgdadosFlats);      
            
            foreach (DataGridViewRow row in dgdadosFlats.Rows)
            {
                AplicarFormatacaoLinha(row);
                dgdadosFlats.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }
        private void CarregarDadosDataGrid()
        {
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
        //
        //Eventos
        private void dgdadosFlats_CellDoubleClic(object sender, DataGridViewCellEventArgs e)
        {
            dgdadosFlats.Focus();

            if (e.RowIndex >= 0)
            {
                id = (int)dgdadosFlats.Rows[e.RowIndex].Cells[0].Value; // Armazena o ID
                this.Close(); // Fecha o formulário
            };
        }
        private void FrmConsultaFlat_Resize(object sender, EventArgs e)
        {
            Estilos.AjustarPosicaopbMaximizarFechar(this, pbMaximizar, pbFechar );
        }
        private void pbFechar_Click_1(object sender, EventArgs e)
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
