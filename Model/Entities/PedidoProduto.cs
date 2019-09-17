using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("pedidos_produtos")]
    public class PedidoProduto : Base
    {
        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }

        [Column("id_produto")]
        public int IdProduto { get; set; }

        [ForeignKey("IdPedido")]
        public Pedido Pedido { get; set; }

        [Column("id_pedido")]
        public int IdPedido { get; set; }
    }
}
