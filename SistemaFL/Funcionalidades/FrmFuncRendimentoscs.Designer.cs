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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncRendimentoscs));
            dgdadosTotais = new DataGridView();
            pbFechar = new PictureBox();
            pbMaximizar = new PictureBox();
            label2 = new Label();
            dgdadosRendimentos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgdadosTotais).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgdadosRendimentos).BeginInit();
            SuspendLayout();
            // 
            // dgdadosTotais
            // 
            dgdadosTotais.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosTotais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosTotais.Dock = DockStyle.Bottom;
            dgdadosTotais.Location = new Point(0, 344);
            dgdadosTotais.Margin = new Padding(4);
            dgdadosTotais.Name = "dgdadosTotais";
            dgdadosTotais.Size = new Size(900, 77);
            dgdadosTotais.TabIndex = 1;
            // 
            // pbFechar
            // 
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(862, 12);
            pbFechar.Margin = new Padding(4, 3, 4, 3);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(27, 20);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 11;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // pbMaximizar
            // 
            pbMaximizar.Image = (Image)resources.GetObject("pbMaximizar.Image");
            pbMaximizar.Location = new Point(829, 12);
            pbMaximizar.Margin = new Padding(4, 3, 4, 3);
            pbMaximizar.Name = "pbMaximizar";
            pbMaximizar.Size = new Size(27, 20);
            pbMaximizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMaximizar.TabIndex = 10;
            pbMaximizar.TabStop = false;
            pbMaximizar.Click += pbMaximizar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 9);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 16;
            label2.Text = "Rendimentos";
            // 
            // dgdadosRendimentos
            // 
            dgdadosRendimentos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosRendimentos.BackgroundColor = Color.White;
            dgdadosRendimentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosRendimentos.Location = new Point(0, 38);
            dgdadosRendimentos.Name = "dgdadosRendimentos";
            dgdadosRendimentos.Size = new Size(900, 277);
            dgdadosRendimentos.TabIndex = 17;
            dgdadosRendimentos.CellPainting += dgdadosRendimentos_CellPainting;
            dgdadosRendimentos.DataBindingComplete += dgdadosRendimentos_DataBindingComplete;
            // 
            // FrmFuncRendimentoscs
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 421);
            Controls.Add(dgdadosRendimentos);
            Controls.Add(label2);
            Controls.Add(pbFechar);
            Controls.Add(pbMaximizar);
            Controls.Add(dgdadosTotais);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FrmFuncRendimentoscs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rendimentos";
            Load += FrmFuncRendimentoscs_Load;
            Resize += FrmFuncRendimentoscs_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadosTotais).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgdadosRendimentos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgdadosTotais;
        private PictureBox pbFechar;
        private PictureBox pbMaximizar;
        private Label label2;
        private DataGridView dgdadosRendimentos;
    }
}