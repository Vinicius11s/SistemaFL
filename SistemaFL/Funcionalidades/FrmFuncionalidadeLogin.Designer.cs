namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncionalidadeLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncionalidadeLogin));
            txtlogin = new TextBox();
            txtsenha = new TextBox();
            btnentrar = new Button();
            panel1 = new Panel();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // txtlogin
            // 
            txtlogin.BackColor = Color.Black;
            txtlogin.BorderStyle = BorderStyle.FixedSingle;
            txtlogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtlogin.Location = new Point(349, 106);
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
            txtsenha.Location = new Point(349, 170);
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
            btnentrar.Location = new Point(349, 239);
            btnentrar.Name = "btnentrar";
            btnentrar.Size = new Size(325, 37);
            btnentrar.TabIndex = 13;
            btnentrar.Text = "Entrar";
            btnentrar.UseVisualStyleBackColor = true;
            btnentrar.Click += btnentrar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 330);
            panel1.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(349, 82);
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
            label2.Location = new Point(349, 146);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 15;
            label2.Text = "Senha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(453, 21);
            label1.Name = "label1";
            label1.Size = new Size(106, 47);
            label1.TabIndex = 16;
            label1.Text = "Login";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(77, 63);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(97, 83);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Modern No. 20", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(44, 160);
            label3.Name = "label3";
            label3.Size = new Size(169, 21);
            label3.TabIndex = 17;
            label3.Text = "Sistema Gerenciador";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Modern No. 20", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(56, 181);
            label5.Name = "label5";
            label5.Size = new Size(143, 18);
            label5.TabIndex = 18;
            label5.Text = "de Empreendimentos";
            // 
            // FrmFuncionalidadeLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(780, 330);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(btnentrar);
            Controls.Add(txtsenha);
            Controls.Add(label4);
            Controls.Add(txtlogin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmFuncionalidadeLogin";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFuncionalidadeLogin";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private Label label5;
        private Label label3;
        private PictureBox pictureBox2;
    }
}