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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncionalidadeRegisto));
            dgdadosFunRegistro = new DataGridView();
            txtTotalInvestimento = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRegistro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFunRegistro
            // 
            dgdadosFunRegistro.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosFunRegistro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFunRegistro.Dock = DockStyle.Bottom;
            dgdadosFunRegistro.GridColor = Color.FromArgb(23, 24, 29);
            dgdadosFunRegistro.Location = new Point(0, 121);
            dgdadosFunRegistro.Name = "dgdadosFunRegistro";
            dgdadosFunRegistro.Size = new Size(1020, 484);
            dgdadosFunRegistro.TabIndex = 0;
            dgdadosFunRegistro.CellFormatting += dgdadosFunRegistro_CellFormatting;
            // 
            // txtTotalInvestimento
            // 
            txtTotalInvestimento.Location = new Point(469, 60);
            txtTotalInvestimento.Margin = new Padding(3, 5, 3, 5);
            txtTotalInvestimento.Name = "txtTotalInvestimento";
            txtTotalInvestimento.ReadOnly = true;
            txtTotalInvestimento.Size = new Size(137, 25);
            txtTotalInvestimento.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(332, 61);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 6;
            label1.Text = "Total Investimento";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(746, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(779, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(27, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 9);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 15;
            label2.Text = "Registros";
            // 
            // FrmFuncionalidadeRegisto
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1020, 605);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(txtTotalInvestimento);
            Controls.Add(label1);
            Controls.Add(dgdadosFunRegistro);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmFuncionalidadeRegisto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registros";
            Load += FrmFuncionalidadeRegisto_Load;
            Resize += FrmFuncionalidadeRegisto_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRegistro).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosFunRegistro;
        private TextBox txtTotalInvestimento;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label2;
    }
}