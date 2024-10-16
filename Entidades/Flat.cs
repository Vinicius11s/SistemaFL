using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Flat
    {

        public Flat()
        {
            this.Lancamentos = new HashSet<Lancamento>();
            this.Ocorrencias = new HashSet<Ocorrencia>();
            Empresa = new Empresa();
        }

        public int id { get; set; }
        public DateTime DataAquisicao { get; set; }
        public String Descricao { get; set; } = String.Empty;
        public String TipoInvestimento { get; set; } = String.Empty;
        public string Rua { get; set; } = String.Empty;
        public string NumeroAp { get; set; } = String.Empty;
        public string Bairro { get; set; } = String.Empty;
        public string Cidade { get; set; } = String.Empty;
        public Decimal ValorInvestimento { get; set; }
        public bool Status { get; set; }

        public int idEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Lancamento> Lancamentos { get; set; }
        public virtual ICollection<Ocorrencia> Ocorrencias { get; set; } 

    }
}
