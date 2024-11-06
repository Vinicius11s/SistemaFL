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
               /* UsuarioRepositorio usu = new UsuarioRepositorio(contexto);
                usu.Inserir(new Usuario()
                {
                    Nome = "ADMIN",
                    Login = "ADMIN",
                    Senha = "123456789",
                    DataCriacao = DateTime.Now
                });
                contexto.SaveChanges();*/
            }
        }
    }
}
 