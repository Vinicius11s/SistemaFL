using Infraestrutura.Contexto;
using Interfaces;
using System;
using System.Collections;
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
    public partial class FrmConsultaEmpresa : Form
    {
        private IEmpresaRepositorio repositorio;
        public int id;
        public FrmConsultaEmpresa(IEmpresaRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }
        private void FrmConsultaEmpresa_Load(object sender, EventArgs e)
        {
            dgdados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //No clique do botão localizar
            var lista = repositorio.Listar(e => e.Descricao.Contains(txtdescricao.Text))
                        .OrderBy(e => e.Descricao) // Ordena alfabeticamente pela Descricao
                        .ToList(); // Converte para lista

            dgdados.DataSource = lista;


            AlterarFormatacaoGrid(dgdados);
            AlterarCorFundoETextoCabecalho();      

        }
        private void AlterarFormatacaoGrid(DataGridView grid)
        {        
            dgdados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgdados.Columns["id"].HeaderText = "CÓD";
            dgdados.Columns["Cnpj"].HeaderText = "CNPJ";
            dgdados.Columns["descricao"].HeaderText = "DESCRIÇÃO";
            dgdados.Columns["RazaoSocial"].HeaderText = "RAZÃO SOCIAL";
            dgdados.Columns["InscricaoEstadual"].HeaderText = "INSC. ESTADUAL";
            dgdados.Columns["Numero"].HeaderText = "Nº";
            dgdados.Columns["Cidade"].HeaderText = "CIDADE";
            dgdados.Columns["Bairro"].HeaderText = "BAIRRO";
            dgdados.Columns["Flats"].Visible = false;
            
        }
        private void AlterarCorFundoETextoCabecalho()
        {
            foreach (DataGridViewColumn col in dgdados.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);  // Espaçamento interno
            }
            // Desativa o estilo visual para permitir personalização
            dgdados.EnableHeadersVisualStyles = false;
            dgdados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            dgdados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgdados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            foreach (DataGridViewRow row in dgdados.Rows)
            {
                AplicarFormatacaoLinha(row);
            }


        }
        private void AplicarFormatacaoLinha(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;
        }
        private void dgdados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = (int)dgdados.Rows[e.RowIndex].Cells[0].Value; // Armazena o ID
                this.Close(); // Fecha o formulário
            }
        }      
        private void dgdados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgdados.Columns[e.ColumnIndex].Name == "Cnpj")
            {
                // Verifica se a célula contém um valor válido
                if (e.Value != null && e.Value is string cnpj)
                {
                    // Aplica a máscara de CNPJ ao valor
                    e.Value = FormatCnpj(cnpj);
                }
            }
            if (dgdados.Columns[e.ColumnIndex].Name == "InscricaoEstadual")
            {
                if (e.Value != null && e.Value is string ie)
                {
                    e.Value = FormatInscricaoEstadual(ie);
                }
            }
            if (dgdados.Columns[e.ColumnIndex].Name == "Cep")
            {
                if (e.Value != null && e.Value is string cep)
                {
                    e.Value = FormatCep(cep);
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
        private string FormatInscricaoEstadual(string ie)
        {
            ie = new string(ie.Where(char.IsDigit).ToArray());

            if (ie.Length == 12)
            {
                return string.Format("{0:000\\.000\\.000\\.000}", double.Parse(ie));
            }

            return ie; 
        }
        private string FormatCep(string cep)
        {
            cep = new string(cep.Where(char.IsDigit).ToArray());

            if (cep.Length == 8)
            {
                return string.Format("{0:00000\\-000}", double.Parse(cep));
            }

            return cep; 
        }

    }
}
