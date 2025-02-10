namespace SistemaFL
{
    partial class RelatorioTributacaoAnual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatorioTributacaoAnual));
            txtAno = new TextBox();
            label1 = new Label();
            btnSalvarPDF = new Button();
            label2 = new Label();
            panel1 = new Panel();
            pbFecharr = new PictureBox();
            label3 = new Label();
            ckPis = new CheckBox();
            label4 = new Label();
            ckCofins = new CheckBox();
            ckRendimentoBruto = new CheckBox();
            ckRendimentoLiq = new CheckBox();
            ckIRPJ = new CheckBox();
            ckContrSocial = new CheckBox();
            axAcropdf1 = new AxAcroPDFLib.AxAcroPDF();
            btnVizualizarPDF = new Button();
            tTamanhotela = new System.Windows.Forms.Timer(components);
            ckTodos = new CheckBox();
            ckRendimentos = new CheckBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFecharr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axAcropdf1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtAno
            // 
            txtAno.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAno.Location = new Point(77, 131);
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(78, 27);
            txtAno.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 133);
            label1.Name = "label1";
            label1.Size = new Size(42, 21);
            label1.TabIndex = 1;
            label1.Text = "Ano:";
            // 
            // btnSalvarPDF
            // 
            btnSalvarPDF.FlatAppearance.BorderSize = 0;
            btnSalvarPDF.FlatStyle = FlatStyle.Flat;
            btnSalvarPDF.Image = (Image)resources.GetObject("btnSalvarPDF.Image");
            btnSalvarPDF.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalvarPDF.Location = new Point(1025, 149);
            btnSalvarPDF.Margin = new Padding(3, 4, 3, 4);
            btnSalvarPDF.Name = "btnSalvarPDF";
            btnSalvarPDF.Size = new Size(50, 44);
            btnSalvarPDF.TabIndex = 14;
            btnSalvarPDF.TextAlign = ContentAlignment.MiddleRight;
            btnSalvarPDF.UseVisualStyleBackColor = true;
            btnSalvarPDF.Click += btnSalvarPDF_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(24, 23);
            label2.Name = "label2";
            label2.Size = new Size(298, 22);
            label2.TabIndex = 18;
            label2.Text = "Relatório de Fechamento Anual";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(23, 24, 29);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(pbFecharr);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1087, 73);
            panel1.TabIndex = 19;
            // 
            // pbFecharr
            // 
            pbFecharr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFecharr.Image = (Image)resources.GetObject("pbFecharr.Image");
            pbFecharr.Location = new Point(847, 8);
            pbFecharr.Name = "pbFecharr";
            pbFecharr.Size = new Size(25, 28);
            pbFecharr.TabIndex = 19;
            pbFecharr.TabStop = false;
            pbFecharr.Click += pbFecharr_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(534, 113);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 20;
            label3.Text = "Pré-visualização";
            // 
            // ckPis
            // 
            ckPis.AutoSize = true;
            ckPis.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckPis.Location = new Point(33, 289);
            ckPis.Name = "ckPis";
            ckPis.Size = new Size(48, 24);
            ckPis.TabIndex = 21;
            ckPis.Text = "PIS";
            ckPis.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(33, 201);
            label4.Name = "label4";
            label4.Size = new Size(142, 20);
            label4.TabIndex = 22;
            label4.Text = "Campos Disponíveis:";
            // 
            // ckCofins
            // 
            ckCofins.AutoSize = true;
            ckCofins.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckCofins.Location = new Point(33, 319);
            ckCofins.Name = "ckCofins";
            ckCofins.Size = new Size(78, 24);
            ckCofins.TabIndex = 23;
            ckCofins.Text = "COFINS";
            ckCofins.UseVisualStyleBackColor = true;
            // 
            // ckRendimentoBruto
            // 
            ckRendimentoBruto.AutoSize = true;
            ckRendimentoBruto.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckRendimentoBruto.Location = new Point(208, 289);
            ckRendimentoBruto.Name = "ckRendimentoBruto";
            ckRendimentoBruto.Size = new Size(169, 24);
            ckRendimentoBruto.TabIndex = 24;
            ckRendimentoBruto.Text = "RENDIMENTO BRUTO";
            ckRendimentoBruto.UseVisualStyleBackColor = true;
            // 
            // ckRendimentoLiq
            // 
            ckRendimentoLiq.AutoSize = true;
            ckRendimentoLiq.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckRendimentoLiq.Location = new Point(208, 319);
            ckRendimentoLiq.Name = "ckRendimentoLiq";
            ckRendimentoLiq.Size = new Size(181, 24);
            ckRendimentoLiq.TabIndex = 25;
            ckRendimentoLiq.Text = "RENDIMENTO LÍQUIDO";
            ckRendimentoLiq.UseVisualStyleBackColor = true;
            // 
            // ckIRPJ
            // 
            ckIRPJ.AutoSize = true;
            ckIRPJ.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckIRPJ.Location = new Point(33, 349);
            ckIRPJ.Name = "ckIRPJ";
            ckIRPJ.Size = new Size(53, 24);
            ckIRPJ.TabIndex = 26;
            ckIRPJ.Text = "IRPJ";
            ckIRPJ.UseVisualStyleBackColor = true;
            // 
            // ckContrSocial
            // 
            ckContrSocial.AutoSize = true;
            ckContrSocial.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckContrSocial.Location = new Point(208, 259);
            ckContrSocial.Name = "ckContrSocial";
            ckContrSocial.Size = new Size(185, 24);
            ckContrSocial.TabIndex = 27;
            ckContrSocial.Text = "CONTRIBUIÇÃO SOCIAL";
            ckContrSocial.UseVisualStyleBackColor = true;
            // 
            // axAcropdf1
            // 
            axAcropdf1.Enabled = true;
            axAcropdf1.Location = new Point(534, 131);
            axAcropdf1.Name = "axAcropdf1";
            axAcropdf1.OcxState = (AxHost.State)resources.GetObject("axAcropdf1.OcxState");
            axAcropdf1.Size = new Size(441, 550);
            axAcropdf1.TabIndex = 28;
            // 
            // btnVizualizarPDF
            // 
            btnVizualizarPDF.FlatAppearance.BorderSize = 2;
            btnVizualizarPDF.FlatStyle = FlatStyle.Flat;
            btnVizualizarPDF.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVizualizarPDF.Location = new Point(142, 418);
            btnVizualizarPDF.Name = "btnVizualizarPDF";
            btnVizualizarPDF.Size = new Size(141, 31);
            btnVizualizarPDF.TabIndex = 29;
            btnVizualizarPDF.Text = "Vizualizar pdf";
            btnVizualizarPDF.UseVisualStyleBackColor = true;
            btnVizualizarPDF.Click += btnVizualizarPDF_Click_1;
            // 
            // tTamanhotela
            // 
            tTamanhotela.Interval = 1;
            tTamanhotela.Tick += tTamanhotela_Tick;
            // 
            // ckTodos
            // 
            ckTodos.AutoSize = true;
            ckTodos.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckTodos.Location = new Point(33, 239);
            ckTodos.Name = "ckTodos";
            ckTodos.Size = new Size(15, 14);
            ckTodos.TabIndex = 30;
            ckTodos.UseVisualStyleBackColor = true;
            ckTodos.CheckedChanged += ckTodos_CheckedChanged;
            // 
            // ckRendimentos
            // 
            ckRendimentos.AutoSize = true;
            ckRendimentos.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckRendimentos.Location = new Point(33, 259);
            ckRendimentos.Name = "ckRendimentos";
            ckRendimentos.Size = new Size(128, 24);
            ckRendimentos.TabIndex = 31;
            ckRendimentos.Text = "RENDIMENTOS";
            ckRendimentos.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(829, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(19, 20);
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // FormRelatoriosTributacaoAnual
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1087, 710);
            Controls.Add(ckRendimentos);
            Controls.Add(ckTodos);
            Controls.Add(btnVizualizarPDF);
            Controls.Add(axAcropdf1);
            Controls.Add(ckContrSocial);
            Controls.Add(ckIRPJ);
            Controls.Add(ckRendimentoLiq);
            Controls.Add(ckRendimentoBruto);
            Controls.Add(ckCofins);
            Controls.Add(label4);
            Controls.Add(ckPis);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(btnSalvarPDF);
            Controls.Add(label1);
            Controls.Add(txtAno);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRelatoriosTributacaoAnual";
            Text = "Relatórios Anuais";
            Load += FormRelatoriosTributacaoAnual_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbFecharr).EndInit();
            ((System.ComponentModel.ISupportInitialize)axAcropdf1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAno;
        private Label label1;
        private PictureBox pbFechar;
        private PictureBox pbFecharr;
        private Button btnSalvarPDF;
        private Label label2;
        private Panel panel1;
        private Label label3;
        private CheckBox ckPis;
        private Label label4;
        private CheckBox ckCofins;
        private CheckBox ckRendimentoBruto;
        private CheckBox ckRendimentoLiq;
        private CheckBox ckIRPJ;
        private CheckBox ckContrSocial;
        private AxAcroPDFLib.AxAcroPDF axAcropdf1;
        private Button btnVizualizarPDF;
        private System.Windows.Forms.Timer tTamanhotela;
        private CheckBox ckTodos;
        private CheckBox ckRendimentos;
        private PictureBox pictureBox1;
    }
}