using Entidades;
using Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class FiscalRepositorio : BaseRepositorio<Fiscal>, IFiscalRepositorio
    {     
        private readonly ContextoSistema _context;
        public FiscalRepositorio(ContextoSistema contexto) : base(contexto)
        {
            _context = contexto;
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