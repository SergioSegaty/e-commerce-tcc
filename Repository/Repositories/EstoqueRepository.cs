using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly SistemaContext _context;

        public EstoqueRepository(SistemaContext context)
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
    }
}
