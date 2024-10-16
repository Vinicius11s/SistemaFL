using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBaseRepositorio<T> where T : class
    {
        void Inserir(T entidade);
        void Alterar(T entidade);
        void Excluir(T entidade);

        List<T> Listar(Expression<Func<T, bool>> expression);
        List<T> ListarTodos();
        T Recuperar(Expression<Func<T, bool>> expression);
    }
}
