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
            label7 = new Label();
            cbbtipoPagamento = new ComboBox();
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
            pbotoes.SuspendLayout();
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
            pbotoes.Location = new Point(0, 227);
            pbotoes.Name = "pbotoes";
            pbotoes.Size = new Size(764, 64);
            pbotoes.TabIndex = 1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.Location = new Point(644, 12);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(89, 40);
            btnlocalizar.TabIndex = 17;
            btnlocalizar.Text = "Localizar";
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // btnexcluir
            // 
            btnexcluir.Location = new Point(530, 12);
            btnexcluir.Name = "btnexcluir";
            btnexcluir.Size = new Size(89, 40);
            btnexcluir.TabIndex = 16;
            btnexcluir.Text = "Excluir";
            btnexcluir.UseVisualStyleBackColor = true;
            btnexcluir.Click += btnexcluir_Click;
            // 
            // btncancelar
            // 
            btncancelar.Location = new Point(423, 12);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(89, 40);
            btncancelar.TabIndex = 15;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = true;
            btncancelar.Click += btncancelar_Click;
            // 
            // btnsalvar
            // 
            btnsalvar.Location = new Point(304, 12);
            btnsalvar.Name = "btnsalvar";
            btnsalvar.Size = new Size(89, 40);
            btnsalvar.TabIndex = 14;
            btnsalvar.Text = "Salvar";
            btnsalvar.UseVisualStyleBackColor = true;
            btnsalvar.Click += btnsalvar_Click;
            // 
            // btnalterar
            // 
            btnalterar.Location = new Point(186, 12);
            btnalterar.Name = "btnalterar";
            btnalterar.Size = new Size(89, 40);
            btnalterar.TabIndex = 13;
            btnalterar.Text = "Alterar";
            btnalterar.UseVisualStyleBackColor = true;
            btnalterar.Click += btnalterar_Click;
            // 
            // btnnovo
            // 
            btnnovo.Location = new Point(72, 12);
            btnnovo.Name = "btnnovo";
            btnnovo.Size = new Size(89, 40);
            btnnovo.TabIndex = 12;
            btnnovo.Text = "Novo";
            btnnovo.UseVisualStyleBackColor = true;
            btnnovo.Click += btnnovo_Click;
            // 
            // txtValorFunReserva
            // 
            txtValorFunReserva.Location = new Point(507, 150);
            txtValorFunReserva.Name = "txtValorFunReserva";
            txtValorFunReserva.Size = new Size(143, 23);
            txtValorFunReserva.TabIndex = 49;
            // 
            // txtValorDiv
            // 
            txtValorDiv.Location = new Point(358, 150);
            txtValorDiv.Name = "txtValorDiv";
            txtValorDiv.Size = new Size(122, 23);
            txtValorDiv.TabIndex = 48;
            // 
            // labelValorDiv
            // 
            labelValorDiv.AutoSize = true;
            labelValorDiv.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelValorDiv.Location = new Point(358, 124);
            labelValorDiv.Name = "labelValorDiv";
            labelValorDiv.Size = new Size(122, 20);
            labelValorDiv.TabIndex = 47;
            labelValorDiv.Text = "Valor Dividendos";
            // 
            // labelFundoRes
            // 
            labelFundoRes.AutoSize = true;
            labelFundoRes.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFundoRes.Location = new Point(507, 124);
            labelFundoRes.Name = "labelFundoRes";
            labelFundoRes.Size = new Size(143, 20);
            labelFundoRes.TabIndex = 46;
            labelFundoRes.Text = "Valor Fundo Reserva";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(233, 75);
            label7.Name = "label7";
            label7.Size = new Size(118, 20);
            label7.TabIndex = 45;
            label7.Text = "Tipo Pagamento";
            // 
            // cbbtipoPagamento
            // 
            cbbtipoPagamento.FormattingEnabled = true;
            cbbtipoPagamento.Items.AddRange(new object[] { "Aluguel Fixo", "Dividendos", "Aluguel Fixo + Dividendos", "Fundo de Reserva" });
            cbbtipoPagamento.Location = new Point(234, 98);
            cbbtipoPagamento.Name = "cbbtipoPagamento";
            cbbtipoPagamento.Size = new Size(191, 23);
            cbbtipoPagamento.TabIndex = 44;
            cbbtipoPagamento.SelectedIndexChanged += cbbtipoPagamento_SelectedIndexChanged;
            // 
            // txtid
            // 
            txtid.Enabled = false;
            txtid.Location = new Point(234, 35);
            txtid.Name = "txtid";
            txtid.ReadOnly = true;
            txtid.Size = new Size(58, 23);
            txtid.TabIndex = 43;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(234, 12);
            label6.Name = "label6";
            label6.Size = new Size(58, 20);
            label6.TabIndex = 42;
            label6.Text = "Código";
            // 
            // btnLocFlatLancamento
            // 
            btnLocFlatLancamento.Location = new Point(32, 170);
            btnLocFlatLancamento.Name = "btnLocFlatLancamento";
            btnLocFlatLancamento.Size = new Size(89, 40);
            btnLocFlatLancamento.TabIndex = 37;
            btnLocFlatLancamento.Text = "Localizar Flat";
            btnLocFlatLancamento.UseVisualStyleBackColor = true;
            btnLocFlatLancamento.Click += btnLocFlatLancamento_Click_1;
            // 
            // txtvaloraluguel
            // 
            txtvaloraluguel.Location = new Point(234, 150);
            txtvaloraluguel.Name = "txtvaloraluguel";
            txtvaloraluguel.Size = new Size(98, 23);
            txtvaloraluguel.TabIndex = 41;
            // 
            // labelValorAlguel
            // 
            labelValorAlguel.AutoSize = true;
            labelValorAlguel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelValorAlguel.Location = new Point(234, 127);
            labelValorAlguel.Name = "labelValorAlguel";
            labelValorAlguel.Size = new Size(98, 20);
            labelValorAlguel.TabIndex = 40;
            labelValorAlguel.Text = "Valor Aluguel";
            // 
            // dtdataLancamento
            // 
            dtdataLancamento.Format = DateTimePickerFormat.Short;
            dtdataLancamento.Location = new Point(345, 32);
            dtdataLancamento.Name = "dtdataLancamento";
            dtdataLancamento.Size = new Size(120, 23);
            dtdataLancamento.TabIndex = 39;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(345, 9);
            label4.Name = "label4";
            label4.Size = new Size(120, 20);
            label4.TabIndex = 38;
            label4.Text = "Data Pagamento";
            // 
            // txttipoInvestimento
            // 
            txttipoInvestimento.BorderStyle = BorderStyle.FixedSingle;
            txttipoInvestimento.Enabled = false;
            txttipoInvestimento.Location = new Point(12, 132);
            txttipoInvestimento.Name = "txttipoInvestimento";
            txttipoInvestimento.ReadOnly = true;
            txttipoInvestimento.Size = new Size(130, 23);
            txttipoInvestimento.TabIndex = 36;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 109);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 35;
            label3.Text = "Tipo Investimento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 34;
            label2.Text = "Descrição";
            // 
            // txtidFlat
            // 
            txtidFlat.Enabled = false;
            txtidFlat.Location = new Point(13, 32);
            txtidFlat.Name = "txtidFlat";
            txtidFlat.ReadOnly = true;
            txtidFlat.Size = new Size(50, 23);
            txtidFlat.TabIndex = 33;
            // 
            // txtDescricaoFlat
            // 
            txtDescricaoFlat.Enabled = false;
            txtDescricaoFlat.Location = new Point(12, 83);
            txtDescricaoFlat.Name = "txtDescricaoFlat";
            txtDescricaoFlat.ReadOnly = true;
            txtDescricaoFlat.Size = new Size(130, 23);
            txtDescricaoFlat.TabIndex = 32;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 31;
            label1.Text = "Id Flat";
            // 
            // FrmCadLancamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 291);
            Controls.Add(txtValorFunReserva);
            Controls.Add(txtValorDiv);
            Controls.Add(labelValorDiv);
            Controls.Add(labelFundoRes);
            Controls.Add(label7);
            Controls.Add(cbbtipoPagamento);
            Controls.Add(txtid);
            Controls.Add(label6);
            Controls.Add(btnLocFlatLancamento);
            Controls.Add(txtvaloraluguel);
            Controls.Add(labelValorAlguel);
            Controls.Add(dtdataLancamento);
            Controls.Add(label4);
            Controls.Add(txttipoInvestimento);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtidFlat);
            Controls.Add(txtDescricaoFlat);
            Controls.Add(label1);
            Controls.Add(pbotoes);
            Name = "FrmCadLancamento";
            Text = "FrmCadLancamento";
            Load += FrmCadLancamento_Load;
            pbotoes.ResumeLayout(false);
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
        private Label label7;
        private ComboBox cbbtipoPagamento;
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
    }
}