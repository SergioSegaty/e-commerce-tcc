using System.ComponentModel.DataAnnotations.Schema;

namespace PadawanStore.Domain.Entities
{
    [Table("cidades")]
    public class Cidade : Base
    {
        [Column("id_estado")]
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; private set; }

        [Column("nome")]
        public string Nome { get; set; }
    }
}
