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
        //Formulário Registros
        public IEnumerable<dynamic> ObterDadosInvestimento()
        {
            var dadosInvestimento = _context.Flat
                .Include(f => f.Empresa)
                .Select(flat => new
                {
                    idFlat = flat.id,
                    CnpjRecebimento = flat.idEmpresa != null ? flat.Empresa.Cnpj : null,
                    Empresa = flat.Empresa != null ? flat.Empresa.RazaoSocial : null,
                    DtAquisicao = flat.DataAquisicao,
                    Flat = flat.Descricao,
                    Unid = flat.Unidade,
                    TipoInvestimento = flat.TipoInvestimento,
                    Cidade = flat.Cidade,
                    Endereco = flat.Bairro != null && flat.Bairro != ""
                    ? $"{flat.Rua ?? ""}, {flat.Bairro}"
                    : $"{flat.Rua ?? ""}",
                    Investimento = flat.ValorInvestimento,
                    Status = flat.Status.ToString()
                })
                .OrderBy(flat => flat.Flat)
                .ToList();

            return dadosInvestimento;
        }
        public decimal CalcularTotalValorInvestimento()
        {
            return _context.Flat.Sum(flat => flat.ValorInvestimento);
        }
        //
        //Formulário Aluguel + Dividendos
        public IEnumerable<dynamic> ObterDadosAluguelDividendos()
        {
            int anoAtual = DateTime.Now.Year;

            var flats = _context.Flat
                .Include(flat => flat.Empresa)
              .AsNoTracking()
              .Where(flat => flat.TipoInvestimento == "Aluguel Fixo + Dividendos" ||
                             flat.TipoInvestimento == "Aluguel Fixo" ||
                             flat.TipoInvestimento == "Dividendos")
              .Include(flat => flat.Lancamentos  // Carrega os lançamentos relacionados
              .Where(l => l.DataPagamento.Year == anoAtual))
              .ToList();  // Executa a query e traz os dados para memória

            var dadosAluguelDiv = flats.Select(flat => new
            {
                BANDEIRA = flat.Empresa != null ? flat.Empresa.Descricao : "",
                EMPREENDIMENTO = flat.Descricao,
                CODFLAT = flat.id,
                ValorImovel = flat.ValorInvestimento,

                AluguelJan = CalculaAlugueisFlatsPorMes(flat.Lancamentos, 1),
                DividendosJan = CalculaDividendosFlatsPorMes(flat.Lancamentos, 1),

                AluguelFev = CalculaAlugueisFlatsPorMes(flat.Lancamentos, 2),
                DividendosFev = CalculaDividendosFlatsPorMes(flat.Lancamentos, 2),

                AluguelMar = CalculaAlugueisFlatsPorMes(flat.Lancamentos, 3),
                DividendosMAR = CalculaDividendosFlatsPorMes(flat.Lancamentos, 3),

                AluguelABR = CalculaAlugueisFlatsPorMes(flat.Lancamentos, 4),
                DividendosABR = CalculaDividendosFlatsPorMes(flat.Lancamentos, 4),

                AluguelMAI = CalculaAlugueisFlatsPorMes(flat.Lancamentos, 5),
                DividendosMAI = CalculaDividendosFlatsPorMes(flat.Lancamentos, 5),  

                AluguelJUN = CalculaAlugueisFlatsPorMes(flat.Lancamentos, 6),
                DividendosJUN = CalculaDividendosFlatsPorMes(flat.Lancamentos, 6),

                AluguelJUL = CalculaAlugueisFlatsPorMes(flat.Lancamentos, 7),
                DividendosJUL = CalculaDividendosFlatsPorMes(flat.Lancamentos, 7),

                AluguelAGO = CalculaAlugueisFlatsPorMes(flat.Lancamentos, 8),
                DividendosAGO = CalculaDividendosFlatsPorMes(flat.Lancamentos, 8),

                AluguelSET = CalculaAlugueisFlatsPorMes(flat.Lancamentos, 9),
                DividendosSET = CalculaDividendosFlatsPorMes(flat.Lancamentos, 9),

                AluguelOUT = CalculaAlugueisFlatsPorMes(flat.Lancamentos, 10),
                DividendosOUT = CalculaDividendosFlatsPorMes(flat.Lancamentos, 10),

                AluguelNOV = CalculaAlugueisFlatsPorMes(flat.Lancamentos, 11),
                DividendosNOV = CalculaDividendosFlatsPorMes(flat.Lancamentos, 11),

                AluguelDEZ = CalculaAlugueisFlatsPorMes(flat.Lancamentos, 12),
                DividendosDEZ = CalculaDividendosFlatsPorMes(flat.Lancamentos, 12),

                ACUMULADO = flat.Lancamentos
                   .Where(l => l.TipoPagamento == "Aluguel Fixo + Dividendos" ||
                               l.TipoPagamento == "Aluguel Fixo" ||
                               l.TipoPagamento == "Dividendos")
                   .Sum(l => (l.ValorAluguel ?? 0) + (l.ValorDividendos ?? 0))
            })
            .OrderBy(flat => flat.EMPREENDIMENTO)
            .ToList();

            return dadosAluguelDiv;
        }
        public IEnumerable<object> ObterDadosTotaisALDIV()
        {
            var totalMesJan = CalculaTotaisPorMes(1);
            var totalMesFev = CalculaTotaisPorMes(2);
            var totalMesMar = CalculaTotaisPorMes(3);
            var totalMesAbr = CalculaTotaisPorMes(4);
            var totalMesMai = CalculaTotaisPorMes(5);
            var totalMesJun = CalculaTotaisPorMes(6);
            var totalMesJul = CalculaTotaisPorMes(7);
            var totalMesAgo = CalculaTotaisPorMes(8);
            var totalMesSet = CalculaTotaisPorMes(9);
            var totalMesOut = CalculaTotaisPorMes(10);
            var totalMesNov = CalculaTotaisPorMes(11);
            var totalMesDez = CalculaTotaisPorMes(12);


            var dadosTotaisMes = new List<object>
           {
            new
            {
                Descricao = "TOTAL DO MÊS",
                JANEIRO = totalMesJan,
                FEVEREIRO = totalMesFev,
                MARÇO = totalMesMar,
                ABRIL = totalMesAbr,
                MAIO = totalMesMai,
                JUNHO = totalMesJun,
                JULHO = totalMesJul,
                AGOSTO = totalMesAgo,
                SETEMBRO = totalMesSet,
                OUTUBRO = totalMesOut,
                NOVEMBRO = totalMesNov,
                DEZEMBRO = totalMesDez,
                }
            };
                return dadosTotaisMes;
            
        }
        public decimal CalculaTotaisPorMes(int mes)
        {
            int anoAtual = DateTime.Now.Year;

            var totalAluguel = _context.Lancamento
            .Where(l => (l.DataPagamento.Month == mes && l.DataPagamento.Year == anoAtual))
            .Sum(l => (l.ValorAluguel ?? 0));
                               
            var totalDividendos = _context.Lancamento
            .Where(l => (l.DataPagamento.Month == mes && l.DataPagamento.Year == anoAtual))
            .Sum(l => (l.ValorDividendos ?? 0));

            return totalAluguel + totalDividendos;
            
        }
        public decimal CalculaAlugueisFlatsPorMes(IEnumerable<Lancamento> lancamentos, int mes)
        {
            return lancamentos
                .Where(l => l.DataPagamento.Month == mes)
                .Sum(l => (l.ValorAluguel ?? 0));
        }
        public decimal CalculaDividendosFlatsPorMes(IEnumerable<Lancamento> lancamentos, int mes)
        {
            return lancamentos
                .Where(l => l.DataPagamento.Month == mes)
                .Sum(l => (l.ValorDividendos ?? 0));
        }
        //
        //Formulário Dividendos
        public IEnumerable<dynamic> ObterDadosDividendos()
        {

            var flats = _context.Flat
                .Include(flat => flat.Empresa)
              .AsNoTracking()
              .Where(flat => flat.TipoInvestimento == "Aluguel Fixo + Dividendos" ||                           
                             flat.TipoInvestimento == "Dividendos")
              .Include(flat => flat.Lancamentos)  // Carrega os lançamentos relacionados
              .ToList();  // Executa a query e traz os dados para memória

            var dadosDividendos = flats.Select(flat => new
            {
                BANDEIRA = flat.idEmpresa != null ? flat.Empresa.Descricao : null,
                EMPREENDIMENTO = flat.Descricao,
                CODFLAT = flat.id,
                ValorImovel = flat.ValorInvestimento,
                DividendosJan = CalculaDividendosFlatsPorMes(flat.Lancamentos, 1),
                DividendosFev = CalculaDividendosFlatsPorMes(flat.Lancamentos, 2),
                DividendosMar = CalculaDividendosFlatsPorMes(flat.Lancamentos, 3),
                DividendosAbr = CalculaDividendosFlatsPorMes(flat.Lancamentos, 4),
                DividendosMai = CalculaDividendosFlatsPorMes(flat.Lancamentos, 5),
                DividendosJun = CalculaDividendosFlatsPorMes(flat.Lancamentos, 6),
                DividendosJul = CalculaDividendosFlatsPorMes(flat.Lancamentos, 7),
                DividendosAgo = CalculaDividendosFlatsPorMes(flat.Lancamentos, 8),
                DividendosSet = CalculaDividendosFlatsPorMes(flat.Lancamentos, 9),
                DividendosOut = CalculaDividendosFlatsPorMes(flat.Lancamentos, 10),
                DividendosNov = CalculaDividendosFlatsPorMes(flat.Lancamentos, 11),
                DividendosDez = CalculaDividendosFlatsPorMes(flat.Lancamentos, 12),

                ACUMULADO = flat.Lancamentos
                .Where(l => l.TipoPagamento == "Dividendos")
                .Sum(l => (l.ValorAluguel ?? 0) + (l.ValorDividendos ?? 0))

            })
                .OrderBy(flat => flat.EMPREENDIMENTO)
                .ToList();
                
            return dadosDividendos;
        }
        public decimal CalculaDividendosPorMes(int mes)
        {
            var totalDividendos = _context.Lancamento
            .Where(l => l.DataPagamento.Month == mes && (l.TipoPagamento == "Aluguel Fixo + Dividendos" || l.TipoPagamento == "Dividendos"))
            .Sum(l => (l.ValorDividendos ?? 0));

            return totalDividendos;

        }
        //
        //Formulário Fundo de Reserva
        public IEnumerable<dynamic> ObterDadosFunReserva()
        {
            var dadosFunReserva = _context.Flat
                .Include(flat => flat.Lancamentos)
                .Where(flat => flat.Lancamentos.Any(l => l.ValorFundoReserva > 0))
                .Select(flat => new
                {
                    EMPREENDIMENTO = flat.Descricao,
                    CODFLAT = flat.id,
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
                })
                .OrderBy(flat => flat.EMPREENDIMENTO)
                .ToList();
            return dadosFunReserva;
        }
        public IEnumerable<dynamic> ObterDadosTotaisFundoReserva()
        {
            var totaisFR = _context.Lancamento
               .Where(l => l.ValorFundoReserva > 0)  // Filtra apenas os lançamentos com valor maior que 0
               .GroupBy(l => l.DataPagamento.Month)  // Agrupa por mês
               .Select(g => new
               {
                   Mes = g.Key,  // Mês do agrupamento
                   Total = g.Sum(l => l.ValorFundoReserva)  // Soma os valores do fundo de reserva
               })
               .ToList();
            var resultado = new
            {
                Descricao = "TOTAL",
                Janeiro = totaisFR.FirstOrDefault(x => x.Mes == 1)?.Total ?? 0.00M,
                Fevereiro = totaisFR.FirstOrDefault(x => x.Mes == 2)?.Total ?? 0.00M,
                Março = totaisFR.FirstOrDefault(x => x.Mes == 3)?.Total ?? 0.00M,
                Abril = totaisFR.FirstOrDefault(x => x.Mes == 4)?.Total ?? 0.00M,
                Maio = totaisFR.FirstOrDefault(x => x.Mes == 5)?.Total ?? 0.00M,
                Junho = totaisFR.FirstOrDefault(x => x.Mes == 6)?.Total ?? 0.00M,
                Julho = totaisFR.FirstOrDefault(x => x.Mes == 7)?.Total ?? 0.00M,
                Agosto = totaisFR.FirstOrDefault(x => x.Mes == 8)?.Total ?? 0.00M,
                Setembro = totaisFR.FirstOrDefault(x => x.Mes == 9)?.Total ?? 0.00M,
                Outubro = totaisFR.FirstOrDefault(x => x.Mes == 10)?.Total ?? 0.00M,
                Novembro = totaisFR.FirstOrDefault(x => x.Mes == 11)?.Total ?? 0.00M,
                Dezembro = totaisFR.FirstOrDefault(x => x.Mes == 12)?.Total ?? 0.00M
            };
            return new List<dynamic> { resultado };
        }
        //
        //Formulário Rendimentos
        public IEnumerable<dynamic> ObterDadosRendimentos()
        {
            var flats = _context.Flat
                .Include(flat => flat.Lancamentos)
                .ToList();

            var dadosRendimentos = flats.Select(flat => new
            {
                EMPREENDIMENTO = flat.Descricao,
                CODFLAT = flat.id,
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
                PorceAnual = CalculaPorcentagemAnualPorFlat(flat.Lancamentos, flat.ValorInvestimento)
            })
            .OrderBy(flat => flat.EMPREENDIMENTO)
            .ToList();


            return dadosRendimentos;
        }
        public IEnumerable<object> ObterDadosTotais()
        {
            var totalInv = CalcularTotalValorInvestimento();

            var totalJan = CalculaLancamentosPorMes(1, false);
            var PorcJan = CalculaLancamentosPorMes(1, true);

            var totalFev = CalculaLancamentosPorMes(2, false);
            var PorcFev = CalculaLancamentosPorMes(2, true);

            var totalMar = CalculaLancamentosPorMes(3, false);
            var PorcMar = CalculaLancamentosPorMes(3, true);

            var totalAbr = CalculaLancamentosPorMes(4, false);
            var PorcAbr = CalculaLancamentosPorMes(4, true);

            var totalMai = CalculaLancamentosPorMes(5, false);
            var PorcMai = CalculaLancamentosPorMes(5, true);

            var totalJun = CalculaLancamentosPorMes(6, false);
            var PorcJun = CalculaLancamentosPorMes(6, true);

            var totalJul = CalculaLancamentosPorMes(7, false);
            var PorcJul = CalculaLancamentosPorMes(7, true);

            var totalAgo = CalculaLancamentosPorMes(8, false);
            var PorcAgo = CalculaLancamentosPorMes(8, true);

            var totalSet = CalculaLancamentosPorMes(9, false);
            var PorcSet = CalculaLancamentosPorMes(9, true);

            var totalOut = CalculaLancamentosPorMes(10, false);
            var PorcOut = CalculaLancamentosPorMes(10, true);

            var totalNov = CalculaLancamentosPorMes(11, false);
            var PorcNov = CalculaLancamentosPorMes(11, true);

            var totalDez = CalculaLancamentosPorMes(12, false);
            var PorcDez = CalculaLancamentosPorMes(12, true);

            var dadosTotais = new List<object>
    {
        new
        {
            TOTAL = totalInv,

            Janeiro = totalJan,
            PorcentagemJan = PorcJan,

            Fevereiro = totalFev,
            PorcentagemFev = PorcFev,

            Março = totalMar,
            PorcentagemMar = PorcMar,

            Abril = totalAbr,
            PorcentagemAbr = PorcAbr,

            Maio = totalMai,
            PorcentagemMai = PorcMai,

            Junho = totalJun,
            PorcentagemJun = PorcJun,

            Julho = totalJul,
            PorcentagemJul = PorcJul,

            Agosto = totalAgo,
            PorcentagemAgo = PorcAgo,

            Setembro = totalSet,
            PorcentagemSet = PorcSet,

            Outubro = totalOut,
            PorcentagemOut = PorcOut,

            Novembro = totalNov,
            PorcentagemNov = PorcNov,

            Dezembro = totalDez,
            PorcentagemDez = PorcDez
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
                if (totalInvestimento != 0)
                {
                    total = total / totalInvestimento;
                    return total;
                }
                else return 0;


            }
        }
        public static decimal CalcularRendimentoPorMes(IEnumerable<Lancamento>? lancamentos, int mes)
        {
            if (lancamentos == null || mes < 1 || mes > 12)
                return 0.00M;

            return lancamentos
                .Where(l => l.DataPagamento.Month == mes)
                .Sum(l => (l.ValorDividendos ?? 0.00M) +
                          (l.ValorAluguel ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));
        }
        public static decimal CalcularPorcentagemPorMes(IEnumerable<Lancamento>? lancamentos, int mes, decimal valorImovel)
        {
            if (lancamentos == null || valorImovel <= 0 || mes < 1 || mes > 12)
                return 0.00M;

            decimal rendimentoMes = lancamentos
                .Where(l => l.DataPagamento.Month == mes)
                .Sum(l => (l.ValorAluguel ?? 0.00M) +
                          (l.ValorDividendos ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));

            return (rendimentoMes / valorImovel) * 100;
        }
        public static decimal CalculaRendimentoAnualPorFlat(IEnumerable<Lancamento>? lancamentos)
        {
            if (lancamentos == null)
                return 0.00M;

            decimal rendimentoAno = lancamentos
                .Where(l => l.DataPagamento.Year == DateTime.Now.Year)
                .Sum(l => (l.ValorAluguel ?? 0.00M) +
                          (l.ValorDividendos ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));

            return rendimentoAno;
        }
        public static decimal CalculaPorcentagemAnualPorFlat(IEnumerable<Lancamento> lancamentos, decimal valorImovel)
        {
            if (lancamentos == null || valorImovel <= 0)
                return 0.00M;

            decimal rendimentoAno = lancamentos
                .Where(l => l.DataPagamento.Year == DateTime.Now.Year)
                .Sum(l => (l.ValorAluguel ?? 0.00M) +
                          (l.ValorDividendos ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));

            return (rendimentoAno / valorImovel) * 100;
        }
        //
        //PIS E COFINS
        public IEnumerable<object> ObterDadosPISeCOFINS()
        {
            //DADOS ALUGUEL VENCESLAU
            var totalJanAV = CalculaAluguelVenceslau(1);
            var totalFevAV = CalculaAluguelVenceslau(2);
            var totalMarAV = CalculaAluguelVenceslau(3);
            var totalAbrAV = CalculaAluguelVenceslau(4);
            var totalMaiAV = CalculaAluguelVenceslau(5);
            var totalJunAV = CalculaAluguelVenceslau(6);
            var totalJulAV = CalculaAluguelVenceslau(7);
            var totalAgoAV = CalculaAluguelVenceslau(8);
            var totalSetAV = CalculaAluguelVenceslau(9);
            var totalOutAV = CalculaAluguelVenceslau(10);
            var totalNovAV = CalculaAluguelVenceslau(11);
            var totalDezAV = CalculaAluguelVenceslau(12);

            //DADOS ALUGUEL FLATS
            var totalJanAF = CalculaAlugueleDividendosFlats(1);
            var totalFevAF = CalculaAlugueleDividendosFlats(2);
            var totalMarAF = CalculaAlugueleDividendosFlats(3);
            var totalAbrAF = CalculaAlugueleDividendosFlats(4);
            var totalMaiAF = CalculaAlugueleDividendosFlats(5);
            var totalJunAF = CalculaAlugueleDividendosFlats(6);
            var totalJulAF = CalculaAlugueleDividendosFlats(7);
            var totalAgoAF = CalculaAlugueleDividendosFlats(8);
            var totalSetAF = CalculaAlugueleDividendosFlats(9);
            var totalOutAF = CalculaAlugueleDividendosFlats(10);
            var totalNovAF = CalculaAlugueleDividendosFlats(11);
            var totalDezAF = CalculaAlugueleDividendosFlats(12);

            //DADOS FUNDO DE RESERVA
            var totalJanFR = CalculaFundoReservaFlats(1);
            var totalFevFR = CalculaFundoReservaFlats(2);
            var totalMarFR = CalculaFundoReservaFlats(3);
            var totalAbrFR = CalculaFundoReservaFlats(4);
            var totalMaiFR = CalculaFundoReservaFlats(5);
            var totalJunFR = CalculaFundoReservaFlats(6);
            var totalJulFR = CalculaFundoReservaFlats(7);
            var totalAgoFR = CalculaFundoReservaFlats(8);
            var totalSetFR = CalculaFundoReservaFlats(9);
            var totalOutFR = CalculaFundoReservaFlats(10);
            var totalNovFR = CalculaFundoReservaFlats(11);
            var totalDezFR = CalculaFundoReservaFlats(12);

            //DADOS BASE DE CALCULO
            var BCJan = totalJanAV + totalJanAF + totalJanFR;
            var BCFeb = totalFevAV + totalFevAF + totalFevFR;
            var BCMar = totalMarAV + totalMarAF + totalMarFR;
            var BCAbr = totalAbrAV + totalAbrAF + totalAbrFR;
            var BCMai = totalMaiAV + totalMaiAF + totalMaiFR;
            var BCJun = totalJunAV + totalJunAF + totalJunFR;
            var BCJul = totalJulAV + totalJulAF + totalJulFR;
            var BCAgo = totalAgoAV + totalAgoAF + totalAgoFR;
            var BCSet = totalSetAV + totalSetAF + totalSetFR;
            var BCOut = totalOutAV + totalOutAF + totalOutFR;
            var BCNov = totalNovAV + totalNovAF + totalNovFR;
            var BCDez = totalDezAV + totalDezAF + totalDezFR;


            var JanPIS = CalcularPIS(BCJan);
            var FevPIS = CalcularPIS(BCFeb);
            var MarPIS = CalcularPIS(BCMar);
            var AbrPIS = CalcularPIS(BCAbr);
            var MaiPIS = CalcularPIS(BCMai);
            var JunPIS = CalcularPIS(BCJun);
            var JulPIS = CalcularPIS(BCJul);
            var AgoPIS = CalcularPIS(BCAgo);
            var SetPIS = CalcularPIS(BCSet);
            var OutPIS = CalcularPIS(BCOut);
            var NovPIS = CalcularPIS(BCNov);
            var DezPIS = CalcularPIS(BCDez);


            var JanCOF = CalculaCOFINS(BCJan);
            var FevCOF = CalculaCOFINS(BCFeb);
            var MarCOF = CalculaCOFINS(BCMar);
            var AbrCOF = CalculaCOFINS(BCAbr);
            var MaiCOF = CalculaCOFINS(BCMai);
            var JunCOF = CalculaCOFINS(BCJun);
            var JulCOF = CalculaCOFINS(BCJul);
            var AgoCOF = CalculaCOFINS(BCAgo);
            var SetCOF = CalculaCOFINS(BCSet);
            var OutCOF = CalculaCOFINS(BCOut);
            var NovCOF = CalculaCOFINS(BCNov);
            var DezCOF = CalculaCOFINS(BCDez);

            var dadosTotais = new List<object>
            {
                new
                {
                    Descricao = "Aluguel Venceslau",
                    JANEIRO = totalJanAV,
                    FEVEREIRO = totalFevAV,
                    MARÇO = totalMarAV,
                    ABRIL = totalAbrAV,
                    MAIO = totalMaiAV,
                    JUNHO = totalJunAV,
                    JULHO = totalJulAV,
                    AGOSTO = totalAgoAV,
                    SETEMBRO = totalSetAV,
                    OUTUBRO = totalOutAV,
                    NOVEMBRO = totalNovAV,
                    DEZEMBRO = totalDezAV
                },
                new
                {
                    Descricao = "Aluguel Flats",
                    JANEIRO = totalJanAF,
                    FEVEREIRO = totalFevAF,
                    MARÇO = totalMarAF,
                    ABRIL = totalAbrAF,
                    MAIO = totalMaiAF,
                    JUNHO = totalJunAF,
                    JULHO = totalJulAF,
                    AGOSTO = totalAgoAF,
                    SETEMBRO = totalSetAF,
                    OUTUBRO = totalOutAF,
                    NOVEMBRO = totalNovAF,
                    DEZEMBRO = totalDezAF
                },
                 new
                {
                    Descricao = "Fundo de Reserva Flats",
                    JANEIRO = totalJanFR,
                    FEVEREIRO = totalFevFR,
                    MARÇO = totalMarFR,
                    ABRIL = totalAbrFR,
                    MAIO = totalMaiFR,
                    JUNHO = totalJunFR,
                    JULHO = totalJulFR,
                    AGOSTO = totalAgoFR,
                    SETEMBRO = totalSetFR,
                    OUTUBRO = totalOutFR,
                    NOVEMBRO = totalNovFR,
                    DEZEMBRO = totalDezFR
                },
                 new
                {
                    Descricao = "Base de Cálculo (PIS/COFINS)",
                    JANEIRO = totalJanAV + totalJanAF + totalJanFR,
                    FEVEREIRO = totalFevAV + totalFevAF + totalFevFR,
                    MARÇO = totalMarAV + totalMarAF + totalMarFR,
                    ABRIL = totalAbrAV + totalAbrAF + totalAbrFR,
                    MAIO = totalMaiAV + totalMaiAF + totalMaiFR,
                    JUNHO = totalJunAV + totalJunAF + totalJunFR,
                    JULHO = totalJulAV + totalJulAF + totalJulFR,
                    AGOSTO = totalAgoAV + totalAgoAF + totalAgoFR,
                    SETEMBRO = totalSetAV + totalSetAF + totalSetFR,
                    OUTUBRO = totalOutAV + totalOutAF + totalOutFR,
                    NOVEMBRO = totalNovAV + totalNovAF + totalNovFR,
                    DEZEMBRO = totalDezAV + totalDezAF + totalDezFR
                },
                   new
                {
                    Descricao = "PIS",
                    JANEIRO = JanPIS,
                    FEVEREIRO = FevPIS,
                    MARÇO = MarPIS,
                    ABRIL = AbrPIS,
                    MAIO = MaiPIS,
                    JUNHO = JunPIS,
                    JULHO = JulPIS,
                    AGOSTO = AgoPIS,
                    SETEMBRO = SetPIS,
                    OUTUBRO = OutPIS,
                    NOVEMBRO = NovPIS,
                    DEZEMBRO = DezPIS
                },
                   new
                {
                    Descricao = "COFINS",
                    JANEIRO = JanCOF,
                    FEVEREIRO = FevCOF,
                    MARÇO = MarCOF,
                    ABRIL = AbrCOF,
                    MAIO = MaiCOF,
                    JUNHO = JunCOF,
                    JULHO = JulCOF,
                    AGOSTO = AgoCOF,
                    SETEMBRO = SetCOF,
                    OUTUBRO = OutCOF,
                    NOVEMBRO = NovCOF,
                    DEZEMBRO = DezCOF
                },
             };
            return dadosTotais;
        }
        public decimal CalculaAluguelVenceslau(int mes)
        {
            var total = _context.Lancamento
                .Where(l => l.DataPagamento.Month == mes && l.TipoPagamento == "Aluguel Venceslau")
                .Sum(l => l.AluguelVenceslau ?? 0);
            return total;

        }
        public decimal CalculaAlugueleDividendosFlats(int mes)
        {
            decimal total = _context.Lancamento
                .Where(l => l.DataPagamento.Month == mes)
                .Sum(l => (l.ValorAluguel ?? 0.00M) +
                          (l.ValorDividendos ?? 0.00M));
            return total;

        }
        public decimal CalculaFundoReservaFlats(int mes)
        {
            decimal total = _context.Lancamento
                .Where(l => l.DataPagamento.Month == mes)
                .Sum(l => (l.ValorFundoReserva ?? 0.00M));
            return total;
        }
        public decimal CalcularPIS(decimal BC)
        {
            if (BC != 0)
            {
                decimal resultado = BC * 0.0065M;
                return Math.Round(resultado, 2);
            }
            else return 0;             
        }
        public decimal CalculaCOFINS(decimal BC)
        {
            if (BC != 0)
            {
                decimal resultado = BC * 0.03M;
                return Math.Round(resultado, 2);
            }
            else return 0;
        }
        //
       

    }
}