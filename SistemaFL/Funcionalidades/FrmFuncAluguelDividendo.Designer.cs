namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncAluguelDividendo
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
            dgdadosAlugDiv = new DataGridView();
            cbbmeses = new ComboBox();
            label1 = new Label();
            btncalcular = new Button();
            txtTotalmes = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgdadosAlugDiv).BeginInit();
            SuspendLayout();
            // 
            // dgdadosAlugDiv
            // 
            dgdadosAlugDiv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosAlugDiv.Dock = DockStyle.Bottom;
            dgdadosAlugDiv.Location = new Point(0, 244);
            dgdadosAlugDiv.Margin = new Padding(3, 4, 3, 4);
            dgdadosAlugDiv.Name = "dgdadosAlugDiv";
            dgdadosAlugDiv.Size = new Size(914, 356);
            dgdadosAlugDiv.TabIndex = 0;
            // 
            // cbbmeses
            // 
            cbbmeses.FormattingEnabled = true;
            cbbmeses.Location = new Point(14, 52);
            cbbmeses.Margin = new Padding(3, 4, 3, 4);
            cbbmeses.Name = "cbbmeses";
            cbbmeses.Size = new Size(165, 28);
            cbbmeses.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 28);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 2;
            label1.Text = "Calcular total mês";
            // 
            // btncalcular
            // 
            btncalcular.Location = new Point(13, 89);
            btncalcular.Name = "btncalcular";
            btncalcular.Size = new Size(166, 27);
            btncalcular.TabIndex = 3;
            btncalcular.Text = "Calcular";
            btncalcular.UseVisualStyleBackColor = true;
            btncalcular.Click += btncalcular_Click;
            // 
            // txtTotalmes
            // 
            txtTotalmes.Enabled = false;
            txtTotalmes.Location = new Point(211, 53);
            txtTotalmes.Name = "txtTotalmes";
            txtTotalmes.Size = new Size(119, 27);
            txtTotalmes.TabIndex = 4;
            // 
            // FrmFuncAluguelDividendo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(txtTotalmes);
            Controls.Add(btncalcular);
            Controls.Add(label1);
            Controls.Add(cbbmeses);
            Controls.Add(dgdadosAlugDiv);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncAluguelDividendo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aluguel + Dividendos";
            Load += FrmFuncAluguelDividendo_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosAlugDiv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosAlugDiv;
        private ComboBox cbbmeses;
        private Label label1;
        private Button btncalcular;
        private TextBox txtTotalmes;
    }
}