namespace Model.Entities
{ 
    public class PedidoProduto : Base
    {
        public Produto Produto { get; set; }
        
        public int IdProduto { get; set; }
        
        public Pedido Pedido { get; set; }
        
        public int IdPedido { get; set; }
    }
}
