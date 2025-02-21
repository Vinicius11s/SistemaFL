namespace SistemaFL
{
    partial class RelatorioFlatIndividual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatorioFlatIndividual));
            panel1 = new Panel();
            pbMinimizar = new PictureBox();
            pbFechar = new PictureBox();
            pictureBox1 = new PictureBox();
            pbFecharr = new PictureBox();
            label2 = new Label();
            ckDadosImovel = new CheckBox();
            ckTodos = new CheckBox();
            btnlocalizarImóvel = new Button();
            axAcropdf1 = new AxAcroPDFLib.AxAcroPDF();
            label4 = new Label();
            ckRendimentos = new CheckBox();
            label3 = new Label();
            label1 = new Label();
            txtdescricaoimovel = new TextBox();
            btnVizualizarPdf = new Button();
            pdescricao = new Panel();
            tTamanhotela = new System.Windows.Forms.Timer(components);
            btnSalvarPDF = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFecharr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axAcropdf1).BeginInit();
            pdescricao.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(23, 24, 29);
            panel1.Controls.Add(pbMinimizar);
            panel1.Controls.Add(pbFechar);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(pbFecharr);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1087, 73);
            panel1.TabIndex = 20;
            // 
            // pbMinimizar
            // 
            pbMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbMinimizar.Image = (Image)resources.GetObject("pbMinimizar.Image");
            pbMinimizar.Location = new Point(830, 9);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(19, 20);
            pbMinimizar.TabIndex = 22;
            pbMinimizar.TabStop = false;
            pbMinimizar.Click += pbMinimizar_Click;
            // 
            // pbFechar
            // 
            pbFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(847, 8);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(25, 28);
            pbFechar.TabIndex = 21;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1716, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(19, 20);
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // pbFecharr
            // 
            pbFecharr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFecharr.Image = (Image)resources.GetObject("pbFecharr.Image");
            pbFecharr.Location = new Point(1734, 8);
            pbFecharr.Name = "pbFecharr";
            pbFecharr.Size = new Size(25, 28);
            pbFecharr.TabIndex = 19;
            pbFecharr.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(24, 23);
            label2.Name = "label2";
            label2.Size = new Size(254, 22);
            label2.TabIndex = 18;
            label2.Text = "Relatório Imóvel Individual";
            // 
            // ckDadosImovel
            // 
            ckDadosImovel.AutoSize = true;
            ckDadosImovel.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckDadosImovel.Location = new Point(38, 291);
            ckDadosImovel.Name = "ckDadosImovel";
            ckDadosImovel.Size = new Size(133, 24);
            ckDadosImovel.TabIndex = 45;
            ckDadosImovel.Text = "DADOS IMÓVEL";
            ckDadosImovel.UseVisualStyleBackColor = true;
            // 
            // ckTodos
            // 
            ckTodos.AutoSize = true;
            ckTodos.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckTodos.Location = new Point(38, 271);
            ckTodos.Name = "ckTodos";
            ckTodos.Size = new Size(15, 14);
            ckTodos.TabIndex = 44;
            ckTodos.UseVisualStyleBackColor = true;
            ckTodos.CheckedChanged += ckTodos_CheckedChanged;
            // 
            // btnlocalizarImóvel
            // 
            btnlocalizarImóvel.FlatAppearance.BorderSize = 2;
            btnlocalizarImóvel.FlatStyle = FlatStyle.Flat;
            btnlocalizarImóvel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlocalizarImóvel.Location = new Point(218, 101);
            btnlocalizarImóvel.Name = "btnlocalizarImóvel";
            btnlocalizarImóvel.Size = new Size(234, 31);
            btnlocalizarImóvel.TabIndex = 43;
            btnlocalizarImóvel.Text = "Localizar Imóvel";
            btnlocalizarImóvel.UseVisualStyleBackColor = true;
            btnlocalizarImóvel.Click += btnlocalizarImóvel_Click;
            // 
            // axAcropdf1
            // 
            axAcropdf1.Enabled = true;
            axAcropdf1.Location = new Point(573, 119);
            axAcropdf1.Name = "axAcropdf1";
            axAcropdf1.OcxState = (AxHost.State)resources.GetObject("axAcropdf1.OcxState");
            axAcropdf1.Size = new Size(441, 550);
            axAcropdf1.TabIndex = 42;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(38, 241);
            label4.Name = "label4";
            label4.Size = new Size(142, 20);
            label4.TabIndex = 36;
            label4.Text = "Campos Disponíveis:";
            // 
            // ckRendimentos
            // 
            ckRendimentos.AutoSize = true;
            ckRendimentos.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckRendimentos.Location = new Point(38, 315);
            ckRendimentos.Name = "ckRendimentos";
            ckRendimentos.Size = new Size(184, 24);
            ckRendimentos.TabIndex = 35;
            ckRendimentos.Text = "RENDIMENTOS IMÓVEL";
            ckRendimentos.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(573, 101);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 34;
            label3.Text = "Pré-visualização";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 24);
            label1.Name = "label1";
            label1.Size = new Size(109, 21);
            label1.TabIndex = 46;
            label1.Text = "Descrição Flat :";
            // 
            // txtdescricaoimovel
            // 
            txtdescricaoimovel.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtdescricaoimovel.Location = new Point(139, 22);
            txtdescricaoimovel.Name = "txtdescricaoimovel";
            txtdescricaoimovel.Size = new Size(352, 27);
            txtdescricaoimovel.TabIndex = 47;
            // 
            // btnVizualizarPdf
            // 
            btnVizualizarPdf.FlatAppearance.BorderSize = 2;
            btnVizualizarPdf.FlatStyle = FlatStyle.Flat;
            btnVizualizarPdf.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVizualizarPdf.Location = new Point(242, 366);
            btnVizualizarPdf.Name = "btnVizualizarPdf";
            btnVizualizarPdf.Size = new Size(133, 29);
            btnVizualizarPdf.TabIndex = 48;
            btnVizualizarPdf.Text = "Visualizar Pdf";
            btnVizualizarPdf.UseVisualStyleBackColor = true;
            btnVizualizarPdf.Click += btnVizualizarPdf_Click;
            // 
            // pdescricao
            // 
            pdescricao.Controls.Add(txtdescricaoimovel);
            pdescricao.Controls.Add(label1);
            pdescricao.Location = new Point(24, 151);
            pdescricao.Name = "pdescricao";
            pdescricao.Size = new Size(524, 71);
            pdescricao.TabIndex = 49;
            // 
            // tTamanhotela
            // 
            tTamanhotela.Interval = 1;
            tTamanhotela.Tick += tTamanhotela_Tick;
            // 
            // btnSalvarPDF
            // 
            btnSalvarPDF.FlatAppearance.BorderSize = 0;
            btnSalvarPDF.FlatStyle = FlatStyle.Flat;
            btnSalvarPDF.Image = (Image)resources.GetObject("btnSalvarPDF.Image");
            btnSalvarPDF.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalvarPDF.Location = new Point(518, 528);
            btnSalvarPDF.Margin = new Padding(3, 4, 3, 4);
            btnSalvarPDF.Name = "btnSalvarPDF";
            btnSalvarPDF.Size = new Size(39, 39);
            btnSalvarPDF.TabIndex = 50;
            btnSalvarPDF.TextAlign = ContentAlignment.MiddleRight;
            btnSalvarPDF.UseVisualStyleBackColor = true;
            btnSalvarPDF.Click += btnSalvarPDF_Click;
            // 
            // RelatorioFlatIndividual
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1087, 580);
            Controls.Add(btnSalvarPDF);
            Controls.Add(pdescricao);
            Controls.Add(btnVizualizarPdf);
            Controls.Add(ckDadosImovel);
            Controls.Add(ckTodos);
            Controls.Add(btnlocalizarImóvel);
            Controls.Add(axAcropdf1);
            Controls.Add(label4);
            Controls.Add(ckRendimentos);
            Controls.Add(label3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RelatorioFlatIndividual";
            Text = "RelatorioFlatIndividual";
            Load += RelatorioFlatIndividual_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFecharr).EndInit();
            ((System.ComponentModel.ISupportInitialize)axAcropdf1).EndInit();
            pdescricao.ResumeLayout(false);
            pdescricao.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pbFecharr;
        private Label label2;
        private CheckBox ckDadosImovel;
        private CheckBox ckTodos;
        private Button btnlocalizarImóvel;
        private AxAcroPDFLib.AxAcroPDF axAcropdf1;
        private Label label4;
        private CheckBox ckRendimentos;
        private Label label3;
        private Label label1;
        private TextBox txtdescricaoimovel;
        private Button btnVizualizarPdf;
        private Panel pdescricao;
        private System.Windows.Forms.Timer tTamanhotela;
        private PictureBox pbMinimizar;
        private PictureBox pbFechar;
        private Button btnSalvarPDF;
    }
}