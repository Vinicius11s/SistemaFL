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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncionalidadeRegisto));
            dgdadosFunRegistro = new DataGridView();
            txtTotalInvestimento = new TextBox();
            label1 = new Label();
            pbMaximizar = new PictureBox();
            pbFechar = new PictureBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRegistro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFunRegistro
            // 
            dgdadosFunRegistro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosFunRegistro.BackgroundColor = Color.White;
            dgdadosFunRegistro.BorderStyle = BorderStyle.None;
            dgdadosFunRegistro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFunRegistro.GridColor = Color.FromArgb(23, 24, 29);
            dgdadosFunRegistro.Location = new Point(2, 88);
            dgdadosFunRegistro.Margin = new Padding(4);
            dgdadosFunRegistro.Name = "dgdadosFunRegistro";
            dgdadosFunRegistro.Size = new Size(870, 330);
            dgdadosFunRegistro.TabIndex = 0;
            dgdadosFunRegistro.CellFormatting += dgdadosFunRegistro_CellFormatting;
            dgdadosFunRegistro.DataBindingComplete += dgdadosFunRegistro_DataBindingComplete;
            dgdadosFunRegistro.RowPrePaint += dgdadosFunRegistro_RowPrePaint;
            // 
            // txtTotalInvestimento
            // 
            txtTotalInvestimento.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalInvestimento.Location = new Point(182, 55);
            txtTotalInvestimento.Margin = new Padding(4, 6, 4, 6);
            txtTotalInvestimento.Name = "txtTotalInvestimento";
            txtTotalInvestimento.ReadOnly = true;
            txtTotalInvestimento.Size = new Size(177, 27);
            txtTotalInvestimento.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 58);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 6;
            label1.Text = "TOTAL INVESTIMENTO :";
            // 
            // pbMaximizar
            // 
            pbMaximizar.Image = (Image)resources.GetObject("pbMaximizar.Image");
            pbMaximizar.Location = new Point(790, 6);
            pbMaximizar.Margin = new Padding(4);
            pbMaximizar.Name = "pbMaximizar";
            pbMaximizar.Size = new Size(35, 25);
            pbMaximizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMaximizar.TabIndex = 8;
            pbMaximizar.TabStop = false;
            pbMaximizar.Click += pbMaximizar_Click;
            // 
            // pbFechar
            // 
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(830, 6);
            pbFechar.Margin = new Padding(4);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(35, 25);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 9;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 15);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(92, 22);
            label2.TabIndex = 15;
            label2.Text = "Registros";
            // 
            // FrmFuncionalidadeRegisto
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(870, 420);
            Controls.Add(label2);
            Controls.Add(pbFechar);
            Controls.Add(pbMaximizar);
            Controls.Add(txtTotalInvestimento);
            Controls.Add(label1);
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
            ((System.ComponentModel.ISupportInitialize)pbMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosFunRegistro;
        private TextBox txtTotalInvestimento;
        private Label label1;
        private PictureBox pbMaximizar;
        private PictureBox pbFechar;
        private Label label2;
    }
}