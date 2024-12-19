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
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdados).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 54);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 0;
            label1.Text = "Descrição";
            // 
            // txtdescricao
            // 
            txtdescricao.Location = new Point(114, 51);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(504, 27);
            txtdescricao.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(669, 45);
            button1.Name = "button1";
            button1.Size = new Size(92, 38);
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
            dgdados.Location = new Point(0, 163);
            dgdados.Name = "dgdados";
            dgdados.Size = new Size(831, 275);
            dgdados.TabIndex = 3;
            dgdados.CellDoubleClick += dgdados_CellDoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(348, 116);
            label2.Name = "label2";
            label2.Size = new Size(94, 25);
            label2.TabIndex = 4;
            label2.Text = "Registros";
            // 
            // FrmConsultaEmpresa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(831, 438);
            Controls.Add(label2);
            Controls.Add(dgdados);
            Controls.Add(button1);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmConsultaEmpresa";
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
        private Label label2;
    }
}