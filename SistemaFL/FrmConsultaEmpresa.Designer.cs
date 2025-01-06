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
            ((System.ComponentModel.ISupportInitialize)dgdados).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 11.25F);
            label1.Location = new Point(115, 50);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 0;
            label1.Text = "Descrição Empresa :";
            // 
            // txtdescricao
            // 
            txtdescricao.Font = new Font("Segoe UI Semilight", 11.25F);
            txtdescricao.Location = new Point(261, 50);
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
            btnlocalizar.Location = new Point(594, 45);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(40, 32);
            btnlocalizar.TabIndex = 2;
            btnlocalizar.UseVisualStyleBackColor = true;
            btnlocalizar.Click += button1_Click;
            // 
            // dgdados
            // 
            dgdados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgdados.BackgroundColor = Color.White;
            dgdados.BorderStyle = BorderStyle.None;
            dgdados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdados.Location = new Point(0, 121);
            dgdados.Name = "dgdados";
            dgdados.Size = new Size(807, 329);
            dgdados.TabIndex = 3;
            dgdados.CellDoubleClick += dgdados_CellDoubleClick;
            dgdados.CellFormatting += dgdados_CellFormatting;
            // 
            // FrmConsultaEmpresa
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(807, 450);
            Controls.Add(dgdados);
            Controls.Add(btnlocalizar);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmConsultaEmpresa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta de Empresa";
            Load += FrmConsultaEmpresa_Load;
            ((System.ComponentModel.ISupportInitialize)dgdados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtdescricao;
        private Button btnlocalizar;
        private DataGridView dgdados;
    }
}