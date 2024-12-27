namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncDividendos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncDividendos));
            dgdadosDiv = new DataGridView();
            dgtotais = new DataGridView();
            dataGridView1 = new DataGridView();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosDiv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgtotais).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgdadosDiv
            // 
            dgdadosDiv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosDiv.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosDiv.BorderStyle = BorderStyle.None;
            dgdadosDiv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosDiv.Location = new Point(0, 61);
            dgdadosDiv.Margin = new Padding(3, 4, 3, 4);
            dgdadosDiv.Name = "dgdadosDiv";
            dgdadosDiv.Size = new Size(1023, 472);
            dgdadosDiv.TabIndex = 0;
            // 
            // dgtotais
            // 
            dgtotais.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgtotais.BorderStyle = BorderStyle.None;
            dgtotais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtotais.Dock = DockStyle.Bottom;
            dgtotais.Location = new Point(0, 532);
            dgtotais.Name = "dgtotais";
            dgtotais.Size = new Size(1020, 73);
            dgtotais.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(532, 20);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(208, 10);
            dataGridView1.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(780, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(27, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(747, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 14;
            label1.Text = "Dividendos";
            // 
            // FrmFuncDividendos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1020, 605);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView1);
            Controls.Add(dgtotais);
            Controls.Add(dgdadosDiv);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncDividendos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dividendos";
            Load += FrmFuncDividendos_Load;
            Resize += FrmFuncDividendos_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadosDiv).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgtotais).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosDiv;
        private DataGridView dgtotais;
        private DataGridView dataGridView1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label1;
    }
}