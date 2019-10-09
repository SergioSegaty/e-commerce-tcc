using Microsoft.EntityFrameworkCore;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Context;
using LivrariaNerd.Infra.Data.Interface;
using System.Collections.Generic;
using System.Linq;

namespace LivrariaNerd.Infra.Data.Repositories
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

        public List<Cidade> ObterTodos(string busca)
        {
            return _context
                .Cidades
                .Include(x => x.Estado)
                .Where(x => x.RegistroAtivo && x.Nome.ToUpper().Contains(busca.ToUpper()) || x.Estado.Sigla.ToUpper().Contains(busca) || x.Estado.Nome.ToUpper().Contains(busca))
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
