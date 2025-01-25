using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFL
{
    public static class Estilos
    {
        public static void AlterarEstilosCabecalho(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 24, 29);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Regular);
        }
        public static void AplicarFormatacaoLinha(DataGridViewRow row)
        {        
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.White : Color.Gainsboro;          
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
    }
}