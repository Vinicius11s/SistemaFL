namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncAluguel_Dividendos
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
            dgdadosALeDIV = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosALeDIV).BeginInit();
            SuspendLayout();
            // 
            // dgdadosALeDIV
            // 
            dgdadosALeDIV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosALeDIV.Dock = DockStyle.Bottom;
            dgdadosALeDIV.Location = new Point(0, 96);
            dgdadosALeDIV.Name = "dgdadosALeDIV";
            dgdadosALeDIV.Size = new Size(800, 354);
            dgdadosALeDIV.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(160, 20);
            label1.TabIndex = 1;
            label1.Text = "Aluguel + Dividendos";
            // 
            // FrmFuncAluguel_Dividendos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dgdadosALeDIV);
            Name = "FrmFuncAluguel_Dividendos";
            Text = "Aluguel + Dividendos";
            Load += FrmFuncAluguel_Dividendos_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosALeDIV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosALeDIV;
        private Label label1;
    }
}