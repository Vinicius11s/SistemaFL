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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaEmpresa));
            label1 = new Label();
            txtdescricao = new TextBox();
            btnlocalizar = new Button();
            dgdados = new DataGridView();
            pbFechar = new PictureBox();
            tTamanhotela = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgdados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(152, 43);
            label1.Name = "label1";
            label1.Size = new Size(105, 25);
            label1.TabIndex = 0;
            label1.Text = "Descrição :";
            // 
            // txtdescricao
            // 
            txtdescricao.Font = new Font("Segoe UI Semilight", 11.25F);
            txtdescricao.Location = new Point(263, 44);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(472, 27);
            txtdescricao.TabIndex = 1;
            // 
            // btnlocalizar
            // 
            btnlocalizar.FlatAppearance.BorderSize = 0;
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.Font = new Font("Segoe UI Semilight", 11.25F);
            btnlocalizar.Image = (Image)resources.GetObject("btnlocalizar.Image");
            btnlocalizar.Location = new Point(747, 41);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(41, 32);
            btnlocalizar.TabIndex = 2;
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // dgdados
            // 
            dgdados.BackgroundColor = Color.White;
            dgdados.BorderStyle = BorderStyle.None;
            dgdados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdados.Location = new Point(12, 108);
            dgdados.Name = "dgdados";
            dgdados.Size = new Size(1063, 448);
            dgdados.TabIndex = 3;
            dgdados.CellDoubleClick += dgdados_CellDoubleClick;
            dgdados.CellFormatting += dgdados_CellFormatting;
            dgdados.DataBindingComplete += dgdados_DataBindingComplete;
            // 
            // pbFechar
            // 
            pbFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(835, 4);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(30, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 15;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // tTamanhotela
            // 
            tTamanhotela.Interval = 5;
            tTamanhotela.Tick += tTamanhotela_Tick;
            // 
            // FrmConsultaEmpresa
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1087, 558);
            Controls.Add(pbFechar);
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
            ((System.ComponentModel.ISupportInitialize)dgdados).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtdescricao;
        private Button btnlocalizar;
        private DataGridView dgdados;
        private PictureBox pbFechar;
        private System.Windows.Forms.Timer tTamanhotela;
    }
}