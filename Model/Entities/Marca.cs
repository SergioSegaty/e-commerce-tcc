using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("marcas")]
    public class Marca : Base
    {
        [Column("nome")]
        public string Nome { get; set; }
    }
}
