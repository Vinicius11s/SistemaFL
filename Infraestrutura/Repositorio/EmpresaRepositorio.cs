using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Infraestrutura.Contexto;
using InfraEstrutura.Repositorio;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio
{
    public class EmpresaRepositorio : BaseRepositorio<Empresa>, IEmpresaRepositorio
    {
        public EmpresaRepositorio(ContextoSistema contexto) : base(contexto) { }

        public Empresa BuscarPorId(int id)
        {
            return _contexto.Empresa.FirstOrDefault(e => e.id == id);
        }
    }
}
