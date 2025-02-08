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
        public decimal CalcularIRPJTrimestre(int ano, int trimestre);
        public decimal CalcularContrSocialTrimestre(int ano, int trimestre);
        public decimal SomaLancamentosAnoTodoExcetoDividendos(int ano);
    }
}
