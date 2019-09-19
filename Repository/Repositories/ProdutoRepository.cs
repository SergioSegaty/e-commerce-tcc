using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Context;
using Repository.Interface;

namespace Repository.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly StoreContext _context;

        public ProdutoRepository(StoreContext context)
        {
            _context = context;
        }

        public Produto ObterPeloId(int id)
        {
            return _context.Produtos
            .Include(x => x.Categoria)
            .Where(x => x.Id == id && x.RegistroAtivo).FirstOrDefault();
        }

        public List<Produto> ObterTodos()
        {
            return _context.Produtos
            .Include(x => x.Categoria)
            .Where(x => x.RegistroAtivo).ToList();
        }

        public List<Produto> ObterTodosPelaCategoria(int idCategoria)
        {
            return _context.Produtos
            .Include(x => x.Categoria)
            .Where(x => x.IdCategoria == idCategoria && x.RegistroAtivo).ToList();
        }
    }
}