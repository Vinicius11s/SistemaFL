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
        IEnumerable<dynamic> ObterDadosAluguelDividendos();
        IEnumerable<dynamic> ObterDadosInvestimento();
        decimal CalcularTotalValorInvestimento();

    }
}
