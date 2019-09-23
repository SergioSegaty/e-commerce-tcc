using Microsoft.EntityFrameworkCore;
using PadawanStore.Domain.Entities;
using PadawanStore.Infra.Data.Context;
using PadawanStore.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PadawanStore.Infra.Data.Repositories
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
