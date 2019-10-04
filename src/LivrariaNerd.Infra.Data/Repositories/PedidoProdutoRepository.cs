using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Context;
using LivrariaNerd.Infra.Data.Interface;

namespace LivrariaNerd.Infra.Data.Repositories
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
            .AsNoTracking()
            .FirstOrDefault();
        }

        public List<PedidoProduto> ObterTodosPeloPedido(int idPedido)
        {
            return _context.PedidoProdutos
            .Include(x => x.Pedido)
            .Include(x => x.Produto)
            .Where(x => x.RegistroAtivo && x.IdPedido == idPedido)
             .AsNoTracking()
            .ToList();
        }

        public List<PedidoProduto> ObterTodosPeloProduto(int idProduto)
        {
            return _context.PedidoProdutos
            .Include(x => x.Pedido)
            .Include(x => x.Produto)
            .Where(x => x.RegistroAtivo && x.IdProduto == idProduto)
             .AsNoTracking()
            .ToList();
        }

        public List<PedidoProduto> ObterTodosPeloIdUsuario(int idUsuario)
        {
            return _context.PedidoProdutos
                .Include(x => x.Pedido)
                .Include(x => x.Produto)
                .Where(x => x.RegistroAtivo && x.Pedido.IdUsuario == idUsuario)
                 .AsNoTracking()
                .ToList();
        }

        public List<PedidoProduto> ObterTudo()
        {
            return _context.PedidoProdutos
                .Include(x => x.Pedido)
                .Include(x => x.Produto)
                .Include(x => x.Pedido.Usuario)
                .Where(x => x.RegistroAtivo)
                .OrderBy(x => x.Pedido.DataCriacao)
                .AsNoTracking()
                .ToList();
        }
    }
}