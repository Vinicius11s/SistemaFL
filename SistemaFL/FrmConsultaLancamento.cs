using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFL
{
    public partial class FrmConsultaLancamento : Form
    {
        private ILancamentoRepositorio repositorio;
        public int id;
        public FrmConsultaLancamento(ILancamentoRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }
    }
}
