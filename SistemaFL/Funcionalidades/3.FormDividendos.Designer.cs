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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncDividendos));
            dgdadosDiv = new DataGridView();
            pbFechar = new PictureBox();
            label1 = new Label();
            pbMinimizar = new PictureBox();
            tTamanhotela = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgdadosDiv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            SuspendLayout();
            // 
            // dgdadosDiv
            // 
            dgdadosDiv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosDiv.BackgroundColor = Color.White;
            dgdadosDiv.BorderStyle = BorderStyle.None;
            dgdadosDiv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosDiv.Location = new Point(0, 77);
            dgdadosDiv.Margin = new Padding(3, 4, 3, 4);
            dgdadosDiv.Name = "dgdadosDiv";
            dgdadosDiv.Size = new Size(903, 343);
            dgdadosDiv.TabIndex = 0;
            dgdadosDiv.ColumnHeaderMouseClick += dgdadosDiv_ColumnHeaderMouseClick;
            dgdadosDiv.DataBindingComplete += dgdadosDiv_DataBindingComplete;
            // 
            // pbFechar
            // 
            pbFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(863, 5);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(30, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 13;
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
            label1.Size = new Size(111, 30);
            label1.TabIndex = 14;
            label1.Text = "Dividendos";
            // 
            // pbMinimizar
            // 
            pbMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbMinimizar.Image = (Image)resources.GetObject("pbMinimizar.Image");
            pbMinimizar.Location = new Point(833, 5);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(30, 21);
            pbMinimizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMinimizar.TabIndex = 15;
            pbMinimizar.TabStop = false;
            pbMinimizar.Click += pbMinimizar_Click;
            // 
            // tTamanhotela
            // 
            tTamanhotela.Interval = 1;
            tTamanhotela.Tick += tTamanhotela_Tick;
            // 
            // FrmFuncDividendos
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 421);
            Controls.Add(pbMinimizar);
            Controls.Add(label1);
            Controls.Add(pbFechar);
            Controls.Add(dgdadosDiv);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncDividendos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dividendos";
            Load += FrmFuncDividendos_Load;
            Resize += FrmFuncDividendos_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadosDiv).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosDiv;
        private PictureBox pbFechar;
        private Label label1;
        private PictureBox pbMinimizar;
        private System.Windows.Forms.Timer tTamanhotela;
    }
}