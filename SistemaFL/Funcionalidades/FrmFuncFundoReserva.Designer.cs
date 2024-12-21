namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncFundoReserva
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
            dgdadosFunRes = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            cbbMesFunRes = new ComboBox();
            txttotalFunRes = new TextBox();
            btncalcular = new Button();
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRes).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFunRes
            // 
            dgdadosFunRes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFunRes.Dock = DockStyle.Bottom;
            dgdadosFunRes.Location = new Point(0, 192);
            dgdadosFunRes.Margin = new Padding(3, 4, 3, 4);
            dgdadosFunRes.Name = "dgdadosFunRes";
            dgdadosFunRes.Size = new Size(914, 408);
            dgdadosFunRes.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 18);
            label1.Name = "label1";
            label1.Size = new Size(197, 21);
            label1.TabIndex = 1;
            label1.Text = "Dados Fundo de Reserva";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 53);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 2;
            label2.Text = "Total Mês";
            // 
            // cbbMesFunRes
            // 
            cbbMesFunRes.FormattingEnabled = true;
            cbbMesFunRes.Location = new Point(23, 76);
            cbbMesFunRes.Name = "cbbMesFunRes";
            cbbMesFunRes.Size = new Size(146, 28);
            cbbMesFunRes.TabIndex = 3;
            // 
            // txttotalFunRes
            // 
            txttotalFunRes.Enabled = false;
            txttotalFunRes.Location = new Point(202, 77);
            txttotalFunRes.Name = "txttotalFunRes";
            txttotalFunRes.Size = new Size(107, 27);
            txttotalFunRes.TabIndex = 4;
            // 
            // btncalcular
            // 
            btncalcular.Location = new Point(23, 110);
            btncalcular.Name = "btncalcular";
            btncalcular.Size = new Size(146, 27);
            btncalcular.TabIndex = 5;
            btncalcular.Text = "Calcular";
            btncalcular.UseVisualStyleBackColor = true;
            btncalcular.Click += btncalcular_Click;
            // 
            // FrmFuncFundoReserva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btncalcular);
            Controls.Add(txttotalFunRes);
            Controls.Add(cbbMesFunRes);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgdadosFunRes);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncFundoReserva";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fundo de Reserva";
            Load += FrmFuncFundoReserva_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosFunRes;
        private Label label1;
        private Label label2;
        private ComboBox cbbMesFunRes;
        private TextBox txttotalFunRes;
        private Button btncalcular;
    }
}