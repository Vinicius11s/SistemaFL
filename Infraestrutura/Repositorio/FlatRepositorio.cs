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
    public class FlatRepositorio : BaseRepositorio<Flat>, IFlatRepositorio
    {
        private readonly ContextoSistema _context;
        public FlatRepositorio(ContextoSistema contexto) : base(contexto) {
            _context = contexto;
        }
        public IEnumerable<dynamic> ObterDadosInvestimento()
        {
            // Usando Include para carregar os dados relacionados
            var dadosInvestimento = _context.Flat
                .Include(f => f.Empresa)
                .Select(flat => new
                {
                    idFlat = flat.id,
                    CnpjRecebimento = flat.Empresa.Cnpj,
                    Empresa = flat.Empresa.RazaoSocial,
                    DtAquisicao = flat.DataAquisicao,
                    Flat = flat.Descricao,
                    Unid = flat.Unidade,
                    TipoInvestimento = flat.TipoInvestimento,
                    Cidade = flat.Cidade,
                    Endereco = $"{flat.Rua}, {flat.Bairro}",
                    Investimento = flat.ValorInvestimento,
                    Status = flat.Status
                })
                .ToList<dynamic>();

            return dadosInvestimento;
        }
        public decimal CalcularTotalValorInvestimento()
        {
            // Recupera todos os flats
            var flats = _contexto.Set<Flat>().ToList();
            // Soma os valores de investimento
            return flats.Sum(flat => flat.ValorInvestimento);
        }
    }
}
