namespace SistemaFL.Funcionalidades
{
    partial class FrmFuncPISeCOFINS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFuncPISeCOFINS));
            lblPisTopo = new Label();
            lblCofinsTopo = new Label();
            dgdadosPIS = new DataGridView();
            pbFechar = new PictureBox();
            ckAlterarBases = new CheckBox();
            txtPis = new TextBox();
            txtCofins = new TextBox();
            btnSalvar = new Button();
            lblpis = new Label();
            lblcofins = new Label();
            pbMinimizar = new PictureBox();
            tTamanhotela = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgdadosPIS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            SuspendLayout();
            // 
            // lblPisTopo
            // 
            lblPisTopo.AutoSize = true;
            lblPisTopo.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            lblPisTopo.ForeColor = Color.Black;
            lblPisTopo.Location = new Point(374, 44);
            lblPisTopo.Name = "lblPisTopo";
            lblPisTopo.Size = new Size(42, 30);
            lblPisTopo.TabIndex = 0;
            lblPisTopo.Text = "PIS";
            // 
            // lblCofinsTopo
            // 
            lblCofinsTopo.AutoSize = true;
            lblCofinsTopo.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            lblCofinsTopo.ForeColor = Color.Black;
            lblCofinsTopo.Location = new Point(490, 44);
            lblCofinsTopo.Name = "lblCofinsTopo";
            lblCofinsTopo.Size = new Size(86, 30);
            lblCofinsTopo.TabIndex = 1;
            lblCofinsTopo.Text = "COFINS";
            // 
            // dgdadosPIS
            // 
            dgdadosPIS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosPIS.BackgroundColor = Color.White;
            dgdadosPIS.BorderStyle = BorderStyle.None;
            dgdadosPIS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosPIS.Location = new Point(1, 153);
            dgdadosPIS.Name = "dgdadosPIS";
            dgdadosPIS.Size = new Size(1027, 384);
            dgdadosPIS.TabIndex = 2;
            dgdadosPIS.CellFormatting += dgdadosPIS_CellFormatting_1;
            // 
            // pbFechar
            // 
            pbFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(856, 5);
            pbFechar.Margin = new Padding(4, 3, 4, 3);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(27, 20);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 12;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // ckAlterarBases
            // 
            ckAlterarBases.AutoSize = true;
            ckAlterarBases.Font = new Font("Segoe UI Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckAlterarBases.Location = new Point(12, 109);
            ckAlterarBases.Name = "ckAlterarBases";
            ckAlterarBases.Size = new Size(160, 21);
            ckAlterarBases.TabIndex = 13;
            ckAlterarBases.Text = "Alterar Base Pis e Cofins";
            ckAlterarBases.UseVisualStyleBackColor = true;
            ckAlterarBases.CheckedChanged += ckAlterarBases_CheckedChanged;
            // 
            // txtPis
            // 
            txtPis.Location = new Point(376, 77);
            txtPis.Name = "txtPis";
            txtPis.Size = new Size(42, 29);
            txtPis.TabIndex = 14;
            // 
            // txtCofins
            // 
            txtCofins.Location = new Point(508, 76);
            txtCofins.Name = "txtCofins";
            txtCofins.Size = new Size(42, 29);
            txtCofins.TabIndex = 15;
            // 
            // btnSalvar
            // 
            btnSalvar.FlatAppearance.BorderColor = Color.Black;
            btnSalvar.FlatAppearance.BorderSize = 2;
            btnSalvar.FlatStyle = FlatStyle.Popup;
            btnSalvar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvar.Location = new Point(603, 76);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(45, 30);
            btnSalvar.TabIndex = 16;
            btnSalvar.Text = "OK";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // lblpis
            // 
            lblpis.AutoSize = true;
            lblpis.Location = new Point(422, 80);
            lblpis.Name = "lblpis";
            lblpis.Size = new Size(23, 21);
            lblpis.TabIndex = 17;
            lblpis.Text = "%";
            // 
            // lblcofins
            // 
            lblcofins.AutoSize = true;
            lblcofins.Location = new Point(553, 78);
            lblcofins.Name = "lblcofins";
            lblcofins.Size = new Size(23, 21);
            lblcofins.TabIndex = 18;
            lblcofins.Text = "%";
            // 
            // pbMinimizar
            // 
            pbMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbMinimizar.Image = (Image)resources.GetObject("pbMinimizar.Image");
            pbMinimizar.Location = new Point(830, 5);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(27, 20);
            pbMinimizar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMinimizar.TabIndex = 23;
            pbMinimizar.TabStop = false;
            // 
            // tTamanhotela
            // 
            tTamanhotela.Tick += tTamanhotela_Tick;
            // 
            // FrmFuncPISeCOFINS
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1087, 549);
            Controls.Add(pbMinimizar);
            Controls.Add(lblcofins);
            Controls.Add(lblpis);
            Controls.Add(btnSalvar);
            Controls.Add(txtCofins);
            Controls.Add(txtPis);
            Controls.Add(ckAlterarBases);
            Controls.Add(pbFechar);
            Controls.Add(dgdadosPIS);
            Controls.Add(lblCofinsTopo);
            Controls.Add(lblPisTopo);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.InfoText;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FrmFuncPISeCOFINS";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Previsão Pis e Cofins";
            Load += FrmFuncPISeCOFINS_Load;
            ((System.ComponentModel.ISupportInitialize)dgdadosPIS).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPisTopo;
        private Label lblCofinsTopo;
        private DataGridView dgdadosPIS;
        private PictureBox pbFechar;
        private CheckBox ckAlterarBases;
        private TextBox txtPis;
        private TextBox txtCofins;
        private Button btnSalvar;
        private Label lblpis;
        private Label lblcofins;
        private PictureBox pbMinimizar;
        private System.Windows.Forms.Timer tTamanhotela;
    }
}