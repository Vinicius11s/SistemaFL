namespace SistemaFL
{
    partial class FrmConsultaEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaEmpresa));
            label1 = new Label();
            txtdescricao = new TextBox();
            btnlocalizar = new Button();
            dgdados = new DataGridView();
            pbFechar = new PictureBox();
            pbMaximizar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgdados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMaximizar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(158, 48);
            label1.Name = "label1";
            label1.Size = new Size(145, 20);
            label1.TabIndex = 0;
            label1.Text = "Descrição Empresa :";
            // 
            // txtdescricao
            // 
            txtdescricao.Font = new Font("Segoe UI Semilight", 11.25F);
            txtdescricao.Location = new Point(304, 47);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(327, 27);
            txtdescricao.TabIndex = 1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.FlatAppearance.BorderSize = 0;
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.Font = new Font("Segoe UI Semilight", 11.25F);
            btnlocalizar.Image = (Image)resources.GetObject("btnlocalizar.Image");
            btnlocalizar.Location = new Point(653, 45);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(40, 32);
            btnlocalizar.TabIndex = 2;
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // dgdados
            // 
            dgdados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdados.BackgroundColor = Color.White;
            dgdados.BorderStyle = BorderStyle.None;
            dgdados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdados.Location = new Point(0, 121);
            dgdados.Name = "dgdados";
            dgdados.Size = new Size(891, 347);
            dgdados.TabIndex = 3;
            dgdados.CellDoubleClick += dgdados_CellDoubleClick;
            dgdados.CellFormatting += dgdados_CellFormatting;
            // 
            // pbFechar
            // 
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(857, 4);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(30, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 15;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // pbMaximizar
            // 
            pbMaximizar.Image = (Image)resources.GetObject("pbMaximizar.Image");
            pbMaximizar.Location = new Point(820, 4);
            pbMaximizar.Name = "pbMaximizar";
            pbMaximizar.Size = new Size(30, 21);
            pbMaximizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMaximizar.TabIndex = 14;
            pbMaximizar.TabStop = false;
            pbMaximizar.Click += pbMaximizar_Click;
            // 
            // FrmConsultaEmpresa
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(891, 468);
            Controls.Add(pbFechar);
            Controls.Add(pbMaximizar);
            Controls.Add(dgdados);
            Controls.Add(btnlocalizar);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmConsultaEmpresa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta de Empresa";
            Load += FrmConsultaEmpresa_Load;
            Resize += FrmConsultaEmpresa_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdados).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMaximizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtdescricao;
        private Button btnlocalizar;
        private DataGridView dgdados;
        private PictureBox pbFechar;
        private PictureBox pbMaximizar;
    }
}