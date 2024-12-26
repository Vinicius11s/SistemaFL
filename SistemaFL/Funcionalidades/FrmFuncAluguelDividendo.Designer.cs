namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncAluguelDividendo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncAluguelDividendo));
            dgdadosAlugDiv = new DataGridView();
            dgtotaisindividual = new DataGridView();
            dgtotalmes = new DataGridView();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgdadosAlugDiv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgtotaisindividual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgtotalmes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgdadosAlugDiv
            // 
            dgdadosAlugDiv.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosAlugDiv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosAlugDiv.Dock = DockStyle.Top;
            dgdadosAlugDiv.Location = new Point(0, 0);
            dgdadosAlugDiv.Margin = new Padding(3, 4, 3, 4);
            dgdadosAlugDiv.Name = "dgdadosAlugDiv";
            dgdadosAlugDiv.Size = new Size(827, 333);
            dgdadosAlugDiv.TabIndex = 0;
            // 
            // dgtotaisindividual
            // 
            dgtotaisindividual.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgtotaisindividual.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtotaisindividual.Dock = DockStyle.Bottom;
            dgtotaisindividual.Location = new Point(0, 410);
            dgtotaisindividual.Name = "dgtotaisindividual";
            dgtotaisindividual.Size = new Size(827, 78);
            dgtotaisindividual.TabIndex = 1;
            // 
            // dgtotalmes
            // 
            dgtotalmes.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgtotalmes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtotalmes.Dock = DockStyle.Bottom;
            dgtotalmes.Location = new Point(0, 333);
            dgtotalmes.Name = "dgtotalmes";
            dgtotalmes.Size = new Size(827, 77);
            dgtotalmes.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(774, 6);
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
            pictureBox1.Location = new Point(741, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // FrmFuncAluguelDividendo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(827, 488);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(dgtotalmes);
            Controls.Add(dgtotaisindividual);
            Controls.Add(dgdadosAlugDiv);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncAluguelDividendo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aluguel + Dividendos";
            Load += FrmFuncAluguelDividendo_Load;
            Resize += FrmFuncAluguelDividendo_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadosAlugDiv).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgtotaisindividual).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgtotalmes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgdadosAlugDiv;
        private DataGridView dgtotaisindividual;
        private DataGridView dgtotalmes;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}