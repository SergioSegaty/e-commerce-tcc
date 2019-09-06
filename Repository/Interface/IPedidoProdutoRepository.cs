using System.Collections.Generic;
using Model.Entities;

namespace Repository.Interface
{
    public interface IPedidoProdutoRepository
    {
        PedidoProduto ObterPeloId(int id);

        List<PedidoProduto> ObterTodosPeloPedido(int idPedido);

        List<PedidoProduto> ObterTodosPeloProduto(int idProduto);
    }
}