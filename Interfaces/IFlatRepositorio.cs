using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Interfaces
{
    public interface IFlatRepositorio : IBaseRepositorio<Flat>
    {
        //form aluguel + dividendos
        IEnumerable<dynamic> ObterDadosAluguelDividendos();
        IEnumerable<dynamic> ObterDadosTotaisALDIV(int retorno);

        
        //form aluguel + dividendos

        IEnumerable<dynamic> ObterDadosInvestimento();
        decimal CalcularTotalValorInvestimento();
        IEnumerable<dynamic> ObterDadosDividendos();
        IEnumerable<dynamic> ObterDadosFunReserva();
        IEnumerable<dynamic> ObterDadosRendimentos();
        IEnumerable<dynamic> ObterDadosTotais();

        //Form PIS E COFINS
        IEnumerable<object> ObterDadosPISeCOFINS();
        

    }
}
