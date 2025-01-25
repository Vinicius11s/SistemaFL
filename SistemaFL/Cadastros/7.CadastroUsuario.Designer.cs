namespace SistemaFL
{
    partial class FrmCadUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadUsuario));
            pdados = new Panel();
            btnexcluir = new Button();
            panel1 = new Panel();
            txtsenha = new TextBox();
            txtlogin = new TextBox();
            label2 = new Label();
            label3 = new Label();
            pbFechar = new PictureBox();
            btncancelar = new Button();
            dtDataCriacao = new DateTimePicker();
            label5 = new Label();
            txtid = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            btnlocalizar = new Button();
            btnsalvar = new Button();
            btnalterar = new Button();
            btnnovo = new Button();
            pdados.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pdados
            // 
            pdados.BackColor = Color.White;
            pdados.Controls.Add(btnexcluir);
            pdados.Controls.Add(panel1);
            pdados.Controls.Add(pbFechar);
            pdados.Controls.Add(btncancelar);
            pdados.Controls.Add(dtDataCriacao);
            pdados.Controls.Add(label5);
            pdados.Controls.Add(txtid);
            pdados.Controls.Add(label1);
            pdados.Dock = DockStyle.Top;
            pdados.Location = new Point(0, 0);
            pdados.Margin = new Padding(3, 4, 3, 4);
            pdados.Name = "pdados";
            pdados.Size = new Size(532, 266);
            pdados.TabIndex = 0;
            // 
            // btnexcluir
            // 
            btnexcluir.BackColor = Color.Transparent;
            btnexcluir.FlatStyle = FlatStyle.Flat;
            btnexcluir.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnexcluir.ForeColor = Color.White;
            btnexcluir.Image = (Image)resources.GetObject("btnexcluir.Image");
            btnexcluir.Location = new Point(448, 172);
            btnexcluir.Margin = new Padding(3, 4, 3, 4);
            btnexcluir.Name = "btnexcluir";
            btnexcluir.Size = new Size(37, 42);
            btnexcluir.TabIndex = 31;
            btnexcluir.UseVisualStyleBackColor = false;
            btnexcluir.Click += btnexcluir_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtsenha);
            panel1.Controls.Add(txtlogin);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(107, 93);
            panel1.Name = "panel1";
            panel1.Size = new Size(292, 135);
            panel1.TabIndex = 30;
            // 
            // txtsenha
            // 
            txtsenha.Font = new Font("Segoe UI Semilight", 12F);
            txtsenha.Location = new Point(67, 78);
            txtsenha.Margin = new Padding(3, 5, 3, 5);
            txtsenha.MaxLength = 150;
            txtsenha.Name = "txtsenha";
            txtsenha.Size = new Size(196, 29);
            txtsenha.TabIndex = 20;
            // 
            // txtlogin
            // 
            txtlogin.Font = new Font("Segoe UI Semilight", 12F);
            txtlogin.Location = new Point(67, 22);
            txtlogin.Margin = new Padding(3, 5, 3, 5);
            txtlogin.MaxLength = 150;
            txtlogin.Name = "txtlogin";
            txtlogin.Size = new Size(196, 29);
            txtlogin.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 12F);
            label2.Location = new Point(15, 28);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 18;
            label2.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semilight", 12F);
            label3.Location = new Point(12, 81);
            label3.Name = "label3";
            label3.Size = new Size(52, 21);
            label3.TabIndex = 19;
            label3.Text = "Senha";
            // 
            // pbFechar
            // 
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(499, 3);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(30, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 26;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // btncancelar
            // 
            btncancelar.BackColor = Color.Transparent;
            btncancelar.FlatStyle = FlatStyle.Flat;
            btncancelar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btncancelar.ForeColor = Color.White;
            btncancelar.Image = (Image)resources.GetObject("btncancelar.Image");
            btncancelar.Location = new Point(448, 105);
            btncancelar.Margin = new Padding(3, 4, 3, 4);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(37, 42);
            btncancelar.TabIndex = 21;
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += btncancelar_Click;
            // 
            // dtDataCriacao
            // 
            dtDataCriacao.CalendarTitleBackColor = SystemColors.ActiveCaptionText;
            dtDataCriacao.Font = new Font("Segoe UI Semilight", 12F);
            dtDataCriacao.Format = DateTimePickerFormat.Short;
            dtDataCriacao.Location = new Point(107, 46);
            dtDataCriacao.Margin = new Padding(3, 4, 3, 4);
            dtDataCriacao.Name = "dtDataCriacao";
            dtDataCriacao.Size = new Size(108, 29);
            dtDataCriacao.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semilight", 12F);
            label5.Location = new Point(107, 21);
            label5.Name = "label5";
            label5.Size = new Size(97, 21);
            label5.TabIndex = 23;
            label5.Text = "Data Criação";
            // 
            // txtid
            // 
            txtid.Font = new Font("Segoe UI Semilight", 12F);
            txtid.Location = new Point(329, 46);
            txtid.Margin = new Padding(3, 5, 3, 5);
            txtid.Name = "txtid";
            txtid.ReadOnly = true;
            txtid.Size = new Size(57, 29);
            txtid.TabIndex = 16;
            txtid.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 12F);
            label1.Location = new Point(326, 21);
            label1.Name = "label1";
            label1.Size = new Size(60, 21);
            label1.TabIndex = 15;
            label1.Text = "Código";
            label1.Visible = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(23, 24, 29);
            panel2.Controls.Add(btnlocalizar);
            panel2.Controls.Add(btnsalvar);
            panel2.Controls.Add(btnalterar);
            panel2.Controls.Add(btnnovo);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 300);
            panel2.Name = "panel2";
            panel2.Size = new Size(532, 79);
            panel2.TabIndex = 1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.BackColor = Color.FromArgb(23, 24, 29);
            btnlocalizar.FlatAppearance.BorderSize = 2;
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            btnlocalizar.ForeColor = Color.White;
            btnlocalizar.Location = new Point(408, 22);
            btnlocalizar.Margin = new Padding(3, 4, 3, 4);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(95, 38);
            btnlocalizar.TabIndex = 21;
            btnlocalizar.Text = "Localizar";
            btnlocalizar.UseVisualStyleBackColor = false;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // btnsalvar
            // 
            btnsalvar.BackColor = Color.FromArgb(23, 24, 29);
            btnsalvar.FlatAppearance.BorderSize = 2;
            btnsalvar.FlatStyle = FlatStyle.Flat;
            btnsalvar.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            btnsalvar.ForeColor = Color.White;
            btnsalvar.Location = new Point(291, 22);
            btnsalvar.Margin = new Padding(3, 4, 3, 4);
            btnsalvar.Name = "btnsalvar";
            btnsalvar.Size = new Size(95, 38);
            btnsalvar.TabIndex = 20;
            btnsalvar.Text = "Salvar";
            btnsalvar.UseVisualStyleBackColor = false;
            btnsalvar.Click += btnsalvar_Click_1;
            // 
            // btnalterar
            // 
            btnalterar.BackColor = Color.FromArgb(23, 24, 29);
            btnalterar.FlatAppearance.BorderSize = 2;
            btnalterar.FlatStyle = FlatStyle.Flat;
            btnalterar.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            btnalterar.ForeColor = Color.White;
            btnalterar.Location = new Point(175, 22);
            btnalterar.Margin = new Padding(3, 4, 3, 4);
            btnalterar.Name = "btnalterar";
            btnalterar.Size = new Size(95, 38);
            btnalterar.TabIndex = 19;
            btnalterar.Text = "Alterar";
            btnalterar.UseVisualStyleBackColor = false;
            btnalterar.Click += btnalterar_Click;
            // 
            // btnnovo
            // 
            btnnovo.BackColor = Color.FromArgb(23, 24, 29);
            btnnovo.FlatAppearance.BorderSize = 2;
            btnnovo.FlatStyle = FlatStyle.Flat;
            btnnovo.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            btnnovo.ForeColor = Color.White;
            btnnovo.Location = new Point(45, 22);
            btnnovo.Margin = new Padding(3, 4, 3, 4);
            btnnovo.Name = "btnnovo";
            btnnovo.Size = new Size(95, 38);
            btnnovo.TabIndex = 18;
            btnnovo.Text = "Novo";
            btnnovo.UseVisualStyleBackColor = false;
            btnnovo.Click += btnnovo_Click;
            // 
            // FrmCadUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(532, 379);
            Controls.Add(panel2);
            Controls.Add(pdados);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmCadUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro Usuário";
            Load += FrmCadUsuario_Load;
            pdados.ResumeLayout(false);
            pdados.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pdados;
        private Label label5;
        private TextBox txtsenha;
        private Label label3;
        private Label label2;
        private TextBox txtlogin;
        private TextBox txtid;
        private Label label1;
        private DateTimePicker dtDataCriacao;
        private Button btncancelar;
        private PictureBox pbFechar;
        private Button btnexcluir;
        private Panel panel1;
        private Panel panel2;
        private Button btnlocalizar;
        private Button btnsalvar;
        private Button btnalterar;
        private Button btnnovo;
    }
}