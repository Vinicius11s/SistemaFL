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
            pdados = new Panel();
            txtValorFunReserva = new TextBox();
            txtValorDiv = new TextBox();
            labelValorDiv = new Label();
            labelFundoRes = new Label();
            label7 = new Label();
            cbbtipoPagamento = new ComboBox();
            txtid = new TextBox();
            label6 = new Label();
            btnLocFlatLancamento = new Button();
            txtvalorPagamento = new TextBox();
            labelValorPag = new Label();
            dtdataLancamento = new DateTimePicker();
            label4 = new Label();
            txttipoInvestimento = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtidFlat = new TextBox();
            txtDescricaoFlat = new TextBox();
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
            pdados.Controls.Add(txtValorFunReserva);
            pdados.Controls.Add(txtValorDiv);
            pdados.Controls.Add(labelValorDiv);
            pdados.Controls.Add(labelFundoRes);
            pdados.Controls.Add(label7);
            pdados.Controls.Add(cbbtipoPagamento);
            pdados.Controls.Add(txtid);
            pdados.Controls.Add(label6);
            pdados.Controls.Add(btnLocFlatLancamento);
            pdados.Controls.Add(txtvalorPagamento);
            pdados.Controls.Add(labelValorPag);
            pdados.Controls.Add(dtdataLancamento);
            pdados.Controls.Add(label4);
            pdados.Controls.Add(txttipoInvestimento);
            pdados.Controls.Add(label3);
            pdados.Controls.Add(label2);
            pdados.Controls.Add(txtidFlat);
            pdados.Controls.Add(txtDescricaoFlat);
            pdados.Controls.Add(label1);
            pdados.Dock = DockStyle.Top;
            pdados.Location = new Point(0, 0);
            pdados.Name = "pdados";
            pdados.Size = new Size(1072, 281);
            pdados.TabIndex = 0;
            // 
            // txtValorFunReserva
            // 
            txtValorFunReserva.Location = new Point(302, 190);
            txtValorFunReserva.Name = "txtValorFunReserva";
            txtValorFunReserva.Size = new Size(143, 23);
            txtValorFunReserva.TabIndex = 30;
            // 
            // txtValorDiv
            // 
            txtValorDiv.Location = new Point(495, 121);
            txtValorDiv.Name = "txtValorDiv";
            txtValorDiv.Size = new Size(145, 23);
            txtValorDiv.TabIndex = 29;
            // 
            // labelValorDiv
            // 
            labelValorDiv.AutoSize = true;
            labelValorDiv.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelValorDiv.Location = new Point(495, 98);
            labelValorDiv.Name = "labelValorDiv";
            labelValorDiv.Size = new Size(122, 20);
            labelValorDiv.TabIndex = 28;
            labelValorDiv.Text = "Valor Dividendos";
            // 
            // labelFundoRes
            // 
            labelFundoRes.AutoSize = true;
            labelFundoRes.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFundoRes.Location = new Point(302, 167);
            labelFundoRes.Name = "labelFundoRes";
            labelFundoRes.Size = new Size(143, 20);
            labelFundoRes.TabIndex = 27;
            labelFundoRes.Text = "Valor Fundo Reserva";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(527, 23);
            label7.Name = "label7";
            label7.Size = new Size(118, 20);
            label7.TabIndex = 26;
            label7.Text = "Tipo Pagamento";
            // 
            // cbbtipoPagamento
            // 
            cbbtipoPagamento.FormattingEnabled = true;
            cbbtipoPagamento.Items.AddRange(new object[] { "Aluguel Fixo", "Dividendos", "Aluguel Fixo + Dividendos", "Fundo de Reserva" });
            cbbtipoPagamento.Location = new Point(528, 46);
            cbbtipoPagamento.Name = "cbbtipoPagamento";
            cbbtipoPagamento.Size = new Size(191, 23);
            cbbtipoPagamento.TabIndex = 25;
            // 
            // txtid
            // 
            txtid.Location = new Point(302, 46);
            txtid.Name = "txtid";
            txtid.ReadOnly = true;
            txtid.Size = new Size(50, 23);
            txtid.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(302, 23);
            label6.Name = "label6";
            label6.Size = new Size(22, 20);
            label6.TabIndex = 23;
            label6.Text = "Id";
            // 
            // btnLocFlatLancamento
            // 
            btnLocFlatLancamento.Location = new Point(70, 212);
            btnLocFlatLancamento.Name = "btnLocFlatLancamento";
            btnLocFlatLancamento.Size = new Size(89, 40);
            btnLocFlatLancamento.TabIndex = 18;
            btnLocFlatLancamento.Text = "Localizar Flat";
            btnLocFlatLancamento.UseVisualStyleBackColor = true;
            btnLocFlatLancamento.Click += btnLocFlatLancamento_Click;
            // 
            // txtvalorPagamento
            // 
            txtvalorPagamento.Location = new Point(302, 121);
            txtvalorPagamento.Name = "txtvalorPagamento";
            txtvalorPagamento.Size = new Size(143, 23);
            txtvalorPagamento.TabIndex = 22;
            // 
            // labelValorPag
            // 
            labelValorPag.AutoSize = true;
            labelValorPag.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelValorPag.Location = new Point(302, 98);
            labelValorPag.Name = "labelValorPag";
            labelValorPag.Size = new Size(122, 20);
            labelValorPag.TabIndex = 21;
            labelValorPag.Text = "Valor Pagamento";
            // 
            // dtdataLancamento
            // 
            dtdataLancamento.Format = DateTimePickerFormat.Short;
            dtdataLancamento.Location = new Point(373, 46);
            dtdataLancamento.Name = "dtdataLancamento";
            dtdataLancamento.Size = new Size(120, 23);
            dtdataLancamento.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(373, 23);
            label4.Name = "label4";
            label4.Size = new Size(120, 20);
            label4.TabIndex = 19;
            label4.Text = "Data Pagamento";
            // 
            // txttipoInvestimento
            // 
            txttipoInvestimento.Location = new Point(24, 106);
            txttipoInvestimento.Name = "txttipoInvestimento";
            txttipoInvestimento.ReadOnly = true;
            txttipoInvestimento.Size = new Size(183, 23);
            txttipoInvestimento.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 83);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 5;
            label3.Text = "Tipo Investimento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 141);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 4;
            label2.Text = "Descrição";
            // 
            // txtidFlat
            // 
            txtidFlat.Location = new Point(28, 46);
            txtidFlat.Name = "txtidFlat";
            txtidFlat.ReadOnly = true;
            txtidFlat.Size = new Size(50, 23);
            txtidFlat.TabIndex = 3;
            // 
            // txtDescricaoFlat
            // 
            txtDescricaoFlat.Enabled = false;
            txtDescricaoFlat.Location = new Point(28, 164);
            txtDescricaoFlat.Name = "txtDescricaoFlat";
            txtDescricaoFlat.ReadOnly = true;
            txtDescricaoFlat.Size = new Size(179, 23);
            txtDescricaoFlat.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 23);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "Id Flat";
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
            pbotoes.Location = new Point(0, 365);
            pbotoes.Name = "pbotoes";
            pbotoes.Size = new Size(1072, 94);
            pbotoes.TabIndex = 1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.Location = new Point(642, 27);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(89, 40);
            btnlocalizar.TabIndex = 17;
            btnlocalizar.Text = "Localizar";
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // btnexcluir
            // 
            btnexcluir.Location = new Point(528, 27);
            btnexcluir.Name = "btnexcluir";
            btnexcluir.Size = new Size(89, 40);
            btnexcluir.TabIndex = 16;
            btnexcluir.Text = "Excluir";
            btnexcluir.UseVisualStyleBackColor = true;
            btnexcluir.Click += btnexcluir_Click;
            // 
            // btncancelar
            // 
            btncancelar.Location = new Point(421, 27);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(89, 40);
            btncancelar.TabIndex = 15;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = true;
            btncancelar.Click += btncancelar_Click;
            // 
            // btnsalvar
            // 
            btnsalvar.Location = new Point(302, 27);
            btnsalvar.Name = "btnsalvar";
            btnsalvar.Size = new Size(89, 40);
            btnsalvar.TabIndex = 14;
            btnsalvar.Text = "Salvar";
            btnsalvar.UseVisualStyleBackColor = true;
            btnsalvar.Click += btnsalvar_Click;
            // 
            // btnalterar
            // 
            btnalterar.Location = new Point(184, 27);
            btnalterar.Name = "btnalterar";
            btnalterar.Size = new Size(89, 40);
            btnalterar.TabIndex = 13;
            btnalterar.Text = "Alterar";
            btnalterar.UseVisualStyleBackColor = true;
            btnalterar.Click += btnalterar_Click;
            // 
            // btnnovo
            // 
            btnnovo.Location = new Point(70, 27);
            btnnovo.Name = "btnnovo";
            btnnovo.Size = new Size(89, 40);
            btnnovo.TabIndex = 12;
            btnnovo.Text = "Novo";
            btnnovo.UseVisualStyleBackColor = true;
            btnnovo.Click += btnnovo_Click;
            // 
            // FrmCadLancamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1072, 459);
            Controls.Add(pbotoes);
            Controls.Add(pdados);
            Name = "FrmCadLancamento";
            Text = "FrmCadLancamento";
            Load += FrmCadLancamento_Load;
            pdados.ResumeLayout(false);
            pdados.PerformLayout();
            pbotoes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pdados;
        private TextBox txtDescricaoFlat;
        private Label label1;
        private Panel pbotoes;
        private TextBox txttipoInvestimento;
        private Label label3;
        private Label label2;
        private TextBox txtidFlat;
        private Button btnlocalizar;
        private Button btnexcluir;
        private Button btncancelar;
        private Button btnsalvar;
        private Button btnalterar;
        private Button btnnovo;
        private TextBox txtvalorPagamento;
        private Label labelValorPag;
        private DateTimePicker dtdataLancamento;
        private Label label4;
        private Button btnLocFlatLancamento;
        private TextBox txtid;
        private Label label6;
        private Label label7;
        private ComboBox cbbtipoPagamento;
        private Label labelValorDiv;
        private Label labelFundoRes;
        private TextBox txtValorFunReserva;
        private TextBox txtValorDiv;
    }
}