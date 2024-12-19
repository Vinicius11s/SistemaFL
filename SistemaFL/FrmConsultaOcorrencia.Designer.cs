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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaOcorrencia));
            label2 = new Label();
            dgdadosocorrencias = new DataGridView();
            fecharjanela = new PictureBox();
            minimizar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgdadosocorrencias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fecharjanela).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minimizar).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(276, 9);
            label2.Name = "label2";
            label2.Size = new Size(211, 37);
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
            // fecharjanela
            // 
            fecharjanela.Dock = DockStyle.Right;
            fecharjanela.Image = (Image)resources.GetObject("fecharjanela.Image");
            fecharjanela.Location = new Point(776, 0);
            fecharjanela.Name = "fecharjanela";
            fecharjanela.Size = new Size(24, 58);
            fecharjanela.SizeMode = PictureBoxSizeMode.CenterImage;
            fecharjanela.TabIndex = 17;
            fecharjanela.TabStop = false;
            fecharjanela.Click += fecharjanela_Click;
            // 
            // minimizar
            // 
            minimizar.Dock = DockStyle.Right;
            minimizar.Image = (Image)resources.GetObject("minimizar.Image");
            minimizar.Location = new Point(752, 0);
            minimizar.Name = "minimizar";
            minimizar.Size = new Size(24, 58);
            minimizar.SizeMode = PictureBoxSizeMode.CenterImage;
            minimizar.TabIndex = 18;
            minimizar.TabStop = false;
            minimizar.Click += minimizar_Click;
            // 
            // FrmConsultaOcorrencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(minimizar);
            Controls.Add(fecharjanela);
            Controls.Add(label2);
            Controls.Add(dgdadosocorrencias);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmConsultaOcorrencia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmConsultaOcorrencia";
            Load += FrmConsultaOcorrencia_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosocorrencias).EndInit();
            ((System.ComponentModel.ISupportInitialize)fecharjanela).EndInit();
            ((System.ComponentModel.ISupportInitialize)minimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private DataGridView dgdadosocorrencias;
        private PictureBox fecharjanela;
        private PictureBox minimizar;
    }
}