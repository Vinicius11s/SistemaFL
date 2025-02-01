using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OutrosLancamentos
    {
        public int Id { get; set; }
        public Decimal? OutrosRecebimentos { get; set; }
        public Decimal? GanhoDeCapital { get; set; }
        public Decimal? ValorRetidoNaFonte { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
