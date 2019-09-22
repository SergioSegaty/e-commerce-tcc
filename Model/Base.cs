using System;

namespace Model
{
    public class Base
    {
        public int Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataUltimaAtualizacao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public bool RegistroAtivo { get; set; }
    }
}