using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Context;
using Repository.Interface;

namespace Repository.Repositories
{
    public class PedidoProdutoRepository : IPedidoProdutoRepository
    {
        private readonly StoreContext _context;

        public PedidoProdutoRepository(StoreContext context)
        {
            _context = context;
        }

        public PedidoProduto ObterPeloId(int id)
        {
            return _context.PedidoProdutos
            .Include(x => x.Pedido)
            .Include(x => x.Produto)
            .Where(x => x.RegistroAtivo && x.Id == id)
            .FirstOrDefault();
        }

        public List<PedidoProduto> ObterTodosPeloPedido(int idPedido)
        {
            return _context.PedidoProdutos
            .Include(x => x.Pedido)
            .Include(x => x.Produto)
            .Where(x => x.RegistroAtivo && x.IdPedido == idPedido)
            .ToList();
        }

        public List<PedidoProduto> ObterTodosPeloProduto(int idProduto)
        {
            return _context.PedidoProdutos
            .Include(x => x.Pedido)
            .Include(x => x.Produto)
            .Where(x => x.RegistroAtivo && x.IdProduto == idProduto)
            .ToList();
        }
    }
}