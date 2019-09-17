using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("categorias")]
    public class Categoria : Base
    {
        [Column("nome"), StringLength(100, ErrorMessage = "No maximo 100 caracteres", MinimumLength = 3)]
        public string Nome { get; set; }
    }
}