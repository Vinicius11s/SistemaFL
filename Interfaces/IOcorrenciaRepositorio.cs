using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface IOcorrenciaRepositorio : IBaseRepositorio<Ocorrencia>
    {
        IQueryable<Ocorrencia> ListarComFlat(Expression<Func<Ocorrencia, bool>> predicate);
    }
}
