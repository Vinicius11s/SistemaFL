namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncionalidadeRegisto
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
            dgdadosFunRegistro = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRegistro).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFunRegistro
            // 
            dgdadosFunRegistro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFunRegistro.Dock = DockStyle.Bottom;
            dgdadosFunRegistro.Location = new Point(0, 107);
            dgdadosFunRegistro.Name = "dgdadosFunRegistro";
            dgdadosFunRegistro.Size = new Size(800, 343);
            dgdadosFunRegistro.TabIndex = 0;
            // 
            // FrmFuncionalidadeRegisto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgdadosFunRegistro);
            Name = "FrmFuncionalidadeRegisto";
            Text = "FrmFuncionalidadeRegisto";
            Load += FrmFuncionalidadeRegisto_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRegistro).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgdadosFunRegistro;
    }
}