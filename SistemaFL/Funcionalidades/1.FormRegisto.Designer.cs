﻿namespace SistemaFL.Funcionalidades
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncionalidadeRegisto));
            dgdadosFunRegistro = new DataGridView();
            label1 = new Label();
            pbFechar = new PictureBox();
            label2 = new Label();
            lblTotalInvestimento = new Label();
            label3 = new Label();
            lblTotalFlats = new Label();
            label5 = new Label();
            label6 = new Label();
            tTamanhotela = new System.Windows.Forms.Timer(components);
            pbMinimizar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRegistro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFunRegistro
            // 
            dgdadosFunRegistro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosFunRegistro.BackgroundColor = Color.White;
            dgdadosFunRegistro.BorderStyle = BorderStyle.None;
            dgdadosFunRegistro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFunRegistro.GridColor = Color.FromArgb(23, 24, 29);
            dgdadosFunRegistro.Location = new Point(2, 120);
            dgdadosFunRegistro.Margin = new Padding(4);
            dgdadosFunRegistro.Name = "dgdadosFunRegistro";
            dgdadosFunRegistro.Size = new Size(1063, 436);
            dgdadosFunRegistro.TabIndex = 0;
            dgdadosFunRegistro.CellFormatting += dgdadosFunRegistro_CellFormatting;
            dgdadosFunRegistro.DataBindingComplete += dgdadosFunRegistro_DataBindingComplete;
            dgdadosFunRegistro.RowPrePaint += dgdadosFunRegistro_RowPrePaint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(224, 72);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(135, 20);
            label1.TabIndex = 6;
            label1.Text = "Total Investimento :";
            // 
            // pbFechar
            // 
            pbFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(856, 5);
            pbFechar.Margin = new Padding(4);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(26, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 9;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 21);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(93, 30);
            label2.TabIndex = 15;
            label2.Text = "Registros";
            // 
            // lblTotalInvestimento
            // 
            lblTotalInvestimento.AutoSize = true;
            lblTotalInvestimento.Location = new Point(362, 71);
            lblTotalInvestimento.Name = "lblTotalInvestimento";
            lblTotalInvestimento.Size = new Size(0, 21);
            lblTotalInvestimento.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(224, 78);
            label3.Name = "label3";
            label3.Size = new Size(269, 21);
            label3.TabIndex = 17;
            label3.Text = "_____________________________________";
            // 
            // lblTotalFlats
            // 
            lblTotalFlats.AutoSize = true;
            lblTotalFlats.Location = new Point(608, 71);
            lblTotalFlats.Name = "lblTotalFlats";
            lblTotalFlats.Size = new Size(0, 21);
            lblTotalFlats.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(528, 72);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 18;
            label5.Text = "Total Flats :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(528, 77);
            label6.Name = "label6";
            label6.Size = new Size(108, 21);
            label6.TabIndex = 20;
            label6.Text = "______________";
            // 
            // tTamanhotela
            // 
            tTamanhotela.Interval = 1;
            tTamanhotela.Tick += tTamanhotela_Tick;
            // 
            // pbMinimizar
            // 
            pbMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbMinimizar.Image = (Image)resources.GetObject("pbMinimizar.Image");
            pbMinimizar.Location = new Point(838, 5);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(20, 21);
            pbMinimizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMinimizar.TabIndex = 21;
            pbMinimizar.TabStop = false;
            pbMinimizar.Click += pbMinimizar_Click_1;
            // 
            // FrmFuncionalidadeRegisto
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1087, 558);
            Controls.Add(pbMinimizar);
            Controls.Add(lblTotalFlats);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(lblTotalInvestimento);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pbFechar);
            Controls.Add(dgdadosFunRegistro);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FrmFuncionalidadeRegisto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registros";
            FormClosing += FrmFuncionalidadeRegisto_FormClosing;
            Load += FrmFuncionalidadeRegisto_Load;
            Resize += FrmFuncionalidadeRegisto_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRegistro).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosFunRegistro;
        private Label label1;
        private PictureBox pbFechar;
        private Label label2;
        private Label lblTotalInvestimento;
        private Label label3;
        private Label lblTotalFlats;
        private Label label5;
        private Label label6;
        private System.Windows.Forms.Timer tTamanhotela;
        private PictureBox pbMinimizar;
    }
}