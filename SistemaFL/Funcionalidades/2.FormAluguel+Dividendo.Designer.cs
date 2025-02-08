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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncAluguelDividendo));
            dgdadosAlugDiv = new DataGridView();
            dgtotalmes = new DataGridView();
            pbFechar = new PictureBox();
            label1 = new Label();
            pbMinimizar = new PictureBox();
            tTamanhotela = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgdadosAlugDiv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgtotalmes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            SuspendLayout();
            // 
            // dgdadosAlugDiv
            // 
            dgdadosAlugDiv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosAlugDiv.BackgroundColor = Color.White;
            dgdadosAlugDiv.BorderStyle = BorderStyle.None;
            dgdadosAlugDiv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosAlugDiv.Location = new Point(0, 88);
            dgdadosAlugDiv.Margin = new Padding(3, 10, 3, 4);
            dgdadosAlugDiv.Name = "dgdadosAlugDiv";
            dgdadosAlugDiv.ReadOnly = true;
            dgdadosAlugDiv.ScrollBars = ScrollBars.Horizontal;
            dgdadosAlugDiv.Size = new Size(872, 562);
            dgdadosAlugDiv.TabIndex = 0;
            dgdadosAlugDiv.ColumnHeaderMouseClick += dgdadosAlugDiv_ColumnHeaderMouseClick;
            dgdadosAlugDiv.DataBindingComplete += dgdadosAlugDiv_DataBindingComplete;
            // 
            // dgtotalmes
            // 
            dgtotalmes.BackgroundColor = Color.White;
            dgtotalmes.BorderStyle = BorderStyle.None;
            dgtotalmes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtotalmes.Location = new Point(0, 682);
            dgtotalmes.Name = "dgtotalmes";
            dgtotalmes.ReadOnly = true;
            dgtotalmes.Size = new Size(1045, 69);
            dgtotalmes.TabIndex = 1;
            // 
            // pbFechar
            // 
            pbFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(842, 5);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(30, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 11;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(24, 21);
            label1.Name = "label1";
            label1.Size = new Size(203, 30);
            label1.TabIndex = 15;
            label1.Text = "Aluguel + Dividendos";
            // 
            // pbMinimizar
            // 
            pbMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbMinimizar.Image = (Image)resources.GetObject("pbMinimizar.Image");
            pbMinimizar.Location = new Point(813, 5);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(30, 21);
            pbMinimizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMinimizar.TabIndex = 16;
            pbMinimizar.TabStop = false;
            pbMinimizar.Click += pbMinimizar_Click;
            // 
            // tTamanhotela
            // 
            tTamanhotela.Interval = 1;
            tTamanhotela.Tick += tTamanhotela_Tick;
            // 
            // FrmFuncAluguelDividendo
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1087, 749);
            Controls.Add(pbMinimizar);
            Controls.Add(label1);
            Controls.Add(pbFechar);
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
            Resize += FrmFuncAluguelDividendo_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadosAlugDiv).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgtotalmes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosAlugDiv;
        private DataGridView dgtotalmes;
        private PictureBox pbFechar;
        private Label label1;
        private PictureBox pbMinimizar;
        private System.Windows.Forms.Timer tTamanhotela;
    }
}