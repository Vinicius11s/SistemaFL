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
            dgdadosRendimentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosRendimentos.Location = new Point(2, 48);
            dgdadosRendimentos.Name = "dgdadosRendimentos";
            dgdadosRendimentos.Size = new Size(796, 230);
            dgdadosRendimentos.TabIndex = 0;
            // 
            // dgdadosTotais
            // 
            dgdadosTotais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosTotais.Location = new Point(311, 306);
            dgdadosTotais.Name = "dgdadosTotais";
            dgdadosTotais.Size = new Size(487, 75);
            dgdadosTotais.TabIndex = 1;
            // 
            // FrmFuncRendimentoscs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgdadosTotais);
            Controls.Add(dgdadosRendimentos);
            Name = "FrmFuncRendimentoscs";
            Text = "FrmFuncRendimentoscs";
            Load += FrmFuncRendimentoscs_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosRendimentos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgdadosTotais).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgdadosRendimentos;
        private DataGridView dgdadosTotais;
    }
}