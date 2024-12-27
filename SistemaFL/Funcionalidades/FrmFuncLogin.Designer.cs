namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncLogin));
            txtlogin = new TextBox();
            txtsenha = new TextBox();
            btnentrar = new Button();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtlogin
            // 
            txtlogin.BackColor = Color.Black;
            txtlogin.BorderStyle = BorderStyle.FixedSingle;
            txtlogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtlogin.ForeColor = SystemColors.ControlLightLight;
            txtlogin.Location = new Point(272, 120);
            txtlogin.Margin = new Padding(3, 4, 3, 4);
            txtlogin.MaxLength = 150;
            txtlogin.Name = "txtlogin";
            txtlogin.Size = new Size(325, 29);
            txtlogin.TabIndex = 9;
            // 
            // txtsenha
            // 
            txtsenha.BackColor = Color.Black;
            txtsenha.BorderStyle = BorderStyle.FixedSingle;
            txtsenha.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtsenha.ForeColor = SystemColors.ControlLightLight;
            txtsenha.Location = new Point(272, 184);
            txtsenha.Margin = new Padding(3, 4, 3, 4);
            txtsenha.MaxLength = 150;
            txtsenha.Name = "txtsenha";
            txtsenha.PasswordChar = '*';
            txtsenha.Size = new Size(325, 29);
            txtsenha.TabIndex = 11;
            // 
            // btnentrar
            // 
            btnentrar.FlatStyle = FlatStyle.Flat;
            btnentrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnentrar.ForeColor = SystemColors.ButtonShadow;
            btnentrar.Location = new Point(272, 253);
            btnentrar.Name = "btnentrar";
            btnentrar.Size = new Size(325, 37);
            btnentrar.TabIndex = 13;
            btnentrar.Text = "Entrar";
            btnentrar.UseVisualStyleBackColor = true;
            btnentrar.Click += btnentrar_Click;
            btnentrar.KeyDown += btnentrar_KeyDown;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(23, 24, 29);
            panel1.Controls.Add(pictureBox2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 344);
            panel1.TabIndex = 14;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 59);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(225, 231);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(272, 96);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 10;
            label4.Text = "Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(272, 160);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 15;
            label2.Text = "Senha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(376, 35);
            label1.Name = "label1";
            label1.Size = new Size(106, 47);
            label1.TabIndex = 16;
            label1.Text = "Login";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(602, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // FrmFuncLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 24, 29);
            ClientSize = new Size(629, 344);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(btnentrar);
            Controls.Add(txtsenha);
            Controls.Add(label4);
            Controls.Add(txtlogin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmFuncLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFuncionalidadeLogin";
            Load += FrmFuncionalidadeLogin_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtlogin;
        private TextBox txtsenha;
        private Button btnentrar;
        private Panel panel1;
        private Label label4;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}