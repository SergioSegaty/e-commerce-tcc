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
    public class CidadeRepository : ICidadeRepository
    {
        private readonly StoreContext _context;

        public CidadeRepository(StoreContext context)
        {
            this._context = context;
        }

        public Cidade ObterPeloId(int id)
        {
            return _context
                .Cidades
                .Include(x => x.Estado)
                .FirstOrDefault(x => x.RegistroAtivo && x.Id == id);
        }

        public List<Cidade> ObterTodos()
        {
            return _context
                .Cidades
                .Include(x => x.Estado)
                .Where(x => x.RegistroAtivo)
                .ToList();
        }

        public List<Cidade> ObterTodosPeloEstado(int idEstado)
        {
            return _context
                .Cidades
                .Include(x => x.Estado)
                .Where(x => x.RegistroAtivo && x.IdEstado == idEstado)
                .ToList();
        }
    }
}
