namespace SistemaFL
{
    partial class FrmConsultaOcorrencia
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
            label2 = new Label();
            dgdadosocorrencias = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgdadosocorrencias).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(305, 21);
            label2.Name = "label2";
            label2.Size = new Size(160, 25);
            label2.TabIndex = 16;
            label2.Text = "Registros de Log";
            // 
            // dgdadosocorrencias
            // 
            dgdadosocorrencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosocorrencias.Dock = DockStyle.Bottom;
            dgdadosocorrencias.Location = new Point(0, 58);
            dgdadosocorrencias.Name = "dgdadosocorrencias";
            dgdadosocorrencias.Size = new Size(800, 392);
            dgdadosocorrencias.TabIndex = 12;
            // 
            // FrmConsultaOcorrencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(dgdadosocorrencias);
            Name = "FrmConsultaOcorrencia";
            Text = "FrmConsultaOcorrencia";
            Load += FrmConsultaOcorrencia_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosocorrencias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private DataGridView dgdadosocorrencias;
    }
}