using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;

namespace SistemaFL.Funcionalidades
{
    public partial class FrmFuncPISeCOFINS : Form
    {
        private ILancamentoRepositorio repositorio;
        public FrmFuncPISeCOFINS()
        {
            InitializeComponent();
            this.repositorio = repositorio
        }

        private void FrmFuncPISeCOFINS_Load(object sender, EventArgs e)
        {
            var dados = repositorio = ObterDadosPisCofins();
            dgdadosPIS.DataSource = dados;

            
        }
    }
}
