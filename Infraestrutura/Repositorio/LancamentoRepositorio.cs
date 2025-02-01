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

       
        public decimal CalcularIRPJTrimestre(int ano, int trimestre)
        {
            decimal valorA = ObterRendimentoTrimestral(ano, trimestre) * 0.32m;

            // Soma os valores de "OutrosRecebimentos" e "GanhoDeCapital" ao valorA
            valorA += ObterOutrosRecebimentosEGanhoDeCapital(ano, trimestre);

            decimal valorB = valorA * 0.15m;
            decimal valorC = valorA > 20000 ? valorA - 60000 : 0;
            decimal valorD = valorC > 0 ? valorC * 0.10m : 0;
            decimal valorE = valorB + valorD;

            // Subtrai o valor retido na fonte
            valorE -= ObterValorRetidoNaFonte(ano, trimestre);

            return valorE > 0 ? valorE : 0; // Evita valores negativos
        }
        public decimal ObterRendimentoTrimestral(int ano, int trimestre)
        {
            decimal totalTrimestral = 0;

            // Determinar os meses correspondentes ao trimestre
            int mesInicial = (trimestre - 1) * 3 + 1; // Exemplo: 1° trimestre → mês 1, 2° trimestre → mês 4, etc.
            int mesFinal = mesInicial + 2; // Cada trimestre tem 3 meses

            totalTrimestral = _context.Lancamento
                .Where(l => l.DataPagamento.Month >= mesInicial && l.DataPagamento.Month <= mesFinal && l.DataPagamento.Year == ano)
                .Sum(l => (l.ValorAluguel ?? 0.00M) +
                          (l.AluguelVenceslau ?? 0.00M) +
                          (l.ValorFundoReserva ?? 0.00M));

            return totalTrimestral;
        }
        public decimal ObterOutrosRecebimentosEGanhoDeCapital(int ano, int trimestre)
        {
            decimal totalTrimestral = 0;

            int mesInicial = (trimestre - 1) * 3 + 1;
            int mesFinal = mesInicial + 2; 

            totalTrimestral = _context.Lancamento
                .Where(l => l.DataPagamento.Month >= mesInicial && l.DataPagamento.Month <= mesFinal && l.DataPagamento.Year == ano)
                .Sum(l => (l.OutrosRecebimentos ?? 0.00M) +
                          (l.GanhoDeCapital ?? 0.00M));

            return totalTrimestral;
        }
        public decimal ObterValorRetidoNaFonte(int ano, int trimestre)
        {
            decimal totalTrimestral = 0;

            int mesInicial = (trimestre - 1) * 3 + 1;
            int mesFinal = mesInicial + 2;

            totalTrimestral = _context.Lancamento
                .Where(l => l.DataPagamento.Month >= mesInicial && l.DataPagamento.Month <= mesFinal && l.DataPagamento.Year == ano)
                .Sum(l => (l.ValorRetidoNaFonte ?? 0.00M));

            return totalTrimestral;
        }


    }
}

