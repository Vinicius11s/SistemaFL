namespace SistemaFL
{
    partial class FormRelatoriosTributacaoAnual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelatoriosTributacaoAnual));
            txtAno = new TextBox();
            label1 = new Label();
            pbFechar = new PictureBox();
            btnlocalizar = new Button();
            dataGridView1 = new DataGridView();
            GerarInformacoes = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtAno
            // 
            txtAno.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAno.Location = new Point(157, 63);
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(77, 29);
            txtAno.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(106, 67);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 1;
            label1.Text = "Ano :";
            // 
            // pbFechar
            // 
            pbFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(1056, 1);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(30, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 15;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // btnlocalizar
            // 
            btnlocalizar.FlatAppearance.BorderSize = 0;
            btnlocalizar.Image = (Image)resources.GetObject("btnlocalizar.Image");
            btnlocalizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnlocalizar.Location = new Point(352, 453);
            btnlocalizar.Margin = new Padding(3, 4, 3, 4);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(98, 31);
            btnlocalizar.TabIndex = 14;
            btnlocalizar.Text = "Gerar PDF";
            btnlocalizar.TextAlign = ContentAlignment.MiddleRight;
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(70, 122);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(267, 362);
            dataGridView1.TabIndex = 16;
            // 
            // GerarInformacoes
            // 
            GerarInformacoes.FlatAppearance.BorderSize = 0;
            GerarInformacoes.FlatStyle = FlatStyle.Flat;
            GerarInformacoes.Image = (Image)resources.GetObject("GerarInformacoes.Image");
            GerarInformacoes.Location = new Point(240, 63);
            GerarInformacoes.Margin = new Padding(3, 4, 3, 4);
            GerarInformacoes.Name = "GerarInformacoes";
            GerarInformacoes.Size = new Size(36, 31);
            GerarInformacoes.TabIndex = 17;
            GerarInformacoes.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(56, 12);
            label2.Name = "label2";
            label2.Size = new Size(281, 25);
            label2.TabIndex = 18;
            label2.Text = "Relatório de Fechamento Anual";
            // 
            // FormRelatoriosTributacaoAnual
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1087, 558);
            Controls.Add(label2);
            Controls.Add(GerarInformacoes);
            Controls.Add(dataGridView1);
            Controls.Add(pbFechar);
            Controls.Add(btnlocalizar);
            Controls.Add(label1);
            Controls.Add(txtAno);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRelatoriosTributacaoAnual";
            Text = "Relatórios Anuais";
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAno;
        private Label label1;
        private PictureBox pbFechar;
        private Button btnlocalizar;
        private DataGridView dataGridView1;
        private Button GerarInformacoes;
        private Label label2;
    }
}