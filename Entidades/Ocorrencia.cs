﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ocorrencia
    {
        public Ocorrencia()
        {}

        public int id { get; set; }
        public Decimal? oco_valorAntigo { get; set; }
        public Decimal? oco_valorAlteracao { get; set; }
        public DateTime? oco_DataLancamentoAntigo { get; set; }
        public DateTime oco_DataAlteracao { get; set; }
        public String? oco_Tabela { get; set; }
        public String? oco_Descricao { get; set; }

        public int idLancamento { get; set; }
        public Lancamento? Lancamento { get; set; }

        public int? idOutrosLancamentos { get; set; }
        public OutrosLancamentos? OutrosLancamentos { get; set; }

        public int idFlat { get; set; }
        public Flat? Flat { get; set; }
        public string? DescricaoFlat { get; set; }

        public int? idUsuario { get; set; }
        public Usuario? Usuario{ get; set; }
        public string? DescricaoUsuario{ get; set; }



    }
}
