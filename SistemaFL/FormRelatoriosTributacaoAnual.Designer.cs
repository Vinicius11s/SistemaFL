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
            label2 = new Label();
            panel1 = new Panel();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtAno
            // 
            txtAno.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAno.Location = new Point(208, 114);
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(114, 29);
            txtAno.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(143, 113);
            label1.Name = "label1";
            label1.Size = new Size(61, 30);
            label1.TabIndex = 1;
            label1.Text = "Ano :";
            // 
            // pbFechar
            // 
            pbFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFechar.BackColor = Color.Transparent;
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(1054, 3);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(30, 33);
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
            btnlocalizar.Location = new Point(977, 504);
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
            dataGridView1.Location = new Point(667, 141);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(290, 394);
            dataGridView1.TabIndex = 16;
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
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pbFechar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1087, 73);
            panel1.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(772, 105);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 20;
            label3.Text = "Pré-visualização";
            // 
            // FormRelatoriosTributacaoAnual
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1087, 558);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(btnlocalizar);
            Controls.Add(label1);
            Controls.Add(txtAno);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRelatoriosTributacaoAnual";
            Text = "Relatórios Anuais";
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAno;
        private Label label1;
        private PictureBox pbFechar;
        private Button btnlocalizar;
        private DataGridView dataGridView1;
        private Label label2;
        private Panel panel1;
        private Label label3;
    }
}