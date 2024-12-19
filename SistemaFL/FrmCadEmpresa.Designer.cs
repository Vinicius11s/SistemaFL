namespace SistemaFL
{
    partial class FrmCadEmpresa
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
            pbotoes = new Panel();
            btnlocalizar = new Button();
            btnexcluir = new Button();
            btncancelar = new Button();
            btnsalvar = new Button();
            btnalterar = new Button();
            btnnovo = new Button();
            pdados = new Panel();
            txtbairro = new TextBox();
            txtcidade = new TextBox();
            txtestado = new TextBox();
            txtcep = new TextBox();
            txtnumero = new TextBox();
            txtrua = new TextBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            txtrazaosocial = new TextBox();
            label5 = new Label();
            txtinscricaoestadual = new TextBox();
            label4 = new Label();
            txtcnpj = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtdescricao = new TextBox();
            txtid = new TextBox();
            label1 = new Label();
            pbotoes.SuspendLayout();
            pdados.SuspendLayout();
            SuspendLayout();
            // 
            // pbotoes
            // 
            pbotoes.BackColor = Color.Silver;
            pbotoes.Controls.Add(btnlocalizar);
            pbotoes.Controls.Add(btnexcluir);
            pbotoes.Controls.Add(btncancelar);
            pbotoes.Controls.Add(btnsalvar);
            pbotoes.Controls.Add(btnalterar);
            pbotoes.Controls.Add(btnnovo);
            pbotoes.Dock = DockStyle.Bottom;
            pbotoes.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pbotoes.Location = new Point(0, 370);
            pbotoes.Name = "pbotoes";
            pbotoes.Size = new Size(927, 88);
            pbotoes.TabIndex = 1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.ForeColor = Color.Black;
            btnlocalizar.Location = new Point(600, 21);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(89, 42);
            btnlocalizar.TabIndex = 11;
            btnlocalizar.Text = "Localizar";
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // btnexcluir
            // 
            btnexcluir.ForeColor = Color.Black;
            btnexcluir.Location = new Point(506, 21);
            btnexcluir.Name = "btnexcluir";
            btnexcluir.Size = new Size(89, 42);
            btnexcluir.TabIndex = 10;
            btnexcluir.Text = "Excluir";
            btnexcluir.UseVisualStyleBackColor = true;
            btnexcluir.Click += btnexcluir_Click;
            // 
            // btncancelar
            // 
            btncancelar.ForeColor = Color.Black;
            btncancelar.Location = new Point(411, 21);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(89, 42);
            btncancelar.TabIndex = 9;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = true;
            btncancelar.Click += btncancelar_Click;
            // 
            // btnsalvar
            // 
            btnsalvar.ForeColor = Color.Black;
            btnsalvar.Location = new Point(317, 21);
            btnsalvar.Name = "btnsalvar";
            btnsalvar.Size = new Size(89, 42);
            btnsalvar.TabIndex = 8;
            btnsalvar.Text = "Salvar";
            btnsalvar.UseVisualStyleBackColor = true;
            btnsalvar.Click += btnsalvar_Click;
            // 
            // btnalterar
            // 
            btnalterar.ForeColor = Color.Black;
            btnalterar.Location = new Point(222, 21);
            btnalterar.Name = "btnalterar";
            btnalterar.Size = new Size(89, 42);
            btnalterar.TabIndex = 7;
            btnalterar.Text = "Alterar";
            btnalterar.UseVisualStyleBackColor = true;
            btnalterar.Click += btnalterar_Click;
            // 
            // btnnovo
            // 
            btnnovo.ForeColor = Color.Black;
            btnnovo.Location = new Point(122, 21);
            btnnovo.Name = "btnnovo";
            btnnovo.Size = new Size(89, 42);
            btnnovo.TabIndex = 6;
            btnnovo.Text = "Novo";
            btnnovo.UseVisualStyleBackColor = true;
            btnnovo.Click += btnnovo_Click;
            // 
            // pdados
            // 
            pdados.Controls.Add(txtbairro);
            pdados.Controls.Add(txtcidade);
            pdados.Controls.Add(txtestado);
            pdados.Controls.Add(txtcep);
            pdados.Controls.Add(txtnumero);
            pdados.Controls.Add(txtrua);
            pdados.Controls.Add(label12);
            pdados.Controls.Add(label11);
            pdados.Controls.Add(label10);
            pdados.Controls.Add(label9);
            pdados.Controls.Add(label8);
            pdados.Controls.Add(label7);
            pdados.Controls.Add(txtrazaosocial);
            pdados.Controls.Add(label5);
            pdados.Controls.Add(txtinscricaoestadual);
            pdados.Controls.Add(label4);
            pdados.Controls.Add(txtcnpj);
            pdados.Controls.Add(label3);
            pdados.Controls.Add(label2);
            pdados.Controls.Add(txtdescricao);
            pdados.Controls.Add(txtid);
            pdados.Controls.Add(label1);
            pdados.Dock = DockStyle.Top;
            pdados.Location = new Point(0, 0);
            pdados.Margin = new Padding(3, 2, 3, 2);
            pdados.Name = "pdados";
            pdados.Size = new Size(927, 342);
            pdados.TabIndex = 2;
            // 
            // txtbairro
            // 
            txtbairro.BorderStyle = BorderStyle.FixedSingle;
            txtbairro.Enabled = false;
            txtbairro.Location = new Point(241, 261);
            txtbairro.Margin = new Padding(3, 4, 3, 4);
            txtbairro.MaxLength = 150;
            txtbairro.Name = "txtbairro";
            txtbairro.Size = new Size(184, 22);
            txtbairro.TabIndex = 81;
            // 
            // txtcidade
            // 
            txtcidade.BorderStyle = BorderStyle.FixedSingle;
            txtcidade.Enabled = false;
            txtcidade.Location = new Point(32, 261);
            txtcidade.Margin = new Padding(3, 4, 3, 4);
            txtcidade.MaxLength = 150;
            txtcidade.Name = "txtcidade";
            txtcidade.Size = new Size(132, 22);
            txtcidade.TabIndex = 80;
            // 
            // txtestado
            // 
            txtestado.BorderStyle = BorderStyle.FixedSingle;
            txtestado.Enabled = false;
            txtestado.Location = new Point(173, 261);
            txtestado.Margin = new Padding(3, 4, 3, 4);
            txtestado.MaxLength = 150;
            txtestado.Name = "txtestado";
            txtestado.Size = new Size(50, 22);
            txtestado.TabIndex = 79;
            // 
            // txtcep
            // 
            txtcep.BorderStyle = BorderStyle.FixedSingle;
            txtcep.Enabled = false;
            txtcep.Location = new Point(32, 208);
            txtcep.Margin = new Padding(3, 4, 3, 4);
            txtcep.MaxLength = 150;
            txtcep.Name = "txtcep";
            txtcep.Size = new Size(85, 22);
            txtcep.TabIndex = 78;
            // 
            // txtnumero
            // 
            txtnumero.BorderStyle = BorderStyle.FixedSingle;
            txtnumero.Location = new Point(382, 208);
            txtnumero.Margin = new Padding(3, 4, 3, 4);
            txtnumero.MaxLength = 150;
            txtnumero.Name = "txtnumero";
            txtnumero.Size = new Size(43, 22);
            txtnumero.TabIndex = 77;
            // 
            // txtrua
            // 
            txtrua.BorderStyle = BorderStyle.FixedSingle;
            txtrua.Location = new Point(133, 208);
            txtrua.Margin = new Padding(3, 4, 3, 4);
            txtrua.MaxLength = 150;
            txtrua.Name = "txtrua";
            txtrua.Size = new Size(236, 22);
            txtrua.TabIndex = 76;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semilight", 12F);
            label12.Location = new Point(32, 188);
            label12.Name = "label12";
            label12.Size = new Size(37, 21);
            label12.TabIndex = 75;
            label12.Text = "CEP";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semilight", 12F);
            label11.Location = new Point(173, 241);
            label11.Name = "label11";
            label11.Size = new Size(56, 21);
            label11.TabIndex = 74;
            label11.Text = "Estado";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semilight", 12F);
            label10.Location = new Point(241, 241);
            label10.Name = "label10";
            label10.Size = new Size(58, 21);
            label10.TabIndex = 73;
            label10.Text = "Cidade";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semilight", 12F);
            label9.Location = new Point(33, 241);
            label9.Name = "label9";
            label9.Size = new Size(50, 21);
            label9.TabIndex = 72;
            label9.Text = "Bairro";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semilight", 12F);
            label8.Location = new Point(382, 188);
            label8.Name = "label8";
            label8.Size = new Size(29, 21);
            label8.TabIndex = 71;
            label8.Text = "Nº";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semilight", 12F);
            label7.Location = new Point(133, 188);
            label7.Name = "label7";
            label7.Size = new Size(36, 21);
            label7.TabIndex = 70;
            label7.Text = "Rua";
            // 
            // txtrazaosocial
            // 
            txtrazaosocial.BorderStyle = BorderStyle.FixedSingle;
            txtrazaosocial.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtrazaosocial.Location = new Point(116, 151);
            txtrazaosocial.Margin = new Padding(3, 4, 3, 4);
            txtrazaosocial.MaxLength = 150;
            txtrazaosocial.Name = "txtrazaosocial";
            txtrazaosocial.Size = new Size(162, 33);
            txtrazaosocial.TabIndex = 69;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(116, 131);
            label5.Name = "label5";
            label5.Size = new Size(95, 21);
            label5.TabIndex = 68;
            label5.Text = "Razão Social";
            // 
            // txtinscricaoestadual
            // 
            txtinscricaoestadual.BorderStyle = BorderStyle.FixedSingle;
            txtinscricaoestadual.Font = new Font("Segoe UI", 14.25F);
            txtinscricaoestadual.Location = new Point(116, 94);
            txtinscricaoestadual.Margin = new Padding(3, 4, 3, 4);
            txtinscricaoestadual.MaxLength = 150;
            txtinscricaoestadual.Name = "txtinscricaoestadual";
            txtinscricaoestadual.Size = new Size(162, 33);
            txtinscricaoestadual.TabIndex = 67;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Italic);
            label4.Location = new Point(116, 74);
            label4.Name = "label4";
            label4.Size = new Size(133, 21);
            label4.TabIndex = 66;
            label4.Text = "Inscrição Estadual";
            // 
            // txtcnpj
            // 
            txtcnpj.BorderStyle = BorderStyle.FixedSingle;
            txtcnpj.Font = new Font("Segoe UI", 14.25F);
            txtcnpj.Location = new Point(292, 94);
            txtcnpj.Margin = new Padding(3, 4, 3, 4);
            txtcnpj.MaxLength = 150;
            txtcnpj.Name = "txtcnpj";
            txtcnpj.Size = new Size(166, 33);
            txtcnpj.TabIndex = 65;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Italic);
            label3.Location = new Point(292, 73);
            label3.Name = "label3";
            label3.Size = new Size(46, 21);
            label3.TabIndex = 64;
            label3.Text = "CNPJ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 12F);
            label2.Location = new Point(116, 9);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 63;
            label2.Text = "Descrição";
            // 
            // txtdescricao
            // 
            txtdescricao.BorderStyle = BorderStyle.FixedSingle;
            txtdescricao.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtdescricao.Location = new Point(116, 30);
            txtdescricao.Margin = new Padding(3, 4, 3, 4);
            txtdescricao.MaxLength = 150;
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(342, 35);
            txtdescricao.TabIndex = 62;
            // 
            // txtid
            // 
            txtid.Location = new Point(32, 30);
            txtid.Margin = new Padding(3, 4, 3, 4);
            txtid.Name = "txtid";
            txtid.ReadOnly = true;
            txtid.Size = new Size(69, 22);
            txtid.TabIndex = 61;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 12F);
            label1.Location = new Point(32, 4);
            label1.Name = "label1";
            label1.Size = new Size(60, 21);
            label1.TabIndex = 60;
            label1.Text = "Código";
            // 
            // FrmCadEmpresa
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(927, 458);
            Controls.Add(pdados);
            Controls.Add(pbotoes);
            Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            Name = "FrmCadEmpresa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Empresa";
            TransparencyKey = Color.White;
            WindowState = FormWindowState.Maximized;
            Load += FrmCadEmpresa_Load;
            pbotoes.ResumeLayout(false);
            pdados.ResumeLayout(false);
            pdados.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pbotoes;
        private Button btnlocalizar;
        private Button btnexcluir;
        private Button btncancelar;
        private Button btnsalvar;
        private Button btnalterar;
        private Button btnnovo;
        private Panel pdados;
        private TextBox txtbairro;
        private TextBox txtcidade;
        private TextBox txtestado;
        private TextBox txtcep;
        private TextBox txtnumero;
        private TextBox txtrua;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox txtrazaosocial;
        private Label label5;
        private TextBox txtinscricaoestadual;
        private Label label4;
        private TextBox txtcnpj;
        private Label label3;
        private Label label2;
        private TextBox txtdescricao;
        private TextBox txtid;
        private Label label1;
    }
}