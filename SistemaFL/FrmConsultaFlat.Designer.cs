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
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgdadosFlats).BeginInit();
            SuspendLayout();
            // 
            // dgdadosFlats
            // 
            dgdadosFlats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgdadosFlats.Dock = DockStyle.Bottom;
            dgdadosFlats.Location = new Point(0, 148);
            dgdadosFlats.Name = "dgdadosFlats";
            dgdadosFlats.Size = new Size(810, 302);
            dgdadosFlats.TabIndex = 0;
            dgdadosFlats.CellDoubleClick += dgdadosFlats_CellDoubleClic;
            // 
            // button1
            // 
            button1.Location = new Point(673, 45);
            button1.Name = "button1";
            button1.Size = new Size(92, 38);
            button1.TabIndex = 5;
            button1.Text = "Localizar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtdescricao
            // 
            txtdescricao.Location = new Point(118, 51);
            txtdescricao.Name = "txtdescricao";
            txtdescricao.Size = new Size(504, 23);
            txtdescricao.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(38, 54);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 3;
            label1.Text = "Descrição";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(332, 120);
            label2.Name = "label2";
            label2.Size = new Size(94, 25);
            label2.TabIndex = 6;
            label2.Text = "Registros";
            // 
            // FrmConsultaFlat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 450);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(txtdescricao);
            Controls.Add(label1);
            Controls.Add(dgdadosFlats);
            Name = "FrmConsultaFlat";
            Text = "FrmConsultaFlat";
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
        private Label label2;
    }
}