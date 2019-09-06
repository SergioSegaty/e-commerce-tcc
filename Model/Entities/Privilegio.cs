using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("privilegios")]
    public class Privilegio : Base
    {
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Column("admin")]
        public int Admin { get; set; }
    }
}