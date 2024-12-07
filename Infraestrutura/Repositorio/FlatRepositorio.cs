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
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using Azure.Core;

namespace Infraestrutura.Repositorio
{
    public class FlatRepositorio : BaseRepositorio<Flat>, IFlatRepositorio
    {
        private readonly ContextoSistema _context;
        public FlatRepositorio(ContextoSistema contexto) : base(contexto)
        {
            _context = contexto;
        }
        public IEnumerable<dynamic> ObterDadosAluguelDividendos()
        {

            var dadosAluguelDiv = _context.Flat
            .Include(flat => flat.Lancamentos) 
            .Include(flat => flat.Empresa)    // Inclui dados da empresclui lançamentos relacionadosa
            .Where(flat => flat.TipoInvestimento == "Aluguel Fixo + Dividendos")
            .Select(flat => new
            {
                Bandeira = flat.Empresa.Descricao,
                Empreendimento = flat.Descricao,
                CodFlat = flat.id,
                ValorImovel = flat.ValorInvestimento,
                AluguelJan = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 1 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorAluguel), // Soma o valor do aluguel de janeiro
                DividendosJan = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 1 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorDividendos), // Soma o valor dos dividendos de janeiro

                AluguelFev = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 2 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorAluguel),
                DividendosFev = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 2 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorDividendos),

