namespace SistemaFL
{
    partial class FrmCadLancamento
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadLancamento));
            pbotoes = new Panel();
            btnlocalizar = new Button();
            btnsalvar = new Button();
            btnalterar = new Button();
            btnnovo = new Button();
            btnexcluir = new Button();
            btncancelar = new Button();
            txtValorFunReserva = new TextBox();
            txtValorDiv = new TextBox();
            labelValorDiv = new Label();
            labelFundoRes = new Label();
            txtid = new TextBox();
            label6 = new Label();
            btnLocFlatLancamento = new Button();
            txtvaloraluguel = new TextBox();
            labelValorAlguel = new Label();
            dtdataLancamento = new DateTimePicker();
            label4 = new Label();
            txtTipoInvestimento = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtidFlat = new TextBox();
            txtDescricaoFlat = new TextBox();
            label1 = new Label();
            plocalizar = new Panel();
            txtStatus = new TextBox();
            label25 = new Label();
            txtNumMatriculaImovel = new TextBox();
            label7 = new Label();
            txtValoDeCompra = new TextBox();
            label5 = new Label();
            plancamento = new Panel();
            pbfechar = new PictureBox();
            tTamanhotela = new System.Windows.Forms.Timer(components);
            ckOutrosLancamentos = new CheckBox();
            label8 = new Label();
            txtOutrosReceb = new TextBox();
            label9 = new Label();
            txtGanhoCapital = new TextBox();
            label10 = new Label();
            txtRetidoFonte = new TextBox();
            pOutrosLancamentos = new Panel();
            label11 = new Label();
            txtidOutrosLanc = new TextBox();
            pbotoes.SuspendLayout();
            plocalizar.SuspendLayout();
            plancamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbfechar).BeginInit();
            pOutrosLancamentos.SuspendLayout();
            SuspendLayout();
            // 
            // pbotoes
            // 
            pbotoes.BackColor = Color.FromArgb(23, 24, 29);
            pbotoes.Controls.Add(btnlocalizar);
            pbotoes.Controls.Add(btnsalvar);
            pbotoes.Controls.Add(btnalterar);
            pbotoes.Controls.Add(btnnovo);
            pbotoes.Dock = DockStyle.Bottom;
            pbotoes.Location = new Point(0, 493);
            pbotoes.Margin = new Padding(3, 4, 3, 4);
            pbotoes.Name = "pbotoes";
            pbotoes.Size = new Size(1087, 87);
            pbotoes.TabIndex = 1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.BackColor = Color.FromArgb(23, 24, 29);
            btnlocalizar.FlatAppearance.BorderSize = 2;
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            btnlocalizar.ForeColor = Color.White;
            btnlocalizar.Location = new Point(638, 23);
            btnlocalizar.Margin = new Padding(3, 4, 3, 4);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(193, 34);
            btnlocalizar.TabIndex = 17;
            btnlocalizar.Text = "Localizar Lançamentos";
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
            btnsalvar.Location = new Point(489, 23);
            btnsalvar.Margin = new Padding(3, 4, 3, 4);
            btnsalvar.Name = "btnsalvar";
            btnsalvar.Size = new Size(105, 34);
            btnsalvar.TabIndex = 14;
            btnsalvar.Text = "Salvar";
            btnsalvar.UseVisualStyleBackColor = false;
            btnsalvar.Click += btnsalvar_Click;
            // 
            // btnalterar
            // 
            btnalterar.BackColor = Color.FromArgb(23, 24, 29);
            btnalterar.FlatAppearance.BorderSize = 2;
            btnalterar.FlatStyle = FlatStyle.Flat;
            btnalterar.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            btnalterar.ForeColor = Color.White;
            btnalterar.Location = new Point(351, 23);
            btnalterar.Margin = new Padding(3, 4, 3, 4);
            btnalterar.Name = "btnalterar";
            btnalterar.Size = new Size(105, 34);
            btnalterar.TabIndex = 13;
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
            btnnovo.Location = new Point(127, 23);
            btnnovo.Margin = new Padding(3, 4, 3, 4);
            btnnovo.Name = "btnnovo";
            btnnovo.Size = new Size(181, 34);
            btnnovo.TabIndex = 12;
            btnnovo.Text = "Novo Lançamento";
            btnnovo.UseVisualStyleBackColor = false;
            btnnovo.Click += btnnovo_Click;
            // 
            // btnexcluir
            // 
            btnexcluir.BackColor = Color.Transparent;
            btnexcluir.FlatStyle = FlatStyle.Flat;
            btnexcluir.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnexcluir.ForeColor = Color.White;
            btnexcluir.Image = (Image)resources.GetObject("btnexcluir.Image");
            btnexcluir.Location = new Point(297, 13);
            btnexcluir.Margin = new Padding(3, 4, 3, 4);
            btnexcluir.Name = "btnexcluir";
            btnexcluir.Size = new Size(37, 36);
            btnexcluir.TabIndex = 16;
            btnexcluir.UseVisualStyleBackColor = false;
            btnexcluir.Click += btnexcluir_Click;
            // 
            // btncancelar
            // 
            btncancelar.BackColor = Color.Transparent;
            btncancelar.FlatStyle = FlatStyle.Flat;
            btncancelar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btncancelar.ForeColor = Color.White;
            btncancelar.Image = (Image)resources.GetObject("btncancelar.Image");
            btncancelar.Location = new Point(201, 11);
            btncancelar.Margin = new Padding(3, 4, 3, 4);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(39, 38);
            btncancelar.TabIndex = 15;
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += btncancelar_Click;
            // 
            // txtValorFunReserva
            // 
            txtValorFunReserva.Location = new Point(392, 92);
            txtValorFunReserva.Margin = new Padding(3, 4, 3, 4);
            txtValorFunReserva.Name = "txtValorFunReserva";
            txtValorFunReserva.Size = new Size(171, 27);
            txtValorFunReserva.TabIndex = 49;
            // 
            // txtValorDiv
            // 
            txtValorDiv.Location = new Point(205, 92);
            txtValorDiv.Margin = new Padding(3, 4, 3, 4);
            txtValorDiv.Name = "txtValorDiv";
            txtValorDiv.Size = new Size(171, 27);
            txtValorDiv.TabIndex = 48;
            // 
            // labelValorDiv
            // 
            labelValorDiv.AutoSize = true;
            labelValorDiv.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelValorDiv.Location = new Point(205, 68);
            labelValorDiv.Name = "labelValorDiv";
            labelValorDiv.Size = new Size(122, 20);
            labelValorDiv.TabIndex = 47;
            labelValorDiv.Text = "Valor Dividendos";
            // 
            // labelFundoRes
            // 
            labelFundoRes.AutoSize = true;
            labelFundoRes.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFundoRes.Location = new Point(392, 68);
            labelFundoRes.Name = "labelFundoRes";
            labelFundoRes.Size = new Size(143, 20);
            labelFundoRes.TabIndex = 46;
            labelFundoRes.Text = "Valor Fundo Reserva";
            // 
            // txtid
            // 
            txtid.Enabled = false;
            txtid.Location = new Point(34, 354);
            txtid.Margin = new Padding(3, 4, 3, 4);
            txtid.Name = "txtid";
            txtid.ReadOnly = true;
            txtid.Size = new Size(27, 27);
            txtid.TabIndex = 43;
            txtid.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(34, 330);
            label6.Name = "label6";
            label6.Size = new Size(22, 20);
            label6.TabIndex = 42;
            label6.Text = "Id";
            label6.Visible = false;
            // 
            // btnLocFlatLancamento
            // 
            btnLocFlatLancamento.BackColor = Color.White;
            btnLocFlatLancamento.FlatStyle = FlatStyle.Flat;
            btnLocFlatLancamento.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLocFlatLancamento.Location = new Point(16, 141);
            btnLocFlatLancamento.Margin = new Padding(3, 4, 3, 4);
            btnLocFlatLancamento.Name = "btnLocFlatLancamento";
            btnLocFlatLancamento.Size = new Size(224, 32);
            btnLocFlatLancamento.TabIndex = 37;
            btnLocFlatLancamento.Text = "Localizar Flat";
            btnLocFlatLancamento.UseVisualStyleBackColor = false;
            btnLocFlatLancamento.Click += btnLocFlatLancamento_Click_1;
            // 
            // txtvaloraluguel
            // 
            txtvaloraluguel.Location = new Point(13, 92);
            txtvaloraluguel.Margin = new Padding(3, 4, 3, 4);
            txtvaloraluguel.Name = "txtvaloraluguel";
            txtvaloraluguel.Size = new Size(171, 27);
            txtvaloraluguel.TabIndex = 41;
            // 
            // labelValorAlguel
            // 
            labelValorAlguel.AutoSize = true;
            labelValorAlguel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelValorAlguel.Location = new Point(14, 70);
            labelValorAlguel.Name = "labelValorAlguel";
            labelValorAlguel.Size = new Size(98, 20);
            labelValorAlguel.TabIndex = 40;
            labelValorAlguel.Text = "Valor Aluguel";
            // 
            // dtdataLancamento
            // 
            dtdataLancamento.Format = DateTimePickerFormat.Short;
            dtdataLancamento.Location = new Point(16, 30);
            dtdataLancamento.Margin = new Padding(3, 4, 3, 4);
            dtdataLancamento.Name = "dtdataLancamento";
            dtdataLancamento.Size = new Size(137, 27);
            dtdataLancamento.TabIndex = 39;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(13, 8);
            label4.Name = "label4";
            label4.Size = new Size(120, 20);
            label4.TabIndex = 38;
            label4.Text = "Data Pagamento";
            // 
            // txtTipoInvestimento
            // 
            txtTipoInvestimento.BackColor = SystemColors.Control;
            txtTipoInvestimento.Enabled = false;
            txtTipoInvestimento.Location = new Point(15, 88);
            txtTipoInvestimento.Margin = new Padding(3, 4, 3, 4);
            txtTipoInvestimento.Name = "txtTipoInvestimento";
            txtTipoInvestimento.ReadOnly = true;
            txtTipoInvestimento.Size = new Size(225, 27);
            txtTipoInvestimento.TabIndex = 36;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 64);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 35;
            label3.Text = "Tipo Investimento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 8);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 34;
            label2.Text = "Descrição";
            // 
            // txtidFlat
            // 
            txtidFlat.Enabled = false;
            txtidFlat.Location = new Point(22, 121);
            txtidFlat.Margin = new Padding(3, 4, 3, 4);
            txtidFlat.Name = "txtidFlat";
            txtidFlat.ReadOnly = true;
            txtidFlat.Size = new Size(28, 27);
            txtidFlat.TabIndex = 33;
            txtidFlat.Visible = false;
            // 
            // txtDescricaoFlat
            // 
            txtDescricaoFlat.BackColor = SystemColors.Control;
            txtDescricaoFlat.Enabled = false;
            txtDescricaoFlat.Location = new Point(16, 32);
            txtDescricaoFlat.Margin = new Padding(3, 4, 3, 4);
            txtDescricaoFlat.Name = "txtDescricaoFlat";
            txtDescricaoFlat.ReadOnly = true;
            txtDescricaoFlat.Size = new Size(359, 27);
            txtDescricaoFlat.TabIndex = 32;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 100);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 31;
            label1.Text = "Id Flat";
            label1.Visible = false;
            // 
            // plocalizar
            // 
            plocalizar.Controls.Add(txtStatus);
            plocalizar.Controls.Add(label25);
            plocalizar.Controls.Add(txtNumMatriculaImovel);
            plocalizar.Controls.Add(label7);
            plocalizar.Controls.Add(txtValoDeCompra);
            plocalizar.Controls.Add(label5);
            plocalizar.Controls.Add(txtDescricaoFlat);
            plocalizar.Controls.Add(label2);
            plocalizar.Controls.Add(label3);
            plocalizar.Controls.Add(txtTipoInvestimento);
            plocalizar.Controls.Add(btnLocFlatLancamento);
            plocalizar.Location = new Point(76, 57);
            plocalizar.Margin = new Padding(3, 4, 3, 4);
            plocalizar.Name = "plocalizar";
            plocalizar.Size = new Size(665, 192);
            plocalizar.TabIndex = 50;
            // 
            // txtStatus
            // 
            txtStatus.BackColor = SystemColors.Control;
            txtStatus.Enabled = false;
            txtStatus.Location = new Point(392, 32);
            txtStatus.Margin = new Padding(3, 4, 3, 4);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(225, 27);
            txtStatus.TabIndex = 88;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI Semilight", 12F);
            label25.Location = new Point(254, 63);
            label25.Name = "label25";
            label25.Size = new Size(168, 21);
            label25.TabIndex = 87;
            label25.Text = "Nº Matrícula do Imóvel";
            // 
            // txtNumMatriculaImovel
            // 
            txtNumMatriculaImovel.Enabled = false;
            txtNumMatriculaImovel.Font = new Font("Segoe UI Semilight", 12F);
            txtNumMatriculaImovel.Location = new Point(254, 88);
            txtNumMatriculaImovel.Margin = new Padding(3, 4, 3, 4);
            txtNumMatriculaImovel.MaxLength = 150;
            txtNumMatriculaImovel.Name = "txtNumMatriculaImovel";
            txtNumMatriculaImovel.ReadOnly = true;
            txtNumMatriculaImovel.Size = new Size(168, 29);
            txtNumMatriculaImovel.TabIndex = 84;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semilight", 12F);
            label7.Location = new Point(444, 63);
            label7.Name = "label7";
            label7.Size = new Size(124, 21);
            label7.TabIndex = 86;
            label7.Text = "Valor de Compra";
            // 
            // txtValoDeCompra
            // 
            txtValoDeCompra.Enabled = false;
            txtValoDeCompra.Font = new Font("Segoe UI Semilight", 12F);
            txtValoDeCompra.Location = new Point(444, 88);
            txtValoDeCompra.Margin = new Padding(3, 4, 3, 4);
            txtValoDeCompra.MaxLength = 150;
            txtValoDeCompra.Name = "txtValoDeCompra";
            txtValoDeCompra.ReadOnly = true;
            txtValoDeCompra.Size = new Size(171, 29);
            txtValoDeCompra.TabIndex = 85;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semilight", 12F);
            label5.Location = new Point(392, 7);
            label5.Name = "label5";
            label5.Size = new Size(51, 21);
            label5.TabIndex = 39;
            label5.Text = "Status";
            // 
            // plancamento
            // 
            plancamento.Controls.Add(label4);
            plancamento.Controls.Add(txtValorFunReserva);
            plancamento.Controls.Add(dtdataLancamento);
            plancamento.Controls.Add(txtValorDiv);
            plancamento.Controls.Add(labelValorAlguel);
            plancamento.Controls.Add(labelValorDiv);
            plancamento.Controls.Add(txtvaloraluguel);
            plancamento.Controls.Add(labelFundoRes);
            plancamento.Location = new Point(76, 284);
            plancamento.Margin = new Padding(3, 4, 3, 4);
            plancamento.Name = "plancamento";
            plancamento.Size = new Size(665, 150);
            plancamento.TabIndex = 51;
            // 
            // pbfechar
            // 
            pbfechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbfechar.Image = (Image)resources.GetObject("pbfechar.Image");
            pbfechar.Location = new Point(847, 8);
            pbfechar.Name = "pbfechar";
            pbfechar.Size = new Size(30, 21);
            pbfechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbfechar.TabIndex = 52;
            pbfechar.TabStop = false;
            pbfechar.Click += pbfechar_Click;
            // 
            // tTamanhotela
            // 
            tTamanhotela.Interval = 1;
            tTamanhotela.Tick += tTamanhotela_Tick;
            // 
            // ckOutrosLancamentos
            // 
            ckOutrosLancamentos.AutoSize = true;
            ckOutrosLancamentos.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckOutrosLancamentos.Location = new Point(813, 80);
            ckOutrosLancamentos.Name = "ckOutrosLancamentos";
            ckOutrosLancamentos.Size = new Size(170, 25);
            ckOutrosLancamentos.TabIndex = 53;
            ckOutrosLancamentos.Text = "Outros Lançamentos";
            ckOutrosLancamentos.UseVisualStyleBackColor = true;
            ckOutrosLancamentos.CheckedChanged += ckOutrosLancamentos_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(16, 15);
            label8.Name = "label8";
            label8.Size = new Size(151, 20);
            label8.TabIndex = 54;
            label8.Text = "Outros Recebimentos";
            // 
            // txtOutrosReceb
            // 
            txtOutrosReceb.Location = new Point(15, 37);
            txtOutrosReceb.Margin = new Padding(3, 4, 3, 4);
            txtOutrosReceb.Name = "txtOutrosReceb";
            txtOutrosReceb.Size = new Size(171, 27);
            txtOutrosReceb.TabIndex = 55;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(15, 79);
            label9.Name = "label9";
            label9.Size = new Size(162, 20);
            label9.TabIndex = 56;
            label9.Text = "Valor Ganho de Capital";
            // 
            // txtGanhoCapital
            // 
            txtGanhoCapital.Location = new Point(14, 101);
            txtGanhoCapital.Margin = new Padding(3, 4, 3, 4);
            txtGanhoCapital.Name = "txtGanhoCapital";
            txtGanhoCapital.Size = new Size(171, 27);
            txtGanhoCapital.TabIndex = 57;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(15, 144);
            label10.Name = "label10";
            label10.Size = new Size(152, 20);
            label10.TabIndex = 58;
            label10.Text = "Valor Retido na Fonte";
            // 
            // txtRetidoFonte
            // 
            txtRetidoFonte.Location = new Point(14, 168);
            txtRetidoFonte.Margin = new Padding(3, 4, 3, 4);
            txtRetidoFonte.Name = "txtRetidoFonte";
            txtRetidoFonte.Size = new Size(171, 27);
            txtRetidoFonte.TabIndex = 59;
            // 
            // pOutrosLancamentos
            // 
            pOutrosLancamentos.Controls.Add(txtRetidoFonte);
            pOutrosLancamentos.Controls.Add(label10);
            pOutrosLancamentos.Controls.Add(txtOutrosReceb);
            pOutrosLancamentos.Controls.Add(label8);
            pOutrosLancamentos.Controls.Add(label9);
            pOutrosLancamentos.Controls.Add(txtGanhoCapital);
            pOutrosLancamentos.Location = new Point(786, 121);
            pOutrosLancamentos.Name = "pOutrosLancamentos";
            pOutrosLancamentos.Size = new Size(226, 220);
            pOutrosLancamentos.TabIndex = 60;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(924, 25);
            label11.Name = "label11";
            label11.Size = new Size(70, 20);
            label11.TabIndex = 61;
            label11.Text = "Id Outros";
            label11.Visible = false;
            // 
            // txtidOutrosLanc
            // 
            txtidOutrosLanc.Enabled = false;
            txtidOutrosLanc.Location = new Point(935, 46);
            txtidOutrosLanc.Margin = new Padding(3, 4, 3, 4);
            txtidOutrosLanc.Name = "txtidOutrosLanc";
            txtidOutrosLanc.ReadOnly = true;
            txtidOutrosLanc.Size = new Size(28, 27);
            txtidOutrosLanc.TabIndex = 62;
            txtidOutrosLanc.Visible = false;
            // 
            // FrmCadLancamento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1087, 580);
            Controls.Add(label11);
            Controls.Add(txtidOutrosLanc);
            Controls.Add(pOutrosLancamentos);
            Controls.Add(ckOutrosLancamentos);
            Controls.Add(txtid);
            Controls.Add(label1);
            Controls.Add(pbfechar);
            Controls.Add(btnexcluir);
            Controls.Add(txtidFlat);
            Controls.Add(plancamento);
            Controls.Add(btncancelar);
            Controls.Add(plocalizar);
            Controls.Add(pbotoes);
            Controls.Add(label6);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmCadLancamento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro Lançamento";
            Load += FrmCadLancamento_Load;
            pbotoes.ResumeLayout(false);
            plocalizar.ResumeLayout(false);
            plocalizar.PerformLayout();
            plancamento.ResumeLayout(false);
            plancamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbfechar).EndInit();
            pOutrosLancamentos.ResumeLayout(false);
            pOutrosLancamentos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel pbotoes;
        private Button btnlocalizar;
        private Button btnexcluir;
        private Button btncancelar;
        private Button btnsalvar;
        private Button btnalterar;
        private Button btnnovo;
        private TextBox txtValorFunReserva;
        private TextBox txtValorDiv;
        private Label labelValorDiv;
        private Label labelFundoRes;
        private TextBox txtid;
        private Label label6;
        private Button btnLocFlatLancamento;
        private TextBox txtvaloraluguel;
        private Label labelValorAlguel;
        private DateTimePicker dtdataLancamento;
        private Label label4;
        private TextBox txtTipoInvestimento;
        private Label label3;
        private Label label2;
        private TextBox txtidFlat;
        private TextBox txtDescricaoFlat;
        private Label label1;
        private Panel plocalizar;
        private Panel plancamento;
        private PictureBox pbfechar;
        private System.Windows.Forms.Timer tTamanhotela;
        private Label label5;
        private Label label25;
        private TextBox txtNumMatriculaImovel;
        private Label label7;
        private TextBox txtValoDeCompra;
        private TextBox txtStatus;
        private CheckBox ckOutrosLancamentos;
        private Label label8;
        private TextBox txtOutrosReceb;
        private Label label9;
        private TextBox txtGanhoCapital;
        private Label label10;
        private TextBox txtRetidoFonte;
        private Panel pOutrosLancamentos;
        private Label label11;
        private TextBox txtidOutrosLanc;
    }
}