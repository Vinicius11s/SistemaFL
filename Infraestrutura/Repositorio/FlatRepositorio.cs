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
using System.Text.RegularExpressions;

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
            .Include(flat => flat.Empresa)
            .Where(flat => flat.TipoInvestimento == "Aluguel Fixo + Dividendos")
            .Select(flat => new
            {
                Bandeira = flat.Empresa.Descricao,
                Empreendimento = flat.Descricao,
                CodFlat = flat.id,
                ValorImovel = flat.ValorInvestimento,
                AluguelJan = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 1 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorAluguel),
                DividendosJan = flat.Lancamentos
                    .Where(l => l.DataPagamento.Month == 1 && l.TipoPagamento == "Aluguel Fixo + Dividendos")
                    .Sum(l => l.ValorDividendos),

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
            var flats = _context.Flat
                .Include(flat => flat.Lancamentos)
                .ToList();

            var dadosRendimentos = flats.Select(flat => new
            {
                Empreendimento = flat.Descricao,
                CodFlat = flat.id,
                ValorImovel = flat.ValorInvestimento,

                // Calcular os rendimentos e porcentagens para cada mês
                JANEIRO = CalcularRendimentoPorMes(flat.Lancamentos, 1),
                PorcentagemJan = CalcularPorcentagemPorMes(flat.Lancamentos, 1, flat.ValorInvestimento),

                FEVEREIRO = CalcularRendimentoPorMes(flat.Lancamentos, 2),
                PorcentagemFev = CalcularPorcentagemPorMes(flat.Lancamentos, 2, flat.ValorInvestimento),

                MARÇO = CalcularRendimentoPorMes(flat.Lancamentos, 3),
                PorcentagemMar = CalcularPorcentagemPorMes(flat.Lancamentos, 3, flat.ValorInvestimento),

                ABRIL = CalcularRendimentoPorMes(flat.Lancamentos, 4),
                PorcentagemAbr = CalcularPorcentagemPorMes(flat.Lancamentos, 4, flat.ValorInvestimento),

                MAIO = CalcularRendimentoPorMes(flat.Lancamentos, 5),
                PorcentagemMai = CalcularPorcentagemPorMes(flat.Lancamentos, 5, flat.ValorInvestimento),

                JUNHO = CalcularRendimentoPorMes(flat.Lancamentos, 6),
                PorcentagemJun = CalcularPorcentagemPorMes(flat.Lancamentos, 6, flat.ValorInvestimento),

                JULHO = CalcularRendimentoPorMes(flat.Lancamentos, 7),
                PorcentagemJul = CalcularPorcentagemPorMes(flat.Lancamentos, 7, flat.ValorInvestimento),

                AGOSTO = CalcularRendimentoPorMes(flat.Lancamentos, 8),
                PorcentagemAgo = CalcularPorcentagemPorMes(flat.Lancamentos, 8, flat.ValorInvestimento),

                SETEMBRO = CalcularRendimentoPorMes(flat.Lancamentos, 9),
                PorcentagemSet = CalcularPorcentagemPorMes(flat.Lancamentos, 9, flat.ValorInvestimento),

                OUTUBRO = CalcularRendimentoPorMes(flat.Lancamentos, 10),
                PorcentagemOut = CalcularPorcentagemPorMes(flat.Lancamentos, 10, flat.ValorInvestimento),

                NOVEMBRO = CalcularRendimentoPorMes(flat.Lancamentos, 11),
                PorcentagemNov = CalcularPorcentagemPorMes(flat.Lancamentos, 11, flat.ValorInvestimento),

                DEZEMBRO = CalcularRendimentoPorMes(flat.Lancamentos, 12),
                PorcentagemDez = CalcularPorcentagemPorMes(flat.Lancamentos, 12, flat.ValorInvestimento),

                RendimentoAnual = CalculaRendimentoAnualPorFlat(flat.Lancamentos),
                PorcentagemAnual = CalculaPorcentagemAnualPorFlat(flat.Lancamentos, flat.ValorInvestimento)
            })
            .ToList();


            return dadosRendimentos;
        }
        public IEnumerable<object> ObterDadosTotais()
        {
            
            var totalInv = CalcularTotalValorInvestimento();

            VariaveisGlobais.totalJan = CalculaLancamentosPorMes(1, false);
            var PorcJan = CalculaLancamentosPorMes(1, true);

            VariaveisGlobais.totalFev = CalculaLancamentosPorMes(2, false);
            var PorcFev = CalculaLancamentosPorMes(2, true);

            VariaveisGlobais.totalMar = CalculaLancamentosPorMes(3, false);
            var PorcMar = CalculaLancamentosPorMes(3, true);

            VariaveisGlobais.totalAbr = CalculaLancamentosPorMes(4, false);
            var PorcAbr = CalculaLancamentosPorMes(4, true);

            VariaveisGlobais.totalMai = CalculaLancamentosPorMes(5, false);
            var PorcMai = CalculaLancamentosPorMes(5, true);

            VariaveisGlobais.totalJun = CalculaLancamentosPorMes(6, false);
            var PorcJun = CalculaLancamentosPorMes(6, true);

            VariaveisGlobais.totalJul = CalculaLancamentosPorMes(7, false);
            var PorcJul = CalculaLancamentosPorMes(7, true);

            VariaveisGlobais.totalAgo = CalculaLancamentosPorMes(8, false);
            var PorcAgo = CalculaLancamentosPorMes(8, true);

            VariaveisGlobais.totalSet = CalculaLancamentosPorMes(9, false);
            var PorcSet = CalculaLancamentosPorMes(9, true);

            VariaveisGlobais.totalOut = CalculaLancamentosPorMes(10, false);
            var PorcOut = CalculaLancamentosPorMes(10, true);

            VariaveisGlobais.totalNov = CalculaLancamentosPorMes(11, false);
            var PorcNov = CalculaLancamentosPorMes(11, true);

            VariaveisGlobais.totalDez = CalculaLancamentosPorMes(12, false);
            var PorcDez = CalculaLancamentosPorMes(12, true);


            var dadosTotais = new List<object>
    {
        new
        {
            TOTAL = totalInv,

            JANEIRO = VariaveisGlobais.totalJan,
            PorcentagemJan = PorcJan,

            FEVEREIRO = VariaveisGlobais.totalFev,
            PorcentagemFev = PorcFev,

            MARCO = VariaveisGlobais.totalMar,
            PorcentagemMar = PorcMar,

            ABRIL = VariaveisGlobais.totalAbr,
            PorcentagemAbr = PorcAbr,

            MAIO = VariaveisGlobais.totalMai,
            PorcentagemMai = PorcMai,

            JUNHO = VariaveisGlobais.totalJun,
            PorcentagemJun = PorcJun,

            JULHO = VariaveisGlobais.totalJul,
            PorcentagemJul = PorcJul,

            AGOSTO = VariaveisGlobais.totalAgo,
            PorcentagemAgo = PorcAgo,

            SETEMBRO = VariaveisGlobais.totalSet,
            PorcentagemSet = PorcSet,

            OUTUBRO = VariaveisGlobais.totalOut,
            PorcentagemOut = PorcOut,

            NOVEMBRO = VariaveisGlobais.totalNov,
            PorcentagemNov = PorcNov,

            DEZEMBRO = VariaveisGlobais.totalDez,
            PorcentagemDez = PorcDez


        }
    };

            return dadosTotais;
        }
        public IEnumerable<object> ObterDadosAluguelVenceslau()
        {

            var totalJan = CalculaAluguelVenceslau(1);
            var totalFev = CalculaAluguelVenceslau(2);
            var totalMar = CalculaAluguelVenceslau(3);
            var totalAbr = CalculaAluguelVenceslau(4);
            var totalMai = CalculaAluguelVenceslau(5);
            var totalJun = CalculaAluguelVenceslau(6);
            var totalJul = CalculaAluguelVenceslau(7);
            var totalAgo = CalculaAluguelVenceslau(8);
            var totalSet = CalculaAluguelVenceslau(9);
            var totalOut = CalculaAluguelVenceslau(10);
            var totalNov = CalculaAluguelVenceslau(11);
            var totalDez = CalculaAluguelVenceslau(12);

            var dadosTotais = new List<object>
            {
                new
                {
                    Descricao = "Aluguel Venceslau",
                    JANEIRO = totalJan,
                    FEVEREIRO = totalFev,
                    MARÇO = totalMar,
                    ABRIL = totalAbr,
                    MAIO = totalMai,
                    JUNHO = totalJun,
                    JULHO = totalJul,
                    AGOSTO = totalAgo,
                    SETEMBRO = totalSet,
                    OUTUBRO = totalOut,
                    NOVEMBRO = totalNov,
                    DEZEMBRO = totalDez
                },
                new
                {
                    Descricao = "Aluguel Flats",
                    JANEIRO = VariaveisGlobais.totalJan,
                    FEVEREIRO = VariaveisGlobais.totalFev,
                    MARÇO = VariaveisGlobais.totalMar,
                    ABRIL = VariaveisGlobais.totalAbr,
                    MAIO = VariaveisGlobais.totalMai,
                    JUNHO = VariaveisGlobais.totalJun,
                    JULHO = VariaveisGlobais.totalJul,
                    AGOSTO = VariaveisGlobais.totalAgo,
                    SETEMBRO = VariaveisGlobais.totalSet,
                    OUTUBRO = VariaveisGlobais.totalOut,
                    NOVEMBRO = VariaveisGlobais.totalNov,
                    DEZEMBRO = VariaveisGlobais.totalDez
                }
             };
            return dadosTotais;
        }


        public decimal CalculaLancamentosPorMes(int mes, bool porcentagem)
        {
            // Filtra os lançamentos no mês especificado e exclui o tipo "Aluguel Vencelau"
            var total = _context.Lancamento
                .Where(l => l.DataPagamento.Month == mes && l.TipoPagamento != "Aluguel Vencelau")
                .Sum(l => (l.ValorAluguel ?? 0) + (l.ValorDividendos ?? 0) + (l.ValorFundoReserva ?? 0));

            if (porcentagem == false)
            {
                return total;

            }
            else
            {
                decimal totalInvestimento = CalcularTotalValorInvestimento();
                total = total / totalInvestimento;
                return total;

            }

        }
        public decimal CalcularTotalValorInvestimento()
        {
            return _context.Flat.Sum(flat => flat.ValorInvestimento);
        }
        public static decimal CalcularRendimentoPorMes(IEnumerable<Lancamento>? lancamentos, int mes) 
        {
            if (lancamentos == null) return 0.00M;

            return lancamentos
                .Where(l => l.DataPagamento.Month == mes)
                .Sum(l => (l.ValorDividendos ?? 0.00M) +
                          (l.ValorAluguel ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));
        }
        public static decimal CalcularPorcentagemPorMes(IEnumerable<Lancamento>? lancamentos, int mes, decimal valorImovel)
        {
            if (lancamentos == null || valorImovel <= 0) return 0.00M;

            decimal rendimentoMes = lancamentos
                .Where(l => l.DataPagamento.Month == mes)
                .Sum(l => (l.ValorAluguel ?? 0.00M) +
                          (l.ValorDividendos ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));

            return (rendimentoMes / valorImovel) * 100;
        }
        public static decimal CalculaRendimentoAnualPorFlat(IEnumerable<Lancamento>? lancamentos)
        {

            if (lancamentos == null) return 0.00M;

            decimal rendimentoAno = lancamentos
                .Where(l => l.DataPagamento.Year == DateTime.Now.Year)
                .Sum(l => (l.ValorAluguel ?? 0.00M) +
                          (l.ValorDividendos ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));

            return rendimentoAno;
        }
        public static decimal CalculaPorcentagemAnualPorFlat(IEnumerable<Lancamento> lancamentos, decimal valorImovel)
        {
            if (lancamentos == null) return 0.00M;

            decimal porcentagemAno = lancamentos
                .Where(l => l.DataPagamento.Year == DateTime.Now.Year)
                .Sum(l => (l.ValorAluguel ?? 0.00M) +
                          (l.ValorDividendos ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));

            return porcentagemAno / valorImovel;


        }
        public decimal CalculaAluguelVenceslau(int mes)
        {
            var total = _context.Lancamento
                .Where(l => l.DataPagamento.Month == mes && l.TipoPagamento == "Aluguel Venceslau")
                .Sum(l => l.ValorAluguel ?? 0);
            return total;
        
        }
    }
}