﻿namespace SistemaFL.Funcionalidades
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
            ((System.ComponentModel.ISupportInitialize)dgdadosPIS).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Info;
            label1.Location = new Point(388, 43);
            label1.Name = "label1";
            label1.Size = new Size(83, 21);
            label1.TabIndex = 0;
            label1.Text = "PIS 0,65%";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Info;
            label2.Location = new Point(496, 43);
            label2.Name = "label2";
            label2.Size = new Size(94, 21);
            label2.TabIndex = 1;
            label2.Text = "COFINS 3%";
            // 
            // dgdadosPIS
            // 
            dgdadosPIS.BackgroundColor = SystemColors.ActiveBorder;
            dgdadosPIS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosPIS.Dock = DockStyle.Bottom;
            dgdadosPIS.Location = new Point(0, 117);
            dgdadosPIS.Name = "dgdadosPIS";
            dgdadosPIS.Size = new Size(985, 280);
            dgdadosPIS.TabIndex = 2;
            dgdadosPIS.CellFormatting += dgdadosPIS_CellFormatting_1;
            // 
            // FrmFuncPISeCOFINS
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(985, 397);
            Controls.Add(dgdadosPIS);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.InfoText;
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
    }
}