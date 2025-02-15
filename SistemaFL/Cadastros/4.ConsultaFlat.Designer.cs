namespace SistemaFL
{
    partial class FrmConsultaFlat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaFlat));
            dgdadosFlats = new DataGridView();
            btnlocalizar = new Button();
            txtdescricao = new TextBox();
            label1 = new Label();
            pbFechar = new PictureBox();
            tTamanhotela = new System.Windows.Forms.Timer(components);
            pbMinimizar = new PictureBox();
            cbbTipoCad = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosFlats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFlats
            // 
            dgdadosFlats.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosFlats.BackgroundColor = Color.White;
            dgdadosFlats.BorderStyle = BorderStyle.None;
            dgdadosFlats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFlats.Location = new Point(0, 117);
            dgdadosFlats.Margin = new Padding(3, 4, 3, 4);
            dgdadosFlats.Name = "dgdadosFlats";
            dgdadosFlats.Size = new Size(1025, 441);
            dgdadosFlats.TabIndex = 0;
            dgdadosFlats.CellDoubleClick += dgdadosFlats_CellDoubleClic;
            dgdadosFlats.DataBindingComplete += dgdadosFlats_DataBindingComplete;
            // 
            // btnlocalizar
            // 
            btnlocalizar.FlatAppearance.BorderSize = 0;
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.Image = (Image)resources.GetObject("btnlocalizar.Image");
            btnlocalizar.Location = new Point(731, 50);
            btnlocalizar.Margin = new Padding(3, 4, 3, 4);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(36, 31);
            btnlocalizar.TabIndex = 5;
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // txtdescricao
            // 
            txtdescricao.Location = new Point(104, 53);
            txtdescricao.Margin = new Padding(3, 4, 3, 4);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(390, 29);
            txtdescricao.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(104, 24);
            label1.Name = "label1";
            label1.Size = new Size(147, 25);
            label1.TabIndex = 3;
            label1.Text = "Descrição Flat : ";
            // 
            // pbFechar
            // 
            pbFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(856, 5);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(24, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 13;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click_1;
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
            pbMinimizar.Location = new Point(836, 5);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(20, 21);
            pbMinimizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMinimizar.TabIndex = 51;
            pbMinimizar.TabStop = false;
            // 
            // cbbTipoCad
            // 
            cbbTipoCad.FormattingEnabled = true;
            cbbTipoCad.Items.AddRange(new object[] { "Todos", "Pool ", "Plataforma" });
            cbbTipoCad.Location = new Point(558, 52);
            cbbTipoCad.Name = "cbbTipoCad";
            cbbTipoCad.Size = new Size(131, 29);
            cbbTipoCad.TabIndex = 52;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(549, 24);
            label2.Name = "label2";
            label2.Size = new Size(140, 25);
            label2.TabIndex = 53;
            label2.Text = "Tipo Cadastro :";
            // 
            // FrmConsultaFlat
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1087, 558);
            Controls.Add(label2);
            Controls.Add(cbbTipoCad);
            Controls.Add(pbMinimizar);
            Controls.Add(pbFechar);
            Controls.Add(btnlocalizar);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Controls.Add(dgdadosFlats);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmConsultaFlat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta Flats";
            Load += FrmConsultaFlat_Load_1;
            Resize += FrmConsultaFlat_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadosFlats).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosFlats;
        private Button btnlocalizar;
        private TextBox txtdescricao;
        private Label label1;
        private PictureBox pbFechar;
        private System.Windows.Forms.Timer tTamanhotela;
        private PictureBox pbMinimizar;
        private ComboBox cbbTipoCad;
        private Label label2;
    }
}