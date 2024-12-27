namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncFundoReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncFundoReserva));
            dgdadosFunRes = new DataGridView();
            dgtotais = new DataGridView();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgtotais).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFunRes
            // 
            dgdadosFunRes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosFunRes.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosFunRes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFunRes.Location = new Point(0, 78);
            dgdadosFunRes.Margin = new Padding(3, 4, 3, 4);
            dgdadosFunRes.Name = "dgdadosFunRes";
            dgdadosFunRes.Size = new Size(1020, 453);
            dgdadosFunRes.TabIndex = 0;
            // 
            // dgtotais
            // 
            dgtotais.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgtotais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtotais.Dock = DockStyle.Bottom;
            dgtotais.Location = new Point(0, 531);
            dgtotais.Name = "dgtotais";
            dgtotais.Size = new Size(1020, 74);
            dgtotais.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(765, 5);
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
            pictureBox1.Location = new Point(732, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 32);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 10);
            dataGridView1.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 9);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 16;
            label2.Text = "Fundo de Reserva";
            // 
            // FrmFuncFundoReserva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1020, 605);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(dgtotais);
            Controls.Add(dgdadosFunRes);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncFundoReserva";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fundo de Reserva";
            Load += FrmFuncFundoReserva_Load;
            Resize += FrmFuncFundoReserva_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgtotais).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosFunRes;
        private DataGridView dgtotais;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private Label label2;
    }
}