using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int id { get; set; }
        public String Nome { get; set; } = String.Empty;
        public String Login { get; set; } = String.Empty;
        public String Senha { get; set; } = String.Empty;
        public DateTime DataCriacao { get; set; }

        public virtual ICollection<Ocorrencia> Ocorrencias { get; set; }

        public Usuario()
        {
            this.Ocorrencias = new HashSet<Ocorrencia>();
        }
    }
}
