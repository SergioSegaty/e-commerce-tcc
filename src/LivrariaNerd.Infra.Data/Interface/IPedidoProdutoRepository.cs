using LivrariaNerd.Domain.Entities;
using System.Collections.Generic;

namespace LivrariaNerd.Infra.Data.Interface
{
    public interface IPedidoProdutoRepository
    {
        PedidoProduto ObterPeloId(int id);

        List<PedidoProduto> ObterTodosPeloPedido(int idPedido);

        List<PedidoProduto> ObterTodosPeloProduto(int idProduto);

        List<PedidoProduto> ObterTodosPeloIdUsuario(int idUsuario);
    }
}