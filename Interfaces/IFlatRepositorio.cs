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
        //Formulário Registros
        IEnumerable<dynamic> ObterDadosInvestimento();
        decimal CalcularTotalValorDeCompra();
        int CalcularTotalFlats();
        //
        //Formulário Aluguel + Dividendos
        public IEnumerable<dynamic> ObterDadosAluguelDividendos();
        IEnumerable<dynamic> ObterDadosTotaisALDIV();
        //
        //Formulário Dividendos
        IEnumerable<dynamic> ObterDadosDividendos();
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
    }
}
