using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFL
{
    public static class Estilos
    {
        //Estilos e Formatações
        public static void AlterarEstiloDataGrid(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Regular);

            foreach (DataGridViewColumn coluna in grid.Columns)
            {
                coluna.HeaderText = coluna.HeaderText.ToUpper();
                grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }

            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 40;  // Ajuste o valor conforme necessário

            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);  // Espaçamento interno
            }
        }
        public static void AplicarFormatacaoLinha(DataGridViewRow row)
        {        
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;          
        }

        public static void ReAjustarTamanhoFormulario(Form form, System.Windows.Forms.Timer timer, int incremento)
        {
            var screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            var screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            // Expande o formulário gradualmente
            if (form.Width < screenWidth)
                form.Width += incremento;

            if (form.Height < screenHeight)
                form.Height += incremento;

            // Para o timer quando o formulário atingir o tamanho da tela
            if (form.Width >= screenWidth && form.Height >= screenHeight)
            {
                timer.Stop();
            }
        }
        public static void AjustarPosicaopbMaximizarFechar(Form form, PictureBox pbMaximizar, PictureBox pbFechar)
        {
            int margem = 10;

            // Posição do PictureBox1 (no canto superior direito)
            int x1 = form.ClientSize.Width - pbMaximizar.Width - margem;
            int y1 = margem;

            pbFechar.Location = new Point(x1, y1);

            // Posição do pbFechar (ao lado esquerdo de PictureBox1)
            int x2 = x1 - pbFechar.Width - margem;
            int y2 = margem;

            pbMaximizar.Location = new Point(x2, y2);
        }

        public static string FormatCnpj(string cnpj)
        {
            // Remove quaisquer caracteres não numéricos
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            if (cnpj.Length == 14)
            {
                return string.Format("{0:00\\.000\\.000\\/0000\\-00}", double.Parse(cnpj));
            }

            return cnpj; 
        }
        public static string FormatInscricaoEstadual(string ie)
        {
            ie = new string(ie.Where(char.IsDigit).ToArray());

            if (ie.Length == 12)
            {
                return string.Format("{0:000\\.000\\.000\\.000}", double.Parse(ie));
            }

            return ie;
        }
        public static string FormatCep(string cep)
        {
            cep = new string(cep.Where(char.IsDigit).ToArray());

            if (cep.Length == 8)
            {
                return string.Format("{0:00000\\-000}", double.Parse(cep));
            }

            return cep;
        }

        //
        public static void LimparTextBoxes(Panel painel)
        {
            // Percorre todos os controles dentro do painel
            foreach (Control controle in painel.Controls)
            {
                // Verifica se o controle é um TextBox
                if (controle is TextBox)
                {
                    // Limpa o conteúdo do TextBox
                    ((TextBox)controle).Clear();
                }
            }
        }

    }
}