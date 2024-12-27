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
            dgdadosRendimentos = new DataGridView();
            dgdadosTotais = new DataGridView();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosRendimentos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgdadosTotais).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgdadosRendimentos
            // 
            dgdadosRendimentos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosRendimentos.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosRendimentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosRendimentos.Location = new Point(0, 73);
            dgdadosRendimentos.Margin = new Padding(4);
            dgdadosRendimentos.Name = "dgdadosRendimentos";
            dgdadosRendimentos.Size = new Size(1004, 384);
            dgdadosRendimentos.TabIndex = 0;
            // 
            // dgdadosTotais
            // 
            dgdadosTotais.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosTotais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosTotais.Dock = DockStyle.Bottom;
            dgdadosTotais.Location = new Point(0, 488);
            dgdadosTotais.Margin = new Padding(4);
            dgdadosTotais.Name = "dgdadosTotais";
            dgdadosTotais.Size = new Size(1004, 78);
            dgdadosTotais.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(862, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(27, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(829, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 9);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 16;
            label2.Text = "Rendimentos";
            // 
            // FrmFuncRendimentoscs
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1004, 566);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(dgdadosTotais);
            Controls.Add(dgdadosRendimentos);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "FrmFuncRendimentoscs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rendimentos";
            Load += FrmFuncRendimentoscs_Load;
            Resize += FrmFuncRendimentoscs_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadosRendimentos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgdadosTotais).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosRendimentos;
        private DataGridView dgdadosTotais;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label2;
    }
}