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
            var dados = flatRepositorio.ObterDadosFunReserva();
            dgdadosFunRes.DataSource = dados;

            dgdadosFunRes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            cbbMesFunRes.Items.Clear();
            cbbMesFunRes.Items.AddRange(new string[]{
                "Janeiro",
                "Fevereiro",
                "Março",
                "Abril",
                "Maio",
                "Junho",
                "Julho",
                "Agosto",
                "Setembro",
                "Outubro",
                "Novembro",
                "Dezembro",
                "Todos"
            });

        }

        private void btncalcular_Click(object sender, EventArgs e)
        {
            if (cbbMesFunRes.SelectedIndex > 0)
            {
                decimal SomaFundos = 0;

                if (cbbMesFunRes.SelectedIndex < 12)
                {
                    int mesEscolhido = cbbMesFunRes.SelectedIndex + 1;
                    var lancamentos = lancamentoRepositorio.Listar(r => r.DataPagamento.Month == mesEscolhido);

                    SomaFundos = lancamentos.Sum(r => r.ValorFundoReserva ?? 0);
                }
                else if (cbbMesFunRes.SelectedIndex == 12)
                {
                    var lancamentoTodos = lancamentoRepositorio.Listar(r => true);
                    SomaFundos = lancamentoTodos.Sum(l => l.ValorFundoReserva ?? 0);
                }
                txttotalFunRes.Text = SomaFundos.ToString();
            }
            else txttotalFunRes.Text = String.Empty;
        }
    }
}
