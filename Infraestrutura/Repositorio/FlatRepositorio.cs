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
            .Include(flat => flat.Lancamentos) // In
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
                RendimentoJan = flat.Lancamentos
                    .Where(r => r.DataPagamento.Month == 1)
                    .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                              (decimal?)r.ValorDividendos ?? 0.00M +
                              (decimal?)r.ValorFundoReserva) ?? 0.00M,
                PorcentagemJan = flat.ValorInvestimento != 0
                    ? (flat.Lancamentos
                        .Where(r => r.DataPagamento.Month == 1)
                        .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                                  (decimal?)r.ValorDividendos ?? 0.00M +
                                  (decimal?)r.ValorFundoReserva) ?? 0.00M) / flat.ValorInvestimento * 100 : 0.00M,


                RendimentoFev = flat.Lancamentos
                    .Where(r => r.DataPagamento.Month == 2)
                    .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                              (decimal?)r.ValorDividendos ?? 0.00M +
                              (decimal?)r.ValorFundoReserva) ?? 0.00M,
                PorcentagemFev = flat.ValorInvestimento != 0
                    ? (flat.Lancamentos
                        .Where(r => r.DataPagamento.Month == 2)
                        .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                                  (decimal?)r.ValorDividendos ?? 0.00M +
                                  (decimal?)r.ValorFundoReserva) ?? 0.00M) / flat.ValorInvestimento * 100 : 0.00M,


                RendimentoMar = flat.Lancamentos
                    .Where(r => r.DataPagamento.Month == 3)
                    .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                              (decimal?)r.ValorDividendos ?? 0.00M +
                              (decimal?)r.ValorFundoReserva) ?? 0.00M,
                PorcentagemMar = flat.ValorInvestimento != 0
                    ? (flat.Lancamentos
                        .Where(r => r.DataPagamento.Month == 3)
                        .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                                  (decimal?)r.ValorDividendos ?? 0.00M +
                                  (decimal?)r.ValorFundoReserva) ?? 0.00M) / flat.ValorInvestimento * 100 : 0.00M,


                RendimentoAbr = flat.Lancamentos
                    .Where(r => r.DataPagamento.Month == 4)
                    .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                              (decimal?)r.ValorDividendos ?? 0.00M +
                              (decimal?)r.ValorFundoReserva) ?? 0.00M,
                PorcentagemAbr = flat.ValorInvestimento != 0
                    ? (flat.Lancamentos
                        .Where(r => r.DataPagamento.Month == 4)
                        .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                                  (decimal?)r.ValorDividendos ?? 0.00M +
                                  (decimal?)r.ValorFundoReserva) ?? 0.00M) / flat.ValorInvestimento * 100 : 0.00M,


                RendimentoMai = flat.Lancamentos
                    .Where(r => r.DataPagamento.Month == 5)
                    .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                              (decimal?)r.ValorDividendos ?? 0.00M +
                              (decimal?)r.ValorFundoReserva) ?? 0.00M,
                PorcentagemMai = flat.ValorInvestimento != 0
                    ? (flat.Lancamentos
                        .Where(r => r.DataPagamento.Month == 5)
                        .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                                  (decimal?)r.ValorDividendos ?? 0.00M +
                                  (decimal?)r.ValorFundoReserva) ?? 0.00M) / flat.ValorInvestimento * 100 : 0.00M,


                RendimentoJun = flat.Lancamentos
                    .Where(r => r.DataPagamento.Month == 6)
                    .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                              (decimal?)r.ValorDividendos ?? 0.00M +
                              (decimal?)r.ValorFundoReserva) ?? 0.00M,
                PorcentagemJun = flat.ValorInvestimento != 0
                    ? (flat.Lancamentos
                        .Where(r => r.DataPagamento.Month == 6)
                        .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                                  (decimal?)r.ValorDividendos ?? 0.00M +
                                  (decimal?)r.ValorFundoReserva) ?? 0.00M) / flat.ValorInvestimento * 100 : 0.00M,


                RendimentoJul = flat.Lancamentos
                    .Where(r => r.DataPagamento.Month == 7)
                    .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                              (decimal?)r.ValorDividendos ?? 0.00M +
                              (decimal?)r.ValorFundoReserva) ?? 0.00M,
                PorcentagemJul = flat.ValorInvestimento != 0
                    ? (flat.Lancamentos
                        .Where(r => r.DataPagamento.Month == 7)
                        .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                                  (decimal?)r.ValorDividendos ?? 0.00M +
                                  (decimal?)r.ValorFundoReserva) ?? 0.00M) / flat.ValorInvestimento * 100 : 0.00M,


                RendimentoAgo = flat.Lancamentos
                    .Where(r => r.DataPagamento.Month == 8)
                    .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                              (decimal?)r.ValorDividendos ?? 0.00M +
                              (decimal?)r.ValorFundoReserva) ?? 0.00M,
                PorcentagemAgo = flat.ValorInvestimento != 0
                    ? (flat.Lancamentos
                        .Where(r => r.DataPagamento.Month == 8)
                        .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                                  (decimal?)r.ValorDividendos ?? 0.00M +
                                  (decimal?)r.ValorFundoReserva) ?? 0.00M) / flat.ValorInvestimento * 100 : 0.00M,


                RendimentoSet = flat.Lancamentos
                    .Where(r => r.DataPagamento.Month == 9)
                    .Sum(r => (decimal?)r.ValorAluguel +
                              (decimal?)r.ValorDividendos +
                              (decimal?)r.ValorFundoReserva) ?? 0.00M,
                PorcentagemSet = flat.ValorInvestimento != 0
                    ? (flat.Lancamentos
                        .Where(r => r.DataPagamento.Month == 9)
                        .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                                  (decimal?)r.ValorDividendos ?? 0.00M +
                                  (decimal?)r.ValorFundoReserva) ?? 0.00M) / flat.ValorInvestimento * 100 : 0.00M,


                RendimentoOut = flat.Lancamentos
                    .Where(r => r.DataPagamento.Month == 10)
                    .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                              (decimal?)r.ValorDividendos ?? 0.00M +
                              (decimal?)r.ValorFundoReserva) ?? 0.00M,
                PorcentagemOut = flat.ValorInvestimento != 0
                    ? (flat.Lancamentos
                        .Where(r => r.DataPagamento.Month == 10)
                        .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                                  (decimal?)r.ValorDividendos ?? 0.00M +
                                  (decimal?)r.ValorFundoReserva) ?? 0.00M) / flat.ValorInvestimento * 100 : 0.00M,


                RendimentoNov = flat.Lancamentos
                    .Where(r => r.DataPagamento.Month == 11)
                    .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                              (decimal?)r.ValorDividendos ?? 0.00M +
                              (decimal?)r.ValorFundoReserva) ?? 0.00M,
                PorcentagemNov = flat.ValorInvestimento != 0
                    ? (flat.Lancamentos
                        .Where(r => r.DataPagamento.Month == 11)
                        .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                                  (decimal?)r.ValorDividendos ?? 0.00M +
                                  (decimal?)r.ValorFundoReserva) ?? 0.00M) / flat.ValorInvestimento * 100 : 0.00M,


                RendimentoDez = flat.Lancamentos
                    .Where(r => r.DataPagamento.Month == 12)
                    .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                              (decimal?)r.ValorDividendos ?? 0.00M +
                              (decimal?)r.ValorFundoReserva) ?? 0.00M,
                PorcentagemDez = flat.ValorInvestimento != 0
                    ? (flat.Lancamentos
                        .Where(r => r.DataPagamento.Month == 12)
                        .Sum(r => (decimal?)r.ValorAluguel ?? 0.00M +
                                  (decimal?)r.ValorDividendos ?? 0.00M +
                                  (decimal?)r.ValorFundoReserva) ?? 0.00M) / flat.ValorInvestimento * 100 : 0.00M
            }).ToList();

            return dadosRendimentos;
        }

    }
}
