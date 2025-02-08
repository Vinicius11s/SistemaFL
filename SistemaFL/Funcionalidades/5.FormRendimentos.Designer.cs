namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncRendimentoscs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncRendimentoscs));
            dgdadosTotais = new DataGridView();
            pbFechar = new PictureBox();
            label2 = new Label();
            dgdadosRendimentos = new DataGridView();
            txtano = new TextBox();
            label1 = new Label();
            btnlocalizar = new Button();
            tTamanhotela = new System.Windows.Forms.Timer(components);
            pbMinimizar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgdadosTotais).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgdadosRendimentos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            SuspendLayout();
            // 
            // dgdadosTotais
            // 
            dgdadosTotais.BackgroundColor = Color.White;
            dgdadosTotais.BorderStyle = BorderStyle.None;
            dgdadosTotais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosTotais.Dock = DockStyle.Bottom;
            dgdadosTotais.Location = new Point(0, 447);
            dgdadosTotais.Margin = new Padding(4);
            dgdadosTotais.Name = "dgdadosTotais";
            dgdadosTotais.Size = new Size(900, 67);
            dgdadosTotais.TabIndex = 1;
            // 
            // pbFechar
            // 
            pbFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(659, 12);
            pbFechar.Margin = new Padding(4, 3, 4, 3);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(27, 20);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 11;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 21);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(128, 30);
            label2.TabIndex = 16;
            label2.Text = "Rendimentos";
            // 
            // dgdadosRendimentos
            // 
            dgdadosRendimentos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosRendimentos.BackgroundColor = Color.White;
            dgdadosRendimentos.BorderStyle = BorderStyle.None;
            dgdadosRendimentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosRendimentos.Location = new Point(0, 131);
            dgdadosRendimentos.Name = "dgdadosRendimentos";
            dgdadosRendimentos.Size = new Size(900, 305);
            dgdadosRendimentos.TabIndex = 17;
            dgdadosRendimentos.CellPainting += dgdadosRendimentos_CellPainting;
            dgdadosRendimentos.DataBindingComplete += dgdadosRendimentos_DataBindingComplete;
            // 
            // txtano
            // 
            txtano.Font = new Font("Segoe UI Semilight", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtano.Location = new Point(319, 35);
            txtano.Name = "txtano";
            txtano.Size = new Size(100, 25);
            txtano.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(273, 36);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(46, 21);
            label1.TabIndex = 19;
            label1.Text = "Ano :";
            // 
            // btnlocalizar
            // 
            btnlocalizar.FlatAppearance.BorderSize = 0;
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.Font = new Font("Segoe UI Semilight", 11.25F);
            btnlocalizar.Image = (Image)resources.GetObject("btnlocalizar.Image");
            btnlocalizar.Location = new Point(437, 33);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(33, 26);
            btnlocalizar.TabIndex = 20;
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += btnlocalizar_Click;
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
            pbMinimizar.Location = new Point(629, 11);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(30, 21);
            pbMinimizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMinimizar.TabIndex = 22;
            pbMinimizar.TabStop = false;
            pbMinimizar.Click += pbMinimizar_Click;
            // 
            // FrmFuncRendimentoscs
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 514);
            Controls.Add(pbMinimizar);
            Controls.Add(btnlocalizar);
            Controls.Add(label1);
            Controls.Add(txtano);
            Controls.Add(dgdadosRendimentos);
            Controls.Add(label2);
            Controls.Add(pbFechar);
            Controls.Add(dgdadosTotais);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FrmFuncRendimentoscs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rendimentos";
            Load += FrmFuncRendimentoscs_Load;
            Resize += FrmFuncRendimentoscs_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadosTotais).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgdadosRendimentos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgdadosTotais;
        private PictureBox pbFechar;
        private Label label2;
        private DataGridView dgdadosRendimentos;
        private TextBox txtano;
        private Label label1;
        private Button btnlocalizar;
        private System.Windows.Forms.Timer tTamanhotela;
        private PictureBox pbMinimizar;
    }
}