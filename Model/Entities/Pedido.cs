using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities;

namespace Model.Entities
{
    [Table("pedidos")]
    public class Pedido : Base
    {
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Column("id_usuario")]
        public int IdUsuario { get; set; }
    }
}