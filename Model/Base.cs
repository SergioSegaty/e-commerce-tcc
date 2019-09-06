using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
      public class Base
      {
            [Key, Column("id")]
            public int Id { get; set; }

            [Column("data_criacao")]
            public DateTime DataCriacao { get; set; }

            [Column("data_ultima_atualizacao")]
            public DateTime DataUltimaAtualizacao { get; set; }

            [Column("data_exclusao")]
            public DateTime? DataExclusao { get; set; }

            [Column("registro_ativo")]
            public bool RegistroAtivo { get; set; }
      }
}