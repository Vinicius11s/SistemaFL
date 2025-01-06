namespace SistemaFL
{
    partial class FrmConsultaLancamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaLancamento));
            btnlocalizar = new Button();
            txtdescricao = new TextBox();
            label1 = new Label();
            dgdadoslancamento = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgdadoslancamento).BeginInit();
            SuspendLayout();
            // 
            // btnlocalizar
            // 
            btnlocalizar.BackColor = Color.White;
            btnlocalizar.FlatAppearance.BorderSize = 0;
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlocalizar.ForeColor = Color.FromArgb(23, 24, 29);
            btnlocalizar.Image = (Image)resources.GetObject("btnlocalizar.Image");
            btnlocalizar.Location = new Point(191, 31);
            btnlocalizar.Margin = new Padding(4);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(36, 26);
            btnlocalizar.TabIndex = 10;
            btnlocalizar.UseVisualStyleBackColor = false;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // txtdescricao
            // 
            txtdescricao.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtdescricao.Location = new Point(95, 30);
            txtdescricao.Margin = new Padding(4);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(88, 27);
            txtdescricao.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(43, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 30);
            label1.TabIndex = 8;
            label1.Text = "Mês:";
            // 
            // dgdadoslancamento
            // 
            dgdadoslancamento.BackgroundColor = Color.White;
            dgdadoslancamento.BorderStyle = BorderStyle.None;
            dgdadoslancamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadoslancamento.Dock = DockStyle.Bottom;
            dgdadoslancamento.Location = new Point(0, 79);
            dgdadoslancamento.Margin = new Padding(4);
            dgdadoslancamento.Name = "dgdadoslancamento";
            dgdadoslancamento.Size = new Size(875, 350);
            dgdadoslancamento.TabIndex = 7;
            dgdadoslancamento.CellDoubleClick += dgdadoslancamento_CellDoubleClick;
            dgdadoslancamento.CellFormatting += dgdadoslancamento_CellFormatting;
            // 
            // FrmConsultaLancamento
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(875, 429);
            Controls.Add(btnlocalizar);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Controls.Add(dgdadoslancamento);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmConsultaLancamento";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta Lançamento";
            Load += FrmConsultaLancamento_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadoslancamento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnlocalizar;
        private TextBox txtdescricao;
        private Label label1;
        private DataGridView dgdadoslancamento;
    }
}