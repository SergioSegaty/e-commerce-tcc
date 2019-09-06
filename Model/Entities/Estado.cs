using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("estados")]
    public class Estado : Base
    {
        [Column("nome"), StringLength(100, ErrorMessage = "No maximo 2 caracteres.", MinimumLength = 3)]
        public string Nome { get; set; }

        [Column("sigla"), StringLength(2, ErrorMessage = "No maximo 2 caracteres.")]
        public string Sigla { get; set; }
    }
}