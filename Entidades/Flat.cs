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
        }

        public int id { get; set; }
        public DateTime DataAquisicao { get; set; }
        public String Descricao { get; set; } = String.Empty;
        public int Unidade { get; set; }
        public int TipoInvestimento { get; set; }
        public String Cidade { get; set; } = String.Empty;
        public String Endereco { get; set; } = String.Empty;
        public Decimal ValorInvestimento { get; set; }
        public bool Status { get; set; }

        public int idEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }
        // Relacionamento com Lancamentos
        public virtual ICollection<Lancamento> Lancamentos { get; set; } // Adiciona a coleção de Lancamentos

        // Relacionamento com Ocorrencias
        public virtual ICollection<Ocorrencia> Ocorrencias { get; set; } // Coleção para Ocorrencias

    }
}
