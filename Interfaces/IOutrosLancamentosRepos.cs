using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IOutrosLancamentosRepos : IBaseRepositorio<OutrosLancamentos>
    {
        public IEnumerable<dynamic> ObterDadosOutrosLancamentos(int ano);


    }
}
