using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
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

        public List<Estoque> ObterTodos()
        {
            return _context.Estoques
                .Include(x => x.Produto)
                .Where(x => x.RegistroAtivo)
                .ToList();
        }
    }
}
