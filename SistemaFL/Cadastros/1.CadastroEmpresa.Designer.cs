namespace SistemaFL
{
    partial class FrmCadEmpresaFF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadEmpresaFF));
            pdados = new Panel();
            txtcidade = new TextBox();
            label11 = new Label();
            txtestado = new TextBox();
            label10 = new Label();
            txtbairro = new TextBox();
            label9 = new Label();
            txtnumero = new TextBox();
            label8 = new Label();
            txtrua = new TextBox();
            label7 = new Label();
            txtcep = new TextBox();
            label6 = new Label();
            txtrazaosocial = new TextBox();
            label5 = new Label();
            txtcnpj = new TextBox();
            label4 = new Label();
            txtinscricaoestadual = new TextBox();
            label3 = new Label();
            txtdescricao = new TextBox();
            label2 = new Label();
            txtid = new TextBox();
            label1 = new Label();
            cbbflatsassociados = new ComboBox();
            label13 = new Label();
            panel2 = new Panel();
            btnlocalizar = new Button();
            btnsalvar = new Button();
            btnalterar = new Button();
            btnnovo = new Button();
            btnexcluir = new Button();
            btncancelar = new Button();
            passociar = new Panel();
            btnremover = new Button();
            btnassociar = new Button();
            dgAssociarFlat = new DataGridView();
            pbFechar = new PictureBox();
            pbMinimizar = new PictureBox();
            pdados.SuspendLayout();
            panel2.SuspendLayout();
            passociar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgAssociarFlat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            SuspendLayout();
            // 
            // pdados
            // 
            pdados.BackColor = Color.White;
            pdados.Controls.Add(txtcidade);
            pdados.Controls.Add(label11);
            pdados.Controls.Add(txtestado);
            pdados.Controls.Add(label10);
            pdados.Controls.Add(txtbairro);
            pdados.Controls.Add(label9);
            pdados.Controls.Add(txtnumero);
            pdados.Controls.Add(label8);
            pdados.Controls.Add(txtrua);
            pdados.Controls.Add(label7);
            pdados.Controls.Add(txtcep);
            pdados.Controls.Add(label6);
            pdados.Controls.Add(txtrazaosocial);
            pdados.Controls.Add(label5);
            pdados.Controls.Add(txtcnpj);
            pdados.Controls.Add(label4);
            pdados.Controls.Add(txtinscricaoestadual);
            pdados.Controls.Add(label3);
            pdados.Controls.Add(txtdescricao);
            pdados.Controls.Add(label2);
            pdados.Controls.Add(txtid);
            pdados.Controls.Add(label1);
            pdados.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pdados.ForeColor = Color.White;
            pdados.Location = new Point(34, 35);
            pdados.Name = "pdados";
            pdados.Size = new Size(396, 328);
            pdados.TabIndex = 0;
            // 
            // txtcidade
            // 
            txtcidade.Location = new Point(229, 270);
            txtcidade.Name = "txtcidade";
            txtcidade.Size = new Size(146, 29);
            txtcidade.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Black;
            label11.Location = new Point(229, 247);
            label11.Name = "label11";
            label11.Size = new Size(58, 21);
            label11.TabIndex = 20;
            label11.Text = "Cidade";
            // 
            // txtestado
            // 
            txtestado.Location = new Point(163, 270);
            txtestado.Name = "txtestado";
            txtestado.Size = new Size(50, 29);
            txtestado.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Black;
            label10.Location = new Point(161, 247);
            label10.Name = "label10";
            label10.Size = new Size(29, 21);
            label10.TabIndex = 18;
            label10.Text = "UF";
            // 
            // txtbairro
            // 
            txtbairro.Location = new Point(20, 270);
            txtbairro.Name = "txtbairro";
            txtbairro.Size = new Size(134, 29);
            txtbairro.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.Black;
            label9.Location = new Point(20, 247);
            label9.Name = "label9";
            label9.Size = new Size(50, 21);
            label9.TabIndex = 16;
            label9.Text = "Bairro";
            // 
            // txtnumero
            // 
            txtnumero.Location = new Point(332, 214);
            txtnumero.Name = "txtnumero";
            txtnumero.Size = new Size(43, 29);
            txtnumero.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Black;
            label8.Location = new Point(300, 217);
            label8.Name = "label8";
            label8.Size = new Size(28, 21);
            label8.TabIndex = 14;
            label8.Text = "N°";
            // 
            // txtrua
            // 
            txtrua.Location = new Point(20, 214);
            txtrua.Name = "txtrua";
            txtrua.Size = new Size(265, 29);
            txtrua.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(20, 194);
            label7.Name = "label7";
            label7.Size = new Size(36, 21);
            label7.TabIndex = 12;
            label7.Text = "Rua";
            // 
            // txtcep
            // 
            txtcep.Location = new Point(191, 144);
            txtcep.Name = "txtcep";
            txtcep.Size = new Size(152, 29);
            txtcep.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(191, 121);
            label6.Name = "label6";
            label6.Size = new Size(37, 21);
            label6.TabIndex = 10;
            label6.Text = "CEP";
            // 
            // txtrazaosocial
            // 
            txtrazaosocial.Location = new Point(21, 144);
            txtrazaosocial.Name = "txtrazaosocial";
            txtrazaosocial.Size = new Size(152, 29);
            txtrazaosocial.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(20, 121);
            label5.Name = "label5";
            label5.Size = new Size(95, 21);
            label5.TabIndex = 8;
            label5.Text = "Razão Social";
            // 
            // txtcnpj
            // 
            txtcnpj.Location = new Point(191, 83);
            txtcnpj.Name = "txtcnpj";
            txtcnpj.Size = new Size(152, 29);
            txtcnpj.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(188, 60);
            label4.Name = "label4";
            label4.Size = new Size(45, 21);
            label4.TabIndex = 6;
            label4.Text = "CNPJ";
            // 
            // txtinscricaoestadual
            // 
            txtinscricaoestadual.Location = new Point(21, 85);
            txtinscricaoestadual.Name = "txtinscricaoestadual";
            txtinscricaoestadual.Size = new Size(152, 29);
            txtinscricaoestadual.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(21, 62);
            label3.Name = "label3";
            label3.Size = new Size(132, 21);
            label3.TabIndex = 4;
            label3.Text = "Inscrição Estadual";
            // 
            // txtdescricao
            // 
            txtdescricao.Location = new Point(90, 28);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(285, 29);
            txtdescricao.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(90, 7);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 2;
            label2.Text = "Descrição";
            // 
            // txtid
            // 
            txtid.Location = new Point(21, 28);
            txtid.Name = "txtid";
            txtid.ReadOnly = true;
            txtid.Size = new Size(57, 29);
            txtid.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(21, 7);
            label1.Name = "label1";
            label1.Size = new Size(60, 21);
            label1.TabIndex = 0;
            label1.Text = "Código";
            // 
            // cbbflatsassociados
            // 
            cbbflatsassociados.Font = new Font("Segoe UI Semilight", 11.25F);
            cbbflatsassociados.FormattingEnabled = true;
            cbbflatsassociados.Location = new Point(39, 267);
            cbbflatsassociados.Name = "cbbflatsassociados";
            cbbflatsassociados.Size = new Size(200, 28);
            cbbflatsassociados.TabIndex = 22;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI Semilight", 11.25F);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(39, 242);
            label13.Name = "label13";
            label13.Size = new Size(113, 20);
            label13.TabIndex = 8;
            label13.Text = "Flats associados";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(23, 24, 29);
            panel2.Controls.Add(btnlocalizar);
            panel2.Controls.Add(btnsalvar);
            panel2.Controls.Add(btnalterar);
            panel2.Controls.Add(btnnovo);
            panel2.Dock = DockStyle.Bottom;
            panel2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel2.Location = new Point(0, 385);
            panel2.Name = "panel2";
            panel2.Size = new Size(891, 83);
            panel2.TabIndex = 1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.BackColor = Color.Transparent;
            btnlocalizar.FlatAppearance.BorderSize = 2;
            btnlocalizar.FlatAppearance.MouseDownBackColor = Color.Black;
            btnlocalizar.FlatAppearance.MouseOverBackColor = Color.Black;
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnlocalizar.ForeColor = Color.White;
            btnlocalizar.Location = new Point(584, 20);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(100, 40);
            btnlocalizar.TabIndex = 5;
            btnlocalizar.Text = "Localizar";
            btnlocalizar.UseVisualStyleBackColor = false;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // btnsalvar
            // 
            btnsalvar.BackColor = Color.Transparent;
            btnsalvar.FlatAppearance.BorderSize = 2;
            btnsalvar.FlatAppearance.MouseDownBackColor = Color.Black;
            btnsalvar.FlatAppearance.MouseOverBackColor = Color.Black;
            btnsalvar.FlatStyle = FlatStyle.Flat;
            btnsalvar.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnsalvar.ForeColor = Color.White;
            btnsalvar.Location = new Point(467, 20);
            btnsalvar.Name = "btnsalvar";
            btnsalvar.Size = new Size(91, 40);
            btnsalvar.TabIndex = 2;
            btnsalvar.Text = "Gravar";
            btnsalvar.UseVisualStyleBackColor = false;
            btnsalvar.Click += btnsalvar_Click;
            // 
            // btnalterar
            // 
            btnalterar.BackColor = Color.Transparent;
            btnalterar.FlatAppearance.BorderSize = 2;
            btnalterar.FlatAppearance.MouseDownBackColor = Color.Black;
            btnalterar.FlatAppearance.MouseOverBackColor = Color.Black;
            btnalterar.FlatStyle = FlatStyle.Flat;
            btnalterar.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnalterar.ForeColor = Color.White;
            btnalterar.Location = new Point(339, 20);
            btnalterar.Name = "btnalterar";
            btnalterar.Size = new Size(91, 40);
            btnalterar.TabIndex = 1;
            btnalterar.Text = "Alterar";
            btnalterar.UseVisualStyleBackColor = false;
            btnalterar.Click += btnalterar_Click;
            // 
            // btnnovo
            // 
            btnnovo.BackColor = Color.Transparent;
            btnnovo.FlatAppearance.BorderColor = Color.White;
            btnnovo.FlatAppearance.BorderSize = 2;
            btnnovo.FlatAppearance.MouseDownBackColor = Color.Black;
            btnnovo.FlatAppearance.MouseOverBackColor = Color.Black;
            btnnovo.FlatStyle = FlatStyle.Flat;
            btnnovo.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnnovo.ForeColor = Color.White;
            btnnovo.Location = new Point(198, 20);
            btnnovo.Name = "btnnovo";
            btnnovo.Size = new Size(102, 40);
            btnnovo.TabIndex = 0;
            btnnovo.Text = "Novo";
            btnnovo.UseVisualStyleBackColor = false;
            btnnovo.Click += btnnovo_Click;
            // 
            // btnexcluir
            // 
            btnexcluir.BackColor = Color.Transparent;
            btnexcluir.FlatAppearance.BorderSize = 2;
            btnexcluir.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnexcluir.ForeColor = Color.White;
            btnexcluir.Image = (Image)resources.GetObject("btnexcluir.Image");
            btnexcluir.Location = new Point(830, 175);
            btnexcluir.Name = "btnexcluir";
            btnexcluir.Size = new Size(36, 37);
            btnexcluir.TabIndex = 4;
            btnexcluir.UseVisualStyleBackColor = false;
            btnexcluir.Click += btnexcluir_Click;
            // 
            // btncancelar
            // 
            btncancelar.BackColor = Color.Transparent;
            btncancelar.FlatAppearance.BorderSize = 2;
            btncancelar.FlatStyle = FlatStyle.Popup;
            btncancelar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btncancelar.ForeColor = Color.White;
            btncancelar.Image = (Image)resources.GetObject("btncancelar.Image");
            btncancelar.Location = new Point(830, 114);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(36, 37);
            btncancelar.TabIndex = 3;
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += btncancelar_Click;
            // 
            // passociar
            // 
            passociar.BackColor = Color.White;
            passociar.Controls.Add(cbbflatsassociados);
            passociar.Controls.Add(label13);
            passociar.Controls.Add(btnremover);
            passociar.Controls.Add(btnassociar);
            passociar.Controls.Add(dgAssociarFlat);
            passociar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passociar.Location = new Point(430, 35);
            passociar.Name = "passociar";
            passociar.Size = new Size(377, 328);
            passociar.TabIndex = 2;
            // 
            // btnremover
            // 
            btnremover.FlatAppearance.BorderSize = 0;
            btnremover.FlatStyle = FlatStyle.Flat;
            btnremover.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnremover.ForeColor = Color.FromArgb(224, 224, 224);
            btnremover.Image = (Image)resources.GetObject("btnremover.Image");
            btnremover.Location = new Point(242, 263);
            btnremover.Name = "btnremover";
            btnremover.Size = new Size(35, 34);
            btnremover.TabIndex = 7;
            btnremover.UseVisualStyleBackColor = true;
            btnremover.Click += btnremover_Click;
            // 
            // btnassociar
            // 
            btnassociar.FlatAppearance.BorderSize = 2;
            btnassociar.FlatStyle = FlatStyle.Flat;
            btnassociar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnassociar.ForeColor = Color.FromArgb(224, 224, 224);
            btnassociar.Image = (Image)resources.GetObject("btnassociar.Image");
            btnassociar.Location = new Point(317, 203);
            btnassociar.Name = "btnassociar";
            btnassociar.Size = new Size(37, 27);
            btnassociar.TabIndex = 6;
            btnassociar.UseVisualStyleBackColor = true;
            btnassociar.Click += btnassociar_Click;
            // 
            // dgAssociarFlat
            // 
            dgAssociarFlat.BackgroundColor = Color.White;
            dgAssociarFlat.BorderStyle = BorderStyle.None;
            dgAssociarFlat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAssociarFlat.Location = new Point(23, 22);
            dgAssociarFlat.Name = "dgAssociarFlat";
            dgAssociarFlat.Size = new Size(331, 175);
            dgAssociarFlat.TabIndex = 1;
            // 
            // pbFechar
            // 
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(857, 5);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(30, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 49;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // pbMinimizar
            // 
            pbMinimizar.Image = (Image)resources.GetObject("pbMinimizar.Image");
            pbMinimizar.Location = new Point(824, 5);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(30, 21);
            pbMinimizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMinimizar.TabIndex = 50;
            pbMinimizar.TabStop = false;
            pbMinimizar.Click += pbMinimizar_Click;
            // 
            // FrmCadEmpresaFF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(891, 468);
            Controls.Add(pbMinimizar);
            Controls.Add(pbFechar);
            Controls.Add(btnexcluir);
            Controls.Add(passociar);
            Controls.Add(btncancelar);
            Controls.Add(panel2);
            Controls.Add(pdados);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmCadEmpresaFF";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro Empresa";
            Load += FrmCadEmpresaFF_Load;
            pdados.ResumeLayout(false);
            pdados.PerformLayout();
            panel2.ResumeLayout(false);
            passociar.ResumeLayout(false);
            passociar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgAssociarFlat).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pdados;
        private Label label1;
        private TextBox txtid;
        private TextBox txtdescricao;
        private Label label2;
        private TextBox txtcnpj;
        private Label label4;
        private TextBox txtinscricaoestadual;
        private Label label3;
        private TextBox txtrazaosocial;
        private Label label5;
        private TextBox txtnumero;
        private Label label8;
        private TextBox txtrua;
        private Label label7;
        private TextBox txtcep;
        private Label label6;
        private TextBox txtcidade;
        private Label label11;
        private TextBox txtestado;
        private Label label10;
        private TextBox txtbairro;
        private Label label9;
        private Panel panel2;
        private Button btnexcluir;
        private Button btncancelar;
        private Button btnsalvar;
        private Button btnalterar;
        private Button btnnovo;
        private Button btnlocalizar;
        private ComboBox cbbflatsassociados;
        private Label label13;
        private Panel passociar;
        private Button btnremover;
        private Button btnassociar;
        private DataGridView dgAssociarFlat;
        private PictureBox pbFechar;
        private PictureBox pbMinimizar;
    }
}