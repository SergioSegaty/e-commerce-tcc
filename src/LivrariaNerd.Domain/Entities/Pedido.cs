using LivrariaNerd.Domain.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivrariaNerd.Domain.Entities
{
    [Table("pedidos")]
    public class Pedido : Base
    {
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Column("preco_total", TypeName = ("decimal(18,2)"))]
        public decimal PrecoTotal { get; set; }

        [Column("status_pedido")]
        public string StatusDoPedido { get; set; }
    }
}