namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncionalidadeRegisto
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
            dgdadosFunRegistro = new DataGridView();
            txtTotalInvestimento = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRegistro).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFunRegistro
            // 
            dgdadosFunRegistro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFunRegistro.Dock = DockStyle.Bottom;
            dgdadosFunRegistro.Location = new Point(0, 107);
            dgdadosFunRegistro.Name = "dgdadosFunRegistro";
            dgdadosFunRegistro.Size = new Size(800, 343);
            dgdadosFunRegistro.TabIndex = 0;
            // 
            // txtTotalInvestimento
            // 
            txtTotalInvestimento.Location = new Point(43, 53);
            txtTotalInvestimento.Margin = new Padding(3, 4, 3, 4);
            txtTotalInvestimento.Name = "txtTotalInvestimento";
            txtTotalInvestimento.ReadOnly = true;
            txtTotalInvestimento.Size = new Size(137, 23);
            txtTotalInvestimento.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(43, 29);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 6;
            label1.Text = "Total Investimento";
            // 
            // FrmFuncionalidadeRegisto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtTotalInvestimento);
            Controls.Add(label1);
            Controls.Add(dgdadosFunRegistro);
            Name = "FrmFuncionalidadeRegisto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFuncionalidadeRegisto";
            Load += FrmFuncionalidadeRegisto_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRegistro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosFunRegistro;
        private TextBox txtTotalInvestimento;
        private Label label1;
    }
}