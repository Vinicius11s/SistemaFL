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
    public class LancamentoRepositorio : BaseRepositorio<Lancamento>, ILancamentoRepositorio
    {
        private readonly ContextoSistema _context;
        public LancamentoRepositorio(ContextoSistema contexto) : base(contexto)
        {
            _context = contexto;
        }

        //Primeira Tabela do Relatório
        public IEnumerable<object> ObterDadosRelatorioMensal(int ano)
        {
          
            
            //Soma Todos Lancamentos feitos por Mes (exceto dividendos)
            var BCJan = SomaLancamentosPorMesExcetoDividendos(1, ano);
            var BCFeb = SomaLancamentosPorMesExcetoDividendos(2, ano);
            var BCMar = SomaLancamentosPorMesExcetoDividendos(3, ano);
            var BCAbr = SomaLancamentosPorMesExcetoDividendos(4, ano);
            var BCMai = SomaLancamentosPorMesExcetoDividendos(5, ano);
            var BCJun = SomaLancamentosPorMesExcetoDividendos(6, ano);
            var BCJul = SomaLancamentosPorMesExcetoDividendos(7, ano);
            var BCAgo = SomaLancamentosPorMesExcetoDividendos(8, ano);
            var BCSet = SomaLancamentosPorMesExcetoDividendos(9, ano);
            var BCOut = SomaLancamentosPorMesExcetoDividendos(10, ano);
            var BCNov = SomaLancamentosPorMesExcetoDividendos(11, ano);
            var BCDez = SomaLancamentosPorMesExcetoDividendos(12, ano);

            var BCano = BCJan + BCFeb + BCMar + BCAbr + BCMai + BCJun + BCJul + BCAgo + BCSet + BCOut + BCNov + BCDez;

            var Registros = new List<object>
            {
                new
                {
                    JANEIRO = BCJan,
                    FEVEREIRO = BCFeb,
                    MARÇO = BCMar,
                    ABRIL = BCAbr,
                    MAIO = BCMai,
                    JUNHO = BCJun,
                    JULHO = BCJul,
                    AGOSTO = BCAgo,
                    SETEMBRO = BCSet,
                    OUTUBRO = BCOut,
                    NOVEMBRO = BCNov,
                    DEZEMBRO = BCDez,               
                },
             };
            return Registros;
        }
        public decimal SomaLancamentosPorMesExcetoDividendos(int mes, int ano)
        {
            decimal total = _context.Lancamento
                .Where(l => l.DataPagamento.Month == mes && l.DataPagamento.Year == ano )
                .Sum(l => (l.ValorAluguel ?? 0.00M) +
                          (l.AluguelVenceslau ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));
            return total;

        }

        public IEnumerable<object> ObterDadosRelatorioTrimestral(int ano)
        {


            //Soma Todos Lancamentos feitos por Trimestre (exceto dividendos)
            var PrimeiroTrimestre = SomaLancamentosPorTrimestre(ano);
            var SegundoTrimestre = SomaLancamentosPorTrimestre(ano);
            var TerceiroTrimestre = SomaLancamentosPorTrimestre(ano);
            var QuartoTrimestre = SomaLancamentosPorTrimestre(ano);

            var Registros = new List<object>
            {
                new
                {
                    Trimestre1 = PrimeiroTrimestre,
                    Trimestre2 = SegundoTrimestre,
                    Trimestre3 = TerceiroTrimestre,
                    Trimestre4 = QuartoTrimestre,                  
                },
             };
            return Registros;
        }
        public decimal SomaLancamentosPorTrimestre(int ano)
        {
            decimal totalTrimestral = 0;

            // Agrupar os meses por trimestre
            var trimestres = new[]
            {
                new { Meses = new[] { 1, 2, 3 }, Trimestre = 1 },
                new { Meses = new[] { 4, 5, 6 }, Trimestre = 2 },
                new { Meses = new[] { 7, 8, 9 }, Trimestre = 3 },
                new { Meses = new[] { 10, 11, 12 }, Trimestre = 4 }
            };

            foreach (var trimestre in trimestres)
            {
                // Calculando a soma para o trimestre
                decimal somaTrimestre = _context.Lancamento
                    .Where(l => trimestre.Meses.Contains(l.DataPagamento.Month) && l.DataPagamento.Year == ano)
                    .Sum(l => (l.ValorAluguel ?? 0.00M) +
                              (l.AluguelVenceslau ?? 0.00M) +
                              (l.ValorFundoReserva ?? 0.00M));

                totalTrimestral += somaTrimestre; // Adiciona a soma do trimestre ao total
            }

            return totalTrimestral;
        }
    }
}

