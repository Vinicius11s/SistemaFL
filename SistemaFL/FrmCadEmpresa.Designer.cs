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
            label1 = new Label();
            txtid = new TextBox();
            txtdescricao = new TextBox();
            txtcnpj = new TextBox();
            label4 = new Label();
            txtinscricaoestadual = new TextBox();
            txtrazaosocial = new TextBox();
            label11 = new Label();
            label12 = new Label();
            txtrua = new TextBox();
            txtnumero = new TextBox();
            txtcep = new TextBox();
            txtestado = new TextBox();
            txtcidade = new TextBox();
            txtbairro = new TextBox();
            dgAssociarFlat = new DataGridView();
            label13 = new Label();
            label14 = new Label();
            btnassociar = new Button();
            cbbflatsassociados = new ComboBox();
            btndesassociar = new Button();
            pdados = new Panel();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            pbotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgAssociarFlat).BeginInit();
            pdados.SuspendLayout();
            SuspendLayout();
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
            pbotoes.Location = new Point(0, 375);
            pbotoes.Name = "pbotoes";
            pbotoes.Size = new Size(915, 108);
            pbotoes.TabIndex = 1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.Location = new Point(714, 42);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(89, 40);
            btnlocalizar.TabIndex = 11;
            btnlocalizar.Text = "Localizar";
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // btnexcluir
            // 
            btnexcluir.Location = new Point(595, 42);
            btnexcluir.Name = "btnexcluir";
            btnexcluir.Size = new Size(89, 40);
            btnexcluir.TabIndex = 10;
            btnexcluir.Text = "Excluir";
            btnexcluir.UseVisualStyleBackColor = true;
            btnexcluir.Click += btnexcluir_Click;
            // 
            // btncancelar
            // 
            btncancelar.Location = new Point(472, 42);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(89, 40);
            btncancelar.TabIndex = 9;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = true;
            btncancelar.Click += btncancelar_Click;
            // 
            // btnsalvar
            // 
            btnsalvar.Location = new Point(350, 42);
            btnsalvar.Name = "btnsalvar";
            btnsalvar.Size = new Size(89, 40);
            btnsalvar.TabIndex = 8;
            btnsalvar.Text = "Salvar";
            btnsalvar.UseVisualStyleBackColor = true;
            btnsalvar.Click += btnsalvar_Click;
            // 
            // btnalterar
            // 
            btnalterar.Location = new Point(233, 42);
            btnalterar.Name = "btnalterar";
            btnalterar.Size = new Size(89, 40);
            btnalterar.TabIndex = 7;
            btnalterar.Text = "Alterar";
            btnalterar.UseVisualStyleBackColor = true;
            btnalterar.Click += btnalterar_Click;
            // 
            // btnnovo
            // 
            btnnovo.Location = new Point(114, 42);
            btnnovo.Name = "btnnovo";
            btnnovo.Size = new Size(89, 40);
            btnnovo.TabIndex = 6;
            btnnovo.Text = "Novo";
            btnnovo.UseVisualStyleBackColor = true;
            btnnovo.Click += btnnovo_Click;
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
            // txtid
            // 
            txtid.Location = new Point(23, 51);
            txtid.Margin = new Padding(3, 4, 3, 4);
            txtid.Name = "txtid";
            txtid.ReadOnly = true;
            txtid.Size = new Size(69, 23);
            txtid.TabIndex = 5;
            // 
            // txtdescricao
            // 
            txtdescricao.Location = new Point(23, 102);
            txtdescricao.Margin = new Padding(3, 4, 3, 4);
            txtdescricao.MaxLength = 150;
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(357, 23);
            txtdescricao.TabIndex = 7;
            // 
            // txtcnpj
            // 
            txtcnpj.Location = new Point(23, 199);
            txtcnpj.Margin = new Padding(3, 4, 3, 4);
            txtcnpj.MaxLength = 150;
            txtcnpj.Name = "txtcnpj";
            txtcnpj.Size = new Size(180, 23);
            txtcnpj.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(218, 129);
            label4.Name = "label4";
            label4.Size = new Size(127, 20);
            label4.TabIndex = 11;
            label4.Text = "Inscrição Estadual";
            // 
            // txtinscricaoestadual
            // 
            txtinscricaoestadual.Location = new Point(218, 148);
            txtinscricaoestadual.Margin = new Padding(3, 4, 3, 4);
            txtinscricaoestadual.MaxLength = 150;
            txtinscricaoestadual.Name = "txtinscricaoestadual";
            txtinscricaoestadual.Size = new Size(162, 23);
            txtinscricaoestadual.TabIndex = 12;
            // 
            // txtrazaosocial
            // 
            txtrazaosocial.Location = new Point(23, 148);
            txtrazaosocial.Margin = new Padding(3, 4, 3, 4);
            txtrazaosocial.MaxLength = 150;
            txtrazaosocial.Name = "txtrazaosocial";
            txtrazaosocial.Size = new Size(175, 23);
            txtrazaosocial.TabIndex = 14;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(350, 300);
            label11.Name = "label11";
            label11.Size = new Size(54, 20);
            label11.TabIndex = 20;
            label11.Text = "Estado";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(23, 262);
            label12.Name = "label12";
            label12.Size = new Size(34, 20);
            label12.TabIndex = 21;
            label12.Text = "CEP";
            // 
            // txtrua
            // 
            txtrua.Location = new Point(204, 262);
            txtrua.Margin = new Padding(3, 4, 3, 4);
            txtrua.MaxLength = 150;
            txtrua.Name = "txtrua";
            txtrua.Size = new Size(260, 23);
            txtrua.TabIndex = 22;
            // 
            // txtnumero
            // 
            txtnumero.Location = new Point(292, 299);
            txtnumero.Margin = new Padding(3, 4, 3, 4);
            txtnumero.MaxLength = 150;
            txtnumero.Name = "txtnumero";
            txtnumero.Size = new Size(43, 23);
            txtnumero.TabIndex = 23;
            // 
            // txtcep
            // 
            txtcep.Location = new Point(63, 261);
            txtcep.Margin = new Padding(3, 4, 3, 4);
            txtcep.MaxLength = 150;
            txtcep.Name = "txtcep";
            txtcep.Size = new Size(81, 23);
            txtcep.TabIndex = 24;
            // 
            // txtestado
            // 
            txtestado.Location = new Point(407, 300);
            txtestado.Margin = new Padding(3, 4, 3, 4);
            txtestado.MaxLength = 150;
            txtestado.Name = "txtestado";
            txtestado.Size = new Size(57, 23);
            txtestado.TabIndex = 25;
            // 
            // txtcidade
            // 
            txtcidade.Location = new Point(63, 343);
            txtcidade.Margin = new Padding(3, 4, 3, 4);
            txtcidade.MaxLength = 150;
            txtcidade.Name = "txtcidade";
            txtcidade.Size = new Size(168, 23);
            txtcidade.TabIndex = 26;
            // 
            // txtbairro
            // 
            txtbairro.Location = new Point(63, 299);
            txtbairro.Margin = new Padding(3, 4, 3, 4);
            txtbairro.MaxLength = 150;
            txtbairro.Name = "txtbairro";
            txtbairro.Size = new Size(168, 23);
            txtbairro.TabIndex = 27;
            // 
            // dgAssociarFlat
            // 
            dgAssociarFlat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAssociarFlat.Location = new Point(506, 128);
            dgAssociarFlat.Name = "dgAssociarFlat";
            dgAssociarFlat.Size = new Size(376, 167);
            dgAssociarFlat.TabIndex = 28;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(613, 97);
            label13.Name = "label13";
            label13.Size = new Size(122, 25);
            label13.TabIndex = 29;
            label13.Text = "Associar Flat";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(506, 50);
            label14.Name = "label14";
            label14.Size = new Size(115, 20);
            label14.TabIndex = 30;
            label14.Text = "Flats associados";
            // 
            // btnassociar
            // 
            btnassociar.Location = new Point(595, 312);
            btnassociar.Name = "btnassociar";
            btnassociar.Size = new Size(89, 40);
            btnassociar.TabIndex = 12;
            btnassociar.Text = "Associar";
            btnassociar.UseVisualStyleBackColor = true;
            btnassociar.Click += btnassociar_Click_1;
            // 
            // cbbflatsassociados
            // 
            cbbflatsassociados.FormattingEnabled = true;
            cbbflatsassociados.Location = new Point(627, 51);
            cbbflatsassociados.Name = "cbbflatsassociados";
            cbbflatsassociados.Size = new Size(232, 23);
            cbbflatsassociados.TabIndex = 31;
            // 
            // btndesassociar
            // 
            btndesassociar.Location = new Point(733, 312);
            btndesassociar.Name = "btndesassociar";
            btndesassociar.Size = new Size(89, 40);
            btndesassociar.TabIndex = 32;
            btndesassociar.Text = "Desassociar";
            btndesassociar.UseVisualStyleBackColor = true;
            btndesassociar.Click += btndesassociar_Click;
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
            pdados.Size = new Size(915, 393);
            pdados.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(12, 342);
            label10.Name = "label10";
            label10.Size = new Size(56, 20);
            label10.TabIndex = 19;
            label10.Text = "Cidade";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(12, 300);
            label9.Name = "label9";
            label9.Size = new Size(49, 20);
            label9.TabIndex = 18;
            label9.Text = "Bairro";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(260, 300);
            label8.Name = "label8";
            label8.Size = new Size(26, 20);
            label8.TabIndex = 17;
            label8.Text = "Nº";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(164, 261);
            label7.Name = "label7";
            label7.Size = new Size(34, 20);
            label7.TabIndex = 16;
            label7.Text = "Rua";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(23, 129);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 13;
            label5.Text = "Razão Social";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 175);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 9;
            label3.Text = "CNPJ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 78);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 8;
            label2.Text = "Descrição";
            // 
            // FrmCadEmpresa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 483);
            Controls.Add(pbotoes);
            Controls.Add(pdados);
            Name = "FrmCadEmpresa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Empresa";
            Load += FrmCadEmpresa_Load;
            pbotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgAssociarFlat).EndInit();
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
        private Label label1;
        private TextBox txtid;
        private TextBox txtdescricao;
        private TextBox txtcnpj;
        private Label label4;
        private TextBox txtinscricaoestadual;
        private TextBox txtrazaosocial;
        private Label label11;
        private Label label12;
        private TextBox txtrua;
        private TextBox txtnumero;
        private TextBox txtcep;
        private TextBox txtestado;
        private TextBox txtcidade;
        private TextBox txtbairro;
        private DataGridView dgAssociarFlat;
        private Label label13;
        private Label label14;
        private Button btnassociar;
        private ComboBox cbbflatsassociados;
        private Button btndesassociar;
        private Panel pdados;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label5;
        private Label label3;
        private Label label2;
    }
}