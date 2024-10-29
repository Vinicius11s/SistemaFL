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
            pdados = new Panel();
            btndesassociar = new Button();
            cbbflatsassociados = new ComboBox();
            btnassociar = new Button();
            label14 = new Label();
            label13 = new Label();
            dgAssociarFlat = new DataGridView();
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
            label6 = new Label();
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
            pbotoes = new Panel();
            btnlocalizar = new Button();
            btnexcluir = new Button();
            btncancelar = new Button();
            btnsalvar = new Button();
            btnalterar = new Button();
            btnnovo = new Button();
            pdados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgAssociarFlat).BeginInit();
            pbotoes.SuspendLayout();
            SuspendLayout();
            // 
            // pdados
            // 
            pdados.Controls.Add(btndesassociar);
            pdados.Controls.Add(cbbflatsassociados);
            pdados.Controls.Add(btnassociar);
            pdados.Controls.Add(label14);
            pdados.Controls.Add(label13);
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
            pdados.Controls.Add(label6);
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
            pdados.Size = new Size(1051, 393);
            pdados.TabIndex = 0;
            // 
            // btndesassociar
            // 
            btndesassociar.Location = new Point(924, 313);
            btndesassociar.Name = "btndesassociar";
            btndesassociar.Size = new Size(89, 40);
            btndesassociar.TabIndex = 32;
            btndesassociar.Text = "Desassociar";
            btndesassociar.UseVisualStyleBackColor = true;
            btndesassociar.Click += btndesassociar_Click;
            // 
            // cbbflatsassociados
            // 
            cbbflatsassociados.FormattingEnabled = true;
            cbbflatsassociados.Location = new Point(674, 321);
            cbbflatsassociados.Name = "cbbflatsassociados";
            cbbflatsassociados.Size = new Size(232, 23);
            cbbflatsassociados.TabIndex = 31;
            // 
            // btnassociar
            // 
            btnassociar.Location = new Point(792, 237);
            btnassociar.Name = "btnassociar";
            btnassociar.Size = new Size(89, 40);
            btnassociar.TabIndex = 12;
            btnassociar.Text = "Associar";
            btnassociar.UseVisualStyleBackColor = true;
            btnassociar.Click += btnassociar_Click_1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(674, 298);
            label14.Name = "label14";
            label14.Size = new Size(115, 20);
            label14.TabIndex = 30;
            label14.Text = "Flats associados";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(624, 27);
            label13.Name = "label13";
            label13.Size = new Size(122, 25);
            label13.TabIndex = 29;
            label13.Text = "Associar Flat";
            // 
            // dgAssociarFlat
            // 
            dgAssociarFlat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAssociarFlat.Location = new Point(624, 55);
            dgAssociarFlat.Name = "dgAssociarFlat";
            dgAssociarFlat.Size = new Size(389, 167);
            dgAssociarFlat.TabIndex = 28;
            // 
            // txtbairro
            // 
            txtbairro.Location = new Point(23, 357);
            txtbairro.Margin = new Padding(3, 4, 3, 4);
            txtbairro.MaxLength = 150;
            txtbairro.Name = "txtbairro";
            txtbairro.Size = new Size(168, 23);
            txtbairro.TabIndex = 27;
            // 
            // txtcidade
            // 
            txtcidade.Location = new Point(216, 357);
            txtcidade.Margin = new Padding(3, 4, 3, 4);
            txtcidade.MaxLength = 150;
            txtcidade.Name = "txtcidade";
            txtcidade.Size = new Size(234, 23);
            txtcidade.TabIndex = 26;
            // 
            // txtestado
            // 
            txtestado.Location = new Point(479, 357);
            txtestado.Margin = new Padding(3, 4, 3, 4);
            txtestado.MaxLength = 150;
            txtestado.Name = "txtestado";
            txtestado.Size = new Size(69, 23);
            txtestado.TabIndex = 25;
            // 
            // txtcep
            // 
            txtcep.Location = new Point(23, 300);
            txtcep.Margin = new Padding(3, 4, 3, 4);
            txtcep.MaxLength = 150;
            txtcep.Name = "txtcep";
            txtcep.Size = new Size(69, 23);
            txtcep.TabIndex = 24;
            // 
            // txtnumero
            // 
            txtnumero.Location = new Point(479, 299);
            txtnumero.Margin = new Padding(3, 4, 3, 4);
            txtnumero.MaxLength = 150;
            txtnumero.Name = "txtnumero";
            txtnumero.Size = new Size(43, 23);
            txtnumero.TabIndex = 23;
            // 
            // txtrua
            // 
            txtrua.Location = new Point(110, 299);
            txtrua.Margin = new Padding(3, 4, 3, 4);
            txtrua.MaxLength = 150;
            txtrua.Name = "txtrua";
            txtrua.Size = new Size(352, 23);
            txtrua.TabIndex = 22;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(23, 276);
            label12.Name = "label12";
            label12.Size = new Size(34, 20);
            label12.TabIndex = 21;
            label12.Text = "CEP";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(479, 333);
            label11.Name = "label11";
            label11.Size = new Size(54, 20);
            label11.TabIndex = 20;
            label11.Text = "Estado";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(216, 333);
            label10.Name = "label10";
            label10.Size = new Size(56, 20);
            label10.TabIndex = 19;
            label10.Text = "Cidade";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(23, 333);
            label9.Name = "label9";
            label9.Size = new Size(49, 20);
            label9.TabIndex = 18;
            label9.Text = "Bairro";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(479, 275);
            label8.Name = "label8";
            label8.Size = new Size(26, 20);
            label8.TabIndex = 17;
            label8.Text = "Nº";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(110, 276);
            label7.Name = "label7";
            label7.Size = new Size(34, 20);
            label7.TabIndex = 16;
            label7.Text = "Rua";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(23, 242);
            label6.Name = "label6";
            label6.Size = new Size(95, 25);
            label6.TabIndex = 15;
            label6.Text = "Endereço";
            // 
            // txtrazaosocial
            // 
            txtrazaosocial.Location = new Point(16, 116);
            txtrazaosocial.Margin = new Padding(3, 4, 3, 4);
            txtrazaosocial.MaxLength = 150;
            txtrazaosocial.Name = "txtrazaosocial";
            txtrazaosocial.Size = new Size(228, 23);
            txtrazaosocial.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(23, 92);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 13;
            label5.Text = "Razão Social";
            // 
            // txtinscricaoestadual
            // 
            txtinscricaoestadual.Location = new Point(269, 116);
            txtinscricaoestadual.Margin = new Padding(3, 4, 3, 4);
            txtinscricaoestadual.MaxLength = 150;
            txtinscricaoestadual.Name = "txtinscricaoestadual";
            txtinscricaoestadual.Size = new Size(208, 23);
            txtinscricaoestadual.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(269, 92);
            label4.Name = "label4";
            label4.Size = new Size(127, 20);
            label4.TabIndex = 11;
            label4.Text = "Inscrição Estadual";
            // 
            // txtcnpj
            // 
            txtcnpj.Location = new Point(64, 153);
            txtcnpj.Margin = new Padding(3, 4, 3, 4);
            txtcnpj.MaxLength = 150;
            txtcnpj.Name = "txtcnpj";
            txtcnpj.Size = new Size(180, 23);
            txtcnpj.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 152);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 9;
            label3.Text = "CNPJ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(119, 27);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 8;
            label2.Text = "Descrição";
            // 
            // txtdescricao
            // 
            txtdescricao.Location = new Point(119, 51);
            txtdescricao.Margin = new Padding(3, 4, 3, 4);
            txtdescricao.MaxLength = 150;
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(357, 23);
            txtdescricao.TabIndex = 7;
            // 
            // txtid
            // 
            txtid.Location = new Point(23, 51);
            txtid.Margin = new Padding(3, 4, 3, 4);
            txtid.Name = "txtid";
            txtid.ReadOnly = true;
            txtid.Size = new Size(69, 23);
            txtid.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 27);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 4;
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
            pbotoes.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pbotoes.Location = new Point(0, 399);
            pbotoes.Name = "pbotoes";
            pbotoes.Size = new Size(1051, 108);
            pbotoes.TabIndex = 1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.Location = new Point(727, 43);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(89, 40);
            btnlocalizar.TabIndex = 11;
            btnlocalizar.Text = "Localizar";
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // btnexcluir
            // 
            btnexcluir.Location = new Point(613, 43);
            btnexcluir.Name = "btnexcluir";
            btnexcluir.Size = new Size(89, 40);
            btnexcluir.TabIndex = 10;
            btnexcluir.Text = "Excluir";
            btnexcluir.UseVisualStyleBackColor = true;
            btnexcluir.Click += btnexcluir_Click;
            // 
            // btncancelar
            // 
            btncancelar.Location = new Point(506, 43);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(89, 40);
            btncancelar.TabIndex = 9;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = true;
            btncancelar.Click += btncancelar_Click;
            // 
            // btnsalvar
            // 
            btnsalvar.Location = new Point(387, 43);
            btnsalvar.Name = "btnsalvar";
            btnsalvar.Size = new Size(89, 40);
            btnsalvar.TabIndex = 8;
            btnsalvar.Text = "Salvar";
            btnsalvar.UseVisualStyleBackColor = true;
            btnsalvar.Click += btnsalvar_Click;
            // 
            // btnalterar
            // 
            btnalterar.Location = new Point(269, 43);
            btnalterar.Name = "btnalterar";
            btnalterar.Size = new Size(89, 40);
            btnalterar.TabIndex = 7;
            btnalterar.Text = "Alterar";
            btnalterar.UseVisualStyleBackColor = true;
            btnalterar.Click += btnalterar_Click;
            // 
            // btnnovo
            // 
            btnnovo.Location = new Point(155, 43);
            btnnovo.Name = "btnnovo";
            btnnovo.Size = new Size(89, 40);
            btnnovo.TabIndex = 6;
            btnnovo.Text = "Novo";
            btnnovo.UseVisualStyleBackColor = true;
            btnnovo.Click += btnnovo_Click;
            // 
            // FrmCadEmpresa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 507);
            Controls.Add(pbotoes);
            Controls.Add(pdados);
            Name = "FrmCadEmpresa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Empresa";
            Load += FrmCadEmpresa_Load;
            pdados.ResumeLayout(false);
            pdados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgAssociarFlat).EndInit();
            pbotoes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pdados;
        private Panel pbotoes;
        private TextBox txtdescricao;
        private TextBox txtid;
        private Label label1;
        private Label label2;
        private TextBox txtcnpj;
        private Label label3;
        private Label label4;
        private TextBox txtinscricaoestadual;
        private Label label5;
        private TextBox txtrazaosocial;
        private Label label6;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label11;
        private Label label10;
        private TextBox txtnumero;
        private TextBox txtrua;
        private Label label12;
        private TextBox txtcep;
        private TextBox txtcidade;
        private TextBox txtestado;
        private TextBox txtbairro;
        private Button btnlocalizar;
        private Button btnexcluir;
        private Button btncancelar;
        private Button btnsalvar;
        private Button btnalterar;
        private Button btnnovo;
        private DataGridView dgAssociarFlat;
        private Label label13;
        private Button btnassociar;
        private Label label14;
        private ComboBox cbbflatsassociados;
        private Button btndesassociar;
    }
}