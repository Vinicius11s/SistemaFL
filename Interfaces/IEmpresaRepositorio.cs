using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface IEmpresaRepositorio : IBaseRepositorio<Empresa>
    {
        Empresa BuscarPorId(int id);
        public Empresa RecuperarPorCnpj(string cnpj);
       

    }
}
