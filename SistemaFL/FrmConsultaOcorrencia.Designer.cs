namespace SistemaFL
{
    partial class FrmConsultaOcorrencia
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
            label2 = new Label();
            btnlocalizar = new Button();
            txtdescricao = new TextBox();
            label1 = new Label();
            dgdadoslancamento = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgdadoslancamento).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(295, 105);
            label2.Name = "label2";
            label2.Size = new Size(160, 25);
            label2.TabIndex = 16;
            label2.Text = "Registros de Log";
            // 
            // btnlocalizar
            // 
            btnlocalizar.Location = new Point(644, 53);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(92, 38);
            btnlocalizar.TabIndex = 15;
            btnlocalizar.Text = "Localizar";
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // txtdescricao
            // 
            txtdescricao.Location = new Point(85, 53);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(530, 23);
            txtdescricao.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(85, 26);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 13;
            label1.Text = "Descrição";
            // 
            // dgdadoslancamento
            // 
            dgdadoslancamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadoslancamento.Dock = DockStyle.Bottom;
            dgdadoslancamento.Location = new Point(0, 148);
            dgdadoslancamento.Name = "dgdadoslancamento";
            dgdadoslancamento.Size = new Size(800, 302);
            dgdadoslancamento.TabIndex = 12;
            // 
            // FrmConsultaOcorrencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(btnlocalizar);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Controls.Add(dgdadoslancamento);
            Name = "FrmConsultaOcorrencia";
            Text = "FrmConsultaOcorrencia";
            ((System.ComponentModel.ISupportInitialize)dgdadoslancamento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button btnlocalizar;
        private TextBox txtdescricao;
        private Label label1;
        private DataGridView dgdadoslancamento;
    }
}