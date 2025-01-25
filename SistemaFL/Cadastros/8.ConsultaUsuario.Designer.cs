namespace SistemaFL
{
    partial class FrmConsultaUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaUsuario));
            btnlocalizar = new Button();
            txtdescricao = new TextBox();
            label1 = new Label();
            dgdadosusuario = new DataGridView();
            pbFechar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgdadosusuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).BeginInit();
            SuspendLayout();
            // 
            // btnlocalizar
            // 
            btnlocalizar.BackColor = Color.Transparent;
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.ForeColor = Color.White;
            btnlocalizar.Image = (Image)resources.GetObject("btnlocalizar.Image");
            btnlocalizar.Location = new Point(386, 19);
            btnlocalizar.Margin = new Padding(4);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(45, 36);
            btnlocalizar.TabIndex = 15;
            btnlocalizar.UseVisualStyleBackColor = false;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // txtdescricao
            // 
            txtdescricao.Location = new Point(162, 24);
            txtdescricao.Margin = new Padding(4);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(216, 29);
            txtdescricao.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(77, 28);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 13;
            label1.Text = "Descrição:";
            // 
            // dgdadosusuario
            // 
            dgdadosusuario.BackgroundColor = Color.White;
            dgdadosusuario.BorderStyle = BorderStyle.None;
            dgdadosusuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosusuario.Dock = DockStyle.Bottom;
            dgdadosusuario.Location = new Point(0, 71);
            dgdadosusuario.Margin = new Padding(4);
            dgdadosusuario.Name = "dgdadosusuario";
            dgdadosusuario.Size = new Size(532, 308);
            dgdadosusuario.TabIndex = 12;
            dgdadosusuario.CellDoubleClick += dgdadosusuario_CellDoubleClick;
            dgdadosusuario.CellFormatting += dgdadosusuario_CellFormatting;
            // 
            // pbFechar
            // 
            pbFechar.Image = (Image)resources.GetObject("pbFechar.Image");
            pbFechar.Location = new Point(502, 2);
            pbFechar.Name = "pbFechar";
            pbFechar.Size = new Size(30, 21);
            pbFechar.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFechar.TabIndex = 27;
            pbFechar.TabStop = false;
            pbFechar.Click += pbFechar_Click;
            // 
            // FrmConsultaUsuario
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(532, 379);
            Controls.Add(pbFechar);
            Controls.Add(btnlocalizar);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Controls.Add(dgdadosusuario);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FrmConsultaUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta Usuário";
            ((System.ComponentModel.ISupportInitialize)dgdadosusuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFechar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnlocalizar;
        private TextBox txtdescricao;
        private Label label1;
        private DataGridView dgdadosusuario;
        private PictureBox pbFechar;
    }
}