using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ocorrencia
    {
        public Ocorrencia()
        {
            Flat = new Flat();
            Usuario = new Usuario();
        }
        public int id { get; set; }

        public Decimal valorAntigo { get; set; }
        public Decimal valorNovo { get; set; }
        public int DataAlteracao { get; set; }

        public int idFlat { get; set; }
        public int idUsuario { get; set; }
        public virtual Flat Flat { get; set; }
        public virtual Usuario Usuario { get; set; } 

    }
}
