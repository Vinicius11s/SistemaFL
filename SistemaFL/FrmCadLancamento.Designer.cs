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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadLancamento));
            pbotoes = new Panel();
            btnlocalizar = new Button();
            btnexcluir = new Button();
            btncancelar = new Button();
            btnsalvar = new Button();
            btnalterar = new Button();
            btnnovo = new Button();
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
            txttipoInvestimento = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtidFlat = new TextBox();
            txtDescricaoFlat = new TextBox();
            label1 = new Label();
            plocalizar = new Panel();
            plancamento = new Panel();
            pbfechar = new PictureBox();
            pbotoes.SuspendLayout();
            plocalizar.SuspendLayout();
            plancamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbfechar).BeginInit();
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
            pbotoes.Location = new Point(0, 381);
            pbotoes.Margin = new Padding(3, 4, 3, 4);
            pbotoes.Name = "pbotoes";
            pbotoes.Size = new Size(891, 87);
            pbotoes.TabIndex = 1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.BackColor = Color.FromArgb(23, 24, 29);
            btnlocalizar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnlocalizar.ForeColor = Color.White;
            btnlocalizar.Location = new Point(731, 16);
            btnlocalizar.Margin = new Padding(3, 4, 3, 4);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(106, 57);
            btnlocalizar.TabIndex = 17;
            btnlocalizar.Text = "Localizar";
            btnlocalizar.UseVisualStyleBackColor = false;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // btnexcluir
            // 
            btnexcluir.BackColor = Color.FromArgb(23, 24, 29);
            btnexcluir.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnexcluir.ForeColor = Color.White;
            btnexcluir.Location = new Point(601, 16);
            btnexcluir.Margin = new Padding(3, 4, 3, 4);
            btnexcluir.Name = "btnexcluir";
            btnexcluir.Size = new Size(106, 57);
            btnexcluir.TabIndex = 16;
            btnexcluir.Text = "Excluir";
            btnexcluir.UseVisualStyleBackColor = false;
            btnexcluir.Click += btnexcluir_Click;
            // 
            // btncancelar
            // 
            btncancelar.BackColor = Color.FromArgb(23, 24, 29);
            btncancelar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btncancelar.ForeColor = Color.White;
            btncancelar.Location = new Point(479, 16);
            btncancelar.Margin = new Padding(3, 4, 3, 4);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(106, 57);
            btncancelar.TabIndex = 15;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += btncancelar_Click;
            // 
            // btnsalvar
            // 
            btnsalvar.BackColor = Color.FromArgb(23, 24, 29);
            btnsalvar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnsalvar.ForeColor = Color.White;
            btnsalvar.Location = new Point(343, 16);
            btnsalvar.Margin = new Padding(3, 4, 3, 4);
            btnsalvar.Name = "btnsalvar";
            btnsalvar.Size = new Size(106, 57);
            btnsalvar.TabIndex = 14;
            btnsalvar.Text = "Salvar";
            btnsalvar.UseVisualStyleBackColor = false;
            btnsalvar.Click += btnsalvar_Click;
            // 
            // btnalterar
            // 
            btnalterar.BackColor = Color.FromArgb(23, 24, 29);
            btnalterar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnalterar.ForeColor = Color.White;
            btnalterar.Location = new Point(208, 16);
            btnalterar.Margin = new Padding(3, 4, 3, 4);
            btnalterar.Name = "btnalterar";
            btnalterar.Size = new Size(106, 57);
            btnalterar.TabIndex = 13;
            btnalterar.Text = "Alterar";
            btnalterar.UseVisualStyleBackColor = false;
            btnalterar.Click += btnalterar_Click;
            // 
            // btnnovo
            // 
            btnnovo.BackColor = Color.FromArgb(23, 24, 29);
            btnnovo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnnovo.ForeColor = Color.White;
            btnnovo.Location = new Point(78, 16);
            btnnovo.Margin = new Padding(3, 4, 3, 4);
            btnnovo.Name = "btnnovo";
            btnnovo.Size = new Size(106, 57);
            btnnovo.TabIndex = 12;
            btnnovo.Text = "Novo";
            btnnovo.UseVisualStyleBackColor = false;
            btnnovo.Click += btnnovo_Click;
            // 
            // txtValorFunReserva
            // 
            txtValorFunReserva.Location = new Point(179, 237);
            txtValorFunReserva.Margin = new Padding(3, 4, 3, 4);
            txtValorFunReserva.Name = "txtValorFunReserva";
            txtValorFunReserva.Size = new Size(111, 27);
            txtValorFunReserva.TabIndex = 49;
            // 
            // txtValorDiv
            // 
            txtValorDiv.Location = new Point(179, 192);
            txtValorDiv.Margin = new Padding(3, 4, 3, 4);
            txtValorDiv.Name = "txtValorDiv";
            txtValorDiv.Size = new Size(111, 27);
            txtValorDiv.TabIndex = 48;
            // 
            // labelValorDiv
            // 
            labelValorDiv.AutoSize = true;
            labelValorDiv.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelValorDiv.Location = new Point(38, 196);
            labelValorDiv.Name = "labelValorDiv";
            labelValorDiv.Size = new Size(122, 20);
            labelValorDiv.TabIndex = 47;
            labelValorDiv.Text = "Valor Dividendos";
            // 
            // labelFundoRes
            // 
            labelFundoRes.AutoSize = true;
            labelFundoRes.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFundoRes.Location = new Point(14, 241);
            labelFundoRes.Name = "labelFundoRes";
            labelFundoRes.Size = new Size(143, 20);
            labelFundoRes.TabIndex = 46;
            labelFundoRes.Text = "Valor Fundo Reserva";
            // 
            // txtid
            // 
            txtid.Enabled = false;
            txtid.Location = new Point(82, 89);
            txtid.Margin = new Padding(3, 4, 3, 4);
            txtid.Name = "txtid";
            txtid.ReadOnly = true;
            txtid.Size = new Size(27, 27);
            txtid.TabIndex = 43;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(82, 59);
            label6.Name = "label6";
            label6.Size = new Size(22, 20);
            label6.TabIndex = 42;
            label6.Text = "Id";
            // 
            // btnLocFlatLancamento
            // 
            btnLocFlatLancamento.BackColor = Color.White;
            btnLocFlatLancamento.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLocFlatLancamento.Location = new Point(102, 227);
            btnLocFlatLancamento.Margin = new Padding(3, 4, 3, 4);
            btnLocFlatLancamento.Name = "btnLocFlatLancamento";
            btnLocFlatLancamento.Size = new Size(117, 52);
            btnLocFlatLancamento.TabIndex = 37;
            btnLocFlatLancamento.Text = "Localizar Flat";
            btnLocFlatLancamento.UseVisualStyleBackColor = false;
            btnLocFlatLancamento.Click += btnLocFlatLancamento_Click_1;
            // 
            // txtvaloraluguel
            // 
            txtvaloraluguel.Location = new Point(179, 145);
            txtvaloraluguel.Margin = new Padding(3, 4, 3, 4);
            txtvaloraluguel.Name = "txtvaloraluguel";
            txtvaloraluguel.Size = new Size(111, 27);
            txtvaloraluguel.TabIndex = 41;
            // 
            // labelValorAlguel
            // 
            labelValorAlguel.AutoSize = true;
            labelValorAlguel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelValorAlguel.Location = new Point(61, 144);
            labelValorAlguel.Name = "labelValorAlguel";
            labelValorAlguel.Size = new Size(98, 20);
            labelValorAlguel.TabIndex = 40;
            labelValorAlguel.Text = "Valor Aluguel";
            // 
            // dtdataLancamento
            // 
            dtdataLancamento.Format = DateTimePickerFormat.Short;
            dtdataLancamento.Location = new Point(154, 85);
            dtdataLancamento.Margin = new Padding(3, 4, 3, 4);
            dtdataLancamento.Name = "dtdataLancamento";
            dtdataLancamento.Size = new Size(137, 27);
            dtdataLancamento.TabIndex = 39;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(154, 55);
            label4.Name = "label4";
            label4.Size = new Size(120, 20);
            label4.TabIndex = 38;
            label4.Text = "Data Pagamento";
            // 
            // txttipoInvestimento
            // 
            txttipoInvestimento.Enabled = false;
            txttipoInvestimento.Location = new Point(27, 171);
            txttipoInvestimento.Margin = new Padding(3, 4, 3, 4);
            txttipoInvestimento.Name = "txttipoInvestimento";
            txttipoInvestimento.ReadOnly = true;
            txttipoInvestimento.Size = new Size(261, 27);
            txttipoInvestimento.TabIndex = 36;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(27, 140);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 35;
            label3.Text = "Tipo Investimento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(102, 59);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 34;
            label2.Text = "Descrição";
            // 
            // txtidFlat
            // 
            txtidFlat.Enabled = false;
            txtidFlat.Location = new Point(27, 89);
            txtidFlat.Margin = new Padding(3, 4, 3, 4);
            txtidFlat.Name = "txtidFlat";
            txtidFlat.ReadOnly = true;
            txtidFlat.Size = new Size(57, 27);
            txtidFlat.TabIndex = 33;
            // 
            // txtDescricaoFlat
            // 
            txtDescricaoFlat.Enabled = false;
            txtDescricaoFlat.Location = new Point(102, 89);
            txtDescricaoFlat.Margin = new Padding(3, 4, 3, 4);
            txtDescricaoFlat.Name = "txtDescricaoFlat";
            txtDescricaoFlat.ReadOnly = true;
            txtDescricaoFlat.Size = new Size(187, 27);
            txtDescricaoFlat.TabIndex = 32;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 59);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 31;
            label1.Text = "Id Flat";
            // 
            // plocalizar
            // 
            plocalizar.Controls.Add(label1);
            plocalizar.Controls.Add(txtDescricaoFlat);
            plocalizar.Controls.Add(txtidFlat);
            plocalizar.Controls.Add(label2);
            plocalizar.Controls.Add(label3);
            plocalizar.Controls.Add(txttipoInvestimento);
            plocalizar.Controls.Add(btnLocFlatLancamento);
            plocalizar.Location = new Point(35, 19);
            plocalizar.Margin = new Padding(3, 4, 3, 4);
            plocalizar.Name = "plocalizar";
            plocalizar.Size = new Size(307, 304);
            plocalizar.TabIndex = 50;
            // 
            // plancamento
            // 
            plancamento.Controls.Add(txtid);
            plancamento.Controls.Add(label4);
            plancamento.Controls.Add(txtValorFunReserva);
            plancamento.Controls.Add(dtdataLancamento);
            plancamento.Controls.Add(txtValorDiv);
            plancamento.Controls.Add(labelValorAlguel);
            plancamento.Controls.Add(labelValorDiv);
            plancamento.Controls.Add(txtvaloraluguel);
            plancamento.Controls.Add(labelFundoRes);
            plancamento.Controls.Add(label6);
            plancamento.Location = new Point(381, 19);
            plancamento.Margin = new Padding(3, 4, 3, 4);
            plancamento.Name = "plancamento";
            plancamento.Size = new Size(433, 304);
            plancamento.TabIndex = 51;
            // 
            // pbfechar
            // 
            pbfechar.Image = (Image)resources.GetObject("pbfechar.Image");
            pbfechar.Location = new Point(860, 2);
            pbfechar.Name = "pbfechar";
            pbfechar.Size = new Size(30, 21);
            pbfechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbfechar.TabIndex = 52;
            pbfechar.TabStop = false;
            pbfechar.Click += pbfechar_Click;
            // 
            // FrmCadLancamento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(891, 468);
            Controls.Add(pbfechar);
            Controls.Add(plancamento);
            Controls.Add(plocalizar);
            Controls.Add(pbotoes);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
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
        private TextBox txttipoInvestimento;
        private Label label3;
        private Label label2;
        private TextBox txtidFlat;
        private TextBox txtDescricaoFlat;
        private Label label1;
        private Panel plocalizar;
        private Panel plancamento;
        private PictureBox pbfechar;
    }
}