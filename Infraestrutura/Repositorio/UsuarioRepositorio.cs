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
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ContextoSistema contexto) : base(contexto) { }
    }
}
