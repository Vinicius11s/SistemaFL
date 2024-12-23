using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Infraestrutura.Contexto;
using InfraEstrutura.Repositorio;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio
{
    public class OcorrenciaRepositorio : BaseRepositorio<Ocorrencia>, IOcorrenciaRepositorio
    {
        public OcorrenciaRepositorio(ContextoSistema contexto) : base(contexto) { }

        public IQueryable<Ocorrencia> ListarComFlat(Expression<Func<Ocorrencia, bool>> predicate)
        {
            // Agora, usa o método ListarQuery para retornar IQueryable
            return ListarQuery(predicate).Include(o => o.Flat);  // Inclui o Flat relacionado
        }
    }
}
