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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncFundoReserva));
            dgdadosFunRes = new DataGridView();
            pbFechar = new PictureBox();
            pbMaximizar = new PictureBox();
            label2 = new Label();
            pbMinimizar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgdadosFunRes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFunRes
            // 
            dgdadosFunRes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosFunRes.BackgroundColor = Color.White;
            dgdadosFunRes.BorderStyle = BorderStyle.None;
            dgdadosFunRes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFunRes.Location = new Point(0, 82);
            dgdadosFunRes.Margin = new Padding(3, 4, 3, 4);
            dgdadosFunRes.Name = "dgdadosFunRes";
            dgdadosFunRes.Size = new Size(900, 341);
            dgdadosFunRes.TabIndex = 0;
            dgdadosFunRes.ColumnHeaderMouseClick += dgdadosFunRes_ColumnHeaderMouseClick;
            dgdadosFunRes.DataBindingComplete += dgdadosFunRes_DataBindingComplete;
            // 
            // pbFechar
            // 
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(861, 5);
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
            pbMaximizar.Location = new Point(828, 5);
            pbMaximizar.Name = "pbMaximizar";
            pbMaximizar.Size = new Size(30, 21);
            pbMaximizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMaximizar.TabIndex = 10;
            pbMaximizar.TabStop = false;
            pbMaximizar.Click += pbMaximizar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 20);
            label2.Name = "label2";
            label2.Size = new Size(167, 22);
            label2.TabIndex = 16;
            label2.Text = "Fundo de Reserva";
            // 
            // pbMinimizar
            // 
            pbMinimizar.Image = (Image)resources.GetObject("pbMinimizar.Image");
            pbMinimizar.Location = new Point(794, 5);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(30, 21);
            pbMinimizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMinimizar.TabIndex = 17;
            pbMinimizar.TabStop = false;
            pbMinimizar.Click += pbMinimizar_Click;
            // 
            // FrmFuncFundoReserva
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 421);
            Controls.Add(pbMinimizar);
            Controls.Add(label2);
            Controls.Add(pbFechar);
            Controls.Add(pbMaximizar);
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
            ((System.ComponentModel.ISupportInitialize)pbMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosFunRes;
        private PictureBox pbFechar;
        private PictureBox pbMaximizar;
        private Label label2;
        private PictureBox pbMinimizar;
    }
}