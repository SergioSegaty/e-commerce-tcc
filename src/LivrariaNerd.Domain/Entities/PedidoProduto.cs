using System.ComponentModel.DataAnnotations.Schema;

namespace LivrariaNerd.Domain.Entities
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

        [Column("preco_unidade", TypeName = ("decimal(18,2)"))]
        public decimal PrecoUnidade { get; set; }

        [Column("preco_total", TypeName = ("decimal(18,2)"))]
        public decimal PrecoTotal { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }
    }
}