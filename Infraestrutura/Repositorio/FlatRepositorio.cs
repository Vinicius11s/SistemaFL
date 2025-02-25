﻿using System;
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
using System.Data;
using Infraestrutura.Seguranca;

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
                .Where(f => f.TipoInvestimento != "Aluguel Venceslau")
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
                    ? $"{flat.Rua ?? ""}, {flat.Numero ?? ""}, {flat.Bairro}"
                    : $"{flat.Rua ?? ""}",
                    Investimento = flat.ValorDeCompra,
                    Status = flat.Status.ToString()
                })
                .OrderBy(flat => flat.Flat)
                .ToList();

            return dadosInvestimento;
        }
        public decimal CalcularTotalValorDeCompra()
        {
            return _context.Flat
               .Where(flat => flat.Status != "Vendido") // Filtra os que NÃO estão vendidos
               .Sum(flat => flat.ValorDeCompra);
        }
        public int CalcularTotalFlats()
        {
            return _context.Flat.Count();
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
                ValorImovel = flat.ValorDeCompra,

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
                ValorImovel = flat.ValorDeCompra,
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
            var dados = _context.Flat
                .Where(flat => flat.Lancamentos.Any(l => l.ValorFundoReserva > 0)) // Filtra flats com lançamentos válidos.
                .Select(flat => new
                {
                    flat.Descricao,
                    flat.id,
                    LancamentosPorMes = flat.Lancamentos
                        .Where(l => l.ValorFundoReserva > 0) // Filtra lançamentos com valor positivo de fundo de reserva.
                        .GroupBy(l => l.DataPagamento.Month) // Agrupa por mês.
                        .Select(g => new { Mes = g.Key, Total = g.Sum(l => (decimal?)l.ValorFundoReserva) ?? 0.00M }) // Soma os valores por mês.
                        .ToList()
                })
                .AsEnumerable() // Finaliza a consulta para o banco de dados.
                .Select(flat => new
                {
                    EMPREENDIMENTO = flat.Descricao,
                    CODFLAT = flat.id,
                    JANEIRO = flat.LancamentosPorMes.FirstOrDefault(l => l.Mes == 1)?.Total ?? 0.00M,
                    FEVEREIRO = flat.LancamentosPorMes.FirstOrDefault(l => l.Mes == 2)?.Total ?? 0.00M,
                    MARÇO = flat.LancamentosPorMes.FirstOrDefault(l => l.Mes == 3)?.Total ?? 0.00M,
                    ABRIL = flat.LancamentosPorMes.FirstOrDefault(l => l.Mes == 4)?.Total ?? 0.00M,
                    MAIO = flat.LancamentosPorMes.FirstOrDefault(l => l.Mes == 5)?.Total ?? 0.00M,
                    JUNHO = flat.LancamentosPorMes.FirstOrDefault(l => l.Mes == 6)?.Total ?? 0.00M,
                    JULHO = flat.LancamentosPorMes.FirstOrDefault(l => l.Mes == 7)?.Total ?? 0.00M,
                    AGOSTO = flat.LancamentosPorMes.FirstOrDefault(l => l.Mes == 8)?.Total ?? 0.00M,
                    SETEMBRO = flat.LancamentosPorMes.FirstOrDefault(l => l.Mes == 9)?.Total ?? 0.00M,
                    OUTUBRO = flat.LancamentosPorMes.FirstOrDefault(l => l.Mes == 10)?.Total ?? 0.00M,
                    NOVEMBRO = flat.LancamentosPorMes.FirstOrDefault(l => l.Mes == 11)?.Total ?? 0.00M,
                    DEZEMBRO = flat.LancamentosPorMes.FirstOrDefault(l => l.Mes == 12)?.Total ?? 0.00M
                })
                .OrderBy(flat => flat.EMPREENDIMENTO) // Ordena os flats por descrição.
                .ToList();

            return dados;
        }
        public IEnumerable<dynamic> ObterDadosTotaisFundoReserva()
        {
            var totaisFR = _context.Lancamento
                .Where(l => l.ValorFundoReserva > 0)  // Filtra apenas os lançamentos com valor maior que 0
                .GroupBy(l => l.DataPagamento.Month)  // Agrupa por mês
                .ToDictionary(g => g.Key, g => g.Sum(l => l.ValorFundoReserva)); // Cria um dicionário com mês e soma do valor

            var resultado = new
            {
                Descricao = "TOTAL",
                Janeiro = totaisFR.GetValueOrDefault(1, 0.00M),
                Fevereiro = totaisFR.GetValueOrDefault(2, 0.00M),
                Março = totaisFR.GetValueOrDefault(3, 0.00M),
                Abril = totaisFR.GetValueOrDefault(4, 0.00M),
                Maio = totaisFR.GetValueOrDefault(5, 0.00M),
                Junho = totaisFR.GetValueOrDefault(6, 0.00M),
                Julho = totaisFR.GetValueOrDefault(7, 0.00M),
                Agosto = totaisFR.GetValueOrDefault(8, 0.00M),
                Setembro = totaisFR.GetValueOrDefault(9, 0.00M),
                Outubro = totaisFR.GetValueOrDefault(10, 0.00M),
                Novembro = totaisFR.GetValueOrDefault(11, 0.00M),
                Dezembro = totaisFR.GetValueOrDefault(12, 0.00M)
            };

            return new List<dynamic> { resultado };
        }
        //
        //Formulário Rendimentos
        public IEnumerable<dynamic> ObterDadosRendimentos(int ano)
            {
                var flats = _context.Flat
                    .Include(flat => flat.Lancamentos)
                    .ToList();

                var dadosRendimentos = flats.Select(flat => new
                {
                    EMPREENDIMENTO = flat.Descricao,
                    CODFLAT = flat.id,
                    ValorImovel = flat.ValorDeCompra,

                    // Calcular os rendimentos e porcentagens para cada mês
                    JANEIRO = CalcularRendimentoPorMes(flat.Lancamentos, 1, ano),
                    PorcentagemJan = CalcularPorcentagemPorMes(flat.Lancamentos, 1, ano, flat.ValorDeCompra),

                    FEVEREIRO = CalcularRendimentoPorMes(flat.Lancamentos, 2, ano),
                    PorcentagemFev = CalcularPorcentagemPorMes(flat.Lancamentos, 2, ano, flat.ValorDeCompra),

                    MARÇO = CalcularRendimentoPorMes(flat.Lancamentos, 3, ano),
                    PorcentagemMar = CalcularPorcentagemPorMes(flat.Lancamentos, 3, ano, flat.ValorDeCompra),

                    ABRIL = CalcularRendimentoPorMes(flat.Lancamentos, 4, ano),
                    PorcentagemAbr = CalcularPorcentagemPorMes(flat.Lancamentos, 4, ano, flat.ValorDeCompra),

                    MAIO = CalcularRendimentoPorMes(flat.Lancamentos, 5, ano),
                    PorcentagemMai = CalcularPorcentagemPorMes(flat.Lancamentos, 5, ano, flat.ValorDeCompra),

                    JUNHO = CalcularRendimentoPorMes(flat.Lancamentos, 6, ano),
                    PorcentagemJun = CalcularPorcentagemPorMes(flat.Lancamentos, 6, ano, flat.ValorDeCompra),

                    JULHO = CalcularRendimentoPorMes(flat.Lancamentos, 7, ano),
                    PorcentagemJul = CalcularPorcentagemPorMes(flat.Lancamentos, 7, ano, flat.ValorDeCompra),

                    AGOSTO = CalcularRendimentoPorMes(flat.Lancamentos, 8, ano),
                    PorcentagemAgo = CalcularPorcentagemPorMes(flat.Lancamentos, 8, ano, flat.ValorDeCompra),

                    SETEMBRO = CalcularRendimentoPorMes(flat.Lancamentos, 9, ano),
                    PorcentagemSet = CalcularPorcentagemPorMes(flat.Lancamentos, 9, ano, flat.ValorDeCompra),

                    OUTUBRO = CalcularRendimentoPorMes(flat.Lancamentos, 10, ano),
                    PorcentagemOut = CalcularPorcentagemPorMes(flat.Lancamentos, 10, ano, flat.ValorDeCompra),

                    NOVEMBRO = CalcularRendimentoPorMes(flat.Lancamentos, 11, ano),
                    PorcentagemNov = CalcularPorcentagemPorMes(flat.Lancamentos, 11, ano, flat.ValorDeCompra),

                    DEZEMBRO = CalcularRendimentoPorMes(flat.Lancamentos, 12, ano),
                    PorcentagemDez = CalcularPorcentagemPorMes(flat.Lancamentos, 12, ano, flat.ValorDeCompra),

                    RendimentoAnual = CalculaRendimentoAnualPorFlat(flat.Lancamentos, ano),
                    PorcentagemAnual = CalculaPorcentagemAnualPorFlat(flat.Lancamentos, flat.ValorDeCompra, ano)
                })
                .OrderBy(flat => flat.EMPREENDIMENTO)
                .ToList();


                return dadosRendimentos;
            }
        public IEnumerable<object> ObterDadosTotais(int ano)
        {
            decimal totalAno;
            var totalInv = CalcularTotalValorDeCompra();

            var totalJan = CalculaLancamentosPorMes(1, ano, false);
            var PorcJan = CalculaLancamentosPorMes(1, ano, true);

            var totalFev = CalculaLancamentosPorMes(2, ano, false);
            var PorcFev = CalculaLancamentosPorMes(2, ano, true);

            var totalMar = CalculaLancamentosPorMes(3, ano, false);
            var PorcMar = CalculaLancamentosPorMes(3, ano, true);

            var totalAbr = CalculaLancamentosPorMes(4, ano, false);
            var PorcAbr = CalculaLancamentosPorMes(4, ano, true);

            var totalMai = CalculaLancamentosPorMes(5, ano, false);
            var PorcMai = CalculaLancamentosPorMes(5, ano, true);

            var totalJun = CalculaLancamentosPorMes(6, ano, false);
            var PorcJun = CalculaLancamentosPorMes(6, ano, true);

            var totalJul = CalculaLancamentosPorMes(7, ano, false);
            var PorcJul = CalculaLancamentosPorMes(7, ano, true);

            var totalAgo = CalculaLancamentosPorMes(8, ano, false);
            var PorcAgo = CalculaLancamentosPorMes(8, ano, true);

            var totalSet = CalculaLancamentosPorMes(9, ano, false);
            var PorcSet = CalculaLancamentosPorMes(9, ano, true);

            var totalOut = CalculaLancamentosPorMes(10, ano, false);
            var PorcOut = CalculaLancamentosPorMes(10, ano, true);

            var totalNov = CalculaLancamentosPorMes(11, ano, false);
            var PorcNov = CalculaLancamentosPorMes(11, ano, true);

            var totalDez = CalculaLancamentosPorMes(12, ano, false);
            var PorcDez = CalculaLancamentosPorMes(12, ano, true);

            totalAno = totalJan + totalFev + totalMar + totalAbr + totalAbr + totalMai + totalJun + totalJul + totalAgo + totalSet + totalOut +
                totalNov + totalDez;

            var dadosTotais = new List<object>
            {
                new
                {
                    TOTAL = totalInv,

                    JANEIRO = totalJan,
                    PorcentagemJan = PorcJan,

                    FEVEREIRO = totalFev,
                    PorcentagemFev = PorcFev,

                    MARÇO = totalMar,
                    PorcentagemMar = PorcMar,

                    ABRIL = totalAbr,
                    PorcentagemAbr = PorcAbr,

                    MAIO = totalMai,
                    PorcentagemMai = PorcMai,

                    JUNHO = totalJun,
                    PorcentagemJun = PorcJun,

                    JULHO = totalJul,
                    PorcentagemJul = PorcJul,

                    AGOSTO = totalAgo,
                    PorcentagemAgo = PorcAgo,

                    SETEMBRO = totalSet,
                    PorcentagemSet = PorcSet,

                    OUTUBRO = totalOut,
                    PorcentagemOut = PorcOut,

                    NOVEMBRO = totalNov,
                    PorcentagemNov = PorcNov,

                    DEZEMBRO = totalDez,
                    PorcentagemDez = PorcDez,

                    RendimentoAno = totalAno
                }
            };
            return dadosTotais;
        }
        public decimal CalculaLancamentosPorMes(int mes, int ano, bool porcentagem)
        {
            // Filtra os lançamentos no mês especificado e exclui o tipo "Aluguel Vencelau"
            var total = _context.Lancamento
                .Where(l => l.DataPagamento.Month == mes && l.DataPagamento.Year == ano && l.TipoPagamento != "Aluguel Vencelau")
                .Sum(l => (l.ValorAluguel ?? 0) + (l.ValorDividendos ?? 0) + (l.ValorFundoReserva ?? 0));
            if (porcentagem == false)
            {
                return total;
            }
            else
            {
                decimal totalInvestimento = CalcularTotalValorDeCompra();
                if (totalInvestimento != 0)
                {
                    total = total / totalInvestimento;
                    return total;
                }
                else return 0;
            }
        }
        public static decimal CalcularRendimentoPorMes(IEnumerable<Lancamento>? lancamentos, int mes, int ano)
        {
            if (lancamentos == null || mes < 1 || mes > 12)
                return 0.00M;

            return lancamentos
                .Where(l => l.DataPagamento.Month == mes && l.DataPagamento.Year == ano)
                .Sum(l => (l.ValorDividendos ?? 0.00M) +
                          (l.ValorAluguel ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));
        }
        public static decimal CalcularPorcentagemPorMes(IEnumerable<Lancamento>? lancamentos, int mes, int ano, decimal valorImovel)
        {
            if (lancamentos == null || valorImovel <= 0 || mes < 1 || mes > 12)
                return 0.00M;

            decimal rendimentoMes = lancamentos
                .Where(l => l.DataPagamento.Month == mes && l.DataPagamento.Year == ano)
                .Sum(l => (l.ValorAluguel ?? 0.00M) +
                          (l.ValorDividendos ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));

            return (rendimentoMes / valorImovel) * 100;
        }
        public static decimal CalculaRendimentoAnualPorFlat(IEnumerable<Lancamento>? lancamentos, int ano)
        {
            if (lancamentos == null)
                return 0.00M;

            decimal rendimentoAno = lancamentos
                .Where(l => l.DataPagamento.Year == ano)
                .Sum(l => (l.ValorAluguel ?? 0.00M) +
                          (l.ValorDividendos ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));

            return rendimentoAno;
        }
        public static decimal CalculaPorcentagemAnualPorFlat(IEnumerable<Lancamento> lancamentos, decimal valorImovel, int ano)
        {
            if (lancamentos == null || valorImovel <= 0)
                return 0.00M;

            decimal rendimentoAno = lancamentos
                .Where(l => l.DataPagamento.Year == ano)
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
            var fiscal = _context.Fiscal.FirstOrDefault(); // Obtém a primeira instância de Fiscal

            if (BC > 0 && fiscal?.basePis != null)
            {
                decimal resultado = BC * fiscal.basePis.Value;
                return Math.Round(resultado, 2);
            }
            return 0;
        }
        public decimal CalculaCOFINS(decimal BC)
        {
            var fiscal = _context.Fiscal.FirstOrDefault(); // Obtém a primeira instância de Fiscal

            if (BC > 0 && fiscal?.baseCofins != null)
            {
                decimal resultado = BC * fiscal.baseCofins.Value;
                return Math.Round(resultado, 2);
            }
            return 0;
        }

    }
}