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

            JANEIRO = totalJan,
            PorcentagemJan = PorcJan,

            FEVEREIRO = totalFev,
            PorcentagemFev = PorcFev,

            MARCO = totalMar,
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
            PorcentagemDez = PorcDez
        }
    };
            return dadosTotais;
        }
        public IEnumerable<object> ObterDadosAluguelVenceslau()
        {
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

            var JanPIS = CalcularPIS(totalJanAV, totalJanAF, totalJanFR);
            var FevPIS = CalcularPIS(totalFevAV, totalFevAF, totalFevFR);
            var MarPIS = CalcularPIS(totalMarAV, totalMarAF, totalMarFR);
            var AbrPIS = CalcularPIS(totalAbrAV, totalAbrAF, totalAbrFR);
            var MaiPIS = CalcularPIS(totalMaiAV, totalMaiAF, totalMaiFR);
            var JunPIS = CalcularPIS(totalJunAV, totalJunAF, totalJunFR);
            var JulPIS = CalcularPIS(totalJulAV, totalJulAF, totalJulFR);
            var AgoPIS = CalcularPIS(totalAgoAV, totalAgoAF, totalAgoFR);
            var SetPIS = CalcularPIS(totalSetAV, totalSetAF, totalSetFR);
            var OutPIS = CalcularPIS(totalOutAV, totalOutAF, totalOutFR);
            var NovPIS = CalcularPIS(totalNovAV, totalNovAF, totalNovFR);
            var DezPIS = CalcularPIS(totalDezAV, totalDezAF, totalDezFR);

            var JanCOF = CalculaCOFINS(totalJanAV, totalJanAF, totalJanFR);
            var FevCOF = CalculaCOFINS(totalFevAV, totalFevAF, totalFevFR);
            var MarCOF = CalculaCOFINS(totalMarAV, totalMarAF, totalMarFR);
            var AbrCOF = CalculaCOFINS(totalAbrAV, totalAbrAF, totalAbrFR);
            var MaiCOF = CalculaCOFINS(totalMaiAV, totalMaiAF, totalMaiFR);
            var JunCOF = CalculaCOFINS(totalJunAV, totalJunAF, totalJunFR);
            var JulCOF = CalculaCOFINS(totalJulAV, totalJulAF, totalJulFR);
            var AgoCOF = CalculaCOFINS(totalAgoAV, totalAgoAF, totalAgoFR);
            var SetCOF = CalculaCOFINS(totalSetAV, totalSetAF, totalSetFR);
            var OutCOF = CalculaCOFINS(totalOutAV, totalOutAF, totalOutFR);
            var NovCOF = CalculaCOFINS(totalNovAV, totalNovAF, totalNovFR);
            var DezCOF = CalculaCOFINS(totalDezAV, totalDezAF, totalDezFR);

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

        //PIS E COFINS
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
        public decimal CalcularPIS(decimal totalAV, decimal totalAF, decimal totalFR)
        {
            if (totalAV == 0.00M || totalAF == 0.00M || totalFR == 0.00M)
            {
                return 0.00M;
            }

            decimal resultado = (totalAV + totalAF + totalFR) * 0.0065M;
            return Math.Round(resultado, 2);
        }
        public decimal CalculaCOFINS(decimal totalAV, decimal totalAF, decimal totalFR)
        {
            if (totalAV == 0.00M || totalAF == 0.00M || totalFR == 0.00M)
            {
                return 0.00M;
            }

            decimal resultado = (totalAV + totalAF + totalFR) * 0.03M;
            return Math.Round(resultado, 2);
        }
    }
}