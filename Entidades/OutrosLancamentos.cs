using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OutrosLancamentos
    {
        public OutrosLancamentos()
        {
            Ocorrencias = new HashSet<Ocorrencia>();
        }

        public int id { get; set; }
        public Decimal? OutrosRecebimentos { get; set; }
        public Decimal? GanhoDeCapital { get; set; }
        public Decimal? ValorRetidoNaFonte { get; set; }
        public DateTime DataLancamento { get; set; }

        public int? idUsuario { get; set; }
        public Usuario? Usuario { get; set; }

        public virtual ICollection<Ocorrencia> Ocorrencias { get; set; }

    }
}
