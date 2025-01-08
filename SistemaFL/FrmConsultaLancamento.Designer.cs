namespace SistemaFL
{
    partial class FrmConsultaLancamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaLancamento));
            btnlocalizar = new Button();
            txtdescricao = new TextBox();
            label1 = new Label();
            dgdadoslancamento = new DataGridView();
            pictureBox2 = new PictureBox();
            pbmaximizar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgdadoslancamento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbmaximizar).BeginInit();
            SuspendLayout();
            // 
            // btnlocalizar
            // 
            btnlocalizar.BackColor = Color.White;
            btnlocalizar.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnlocalizar, "btnlocalizar");
            btnlocalizar.ForeColor = Color.FromArgb(23, 24, 29);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.UseVisualStyleBackColor = false;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // txtdescricao
            // 
            resources.ApplyResources(txtdescricao, "txtdescricao");
            txtdescricao.Name = "txtdescricao";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // dgdadoslancamento
            // 
            dgdadoslancamento.BackgroundColor = Color.White;
            dgdadoslancamento.BorderStyle = BorderStyle.None;
            dgdadoslancamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dgdadoslancamento, "dgdadoslancamento");
            dgdadoslancamento.Name = "dgdadoslancamento";
            dgdadoslancamento.CellDoubleClick += dgdadoslancamento_CellDoubleClick;
            dgdadoslancamento.CellFormatting += dgdadoslancamento_CellFormatting;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pbmaximizar
            // 
            resources.ApplyResources(pbmaximizar, "pbmaximizar");
            pbmaximizar.Name = "pbmaximizar";
            pbmaximizar.TabStop = false;
            pbmaximizar.Click += pbmaximizar_Click;
            // 
            // FrmConsultaLancamento
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pictureBox2);
            Controls.Add(pbmaximizar);
            Controls.Add(btnlocalizar);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Controls.Add(dgdadoslancamento);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmConsultaLancamento";
            Load += FrmConsultaLancamento_Load;
            Resize += FrmConsultaLancamento_Resize;
            ((System.ComponentModel.ISupportInitialize)dgdadoslancamento).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbmaximizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnlocalizar;
        private TextBox txtdescricao;
        private Label label1;
        private DataGridView dgdadoslancamento;
        private PictureBox pictureBox2;
        private PictureBox pbmaximizar;
    }
}