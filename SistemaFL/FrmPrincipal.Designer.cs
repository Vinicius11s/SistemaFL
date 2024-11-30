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
            usuárioToolStripMenuItem = new ToolStripMenuItem();
            consultasToolStripMenuItem = new ToolStripMenuItem();
            ocorrênciasToolStripMenuItem = new ToolStripMenuItem();
            funcionalidadesToolStripMenuItem = new ToolStripMenuItem();
            registrosToolStripMenuItem = new ToolStripMenuItem();
            aluguelToolStripMenuItem = new ToolStripMenuItem();
            dividendosToolStripMenuItem = new ToolStripMenuItem();
            fundoDeReservaToolStripMenuItem = new ToolStripMenuItem();
            lbllogin = new Label();
            rendimentosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackgroundImageLayout = ImageLayout.None;
            menuStrip1.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem, consultasToolStripMenuItem, funcionalidadesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(764, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { empresaToolStripMenuItem, flatToolStripMenuItem, lançamentoToolStripMenuItem, usuárioToolStripMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(88, 25);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // empresaToolStripMenuItem
            // 
            empresaToolStripMenuItem.Name = "empresaToolStripMenuItem";
            empresaToolStripMenuItem.Size = new Size(163, 26);
            empresaToolStripMenuItem.Text = "Empresa";
            empresaToolStripMenuItem.Click += empresaToolStripMenuItem_Click;
            // 
            // flatToolStripMenuItem
            // 
            flatToolStripMenuItem.Name = "flatToolStripMenuItem";
            flatToolStripMenuItem.Size = new Size(163, 26);
            flatToolStripMenuItem.Text = "Flat";
            flatToolStripMenuItem.Click += flatToolStripMenuItem_Click;
            // 
            // lançamentoToolStripMenuItem
            // 
            lançamentoToolStripMenuItem.Name = "lançamentoToolStripMenuItem";
            lançamentoToolStripMenuItem.Size = new Size(163, 26);
            lançamentoToolStripMenuItem.Text = "Lançamento";
            lançamentoToolStripMenuItem.Click += lançamentoToolStripMenuItem_Click;
            // 
            // usuárioToolStripMenuItem
            // 
            usuárioToolStripMenuItem.Name = "usuárioToolStripMenuItem";
            usuárioToolStripMenuItem.Size = new Size(163, 26);
            usuárioToolStripMenuItem.Text = "Usuário";
            usuárioToolStripMenuItem.Click += usuárioToolStripMenuItem_Click;
            // 
            // consultasToolStripMenuItem
            // 
            consultasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ocorrênciasToolStripMenuItem });
            consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            consultasToolStripMenuItem.Size = new Size(87, 25);
            consultasToolStripMenuItem.Text = "Consultas";
            // 
            // ocorrênciasToolStripMenuItem
            // 
            ocorrênciasToolStripMenuItem.Name = "ocorrênciasToolStripMenuItem";
            ocorrênciasToolStripMenuItem.Size = new Size(159, 26);
            ocorrênciasToolStripMenuItem.Text = "Ocorrências";
            ocorrênciasToolStripMenuItem.Click += ocorrênciasToolStripMenuItem_Click;
            // 
            // funcionalidadesToolStripMenuItem
            // 
            funcionalidadesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrosToolStripMenuItem, aluguelToolStripMenuItem, dividendosToolStripMenuItem, fundoDeReservaToolStripMenuItem, rendimentosToolStripMenuItem });
            funcionalidadesToolStripMenuItem.Name = "funcionalidadesToolStripMenuItem";
            funcionalidadesToolStripMenuItem.Size = new Size(129, 25);
            funcionalidadesToolStripMenuItem.Text = "Funcionalidades";
            // 
            // registrosToolStripMenuItem
            // 
            registrosToolStripMenuItem.Name = "registrosToolStripMenuItem";
            registrosToolStripMenuItem.Size = new Size(223, 26);
            registrosToolStripMenuItem.Text = "Registros";
            registrosToolStripMenuItem.Click += registrosToolStripMenuItem_Click;
            // 
            // aluguelToolStripMenuItem
            // 
            aluguelToolStripMenuItem.Name = "aluguelToolStripMenuItem";
            aluguelToolStripMenuItem.Size = new Size(223, 26);
            aluguelToolStripMenuItem.Text = "Aluguel + Dividendos";
            aluguelToolStripMenuItem.Click += aluguelToolStripMenuItem_Click;
            // 
            // dividendosToolStripMenuItem
            // 
            dividendosToolStripMenuItem.Name = "dividendosToolStripMenuItem";
            dividendosToolStripMenuItem.Size = new Size(223, 26);
            dividendosToolStripMenuItem.Text = "Dividendos";
            dividendosToolStripMenuItem.Click += dividendosToolStripMenuItem_Click;
            // 
            // fundoDeReservaToolStripMenuItem
            // 
            fundoDeReservaToolStripMenuItem.Name = "fundoDeReservaToolStripMenuItem";
            fundoDeReservaToolStripMenuItem.Size = new Size(223, 26);
            fundoDeReservaToolStripMenuItem.Text = "Fundo de Reserva";
            fundoDeReservaToolStripMenuItem.Click += fundoDeReservaToolStripMenuItem_Click;
            // 
            // lbllogin
            // 
            lbllogin.AutoSize = true;
            lbllogin.BackColor = Color.Black;
            lbllogin.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbllogin.ForeColor = SystemColors.ControlLightLight;
            lbllogin.Location = new Point(237, 122);
            lbllogin.Name = "lbllogin";
            lbllogin.Size = new Size(0, 37);
            lbllogin.TabIndex = 16;
            // 
            // rendimentosToolStripMenuItem
            // 
            rendimentosToolStripMenuItem.Name = "rendimentosToolStripMenuItem";
            rendimentosToolStripMenuItem.Size = new Size(223, 26);
            rendimentosToolStripMenuItem.Text = "Rendimentos";
            rendimentosToolStripMenuItem.Click += rendimentosToolStripMenuItem_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(764, 291);
            Controls.Add(lbllogin);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "FrmPrincipal";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Gerenciamento FL";
            Load += FrmPrincipal_Load;
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
        private ToolStripMenuItem usuárioToolStripMenuItem;
        private ToolStripMenuItem consultasToolStripMenuItem;
        private ToolStripMenuItem ocorrênciasToolStripMenuItem;
        private ToolStripMenuItem funcionalidadesToolStripMenuItem;
        private ToolStripMenuItem registrosToolStripMenuItem;
        private Label lbllogin;
        private ToolStripMenuItem aluguelToolStripMenuItem;
        private ToolStripMenuItem dividendosToolStripMenuItem;
        private ToolStripMenuItem fundoDeReservaToolStripMenuItem;
        private ToolStripMenuItem rendimentosToolStripMenuItem;
    }
}