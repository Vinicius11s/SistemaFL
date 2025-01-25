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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncAluguelDividendo));
            dgdadosAlugDiv = new DataGridView();
            dgtotalmes = new DataGridView();
            pbFechar = new PictureBox();
            pbMaximizar = new PictureBox();
            label1 = new Label();
            pbMinimizar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgdadosAlugDiv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgtotalmes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            SuspendLayout();
            // 
            // dgdadosAlugDiv
            // 
            dgdadosAlugDiv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosAlugDiv.BackgroundColor = Color.White;
            dgdadosAlugDiv.BorderStyle = BorderStyle.None;
            dgdadosAlugDiv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosAlugDiv.Location = new Point(0, 40);
            dgdadosAlugDiv.Margin = new Padding(3, 10, 3, 4);
            dgdadosAlugDiv.Name = "dgdadosAlugDiv";
            dgdadosAlugDiv.ReadOnly = true;
            dgdadosAlugDiv.ScrollBars = ScrollBars.Horizontal;
            dgdadosAlugDiv.Size = new Size(900, 381);
            dgdadosAlugDiv.TabIndex = 0;
            dgdadosAlugDiv.ColumnHeaderMouseClick += dgdadosAlugDiv_ColumnHeaderMouseClick;
            dgdadosAlugDiv.DataBindingComplete += dgdadosAlugDiv_DataBindingComplete;
            dgdadosAlugDiv.Resize += dgdadosAlugDiv_Resize;
            // 
            // dgtotalmes
            // 
            dgtotalmes.BackgroundColor = Color.White;
            dgtotalmes.BorderStyle = BorderStyle.None;
            dgtotalmes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtotalmes.Dock = DockStyle.Bottom;
            dgtotalmes.Location = new Point(0, 352);
            dgtotalmes.Name = "dgtotalmes";
            dgtotalmes.ReadOnly = true;
            dgtotalmes.Size = new Size(900, 69);
            dgtotalmes.TabIndex = 1;
            // 
            // pbFechar
            // 
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(871, 6);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(30, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 11;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // pbMaximizar
            // 
            pbMaximizar.Image = (Image)resources.GetObject("pbMaximizar.Image");
            pbMaximizar.Location = new Point(834, 6);
            pbMaximizar.Name = "pbMaximizar";
            pbMaximizar.Size = new Size(30, 21);
            pbMaximizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMaximizar.TabIndex = 10;
            pbMaximizar.TabStop = false;
            pbMaximizar.Click += pbMaximizar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(10, 9);
            label1.Name = "label1";
            label1.Size = new Size(189, 22);
            label1.TabIndex = 15;
            label1.Text = "Aluguel + Dividendos";
            // 
            // pbMinimizar
            // 
            pbMinimizar.Image = (Image)resources.GetObject("pbMinimizar.Image");
            pbMinimizar.Location = new Point(798, 6);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(30, 21);
            pbMinimizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMinimizar.TabIndex = 16;
            pbMinimizar.TabStop = false;
            pbMinimizar.Click += pbMinimizar_Click;
            // 
            // FrmFuncAluguelDividendo
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 421);
            Controls.Add(pbMinimizar);
            Controls.Add(label1);
            Controls.Add(pbFechar);
            Controls.Add(pbMaximizar);
            Controls.Add(dgtotalmes);
            Controls.Add(dgdadosAlugDiv);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncAluguelDividendo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aluguel + Dividendos";
            Load += FrmFuncAluguelDividendo_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosAlugDiv).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgtotalmes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosAlugDiv;
        private DataGridView dgtotalmes;
        private PictureBox pbFechar;
        private PictureBox pbMaximizar;
        private Label label1;
        private PictureBox pbMinimizar;
    }
}