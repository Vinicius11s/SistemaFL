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
        //Formulário Aluguel + Dividendos
        IEnumerable<dynamic> ObterDadosAluguelDividendos();
        IEnumerable<dynamic> ObterDadosTotaisALDIV(int retorno);
        //
        //Formulário Dividendos
        IEnumerable<dynamic> ObterDadosDividendos();
        IEnumerable<dynamic> ObterDadosTotaisDividendos();
        //
        //Formulário Fundo de Reserva
        IEnumerable<dynamic> ObterDadosFunReserva();
        IEnumerable<dynamic> ObterDadosTotaisFundoReserva();
        //

        IEnumerable<dynamic> ObterDadosRendimentos();
        IEnumerable<dynamic> ObterDadosTotais();

        //Form PIS E COFINS
        IEnumerable<object> ObterDadosPISeCOFINS();
        //
        IEnumerable<dynamic> ObterDadosInvestimento();
        decimal CalcularTotalValorInvestimento();

    }
}
