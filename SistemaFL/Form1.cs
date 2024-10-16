using Infraestrutura;
using Entidades;
using Infraestrutura.Contexto;
using Infraestrutura.Repositorio;

namespace SistemaFL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var contexto = new ContextoSistema())
            {
                EmpresaRepositorio emp = new EmpresaRepositorio(contexto);
                emp.Inserir(new Empresa()
                {
                    Descricao = "Lua Nova",
                });
                contexto.SaveChanges();
            }
        }
    }
}
 