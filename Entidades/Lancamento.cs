using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Lancamento
    {
        public int id { get; set; }
        public DateTime DataPagamento { get; set; }
        public String TipoPagamento { get; set; } = String.Empty;
        public Decimal? ValorAluguel { get; set; }
        public Decimal? ValorDividendos { get; set; }
        public Decimal?  ValorFundoReserva { get; set; }

        public int idFlat { get; set; }
        public Flat Flat { get; set; }

        public Lancamento() {
            Flat = new Flat();
        }
    }
}
