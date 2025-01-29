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

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();

        }
        private void FrmConsultaFlat_Load_1(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);

            txtdescricao.Text = "Digite aqui a descrição do Flat";
            txtdescricao.ForeColor = Color.Gray;

            dgdadosFlats.DataSource = null;
            dgdadosFlats.Rows.Clear();
        }
        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            CarregarDadosDataGrid();
            //bilding Estilos.AlterarEstiloDataGrid(dgdadosFlats);
            AlterarNomesDoCabecalho(dgdadosFlats);

            dgdadosFlats.DataBindingComplete += dgdadosFlats_DataBindingComplete;

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
                    f.TipoInvestimento,
                    f.Status,
                    f.DataAquisicao,
                    f.TamanhoUnidadeM2,
                    f.Rua,
                    f.Unidade,
                    f.Bairro,
                    f.Estado,
                    f.Cidade,
                    f.NumMatriculaImovel,
                    f.ValorDeCompra,
                    PossuiGaragem = f.PossuiGaragem ? "Sim" : "Não",
                    Escriturado = f.Escriturado ? "Sim" : "Não",
                    Registrado = f.Registrado ? "Sim" : "Não",
                    f.valorComissao,
                    NotaComissao = f.NotaComissao ? "Sim" : "Não",
                    f.ValorITBI,
                    f.ValorEscritura,
                    f.ValorRegistro,
                    Laudêmio = f.Laudemio ? "Sim" : "Não",
                    f.ValorLaudemio,
                    f.ValorAforamento,
                    f.ValorTotalImovel,
                    Empresa = f.idEmpresa.HasValue
                          ? empresaRepositorio.BuscarPorId(f.idEmpresa.Value)?.Descricao
                          : "Não Associado" // Verificando se o idEmpresa é válido
                })
                .OrderBy(flat => flat.Descricao)
                .ToList();
            dgdadosFlats.DataSource = listaFlats;
        }
        private void AlterarNomesDoCabecalho(DataGridView grid)
        {
            grid.Columns["id"].Visible = false;

            grid.Columns["Descricao"].HeaderText = "DESCRIÇÃO";
            grid.Columns["TipoInvestimento"].HeaderText = "TIPO INVESTIMENTO";

            grid.Columns["DataAquisicao"].DefaultCellStyle.Format = "d";
            grid.Columns["DataAquisicao"].HeaderText = "DATA AQUISIÇÃO";

            grid.Columns["TamanhoUnidadeM2"].HeaderText = "TAMANHO M2";
            grid.Columns["NumMatriculaImovel"].HeaderText = "Nº MATRÍCULA";
            grid.Columns["ValorDeCompra"].HeaderText = "VALOR COMPRA";
            grid.Columns["PossuiGaragem"].HeaderText = "POSSUI GARAGEM";
            grid.Columns["valorComissao"].HeaderText = "VALOR COMISSÃO";
            grid.Columns["NotaComissao"].HeaderText = "NOTA COMISSÃO";
            grid.Columns["ValorITBI"].HeaderText = "VALOR ITBI";
            grid.Columns["ValorEscritura"].HeaderText = "VALOR ESCRITURA";
            grid.Columns["ValorLaudemio"].HeaderText = "VALOR LAUDÊMIO";
            grid.Columns["ValorRegistro"].HeaderText = "VALOR DE REGISTRO";
            grid.Columns["ValorAforamento"].HeaderText = "VALOR AFORAMENTO";
            grid.Columns["ValorTotalImovel"].HeaderText = "VALOR TOTAL IMÓVEL";

            grid.Columns["Unidade"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns["Estado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }
        private void dgdadosFlats_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Estilos.AlterarEstiloDataGrid(dgdadosFlats);

            foreach (DataGridViewRow row in dgdadosFlats.Rows)
            {
                AplicarFormatacaoLinha(row);
                dgdadosFlats.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
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
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela, 10);
        }
    }
} 
