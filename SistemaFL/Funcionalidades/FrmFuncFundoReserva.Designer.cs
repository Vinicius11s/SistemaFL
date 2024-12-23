namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncFundoReserva
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgdadosFunRes = new DataGridView();
            dgtotais = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgtotais).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFunRes
            // 
            dgdadosFunRes.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosFunRes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFunRes.Dock = DockStyle.Top;
            dgdadosFunRes.Location = new Point(0, 0);
            dgdadosFunRes.Margin = new Padding(3, 4, 3, 4);
            dgdadosFunRes.Name = "dgdadosFunRes";
            dgdadosFunRes.Size = new Size(798, 357);
            dgdadosFunRes.TabIndex = 0;
            // 
            // dgtotais
            // 
            dgtotais.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgtotais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtotais.Location = new Point(164, 355);
            dgtotais.Name = "dgtotais";
            dgtotais.Size = new Size(634, 74);
            dgtotais.TabIndex = 1;
            // 
            // FrmFuncFundoReserva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(798, 465);
            Controls.Add(dgtotais);
            Controls.Add(dgdadosFunRes);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncFundoReserva";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fundo de Reserva";
            Load += FrmFuncFundoReserva_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgtotais).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgdadosFunRes;
        private DataGridView dgtotais;
    }
}