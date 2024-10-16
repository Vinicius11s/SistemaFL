using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Infraestrutura.Contexto;
using InfraEstrutura.Repositorio;
using Interfaces;

namespace Infraestrutura.Repositorio
{
    public class LancamentoRepositorio : BaseRepositorio<Lancamento>, ILancamentoRepositorio
    {
        public LancamentoRepositorio(ContextoSistema contexto) : base(contexto) { }
    }
}
