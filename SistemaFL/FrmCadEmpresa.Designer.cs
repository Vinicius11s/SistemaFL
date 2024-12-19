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
            btndesassociar = new Button();
            cbbflatsassociados = new ComboBox();
            label14 = new Label();
            label13 = new Label();
            btnassociar = new Button();
            dgAssociarFlat = new DataGridView();
            pbotoes.SuspendLayout();
            pdados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgAssociarFlat).BeginInit();
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
            pbotoes.Location = new Point(0, 392);
            pbotoes.Margin = new Padding(3, 4, 3, 4);
            pbotoes.Name = "pbotoes";
            pbotoes.Size = new Size(1059, 180);
            pbotoes.TabIndex = 1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.ForeColor = Color.Black;
            btnlocalizar.Location = new Point(711, 59);
            btnlocalizar.Margin = new Padding(3, 4, 3, 4);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(102, 53);
            btnlocalizar.TabIndex = 11;
            btnlocalizar.Text = "Localizar";
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // btnexcluir
            // 
            btnexcluir.ForeColor = Color.Black;
            btnexcluir.Location = new Point(603, 59);
            btnexcluir.Margin = new Padding(3, 4, 3, 4);
            btnexcluir.Name = "btnexcluir";
            btnexcluir.Size = new Size(102, 53);
            btnexcluir.TabIndex = 10;
            btnexcluir.Text = "Excluir";
            btnexcluir.UseVisualStyleBackColor = true;
            btnexcluir.Click += btnexcluir_Click;
            // 
            // btncancelar
            // 
            btncancelar.ForeColor = Color.Black;
            btncancelar.Location = new Point(495, 59);
            btncancelar.Margin = new Padding(3, 4, 3, 4);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(102, 53);
            btncancelar.TabIndex = 9;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = true;
            btncancelar.Click += btncancelar_Click;
            // 
            // btnsalvar
            // 
            btnsalvar.ForeColor = Color.Black;
            btnsalvar.Location = new Point(387, 59);
            btnsalvar.Margin = new Padding(3, 4, 3, 4);
            btnsalvar.Name = "btnsalvar";
            btnsalvar.Size = new Size(102, 53);
            btnsalvar.TabIndex = 8;
            btnsalvar.Text = "Salvar";
            btnsalvar.UseVisualStyleBackColor = true;
            btnsalvar.Click += btnsalvar_Click;
            // 
            // btnalterar
            // 
            btnalterar.ForeColor = Color.Black;
            btnalterar.Location = new Point(279, 59);
            btnalterar.Margin = new Padding(3, 4, 3, 4);
            btnalterar.Name = "btnalterar";
            btnalterar.Size = new Size(102, 53);
            btnalterar.TabIndex = 7;
            btnalterar.Text = "Alterar";
            btnalterar.UseVisualStyleBackColor = true;
            btnalterar.Click += btnalterar_Click;
            // 
            // btnnovo
            // 
            btnnovo.ForeColor = Color.Black;
            btnnovo.Location = new Point(165, 59);
            btnnovo.Margin = new Padding(3, 4, 3, 4);
            btnnovo.Name = "btnnovo";
            btnnovo.Size = new Size(102, 53);
            btnnovo.TabIndex = 6;
            btnnovo.Text = "Novo";
            btnnovo.UseVisualStyleBackColor = true;
            btnnovo.Click += btnnovo_Click;
            // 
            // pdados
            // 
            pdados.Controls.Add(btndesassociar);
            pdados.Controls.Add(cbbflatsassociados);
            pdados.Controls.Add(label14);
            pdados.Controls.Add(label13);
            pdados.Controls.Add(btnassociar);
            pdados.Controls.Add(dgAssociarFlat);
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
            pdados.Name = "pdados";
            pdados.Size = new Size(1059, 422);
            pdados.TabIndex = 2;
            // 
            // txtbairro
            // 
            txtbairro.BorderStyle = BorderStyle.FixedSingle;
            txtbairro.Enabled = false;
            txtbairro.Location = new Point(275, 326);
            txtbairro.Margin = new Padding(3, 5, 3, 5);
            txtbairro.MaxLength = 150;
            txtbairro.Name = "txtbairro";
            txtbairro.Size = new Size(210, 27);
            txtbairro.TabIndex = 81;
            // 
            // txtcidade
            // 
            txtcidade.BorderStyle = BorderStyle.FixedSingle;
            txtcidade.Enabled = false;
            txtcidade.Location = new Point(37, 326);
            txtcidade.Margin = new Padding(3, 5, 3, 5);
            txtcidade.MaxLength = 150;
            txtcidade.Name = "txtcidade";
            txtcidade.Size = new Size(150, 27);
            txtcidade.TabIndex = 80;
            // 
            // txtestado
            // 
            txtestado.BorderStyle = BorderStyle.FixedSingle;
            txtestado.Enabled = false;
            txtestado.Location = new Point(198, 326);
            txtestado.Margin = new Padding(3, 5, 3, 5);
            txtestado.MaxLength = 150;
            txtestado.Name = "txtestado";
            txtestado.Size = new Size(57, 27);
            txtestado.TabIndex = 79;
            // 
            // txtcep
            // 
            txtcep.BorderStyle = BorderStyle.FixedSingle;
            txtcep.Enabled = false;
            txtcep.Location = new Point(37, 260);
            txtcep.Margin = new Padding(3, 5, 3, 5);
            txtcep.MaxLength = 150;
            txtcep.Name = "txtcep";
            txtcep.Size = new Size(97, 27);
            txtcep.TabIndex = 78;
            // 
            // txtnumero
            // 
            txtnumero.BorderStyle = BorderStyle.FixedSingle;
            txtnumero.Location = new Point(436, 260);
            txtnumero.Margin = new Padding(3, 5, 3, 5);
            txtnumero.MaxLength = 150;
            txtnumero.Name = "txtnumero";
            txtnumero.Size = new Size(49, 27);
            txtnumero.TabIndex = 77;
            // 
            // txtrua
            // 
            txtrua.BorderStyle = BorderStyle.FixedSingle;
            txtrua.Location = new Point(152, 260);
            txtrua.Margin = new Padding(3, 5, 3, 5);
            txtrua.MaxLength = 150;
            txtrua.Name = "txtrua";
            txtrua.Size = new Size(270, 27);
            txtrua.TabIndex = 76;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semilight", 12F);
            label12.Location = new Point(37, 235);
            label12.Name = "label12";
            label12.Size = new Size(37, 21);
            label12.TabIndex = 75;
            label12.Text = "CEP";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semilight", 12F);
            label11.Location = new Point(198, 301);
            label11.Name = "label11";
            label11.Size = new Size(56, 21);
            label11.TabIndex = 74;
            label11.Text = "Estado";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semilight", 12F);
            label10.Location = new Point(275, 301);
            label10.Name = "label10";
            label10.Size = new Size(58, 21);
            label10.TabIndex = 73;
            label10.Text = "Cidade";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semilight", 12F);
            label9.Location = new Point(38, 301);
            label9.Name = "label9";
            label9.Size = new Size(50, 21);
            label9.TabIndex = 72;
            label9.Text = "Bairro";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semilight", 12F);
            label8.Location = new Point(436, 235);
            label8.Name = "label8";
            label8.Size = new Size(29, 21);
            label8.TabIndex = 71;
            label8.Text = "Nº";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semilight", 12F);
            label7.Location = new Point(152, 235);
            label7.Name = "label7";
            label7.Size = new Size(36, 21);
            label7.TabIndex = 70;
            label7.Text = "Rua";
            // 
            // txtrazaosocial
            // 
            txtrazaosocial.BorderStyle = BorderStyle.FixedSingle;
            txtrazaosocial.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtrazaosocial.Location = new Point(133, 167);
            txtrazaosocial.Margin = new Padding(3, 5, 3, 5);
            txtrazaosocial.MaxLength = 150;
            txtrazaosocial.Name = "txtrazaosocial";
            txtrazaosocial.Size = new Size(185, 33);
            txtrazaosocial.TabIndex = 69;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(133, 142);
            label5.Name = "label5";
            label5.Size = new Size(95, 21);
            label5.TabIndex = 68;
            label5.Text = "Razão Social";
            // 
            // txtinscricaoestadual
            // 
            txtinscricaoestadual.BorderStyle = BorderStyle.FixedSingle;
            txtinscricaoestadual.Font = new Font("Segoe UI", 14.25F);
            txtinscricaoestadual.Location = new Point(133, 104);
            txtinscricaoestadual.Margin = new Padding(3, 5, 3, 5);
            txtinscricaoestadual.MaxLength = 150;
            txtinscricaoestadual.Name = "txtinscricaoestadual";
            txtinscricaoestadual.Size = new Size(185, 33);
            txtinscricaoestadual.TabIndex = 67;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Italic);
            label4.Location = new Point(133, 79);
            label4.Name = "label4";
            label4.Size = new Size(133, 21);
            label4.TabIndex = 66;
            label4.Text = "Inscrição Estadual";
            // 
            // txtcnpj
            // 
            txtcnpj.BorderStyle = BorderStyle.FixedSingle;
            txtcnpj.Font = new Font("Segoe UI", 14.25F);
            txtcnpj.Location = new Point(335, 104);
            txtcnpj.Margin = new Padding(3, 5, 3, 5);
            txtcnpj.MaxLength = 150;
            txtcnpj.Name = "txtcnpj";
            txtcnpj.Size = new Size(189, 33);
            txtcnpj.TabIndex = 65;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Italic);
            label3.Location = new Point(335, 77);
            label3.Name = "label3";
            label3.Size = new Size(46, 21);
            label3.TabIndex = 64;
            label3.Text = "CNPJ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 12F);
            label2.Location = new Point(133, 11);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 63;
            label2.Text = "Descrição";
            // 
            // txtdescricao
            // 
            txtdescricao.BorderStyle = BorderStyle.FixedSingle;
            txtdescricao.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtdescricao.Location = new Point(133, 37);
            txtdescricao.Margin = new Padding(3, 5, 3, 5);
            txtdescricao.MaxLength = 150;
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(391, 35);
            txtdescricao.TabIndex = 62;
            // 
            // txtid
            // 
            txtid.Location = new Point(37, 37);
            txtid.Margin = new Padding(3, 5, 3, 5);
            txtid.Name = "txtid";
            txtid.ReadOnly = true;
            txtid.Size = new Size(78, 27);
            txtid.TabIndex = 61;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 12F);
            label1.Location = new Point(37, 5);
            label1.Name = "label1";
            label1.Size = new Size(60, 21);
            label1.TabIndex = 60;
            label1.Text = "Código";
            // 
            // btndesassociar
            // 
            btndesassociar.BackColor = Color.White;
            btndesassociar.Font = new Font("Arial", 11.25F);
            btndesassociar.ForeColor = Color.Black;
            btndesassociar.Location = new Point(704, 348);
            btndesassociar.Margin = new Padding(3, 4, 3, 4);
            btndesassociar.Name = "btndesassociar";
            btndesassociar.Size = new Size(102, 53);
            btndesassociar.TabIndex = 87;
            btndesassociar.Text = "Desassociar";
            btndesassociar.UseVisualStyleBackColor = false;
            // 
            // cbbflatsassociados
            // 
            cbbflatsassociados.Enabled = false;
            cbbflatsassociados.FormattingEnabled = true;
            cbbflatsassociados.Location = new Point(704, 294);
            cbbflatsassociados.Margin = new Padding(3, 4, 3, 4);
            cbbflatsassociados.Name = "cbbflatsassociados";
            cbbflatsassociados.Size = new Size(265, 28);
            cbbflatsassociados.TabIndex = 91;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(570, 296);
            label14.Name = "label14";
            label14.Size = new Size(121, 21);
            label14.TabIndex = 90;
            label14.Text = "Flats associados";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semilight", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(603, 29);
            label13.Name = "label13";
            label13.Size = new Size(142, 32);
            label13.TabIndex = 89;
            label13.Text = "Associar Flat";
            // 
            // btnassociar
            // 
            btnassociar.BackColor = Color.White;
            btnassociar.Font = new Font("Arial", 11.25F);
            btnassociar.ForeColor = Color.Black;
            btnassociar.Location = new Point(596, 348);
            btnassociar.Margin = new Padding(3, 4, 3, 4);
            btnassociar.Name = "btnassociar";
            btnassociar.Size = new Size(102, 53);
            btnassociar.TabIndex = 86;
            btnassociar.Text = "Associar";
            btnassociar.UseVisualStyleBackColor = false;
            // 
            // dgAssociarFlat
            // 
            dgAssociarFlat.BackgroundColor = Color.White;
            dgAssociarFlat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAssociarFlat.Location = new Point(556, 65);
            dgAssociarFlat.Margin = new Padding(3, 4, 3, 4);
            dgAssociarFlat.Name = "dgAssociarFlat";
            dgAssociarFlat.Size = new Size(413, 215);
            dgAssociarFlat.TabIndex = 88;
            dgAssociarFlat.TabStop = false;
            // 
            // FrmCadEmpresa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1059, 572);
            Controls.Add(pdados);
            Controls.Add(pbotoes);
            Font = new Font("Segoe UI Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmCadEmpresa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Empresa";
            TransparencyKey = Color.White;
            Load += FrmCadEmpresa_Load;
            pbotoes.ResumeLayout(false);
            pdados.ResumeLayout(false);
            pdados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgAssociarFlat).EndInit();
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
        private Button btndesassociar;
        private ComboBox cbbflatsassociados;
        private Label label14;
        private Label label13;
        private Button btnassociar;
        private DataGridView dgAssociarFlat;
    }
}