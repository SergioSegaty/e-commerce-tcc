using System.ComponentModel.DataAnnotations.Schema;

namespace PadawanStore.Domain.Entities
{
    [Table("marcas")]
    public class Marca : Base
    {
        [Column("nomes")]
        public string Nome { get; set; }
    }
}
