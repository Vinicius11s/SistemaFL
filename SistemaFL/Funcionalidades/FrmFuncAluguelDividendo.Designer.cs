namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncAluguelDividendo
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
            dgdadosAlugDiv = new DataGridView();
            dgtotaisindividual = new DataGridView();
            dgtotalmes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgdadosAlugDiv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgtotaisindividual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgtotalmes).BeginInit();
            SuspendLayout();
            // 
            // dgdadosAlugDiv
            // 
            dgdadosAlugDiv.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosAlugDiv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosAlugDiv.Dock = DockStyle.Top;
            dgdadosAlugDiv.Location = new Point(0, 0);
            dgdadosAlugDiv.Margin = new Padding(3, 4, 3, 4);
            dgdadosAlugDiv.Name = "dgdadosAlugDiv";
            dgdadosAlugDiv.Size = new Size(914, 396);
            dgdadosAlugDiv.TabIndex = 0;
            // 
            // dgtotaisindividual
            // 
            dgtotaisindividual.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgtotaisindividual.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtotaisindividual.Location = new Point(0, 434);
            dgtotaisindividual.Name = "dgtotaisindividual";
            dgtotaisindividual.Size = new Size(914, 71);
            dgtotaisindividual.TabIndex = 1;
            // 
            // dgtotalmes
            // 
            dgtotalmes.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgtotalmes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtotalmes.Dock = DockStyle.Bottom;
            dgtotalmes.Location = new Point(0, 538);
            dgtotalmes.Name = "dgtotalmes";
            dgtotalmes.Size = new Size(914, 62);
            dgtotalmes.TabIndex = 2;
            // 
            // FrmFuncAluguelDividendo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(914, 600);
            Controls.Add(dgtotalmes);
            Controls.Add(dgtotaisindividual);
            Controls.Add(dgdadosAlugDiv);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncAluguelDividendo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aluguel + Dividendos";
            Load += FrmFuncAluguelDividendo_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosAlugDiv).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgtotaisindividual).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgtotalmes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgdadosAlugDiv;
        private DataGridView dgtotaisindividual;
        private DataGridView dgtotalmes;
    }
}