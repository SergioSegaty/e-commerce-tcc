using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Context;
using LivrariaNerd.Infra.Data.Interface;

namespace LivrariaNerd.Infra.Data.Repositories
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

        public List<Produto> ObterTodos(string busca)
        {
            if (busca == null) busca = "";


            return _context.Produtos
            .Include(x => x.Categoria)
            .OrderByDescending(x => x.Categoria.Nome)
            .Where(x => x.RegistroAtivo && x.Nome.ToUpper().Contains(busca) || x.Categoria.Nome.ToUpper().Contains(busca))
            .ToList();
        }

        public List<Produto> ObterTodosBusca(string busca)
        {
            return _context.Produtos
                .Include(x => x.Categoria)
                .OrderBy(x => x.Nome)
                .Where(x => x.RegistroAtivo && x.Nome.Contains(busca))
                .ToList();
        }

        public List<Produto> ObterTodosBuscaECategoria(string busca, int idCategoria)
        {
            return _context.Produtos
               .Include(x => x.Categoria)
               .OrderBy(x => x.Nome)
               .Where(x => x.RegistroAtivo && x.Nome.Contains(busca) && x.IdCategoria == idCategoria)
               .ToList();
        }

        public List<Produto> ObterTodosPelaCategoria(int idCategoria)
        {
            return _context.Produtos
            .Include(x => x.Categoria)
            .Where(x => x.IdCategoria == idCategoria && x.RegistroAtivo).ToList();
        }
    }
}