                AluguelMar = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 3 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorAluguel),
                DividendosMAR = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 3 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorDividendos),

                AluguelABR = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 4 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorAluguel),
                DividendosABR = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 4 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorDividendos),

                AluguelMAI = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 5 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorAluguel),
                DividendosMAI = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 5 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorDividendos),

                AluguelJUN = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 6 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorAluguel),
                DividendosJUN = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 6 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorDividendos),

                AluguelJUL = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 7 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorAluguel),
                DividendosJUL = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 7 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorDividendos),

                AluguelAGO = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 8 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorAluguel),
                DividendosAGO = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 8 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorDividendos),

                AluguelSET = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 9 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorAluguel),
                DividendosSET = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 9 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorDividendos),

                AluguelOUT = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 10 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorAluguel),
                DividendosOUT = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 10 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorDividendos),

                AluguelNOV = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 11 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorAluguel),
                DividendosNOV = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 11 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorDividendos),

                AluguelDEZ = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 12 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorAluguel),
                DividendosDEZ = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 12 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorDividendos),

                Acumulado = flat.Lancamentos
                .Where(l => l.TipoPagamento == "Aluguel Fixo + Dividendos")
                .Sum(l => (l.ValorAluguel ?? 0) + (l.ValorDividendos ?? 0))
            }).ToList();
            return dadosAluguelDiv;
        }
        public IEnumerable<dynamic> ObterDadosInvestimento()
        {
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
                    Endereco = $"{flat.Rua ?? ""}, {flat.Bairro ?? ""}",
                    Investimento = flat.ValorInvestimento,
                    Status = flat.Status
                }).ToList();

            return dadosInvestimento;
        }
        public decimal CalcularTotalValorInvestimento()
        {
            return _context.Flat.Sum(flat => flat.ValorInvestimento);
        }
        public IEnumerable<dynamic> ObterDadosDividendos()
        {
            var dadosDividendos = _context.Flat
            .Include(flat => flat.Lancamentos)
            .Include(flat => flat.Empresa)
            .Where(flat => flat.TipoInvestimento == "Dividendos")
            .Select(flat => new
            {
                Bandeira = flat.Empresa.Descricao,
                Empreendimento = flat.Descricao,
                CodFlat = flat.id,
                ValorImovel = flat.ValorInvestimento,
                 DividendosJan = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 1 && l.TipoPagamento == "Dividendos")
                    .Sum(l => l.ValorDividendos),

                DividendosFev = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 2 && l.TipoPagamento == "Dividendos")
                    .Sum(l => l.ValorDividendos),

                DividendosMar = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 3 && l.TipoPagamento == "Dividendos")
                    .Sum(l => l.ValorDividendos),

                DividendosAbr = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 4 && l.TipoPagamento == "Dividendos")
                    .Sum(l => l.ValorDividendos),

                DividendosMai = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 5 && l.TipoPagamento == "Dividendos")
                    .Sum(l => l.ValorDividendos),

                DividendosJun = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 6 && l.TipoPagamento == "Dividendos")
                    .Sum(l => l.ValorDividendos),

                DividendosJul = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 7 && l.TipoPagamento == "Dividendos")
                    .Sum(l => l.ValorDividendos),

                DividendosAgo = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 8 && l.TipoPagamento == "Dividendos")
                    .Sum(l => l.ValorDividendos),

                DividendosSet = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 9 && l.TipoPagamento == "Dividendos")
                    .Sum(l => l.ValorDividendos),

                DividendosOut = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 10 && l.TipoPagamento == "Dividendos")
                    .Sum(l => l.ValorDividendos),

                DividendosNov = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 11 && l.TipoPagamento == "Dividendos")
                    .Sum(l => l.ValorDividendos),

                DividendosDez = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 12 && l.TipoPagamento == "Dividendos")
                    .Sum(l => l.ValorDividendos),

                 Acumulado = flat.Lancamentos
                .Where(l => l.TipoPagamento == "Dividendos")
                .Sum(l => (l.ValorAluguel ?? 0) + (l.ValorDividendos ?? 0))

            }).ToList();

            return dadosDividendos;
        }
        public IEnumerable<dynamic> ObterDadosFunReserva()
        {
            var dadosFunReserva = _context.Flat
                .Include(flat => flat.Lancamentos)
                .Where(flat => flat.Lancamentos.Any(l => l.ValorFundoReserva > 0))
                .Select(flat => new
                {
                    Empreendimento = flat.Descricao,
                    CodFlat = flat.id,
                        JANEIRO = flat.Lancamentos
                    .Where(l => l.ValorFundoReserva > 0 && l.DataPagamento.Month == 1)
                    .Sum(l => (decimal?)l.ValorFundoReserva) ?? 0.00M,
                        FEVEREIRO = flat.Lancamentos
                    .Where(l => l.ValorFundoReserva > 0 && l.DataPagamento.Month == 2)
                    .Sum(l => (decimal?)l.ValorFundoReserva) ?? 0.00M,
                        MARÇO = flat.Lancamentos
                    .Where(l => l.ValorFundoReserva > 0 && l.DataPagamento.Month == 3)
                    .Sum(l => (decimal?)l.ValorFundoReserva) ?? 0.00M,
                        ABRIL = flat.Lancamentos
                    .Where(l => l.ValorFundoReserva > 0 && l.DataPagamento.Month == 4)
                    .Sum(l => (decimal?)l.ValorFundoReserva) ?? 0.00M,
                        MAIO = flat.Lancamentos
                    .Where(l => l.ValorFundoReserva > 0 && l.DataPagamento.Month == 5)
                    .Sum(l => (decimal?)l.ValorFundoReserva) ?? 0.00M,
                        JUNHO = flat.Lancamentos
                    .Where(l => l.ValorFundoReserva > 0 && l.DataPagamento.Month == 6)
                    .Sum(l => (decimal?)l.ValorFundoReserva) ?? 0.00M,
                        JULHO = flat.Lancamentos
                    .Where(l => l.ValorFundoReserva > 0 && l.DataPagamento.Month == 7)
                    .Sum(l => (decimal?)l.ValorFundoReserva) ?? 0.00M,
                        AGOSTO = flat.Lancamentos
                    .Where(l => l.ValorFundoReserva > 0 && l.DataPagamento.Month == 8)
                    .Sum(l => (decimal?)l.ValorFundoReserva) ?? 0.00M,
                        SETEMBRO = flat.Lancamentos
                    .Where(l => l.ValorFundoReserva > 0 && l.DataPagamento.Month == 9)
                    .Sum(l => (decimal?)l.ValorFundoReserva) ?? 0.00M,
                        OUTUBRO = flat.Lancamentos
                    .Where(l => l.ValorFundoReserva > 0 && l.DataPagamento.Month == 10)
                    .Sum(l => (decimal?)l.ValorFundoReserva) ?? 0.00M,
                        NOVEMBRO = flat.Lancamentos
                    .Where(l => l.ValorFundoReserva > 0 && l.DataPagamento.Month == 11)
                    .Sum(l => (decimal?)l.ValorFundoReserva) ?? 0.00M,
                        DEZEMBRO = flat.Lancamentos
                    .Where(l => l.ValorFundoReserva > 0 && l.DataPagamento.Month == 12)
                    .Sum(l => (decimal?)l.ValorFundoReserva) ?? 0.00M


                }).ToList();
            return dadosFunReserva;
        }
        public IEnumerable<dynamic> ObterDadosRendimentos()
        {
            var dadosRendimentos = _context.Flat
            .Include(flat => flat.Lancamentos)
            .Select(flat => new
            {
                Empreendimento = flat.Descricao,
                CodFlat = flat.id,
                ValorImovel = flat.ValorInvestimento,

                // Usando o método para calcular os rendimentos mensais
                RendimentoJan = CalcularRendimentoPorMes(flat.Lancamentos, 1),
                PorcentagemJan = CalcularPorcentagemPorMes(flat.Lancamentos, 1, flat.ValorInvestimento),

                RendimentoFev = CalcularRendimentoPorMes(flat.Lancamentos, 2),
                PorcentagemFev = CalcularPorcentagemPorMes(flat.Lancamentos, 2, flat.ValorInvestimento),

                RendimentoMar = CalcularRendimentoPorMes(flat.Lancamentos, 3),
                PorcentagemMar = CalcularPorcentagemPorMes(flat.Lancamentos, 3, flat.ValorInvestimento),

                RendimentoAbr = CalcularRendimentoPorMes(flat.Lancamentos, 4),
                PorcentagemAbr = CalcularPorcentagemPorMes(flat.Lancamentos, 4, flat.ValorInvestimento),

                RendimentoMai = CalcularRendimentoPorMes(flat.Lancamentos, 5),
                PorcentagemMai = CalcularPorcentagemPorMes(flat.Lancamentos, 5, flat.ValorInvestimento),

                RendimentoJun = CalcularRendimentoPorMes(flat.Lancamentos, 6),
                PorcentagemJun = CalcularPorcentagemPorMes(flat.Lancamentos, 6, flat.ValorInvestimento),

                RendimentoJul = CalcularRendimentoPorMes(flat.Lancamentos, 7),
                PorcentagemJul = CalcularPorcentagemPorMes(flat.Lancamentos, 7, flat.ValorInvestimento),

                RendimentoAgo = CalcularRendimentoPorMes(flat.Lancamentos, 8),
                PorcentagemAgo = CalcularPorcentagemPorMes(flat.Lancamentos, 8, flat.ValorInvestimento),

                RendimentoSet = CalcularRendimentoPorMes(flat.Lancamentos, 9),
                PorcentagemSet = CalcularPorcentagemPorMes(flat.Lancamentos, 9, flat.ValorInvestimento),

                RendimentoOut = CalcularRendimentoPorMes(flat.Lancamentos, 10),
                PorcentagemOut = CalcularPorcentagemPorMes(flat.Lancamentos, 10, flat.ValorInvestimento),

                RendimentoNov = CalcularRendimentoPorMes(flat.Lancamentos, 11),
                PorcentagemNov = CalcularPorcentagemPorMes(flat.Lancamentos, 11, flat.ValorInvestimento),

                RendimentoDez = CalcularRendimentoPorMes(flat.Lancamentos, 12),
                PorcentagemDez = CalcularPorcentagemPorMes(flat.Lancamentos, 12, flat.ValorInvestimento)
            })
            .ToList();

            return dadosRendimentos;
        }
        public static decimal CalcularRendimentoPorMes(IEnumerable<Lancamento> lancamentos, int mes)
        {
            return lancamentos
                .Where(l => l.DataPagamento.Month == mes)
                .Sum(l => (l.ValorAluguel ?? 0.00M) +
                          (l.ValorDividendos ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));
        }

        public static decimal CalcularPorcentagemPorMes(IEnumerable<Lancamento> lancamentos, int mes, decimal valorImovel)
        {
            decimal rendimentoMes = lancamentos
                .Where(l => l.DataPagamento.Month == mes)
                .Sum(l => (l.ValorAluguel ?? 0.00M) +
                          (l.ValorDividendos ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));

            return valorImovel > 0 ? (rendimentoMes / valorImovel) * 100 : 0.00M;
        }

    }
}
