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
        
        public int id { get; set; }
        public Decimal valorAntigo { get; set; }
        public Decimal valorAlteracao { get; set; }
        public int DataAlteracao { get; set; }

        public int idLancamento { get; set; }
        public Lancamento lancamento { get; set; }

        public Ocorrencia()
        {
            lancamento = new Lancamento();
        }
    }
}
