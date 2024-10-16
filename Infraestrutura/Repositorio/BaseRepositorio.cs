using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Infraestrutura.Contexto;
using Interfaces;

namespace InfraEstrutura.Repositorio
{
    public abstract class BaseRepositorio<T> : IBaseRepositorio<T> where T : class
    {

        protected ContextoSistema _contexto;

        private DbSet<T> _tabela;

        public BaseRepositorio(ContextoSistema contexto)
        {

            this._contexto = contexto;

            this._tabela = this._contexto.Set<T>();

        }

        public virtual void Inserir(T entidade)
        {

            this._tabela.Add(entidade);

        }

        public virtual void Alterar(T entidade)
        {

            this._contexto.Entry(entidade).State = EntityState.Modified;

        }

        public virtual void Excluir(T entidade)
        {
            this._contexto.Entry(entidade).State = EntityState.Deleted;
            this._tabela.Remove(entidade);

        }

        public virtual List<T> Listar(Expression<Func<T, bool>> expressao)
        {

            return this._tabela
                .Where(expressao)
                .ToList();

        }

        public virtual List<T> ListarTodos()
        {
            //Retorna uma Lista, mas sem parametro, sem where.
            return this._tabela
                .ToList();

        }

        public virtual T Recuperar(Expression<Func<T, bool>> expressao)
        {
            //Recuperar quando quero retornar 1 unico registro
            return this._tabela
                .Where(expressao)
                .SingleOrDefault();

        }

    }
}
