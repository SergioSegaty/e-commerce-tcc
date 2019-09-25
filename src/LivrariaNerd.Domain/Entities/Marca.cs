using System.ComponentModel.DataAnnotations.Schema;

namespace LivrariaNerd.Domain.Entities
{
    [Table("marcas")]
    public class Marca : Base
    {
        [Column("nomes")]
        public string Nome { get; set; }
    }
}
