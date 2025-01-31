using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Interfaces
{
    public interface ILancamentoRepositorio : IBaseRepositorio<Lancamento>
    {
        IEnumerable<dynamic> ObterDadosRelatorioMensal(int ano);
        IEnumerable<dynamic> ObterDadosRelatorioTrimestral(int ano);
    }
}
