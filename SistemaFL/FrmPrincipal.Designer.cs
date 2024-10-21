namespace SistemaFL
{
    partial class FrmPrincipal
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
            menuStrip1 = new MenuStrip();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            empresaToolStripMenuItem = new ToolStripMenuItem();
            flatToolStripMenuItem = new ToolStripMenuItem();
            lançamentoToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(782, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { empresaToolStripMenuItem, flatToolStripMenuItem, lançamentoToolStripMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(71, 20);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // empresaToolStripMenuItem
            // 
            empresaToolStripMenuItem.Name = "empresaToolStripMenuItem";
            empresaToolStripMenuItem.Size = new Size(180, 22);
            empresaToolStripMenuItem.Text = "Empresa";
            empresaToolStripMenuItem.Click += empresaToolStripMenuItem_Click;
            // 
            // flatToolStripMenuItem
            // 
            flatToolStripMenuItem.Name = "flatToolStripMenuItem";
            flatToolStripMenuItem.Size = new Size(180, 22);
            flatToolStripMenuItem.Text = "Flat";
            flatToolStripMenuItem.Click += flatToolStripMenuItem_Click;
            // 
            // lançamentoToolStripMenuItem
            // 
            lançamentoToolStripMenuItem.Name = "lançamentoToolStripMenuItem";
            lançamentoToolStripMenuItem.Size = new Size(180, 22);
            lançamentoToolStripMenuItem.Text = "Lançamento";
            lançamentoToolStripMenuItem.Click += lançamentoToolStripMenuItem_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 428);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmPrincipal";
            Text = "Sistema Gerenciamento FL";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStripMenuItem empresaToolStripMenuItem;
        private ToolStripMenuItem flatToolStripMenuItem;
        private ToolStripMenuItem lançamentoToolStripMenuItem;
    }
}