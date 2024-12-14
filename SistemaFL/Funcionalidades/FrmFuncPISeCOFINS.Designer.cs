namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncPISeCOFINS
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
            label2 = new Label();
            dgdadosPIS = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosPIS).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(480, 44);
            label1.Name = "label1";
            label1.Size = new Size(79, 21);
            label1.TabIndex = 0;
            label1.Text = "PIS 0,65%";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(588, 44);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 1;
            label2.Text = "COFINS 3%";
            // 
            // dgdadosPIS
            // 
            dgdadosPIS.BackgroundColor = SystemColors.ControlLightLight;
            dgdadosPIS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosPIS.Location = new Point(203, 93);
            dgdadosPIS.Name = "dgdadosPIS";
            dgdadosPIS.Size = new Size(770, 226);
            dgdadosPIS.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 103);
            label3.Name = "label3";
            label3.Size = new Size(191, 21);
            label3.TabIndex = 3;
            label3.Text = "Aluguel Pres. Venceslau";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(88, 133);
            label4.Name = "label4";
            label4.Size = new Size(109, 21);
            label4.TabIndex = 4;
            label4.Text = "Aluguel Flats";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(13, 163);
            label5.Name = "label5";
            label5.Size = new Size(184, 21);
            label5.TabIndex = 5;
            label5.Text = "Fundo de Reserva Flats";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(76, 197);
            label6.Name = "label6";
            label6.Size = new Size(121, 21);
            label6.TabIndex = 6;
            label6.Text = "BC Pis e Cofins";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(153, 247);
            label7.Name = "label7";
            label7.Size = new Size(34, 21);
            label7.TabIndex = 7;
            label7.Text = "PIS";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(130, 268);
            label8.Name = "label8";
            label8.Size = new Size(67, 21);
            label8.TabIndex = 8;
            label8.Text = "COFINS";
            // 
            // FrmFuncPISeCOFINS
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(985, 348);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dgdadosPIS);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmFuncPISeCOFINS";
            Text = "Previsão Pis e Cofins";
            Load += FrmFuncPISeCOFINS_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosPIS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView dgdadosPIS;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}