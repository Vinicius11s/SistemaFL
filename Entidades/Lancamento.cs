using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Lancamento
    {
        public Lancamento()
        {
            Ocorrencias = new HashSet<Ocorrencia>();
        }

        public int id { get; set; }
        public DateTime DataPagamento { get; set; }
        public String? TipoPagamento { get; set; }
        public Decimal? ValorAluguel { get; set; }
        public Decimal? ValorDividendos { get; set; }
        public Decimal?  ValorFundoReserva { get; set; }
        public Decimal? AluguelVenceslau { get; set; }



        public int idFlat { get; set; }
        public string? DescricaoFlat { get; set; }
        public Flat? Flat { get; set; }

        public int? idUsuario { get; set; }
        public Usuario? Usuario { get; set; }       


        public virtual ICollection<Ocorrencia> Ocorrencias { get; set; }


        
    }
}
