namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncRendimentos
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
            dgdadosRend = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgdadosRend).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 25);
            label1.Name = "label1";
            label1.Size = new Size(111, 21);
            label1.TabIndex = 0;
            label1.Text = "Rendimentos";
            // 
            // dgdadosRend
            // 
            dgdadosRend.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosRend.Dock = DockStyle.Bottom;
            dgdadosRend.Location = new Point(0, 149);
            dgdadosRend.Name = "dgdadosRend";
            dgdadosRend.Size = new Size(914, 214);
            dgdadosRend.TabIndex = 1;
            // 
            // FrmFuncRendimentos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 363);
            Controls.Add(dgdadosRend);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncRendimentos";
            Text = "Rendimentos";
            Load += FrmFuncRendimentos_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosRend).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgdadosRend;
    }
}