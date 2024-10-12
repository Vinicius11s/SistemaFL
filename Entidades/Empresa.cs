using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empresa
    {
        public Empresa()
        {
            this.Flats = new HashSet<Flat>();
        }

        public int id { get; set; }
        public String Cnpj { get; set; } = String.Empty;
        public String Descricao { get; set; } = String.Empty;
        public String Endereco { get; set; } = String.Empty;
        public String InscricaoEstadual { get; set; } = String.Empty;
        public String RazaoSocial { get; set; } = String.Empty;

        public virtual ICollection<Flat> Flats { get; set; }
    }
}
