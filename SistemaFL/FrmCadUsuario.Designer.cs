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
            sidebar = new FlowLayoutPanel();
            btnnovo = new Button();
            btnexcluir = new Button();
            btnalterar = new Button();
            btnlocalizar = new Button();
            btncancelar = new Button();
            btnsalvar = new Button();
            dtDataCriacao = new DateTimePicker();
            label5 = new Label();
            txtsenha = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtlogin = new TextBox();
            txtid = new TextBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pdados.SuspendLayout();
            sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pdados
            // 
            pdados.BackColor = Color.White;
            pdados.Controls.Add(pictureBox2);
            pdados.Controls.Add(sidebar);
            pdados.Controls.Add(btncancelar);
            pdados.Controls.Add(btnsalvar);
            pdados.Controls.Add(dtDataCriacao);
            pdados.Controls.Add(label5);
            pdados.Controls.Add(txtsenha);
            pdados.Controls.Add(label3);
            pdados.Controls.Add(label2);
            pdados.Controls.Add(txtlogin);
            pdados.Controls.Add(txtid);
            pdados.Controls.Add(label1);
            pdados.Dock = DockStyle.Top;
            pdados.Location = new Point(0, 0);
            pdados.Margin = new Padding(3, 4, 3, 4);
            pdados.Name = "pdados";
            pdados.Size = new Size(610, 449);
            pdados.TabIndex = 0;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(23, 24, 29);
            sidebar.Controls.Add(btnnovo);
            sidebar.Controls.Add(btnexcluir);
            sidebar.Controls.Add(btnalterar);
            sidebar.Controls.Add(btnlocalizar);
            sidebar.Dock = DockStyle.Left;
            sidebar.Location = new Point(0, 0);
            sidebar.Name = "sidebar";
            sidebar.Padding = new Padding(0, 30, 0, 0);
            sidebar.Size = new Size(168, 449);
            sidebar.TabIndex = 25;
            // 
            // btnnovo
            // 
            btnnovo.BackColor = Color.FromArgb(23, 24, 29);
            btnnovo.FlatStyle = FlatStyle.Flat;
            btnnovo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnnovo.ForeColor = Color.White;
            btnnovo.Image = (Image)resources.GetObject("btnnovo.Image");
            btnnovo.ImageAlign = ContentAlignment.MiddleLeft;
            btnnovo.Location = new Point(3, 33);
            btnnovo.Name = "btnnovo";
            btnnovo.Padding = new Padding(25, 0, 0, 0);
            btnnovo.Size = new Size(163, 38);
            btnnovo.TabIndex = 26;
            btnnovo.Text = "      Novo";
            btnnovo.TextAlign = ContentAlignment.MiddleLeft;
            btnnovo.UseVisualStyleBackColor = false;
            btnnovo.Click += btnnovo_Click_1;
            // 
            // btnexcluir
            // 
            btnexcluir.BackColor = Color.FromArgb(23, 24, 29);
            btnexcluir.FlatStyle = FlatStyle.Flat;
            btnexcluir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnexcluir.ForeColor = Color.White;
            btnexcluir.Image = (Image)resources.GetObject("btnexcluir.Image");
            btnexcluir.ImageAlign = ContentAlignment.MiddleLeft;
            btnexcluir.Location = new Point(3, 77);
            btnexcluir.Name = "btnexcluir";
            btnexcluir.Padding = new Padding(25, 0, 0, 0);
            btnexcluir.Size = new Size(163, 38);
            btnexcluir.TabIndex = 27;
            btnexcluir.Text = "      Excluir";
            btnexcluir.TextAlign = ContentAlignment.MiddleLeft;
            btnexcluir.UseVisualStyleBackColor = false;
            btnexcluir.Click += btnexcluir_Click_1;
            // 
            // btnalterar
            // 
            btnalterar.BackColor = Color.FromArgb(23, 24, 29);
            btnalterar.FlatStyle = FlatStyle.Flat;
            btnalterar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnalterar.ForeColor = Color.White;
            btnalterar.Image = (Image)resources.GetObject("btnalterar.Image");
            btnalterar.ImageAlign = ContentAlignment.MiddleLeft;
            btnalterar.Location = new Point(3, 121);
            btnalterar.Name = "btnalterar";
            btnalterar.Padding = new Padding(25, 0, 0, 0);
            btnalterar.Size = new Size(163, 38);
            btnalterar.TabIndex = 28;
            btnalterar.Text = "      Alterar";
            btnalterar.TextAlign = ContentAlignment.MiddleLeft;
            btnalterar.UseVisualStyleBackColor = false;
            btnalterar.Click += btnalterar_Click_1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.BackColor = Color.FromArgb(23, 24, 29);
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnlocalizar.ForeColor = Color.White;
            btnlocalizar.Image = (Image)resources.GetObject("btnlocalizar.Image");
            btnlocalizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnlocalizar.Location = new Point(3, 165);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Padding = new Padding(25, 0, 0, 0);
            btnlocalizar.Size = new Size(163, 38);
            btnlocalizar.TabIndex = 29;
            btnlocalizar.Text = "      Localizar";
            btnlocalizar.TextAlign = ContentAlignment.MiddleLeft;
            btnlocalizar.UseVisualStyleBackColor = false;
            btnlocalizar.Click += btnlocalizar_Click_1;
            // 
            // btncancelar
            // 
            btncancelar.BackColor = Color.FromArgb(23, 24, 29);
            btncancelar.FlatStyle = FlatStyle.Flat;
            btncancelar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btncancelar.ForeColor = Color.White;
            btncancelar.Location = new Point(390, 277);
            btncancelar.Margin = new Padding(3, 4, 3, 4);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(94, 42);
            btncancelar.TabIndex = 21;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += btncancelar_Click;
            // 
            // btnsalvar
            // 
            btnsalvar.BackColor = Color.FromArgb(23, 24, 29);
            btnsalvar.FlatStyle = FlatStyle.Flat;
            btnsalvar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnsalvar.ForeColor = Color.White;
            btnsalvar.Location = new Point(265, 277);
            btnsalvar.Margin = new Padding(3, 4, 3, 4);
            btnsalvar.Name = "btnsalvar";
            btnsalvar.Size = new Size(94, 42);
            btnsalvar.TabIndex = 20;
            btnsalvar.Text = "Salvar";
            btnsalvar.UseVisualStyleBackColor = false;
            btnsalvar.Click += btnsalvar_Click;
            // 
            // dtDataCriacao
            // 
            dtDataCriacao.CalendarTitleBackColor = SystemColors.ActiveCaptionText;
            dtDataCriacao.Font = new Font("Segoe UI Semilight", 12F);
            dtDataCriacao.Format = DateTimePickerFormat.Short;
            dtDataCriacao.Location = new Point(364, 86);
            dtDataCriacao.Margin = new Padding(3, 4, 3, 4);
            dtDataCriacao.Name = "dtDataCriacao";
            dtDataCriacao.Size = new Size(108, 29);
            dtDataCriacao.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semilight", 12F);
            label5.Location = new Point(364, 61);
            label5.Name = "label5";
            label5.Size = new Size(97, 21);
            label5.TabIndex = 23;
            label5.Text = "Data Criação";
            // 
            // txtsenha
            // 
            txtsenha.Font = new Font("Segoe UI Semilight", 12F);
            txtsenha.Location = new Point(276, 211);
            txtsenha.Margin = new Padding(3, 5, 3, 5);
            txtsenha.MaxLength = 150;
            txtsenha.Name = "txtsenha";
            txtsenha.Size = new Size(196, 29);
            txtsenha.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semilight", 12F);
            label3.Location = new Point(221, 214);
            label3.Name = "label3";
            label3.Size = new Size(52, 21);
            label3.TabIndex = 19;
            label3.Text = "Senha";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 12F);
            label2.Location = new Point(224, 161);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 18;
            label2.Text = "Login";
            // 
            // txtlogin
            // 
            txtlogin.Font = new Font("Segoe UI Semilight", 12F);
            txtlogin.Location = new Point(276, 155);
            txtlogin.Margin = new Padding(3, 5, 3, 5);
            txtlogin.MaxLength = 150;
            txtlogin.Name = "txtlogin";
            txtlogin.Size = new Size(196, 29);
            txtlogin.TabIndex = 17;
            // 
            // txtid
            // 
            txtid.Font = new Font("Segoe UI Semilight", 12F);
            txtid.Location = new Point(276, 86);
            txtid.Margin = new Padding(3, 5, 3, 5);
            txtid.Name = "txtid";
            txtid.ReadOnly = true;
            txtid.Size = new Size(57, 29);
            txtid.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 12F);
            label1.Location = new Point(273, 61);
            label1.Name = "label1";
            label1.Size = new Size(60, 21);
            label1.TabIndex = 15;
            label1.Text = "Código";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(580, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 21);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 26;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // FrmCadUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(610, 448);
            Controls.Add(pdados);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmCadUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro Usuário";
            Load += FrmCadUsuario_Load;
            pdados.ResumeLayout(false);
            pdados.PerformLayout();
            sidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private Button btnsalvar;
        private FlowLayoutPanel sidebar;
        private Button btnnovo;
        private Button btnexcluir;
        private Button btnalterar;
        private Button btnlocalizar;
        private PictureBox pictureBox2;
    }
}