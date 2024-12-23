namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncDividendos
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
            dgdadosDiv = new DataGridView();
            dgtotais = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgdadosDiv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgtotais).BeginInit();
            SuspendLayout();
            // 
            // dgdadosDiv
            // 
            dgdadosDiv.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosDiv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosDiv.Dock = DockStyle.Top;
            dgdadosDiv.Location = new Point(0, 0);
            dgdadosDiv.Margin = new Padding(3, 4, 3, 4);
            dgdadosDiv.Name = "dgdadosDiv";
            dgdadosDiv.Size = new Size(814, 453);
            dgdadosDiv.TabIndex = 0;
            // 
            // dgtotais
            // 
            dgtotais.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgtotais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtotais.Dock = DockStyle.Bottom;
            dgtotais.Location = new Point(0, 491);
            dgtotais.Name = "dgtotais";
            dgtotais.Size = new Size(814, 109);
            dgtotais.TabIndex = 1;
            // 
            // FrmFuncDividendos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(814, 600);
            Controls.Add(dgtotais);
            Controls.Add(dgdadosDiv);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncDividendos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dividendos";
            Load += FrmFuncDividendos_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosDiv).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgtotais).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgdadosDiv;
        private DataGridView dgtotais;
    }
}