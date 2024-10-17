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
        public String Descricao { get; set; } = String.Empty;
        public String RazaoSocial { get; set; } = String.Empty;
        public String Cnpj { get; set; } = String.Empty;
        public String InscricaoEstadual { get; set; } = String.Empty;
        

        // Propriedades de endereço detalhado
        public string Rua { get; set; } = String.Empty;
        public string Numero { get; set; } = String.Empty;
        public string Bairro { get; set; } = String.Empty;
        public string Cidade { get; set; } = String.Empty;
        public string Estado { get; set; } = String.Empty;
        public string Cep { get; set; } = String.Empty;


        public virtual ICollection<Flat> Flats { get; set; }
    }
}
