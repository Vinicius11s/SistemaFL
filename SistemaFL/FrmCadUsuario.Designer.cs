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
            pdados = new Panel();
            dtDataCriacao = new DateTimePicker();
            label5 = new Label();
            txtnome = new TextBox();
            label4 = new Label();
            txtsenha = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtlogin = new TextBox();
            txtid = new TextBox();
            label1 = new Label();
            pbotoes = new Panel();
            btnlocalizar = new Button();
            btnexcluir = new Button();
            btncancelar = new Button();
            btnsalvar = new Button();
            btnalterar = new Button();
            btnnovo = new Button();
            pdados.SuspendLayout();
            pbotoes.SuspendLayout();
            SuspendLayout();
            // 
            // pdados
            // 
            pdados.Controls.Add(dtDataCriacao);
            pdados.Controls.Add(label5);
            pdados.Controls.Add(txtnome);
            pdados.Controls.Add(label4);
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
            pdados.Size = new Size(875, 392);
            pdados.TabIndex = 0;
            // 
            // dtDataCriacao
            // 
            dtDataCriacao.CalendarTitleBackColor = SystemColors.ActiveCaptionText;
            dtDataCriacao.Format = DateTimePickerFormat.Short;
            dtDataCriacao.Location = new Point(570, 97);
            dtDataCriacao.Margin = new Padding(3, 4, 3, 4);
            dtDataCriacao.Name = "dtDataCriacao";
            dtDataCriacao.Size = new Size(108, 27);
            dtDataCriacao.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(570, 65);
            label5.Name = "label5";
            label5.Size = new Size(95, 20);
            label5.TabIndex = 23;
            label5.Text = "Data Criação";
            // 
            // txtnome
            // 
            txtnome.Location = new Point(293, 90);
            txtnome.Margin = new Padding(3, 5, 3, 5);
            txtnome.MaxLength = 150;
            txtnome.Name = "txtnome";
            txtnome.Size = new Size(243, 27);
            txtnome.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(293, 65);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 21;
            label4.Text = "Nome";
            // 
            // txtsenha
            // 
            txtsenha.Location = new Point(293, 224);
            txtsenha.Margin = new Padding(3, 5, 3, 5);
            txtsenha.MaxLength = 150;
            txtsenha.Name = "txtsenha";
            txtsenha.Size = new Size(243, 27);
            txtsenha.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(294, 199);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 19;
            label3.Text = "Senha";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(293, 132);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 18;
            label2.Text = "Login";
            // 
            // txtlogin
            // 
            txtlogin.Location = new Point(293, 157);
            txtlogin.Margin = new Padding(3, 5, 3, 5);
            txtlogin.MaxLength = 150;
            txtlogin.Name = "txtlogin";
            txtlogin.Size = new Size(243, 27);
            txtlogin.TabIndex = 17;
            // 
            // txtid
            // 
            txtid.Location = new Point(208, 90);
            txtid.Margin = new Padding(3, 5, 3, 5);
            txtid.Name = "txtid";
            txtid.ReadOnly = true;
            txtid.Size = new Size(57, 27);
            txtid.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(208, 65);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 15;
            label1.Text = "Código";
            // 
            // pbotoes
            // 
            pbotoes.Controls.Add(btnlocalizar);
            pbotoes.Controls.Add(btnexcluir);
            pbotoes.Controls.Add(btncancelar);
            pbotoes.Controls.Add(btnsalvar);
            pbotoes.Controls.Add(btnalterar);
            pbotoes.Controls.Add(btnnovo);
            pbotoes.Dock = DockStyle.Bottom;
            pbotoes.Location = new Point(0, 317);
            pbotoes.Margin = new Padding(3, 4, 3, 4);
            pbotoes.Name = "pbotoes";
            pbotoes.Size = new Size(875, 112);
            pbotoes.TabIndex = 1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.BackColor = Color.FromArgb(23, 24, 29);
            btnlocalizar.Font = new Font("Segoe UI", 9F);
            btnlocalizar.ForeColor = Color.White;
            btnlocalizar.Location = new Point(701, 22);
            btnlocalizar.Margin = new Padding(3, 4, 3, 4);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(102, 53);
            btnlocalizar.TabIndex = 23;
            btnlocalizar.Text = "Localizar";
            btnlocalizar.UseVisualStyleBackColor = false;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // btnexcluir
            // 
            btnexcluir.BackColor = Color.FromArgb(23, 24, 29);
            btnexcluir.Font = new Font("Segoe UI", 9F);
            btnexcluir.ForeColor = Color.White;
            btnexcluir.Location = new Point(570, 22);
            btnexcluir.Margin = new Padding(3, 4, 3, 4);
            btnexcluir.Name = "btnexcluir";
            btnexcluir.Size = new Size(102, 53);
            btnexcluir.TabIndex = 22;
            btnexcluir.Text = "Excluir";
            btnexcluir.UseVisualStyleBackColor = false;
            btnexcluir.Click += btnexcluir_Click;
            // 
            // btncancelar
            // 
            btncancelar.BackColor = Color.FromArgb(23, 24, 29);
            btncancelar.Font = new Font("Segoe UI", 9F);
            btncancelar.ForeColor = Color.White;
            btncancelar.Location = new Point(448, 22);
            btncancelar.Margin = new Padding(3, 4, 3, 4);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(102, 53);
            btncancelar.TabIndex = 21;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += btncancelar_Click;
            // 
            // btnsalvar
            // 
            btnsalvar.BackColor = Color.FromArgb(23, 24, 29);
            btnsalvar.Font = new Font("Segoe UI", 9F);
            btnsalvar.ForeColor = Color.White;
            btnsalvar.Location = new Point(312, 22);
            btnsalvar.Margin = new Padding(3, 4, 3, 4);
            btnsalvar.Name = "btnsalvar";
            btnsalvar.Size = new Size(102, 53);
            btnsalvar.TabIndex = 20;
            btnsalvar.Text = "Salvar";
            btnsalvar.UseVisualStyleBackColor = false;
            btnsalvar.Click += btnsalvar_Click;
            // 
            // btnalterar
            // 
            btnalterar.BackColor = Color.FromArgb(23, 24, 29);
            btnalterar.Font = new Font("Segoe UI", 9F);
            btnalterar.ForeColor = Color.White;
            btnalterar.Location = new Point(177, 22);
            btnalterar.Margin = new Padding(3, 4, 3, 4);
            btnalterar.Name = "btnalterar";
            btnalterar.Size = new Size(102, 53);
            btnalterar.TabIndex = 19;
            btnalterar.Text = "Alterar";
            btnalterar.UseVisualStyleBackColor = false;
            btnalterar.Click += btnalterar_Click;
            // 
            // btnnovo
            // 
            btnnovo.BackColor = Color.FromArgb(23, 24, 29);
            btnnovo.Font = new Font("Segoe UI", 9F);
            btnnovo.ForeColor = Color.White;
            btnnovo.Location = new Point(47, 22);
            btnnovo.Margin = new Padding(3, 4, 3, 4);
            btnnovo.Name = "btnnovo";
            btnnovo.Size = new Size(102, 53);
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
            ClientSize = new Size(875, 429);
            Controls.Add(pbotoes);
            Controls.Add(pdados);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmCadUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCadUsuario";
            Load += FrmCadUsuario_Load;
            pdados.ResumeLayout(false);
            pdados.PerformLayout();
            pbotoes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pdados;
        private Panel pbotoes;
        private Label label5;
        private TextBox txtnome;
        private Label label4;
        private TextBox txtsenha;
        private Label label3;
        private Label label2;
        private TextBox txtlogin;
        private TextBox txtid;
        private Label label1;
        private DateTimePicker dtDataCriacao;
        private Button btnlocalizar;
        private Button btnexcluir;
        private Button btncancelar;
        private Button btnsalvar;
        private Button btnalterar;
        private Button btnnovo;
    }
}