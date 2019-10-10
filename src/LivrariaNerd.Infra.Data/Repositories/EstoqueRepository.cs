using Microsoft.EntityFrameworkCore;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Context;
using LivrariaNerd.Infra.Data.Interface;
using System.Collections.Generic;
using System.Linq;

namespace LivrariaNerd.Infra.Data.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly StoreContext _context;

        public EstoqueRepository(StoreContext context)
        {
            _context = context;
        }
        public Estoque ObterPeloId(int id)
        {
            return _context.Estoques
                .Include(x => x.Produto)
                .Where(x => x.RegistroAtivo && x.Id == id)
                .FirstOrDefault();
        }

        public List<Estoque> ObterTodosPeloProduto(int idProduto)
        {
            return _context.Estoques
                .Include(x => x.Produto)
                .Where(x => x.RegistroAtivo && x.IdProduto == idProduto)
                .ToList();
        }

        public int ObterPeloProduto(int id)
        {
            var estoque = _context.Estoques
                .Where(x => x.RegistroAtivo && x.IdProduto == id)
                .FirstOrDefault();

            return estoque.Id;
        }

        public List<Estoque> ObterTodos(string status)
        {
            var query =  _context.Estoques
                .Include(x => x.Produto)
                .Where(x => x.RegistroAtivo)
                .AsQueryable();


            if (status != "*")
            {
                query = query.Where(x => x.Status == status);
            }

            return query.ToList();
        }   
    }
}
