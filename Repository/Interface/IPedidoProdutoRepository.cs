using PadawanStore.Domain.Entities;
using System.Collections.Generic;

namespace PadawanStore.Infra.Data.Interface
{
    public interface IPedidoProdutoRepository
    {
        PedidoProduto ObterPeloId(int id);

        List<PedidoProduto> ObterTodosPeloPedido(int idPedido);

        List<PedidoProduto> ObterTodosPeloProduto(int idProduto);
    }
}