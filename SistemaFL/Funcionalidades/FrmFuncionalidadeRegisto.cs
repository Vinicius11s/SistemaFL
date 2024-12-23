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

    }

}
