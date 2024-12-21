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
            btnlocalizar = new Button();
            txtdescricao = new TextBox();
            label1 = new Label();
            dgdadosusuario = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgdadosusuario).BeginInit();
            SuspendLayout();
            // 
            // btnlocalizar
            // 
            btnlocalizar.BackColor = Color.FromArgb(23, 24, 29);
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.ForeColor = Color.White;
            btnlocalizar.Location = new Point(555, 51);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(83, 32);
            btnlocalizar.TabIndex = 15;
            btnlocalizar.Text = "Localizar";
            btnlocalizar.UseVisualStyleBackColor = false;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // txtdescricao
            // 
            txtdescricao.Location = new Point(230, 57);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(292, 23);
            txtdescricao.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(230, 34);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 13;
            label1.Text = "Descrição";
            // 
            // dgdadosusuario
            // 
            dgdadosusuario.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosusuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosusuario.Dock = DockStyle.Bottom;
            dgdadosusuario.Location = new Point(0, 109);
            dgdadosusuario.Name = "dgdadosusuario";
            dgdadosusuario.Size = new Size(875, 320);
            dgdadosusuario.TabIndex = 12;
            dgdadosusuario.CellDoubleClick += dgdadosusuario_CellDoubleClick;
            // 
            // FrmConsultaUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(875, 429);
            Controls.Add(btnlocalizar);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Controls.Add(dgdadosusuario);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmConsultaUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta Usuário";
            ((System.ComponentModel.ISupportInitialize)dgdadosusuario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnlocalizar;
        private TextBox txtdescricao;
        private Label label1;
        private DataGridView dgdadosusuario;
    }
}