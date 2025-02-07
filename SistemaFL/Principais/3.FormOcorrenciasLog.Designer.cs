namespace SistemaFL
{
    partial class FrmConsultaOcorrencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaOcorrencia));
            label2 = new Label();
            dgdadosocorrencias = new DataGridView();
            pbFechar = new PictureBox();
            pbMinimizar = new PictureBox();
            tTamanhotela = new System.Windows.Forms.Timer(components);
            ckOutrosLanc = new CheckBox();
            btnlocalizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgdadosocorrencias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(349, 28);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(212, 30);
            label2.TabIndex = 16;
            label2.Text = "Últimos Lançamentos";
            // 
            // dgdadosocorrencias
            // 
            dgdadosocorrencias.BackgroundColor = Color.White;
            dgdadosocorrencias.BorderStyle = BorderStyle.None;
            dgdadosocorrencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosocorrencias.Location = new Point(1, 94);
            dgdadosocorrencias.Margin = new Padding(4);
            dgdadosocorrencias.Name = "dgdadosocorrencias";
            dgdadosocorrencias.Size = new Size(1087, 376);
            dgdadosocorrencias.TabIndex = 12;
            // 
            // pbFechar
            // 
            pbFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(842, 5);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(30, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 17;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // pbMinimizar
            // 
            pbMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbMinimizar.Image = (Image)resources.GetObject("pbMinimizar.Image");
            pbMinimizar.Location = new Point(815, 5);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(30, 21);
            pbMinimizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMinimizar.TabIndex = 18;
            pbMinimizar.TabStop = false;
            pbMinimizar.Click += pbMinimizar_Click;
            // 
            // tTamanhotela
            // 
            tTamanhotela.Interval = 1;
            tTamanhotela.Tick += tTamanhotela_Tick;
            // 
            // ckOutrosLanc
            // 
            ckOutrosLanc.AutoSize = true;
            ckOutrosLanc.ImeMode = ImeMode.NoControl;
            ckOutrosLanc.Location = new Point(44, 34);
            ckOutrosLanc.Name = "ckOutrosLanc";
            ckOutrosLanc.Size = new Size(170, 25);
            ckOutrosLanc.TabIndex = 20;
            ckOutrosLanc.Text = "Outros Lançamentos";
            ckOutrosLanc.UseVisualStyleBackColor = true;
            // 
            // btnlocalizar
            // 
            btnlocalizar.BackColor = Color.White;
            btnlocalizar.FlatAppearance.BorderSize = 0;
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnlocalizar.ForeColor = Color.FromArgb(23, 24, 29);
            btnlocalizar.Image = (Image)resources.GetObject("btnlocalizar.Image");
            btnlocalizar.ImeMode = ImeMode.NoControl;
            btnlocalizar.Location = new Point(221, 33);
            btnlocalizar.Margin = new Padding(4);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(37, 26);
            btnlocalizar.TabIndex = 19;
            btnlocalizar.UseVisualStyleBackColor = false;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // FrmConsultaOcorrencia
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1087, 558);
            Controls.Add(ckOutrosLanc);
            Controls.Add(btnlocalizar);
            Controls.Add(pbMinimizar);
            Controls.Add(pbFechar);
            Controls.Add(label2);
            Controls.Add(dgdadosocorrencias);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FrmConsultaOcorrencia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Últimos Lançamentos";
            Load += FrmConsultaOcorrencia_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosocorrencias).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private DataGridView dgdadosocorrencias;
        private PictureBox pbFechar;
        private PictureBox pbMinimizar;
        private System.Windows.Forms.Timer tTamanhotela;
        private CheckBox ckOutrosLanc;
        private Button btnlocalizar;
    }
}