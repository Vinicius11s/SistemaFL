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

        public IEnumerable<object> ObterDadosRelatorioAnual(string ano)
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

            var PISano = CalcularPIS_Anual(BCano);           
            var COFano = CalculaCOFINS_Anual(BCano);

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

                    PIS = PISano,
                    COFINS = COFano,
               
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
        public decimal CalcularPIS_Anual(decimal BC)
        {
            if (BC != 0)
            {
                decimal resultado = BC * 0.0065M;
                return Math.Round(resultado, 2);
            }
            else return 0;
        }
        public decimal CalculaCOFINS_Anual(decimal BC)
        {
            if (BC != 0)
            {
                decimal resultado = BC * 0.03M;
                return Math.Round(resultado, 2);
            }
            else return 0;
        }
    }
}

