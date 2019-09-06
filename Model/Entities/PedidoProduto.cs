using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entities
{
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
