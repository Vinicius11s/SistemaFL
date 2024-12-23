using Infraestrutura.Repositorio;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFL.Funcionalidades
{
    public partial class FrmFuncRendimentoscs : Form
    {
        private IFlatRepositorio repositorio;
        private ILancamentoRepositorio LancamentoRepositorio;
        public FrmFuncRendimentoscs(IFlatRepositorio repositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.LancamentoRepositorio = lancamentoRepositorio;
        }

        private void FrmFuncRendimentoscs_Load(object sender, EventArgs e)
        {
            var dadosRendimentos = repositorio.ObterDadosRendimentos();
            dgdadosRendimentos.DataSource = dadosRendimentos;

            AjustarFormatacaoGrid(dgdadosRendimentos);

            var dadosTotais = repositorio.ObterDadosTotais();
            dgdadosTotais.DataSource = dadosTotais;

            AjustarFormatacaoGrid(dgdadosTotais);
        }

        private void AjustarFormatacaoGrid(DataGridView grid)
        {
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            foreach (var coluna in grid.Columns.Cast<DataGridViewColumn>())
            {
                if (coluna.Name.StartsWith("Porcentagem"))
                {
                    coluna.DefaultCellStyle.Format = "N2";
                    coluna.Width = 50;
                    coluna.HeaderText = "%";
                }
            }

            dgdadosRendimentos.Columns["RendimentoAnual"].HeaderText = "Rendimento Anual";
            dgdadosRendimentos.Columns["PorceAnual"].HeaderText = "Média(%) Anual";
            dgdadosRendimentos.Columns["PorceAnual"].DefaultCellStyle.Format = "N2";
            dgdadosRendimentos.Columns["PorceAnual"].Width = 150;
        }
    }
}
