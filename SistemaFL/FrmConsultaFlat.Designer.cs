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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaFlat));
            dgdadosFlats = new DataGridView();
            btnlocalizar = new Button();
            txtdescricao = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosFlats).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFlats
            // 
            dgdadosFlats.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdadosFlats.BackgroundColor = Color.White;
            dgdadosFlats.BorderStyle = BorderStyle.None;
            dgdadosFlats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFlats.Location = new Point(0, 87);
            dgdadosFlats.Margin = new Padding(3, 4, 3, 4);
            dgdadosFlats.Name = "dgdadosFlats";
            dgdadosFlats.Size = new Size(875, 342);
            dgdadosFlats.TabIndex = 0;
            dgdadosFlats.CellDoubleClick += dgdadosFlats_CellDoubleClic;
            // 
            // btnlocalizar
            // 
            btnlocalizar.FlatAppearance.BorderSize = 0;
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.Image = (Image)resources.GetObject("btnlocalizar.Image");
            btnlocalizar.Location = new Point(629, 35);
            btnlocalizar.Margin = new Padding(3, 4, 3, 4);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(36, 31);
            btnlocalizar.TabIndex = 5;
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += button1_Click;
            // 
            // txtdescricao
            // 
            txtdescricao.Location = new Point(233, 37);
            txtdescricao.Margin = new Padding(3, 4, 3, 4);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(390, 29);
            txtdescricao.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(117, 41);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 3;
            label1.Text = "Descrição Flat : ";
            // 
            // FrmConsultaFlat
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(875, 429);
            Controls.Add(btnlocalizar);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Controls.Add(dgdadosFlats);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmConsultaFlat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta Flats";
            Load += FrmConsultaFlat_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgdadosFlats).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgdadosFlats;
        private Button btnlocalizar;
        private TextBox txtdescricao;
        private Label label1;
    }
}