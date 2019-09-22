using System.Collections.Generic;

namespace Model.Entities
{
    public class Pedido : Base
    {
        public Usuario Usuario { get; set; }
        
        public int IdUsuario { get; set; }

        public ICollection<PedidoProduto> PedidoProduto { get; set; }
    }
}