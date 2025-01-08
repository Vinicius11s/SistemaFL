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
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgdadosusuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnlocalizar
            // 
            btnlocalizar.BackColor = Color.Transparent;
            btnlocalizar.FlatStyle = FlatStyle.Flat;
            btnlocalizar.ForeColor = Color.White;
            btnlocalizar.Image = (Image)resources.GetObject("btnlocalizar.Image");
            btnlocalizar.Location = new Point(452, 30);
            btnlocalizar.Margin = new Padding(4);
            btnlocalizar.Name = "btnlocalizar";
            btnlocalizar.Size = new Size(45, 36);
            btnlocalizar.TabIndex = 15;
            btnlocalizar.UseVisualStyleBackColor = false;
            btnlocalizar.Click += btnlocalizar_Click;
            // 
            // txtdescricao
            // 
            txtdescricao.Location = new Point(228, 35);
            txtdescricao.Margin = new Padding(4);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(216, 29);
            txtdescricao.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(143, 39);
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
            dgdadosusuario.Location = new Point(0, 91);
            dgdadosusuario.Margin = new Padding(4);
            dgdadosusuario.Name = "dgdadosusuario";
            dgdadosusuario.Size = new Size(684, 377);
            dgdadosusuario.TabIndex = 12;
            dgdadosusuario.CellDoubleClick += dgdadosusuario_CellDoubleClick;
            dgdadosusuario.CellFormatting += dgdadosusuario_CellFormatting;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(654, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 21);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 27;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // FrmConsultaUsuario
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(684, 468);
            Controls.Add(pictureBox2);
            Controls.Add(btnlocalizar);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Controls.Add(dgdadosusuario);
            Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "FrmConsultaUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta Usuário";
            ((System.ComponentModel.ISupportInitialize)dgdadosusuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnlocalizar;
        private TextBox txtdescricao;
        private Label label1;
        private DataGridView dgdadosusuario;
        private PictureBox pictureBox2;
    }
}