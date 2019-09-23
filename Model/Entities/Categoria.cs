using System.ComponentModel.DataAnnotations.Schema;

namespace PadawanStore.Domain.Entities
{
    [Table("categorias")]
    public class Categoria : Base
    {
        [Column("nome")]
        public string Nome { get; set; }
    }
}