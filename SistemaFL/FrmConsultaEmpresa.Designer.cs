namespace SistemaFL
{
    partial class FrmConsultaEmpresa
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
            label1 = new Label();
            txtdescricao = new TextBox();
            button1 = new Button();
            dgdados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgdados).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 11.25F);
            label1.Location = new Point(152, 39);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 0;
            label1.Text = "Descrição Empresa :";
            // 
            // txtdescricao
            // 
            txtdescricao.Font = new Font("Segoe UI Semilight", 11.25F);
            txtdescricao.Location = new Point(152, 67);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(355, 27);
            txtdescricao.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semilight", 11.25F);
            button1.Location = new Point(534, 56);
            button1.Name = "button1";
            button1.Size = new Size(92, 46);
            button1.TabIndex = 2;
            button1.Text = "Localizar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgdados
            // 
            dgdados.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdados.Dock = DockStyle.Bottom;
            dgdados.Location = new Point(0, 137);
            dgdados.Name = "dgdados";
            dgdados.Size = new Size(807, 313);
            dgdados.TabIndex = 3;
            dgdados.CellDoubleClick += dgdados_CellDoubleClick;
            dgdados.CellFormatting += dgdados_CellFormatting;
            // 
            // FrmConsultaEmpresa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(807, 450);
            Controls.Add(dgdados);
            Controls.Add(button1);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmConsultaEmpresa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta de Empresa";
            Load += FrmConsultaEmpresa_Load;
            ((System.ComponentModel.ISupportInitialize)dgdados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtdescricao;
        private Button button1;
        private DataGridView dgdados;
    }
}