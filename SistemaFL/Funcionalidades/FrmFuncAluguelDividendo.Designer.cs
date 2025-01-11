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
            dgtotalmes = new DataGridView();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosAlugDiv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgtotalmes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgdadosAlugDiv
            // 
            dgdadosAlugDiv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosAlugDiv.BackgroundColor = Color.White;
            dgdadosAlugDiv.BorderStyle = BorderStyle.None;
            dgdadosAlugDiv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosAlugDiv.Location = new Point(0, 40);
            dgdadosAlugDiv.Margin = new Padding(3, 10, 3, 4);
            dgdadosAlugDiv.Name = "dgdadosAlugDiv";
            dgdadosAlugDiv.ReadOnly = true;
            dgdadosAlugDiv.Size = new Size(900, 316);
            dgdadosAlugDiv.TabIndex = 0;
            dgdadosAlugDiv.ColumnHeaderMouseClick += dgdadosAlugDiv_ColumnHeaderMouseClick;
            dgdadosAlugDiv.DataBindingComplete += dgdadosAlugDiv_DataBindingComplete;
            // 
            // dgtotalmes
            // 
            dgtotalmes.BackgroundColor = Color.White;
            dgtotalmes.BorderStyle = BorderStyle.None;
            dgtotalmes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtotalmes.Dock = DockStyle.Bottom;
            dgtotalmes.Location = new Point(0, 352);
            dgtotalmes.Name = "dgtotalmes";
            dgtotalmes.ReadOnly = true;
            dgtotalmes.Size = new Size(900, 69);
            dgtotalmes.TabIndex = 1;
            dgtotalmes.DataBindingComplete += dgtotalmes_DataBindingComplete;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(871, 6);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 21);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(834, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 21);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(167, 21);
            label1.TabIndex = 15;
            label1.Text = "Aluguel + Dividendos";
            // 
            // FrmFuncAluguelDividendo
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 421);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(dgtotalmes);
            Controls.Add(dgdadosAlugDiv);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncAluguelDividendo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aluguel + Dividendos";
            Load += FrmFuncAluguelDividendo_Load;
            Resize += FrmFuncAluguelDividendo_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadosAlugDiv).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgtotalmes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosAlugDiv;
        private DataGridView dgtotalmes;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label1;
    }
}