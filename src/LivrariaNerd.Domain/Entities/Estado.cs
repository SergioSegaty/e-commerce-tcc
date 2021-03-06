using System.ComponentModel.DataAnnotations.Schema;

namespace LivrariaNerd.Domain.Entities
{
    [Table("estados")]
    public class Estado : Base
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("sigla")]
        public string Sigla { get; set; }
    }
}