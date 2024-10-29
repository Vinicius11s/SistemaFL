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
            label4 = new Label();
            txtlogin = new TextBox();
            label1 = new Label();
            txtsenha = new TextBox();
            btnentrar = new Button();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(197, 108);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 10;
            label4.Text = "Login";
            // 
            // txtlogin
            // 
            txtlogin.Location = new Point(197, 132);
            txtlogin.Margin = new Padding(3, 4, 3, 4);
            txtlogin.MaxLength = 150;
            txtlogin.Name = "txtlogin";
            txtlogin.Size = new Size(357, 23);
            txtlogin.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(197, 172);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 12;
            label1.Text = "Senha";
            // 
            // txtsenha
            // 
            txtsenha.Location = new Point(197, 196);
            txtsenha.Margin = new Padding(3, 4, 3, 4);
            txtsenha.MaxLength = 150;
            txtsenha.Name = "txtsenha";
            txtsenha.PasswordChar = '*';
            txtsenha.Size = new Size(357, 23);
            txtsenha.TabIndex = 11;
            // 
            // btnentrar
            // 
            btnentrar.Location = new Point(342, 262);
            btnentrar.Name = "btnentrar";
            btnentrar.Size = new Size(89, 40);
            btnentrar.TabIndex = 13;
            btnentrar.Text = "Entrar";
            btnentrar.UseVisualStyleBackColor = true;
            btnentrar.Click += btnentrar_Click;
            // 
            // FrmFuncionalidadeLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnentrar);
            Controls.Add(label1);
            Controls.Add(txtsenha);
            Controls.Add(label4);
            Controls.Add(txtlogin);
            Name = "FrmFuncionalidadeLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFuncionalidadeLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private TextBox txtlogin;
        private Label label1;
        private TextBox txtsenha;
        private Button btnentrar;
    }
}