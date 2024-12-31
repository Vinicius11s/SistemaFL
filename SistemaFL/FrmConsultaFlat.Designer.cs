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
            dgdadosFlats = new DataGridView();
            button1 = new Button();
            txtdescricao = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosFlats).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFlats
            // 
            dgdadosFlats.BackgroundColor = Color.FromArgb(23, 24, 29);
            dgdadosFlats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFlats.Dock = DockStyle.Bottom;
            dgdadosFlats.Location = new Point(0, 108);
            dgdadosFlats.Margin = new Padding(3, 4, 3, 4);
            dgdadosFlats.Name = "dgdadosFlats";
            dgdadosFlats.Size = new Size(875, 321);
            dgdadosFlats.TabIndex = 0;
            dgdadosFlats.CellDoubleClick += dgdadosFlats_CellDoubleClic;
            // 
            // button1
            // 
            button1.Location = new Point(607, 39);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(93, 39);
            button1.TabIndex = 5;
            button1.Text = "Localizar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtdescricao
            // 
            txtdescricao.Location = new Point(242, 45);
            txtdescricao.Margin = new Padding(3, 4, 3, 4);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(347, 27);
            txtdescricao.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(242, 21);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 3;
            label1.Text = "Descrição Flat : ";
            // 
            // FrmConsultaFlat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(875, 429);
            Controls.Add(button1);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Controls.Add(dgdadosFlats);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
        private Button button1;
        private TextBox txtdescricao;
        private Label label1;
    }
}