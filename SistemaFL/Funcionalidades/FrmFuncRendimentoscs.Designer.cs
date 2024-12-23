namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncRendimentoscs
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
            dgdadosRendimentos = new DataGridView();
            dgdadosTotais = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgdadosRendimentos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgdadosTotais).BeginInit();
            SuspendLayout();
            // 
            // dgdadosRendimentos
            // 
            dgdadosRendimentos.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosRendimentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosRendimentos.Dock = DockStyle.Top;
            dgdadosRendimentos.Location = new Point(0, 0);
            dgdadosRendimentos.Margin = new Padding(4);
            dgdadosRendimentos.Name = "dgdadosRendimentos";
            dgdadosRendimentos.Size = new Size(1004, 392);
            dgdadosRendimentos.TabIndex = 0;
            // 
            // dgdadosTotais
            // 
            dgdadosTotais.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosTotais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosTotais.Dock = DockStyle.Bottom;
            dgdadosTotais.Location = new Point(0, 416);
            dgdadosTotais.Margin = new Padding(4);
            dgdadosTotais.Name = "dgdadosTotais";
            dgdadosTotais.Size = new Size(1004, 150);
            dgdadosTotais.TabIndex = 1;
            // 
            // FrmFuncRendimentoscs
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1004, 566);
            Controls.Add(dgdadosTotais);
            Controls.Add(dgdadosRendimentos);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "FrmFuncRendimentoscs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rendimentos";
            WindowState = FormWindowState.Maximized;
            Load += FrmFuncRendimentoscs_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosRendimentos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgdadosTotais).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgdadosRendimentos;
        private DataGridView dgdadosTotais;
        private Label label1;
    }
}