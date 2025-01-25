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
            pbFechar = new PictureBox();
            pbMinimizar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgdadosocorrencias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(322, 13);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(212, 30);
            label2.TabIndex = 16;
            label2.Text = "Últimos Lançamentos";
            // 
            // dgdadosocorrencias
            // 
            dgdadosocorrencias.BackgroundColor = Color.White;
            dgdadosocorrencias.BorderStyle = BorderStyle.None;
            dgdadosocorrencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosocorrencias.Dock = DockStyle.Bottom;
            dgdadosocorrencias.Location = new Point(0, 58);
            dgdadosocorrencias.Margin = new Padding(4);
            dgdadosocorrencias.Name = "dgdadosocorrencias";
            dgdadosocorrencias.Size = new Size(839, 392);
            dgdadosocorrencias.TabIndex = 12;
            // 
            // pbFechar
            // 
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(797, 12);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(30, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 17;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // pbMinimizar
            // 
            pbMinimizar.Image = (Image)resources.GetObject("pbMinimizar.Image");
            pbMinimizar.Location = new Point(761, 13);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(30, 21);
            pbMinimizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMinimizar.TabIndex = 18;
            pbMinimizar.TabStop = false;
            pbMinimizar.Click += pbMinimizar_Click;
            // 
            // FrmConsultaOcorrencia
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(839, 450);
            Controls.Add(pbMinimizar);
            Controls.Add(pbFechar);
            Controls.Add(label2);
            Controls.Add(dgdadosocorrencias);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FrmConsultaOcorrencia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Últimos Lançamentos";
            Load += FrmConsultaOcorrencia_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosocorrencias).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private DataGridView dgdadosocorrencias;
        private PictureBox pbFechar;
        private PictureBox pbMinimizar;
    }
}