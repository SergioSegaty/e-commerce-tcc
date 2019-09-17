using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("cidades")]
    public class Cidade : Base
    {
        [Column("id_estado")]
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }

        [Column("nome"), StringLength(100, ErrorMessage = "No maximo 100 caracteres.", MinimumLength = 3)]
        public string Nome { get; set; }
    }
}
