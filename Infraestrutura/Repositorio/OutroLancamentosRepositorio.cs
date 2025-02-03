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
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio
{
    public class OutrosLancamentosRepositorio : BaseRepositorio<OutrosLancamentos>, IOutrosLancamentosRepos
    {
        private readonly ContextoSistema _context;
        public OutrosLancamentosRepositorio(ContextoSistema contexto) : base(contexto)
        {
            _context = contexto;
        }


        public IEnumerable<dynamic> ObterDadosOutrosLancamentos(int ano)
        {

            var outros = _context.OutrosLancamentos
             .Where(outros => outros.DataLancamento.Year == ano)
             .ToList();  // Executa a query e traz os dados para memória

            return outros;

        }      
    }
}
