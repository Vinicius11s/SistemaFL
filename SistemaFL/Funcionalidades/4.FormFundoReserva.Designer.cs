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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncFundoReserva));
            dgdadosFunRes = new DataGridView();
            pbFechar = new PictureBox();
            label2 = new Label();
            pbMinimizar = new PictureBox();
            tTamanhotela = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFunRes
            // 
            dgdadosFunRes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosFunRes.BackgroundColor = Color.White;
            dgdadosFunRes.BorderStyle = BorderStyle.None;
            dgdadosFunRes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFunRes.Location = new Point(0, 85);
            dgdadosFunRes.Margin = new Padding(3, 4, 3, 4);
            dgdadosFunRes.Name = "dgdadosFunRes";
            dgdadosFunRes.Size = new Size(900, 431);
            dgdadosFunRes.TabIndex = 0;
            dgdadosFunRes.ColumnHeaderMouseClick += dgdadosFunRes_ColumnHeaderMouseClick;
            dgdadosFunRes.DataBindingComplete += dgdadosFunRes_DataBindingComplete;
            // 
            // pbFechar
            // 
            pbFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(659, 12);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(30, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 11;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Light", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 21);
            label2.Name = "label2";
            label2.Size = new Size(168, 30);
            label2.TabIndex = 16;
            label2.Text = "Fundo de Reserva";
            // 
            // pbMinimizar
            // 
            pbMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbMinimizar.Image = (Image)resources.GetObject("pbMinimizar.Image");
            pbMinimizar.Location = new Point(629, 12);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(30, 21);
            pbMinimizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMinimizar.TabIndex = 17;
            pbMinimizar.TabStop = false;
            pbMinimizar.Click += pbMinimizar_Click;
            // 
            // tTamanhotela
            // 
            tTamanhotela.Interval = 1;
            tTamanhotela.Tick += tTamanhotela_Tick;
            // 
            // FrmFuncFundoReserva
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 514);
            Controls.Add(pbMinimizar);
            Controls.Add(label2);
            Controls.Add(pbFechar);
            Controls.Add(dgdadosFunRes);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFuncFundoReserva";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fundo de Reserva";
            Load += FrmFuncFundoReserva_Load;
            Resize += FrmFuncFundoReserva_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosFunRes;
        private PictureBox pbFechar;
        private Label label2;
        private PictureBox pbMinimizar;
        private System.Windows.Forms.Timer tTamanhotela;
    }
}