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
            Lancamentos = new HashSet<Lancamento>();
            Ocorrencias = new HashSet<Ocorrencia>();
        }

        public int id { get; set; }
        public int TipoCadastro { get; set; }// 1=Pool / 2-Plataforma

        public String Descricao { get; set; } = String.Empty;
        public int? Unidade { get; set; }
        public String TipoUnidade { get; set; }
        public String TipoInvestimento { get; set; } = String.Empty;
        public String Status { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAquisicao { get; set; }

        public String Cep { get; set; }
        public string Rua { get; set; } = String.Empty;
        public String Numero { get; set; }
        public string? Bairro { get; set; } = String.Empty;
        public string Estado { get; set; } = String.Empty;
        public string Cidade { get; set; } = String.Empty;

        public int NumMatriculaImovel { get; set; }
        public String NumUCEnergia { get; set; }
        public String NumCadastroPrefeitura { get; set; }
        public Decimal TamanhoUnM2 { get; set; }
        public bool PossuiGaragem { get; set; }
        public bool Escriturado { get; set; }
        public bool Registrado { get; set; }
        public Decimal valorComissao { get; set; }
        public bool NotaComissao { get; set; }

        public Decimal ValorEscritura { get; set; }
        public Decimal ValorITBI { get; set; }
        public bool Laudemio { get; set; }
        public Decimal ValorLaudemio { get; set; }
        public Decimal ValorAforamento { get; set; }
        public Decimal ValorRegistro { get; set; }
        public Decimal ValorDeCompra { get; set; }

        public String MesReajusteAluguel { get; set; }
        public String? IPTU { get; set; }
        public Decimal ValorTotalImovel { get; set; }
        public int? idEmpresa { get; set; }
        public virtual Empresa? Empresa { get; set; }

        public virtual ICollection<Lancamento> Lancamentos { get; set; }
        public virtual ICollection<Ocorrencia> Ocorrencias { get; set; }

    }
}
