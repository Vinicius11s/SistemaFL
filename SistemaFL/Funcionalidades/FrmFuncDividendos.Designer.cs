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
            Button btncalcular;
            Label label1;
            dgdadosDiv = new DataGridView();
            cbbmesDiv = new ComboBox();
            txtTotalmes = new TextBox();
            btncalcular = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosDiv).BeginInit();
            SuspendLayout();
            // 
            // btncalcular
            // 
            btncalcular.Location = new Point(21, 90);
            btncalcular.Margin = new Padding(3, 4, 3, 4);
            btncalcular.Name = "btncalcular";
            btncalcular.Size = new Size(167, 30);
            btncalcular.TabIndex = 7;
            btncalcular.Text = "Calcular";
            btncalcular.UseVisualStyleBackColor = true;
            btncalcular.Click += btncalcular_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 32);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 6;
            label1.Text = "Calcular total mês";
            // 
            // dgdadosDiv
            // 
            dgdadosDiv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosDiv.Dock = DockStyle.Bottom;
            dgdadosDiv.Location = new Point(0, 183);
            dgdadosDiv.Margin = new Padding(3, 4, 3, 4);
            dgdadosDiv.Name = "dgdadosDiv";
            dgdadosDiv.Size = new Size(914, 417);
            dgdadosDiv.TabIndex = 0;
            // 
            // cbbmesDiv
            // 
            cbbmesDiv.FormattingEnabled = true;
            cbbmesDiv.Location = new Point(21, 55);
            cbbmesDiv.Name = "cbbmesDiv";
            cbbmesDiv.Size = new Size(167, 28);
            cbbmesDiv.TabIndex = 9;
            // 
            // txtTotalmes
            // 
            txtTotalmes.Location = new Point(204, 58);
            txtTotalmes.Name = "txtTotalmes";
            txtTotalmes.Size = new Size(100, 27);
            txtTotalmes.TabIndex = 10;
            // 
            // FrmFuncDividendos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(txtTotalmes);
            Controls.Add(cbbmesDiv);
            Controls.Add(btncalcular);
            Controls.Add(label1);
            Controls.Add(dgdadosDiv);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncDividendos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dividendos";
            Load += FrmFuncDividendos_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosDiv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosDiv;
        private ComboBox cbbmesDiv;
        private TextBox txtTotalmes;
    }
}