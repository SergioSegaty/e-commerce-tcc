using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Interface;

namespace Repository.Repositories
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : Base
    {
        private readonly SistemaContext _context;

        public BaseRepositoryAsync(SistemaContext context)
        {
            _context = context;
        }

        public async Task<int> Adicionar(T entity)
        {
            entity.RegistroAtivo = true;
            entity.DataUltimaAtualizacao = DateTime.Now;
            entity.DataCriacao = DateTime.Now;
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public bool Alterar(T entity)
        {
            entity.RegistroAtivo = true;
            entity.DataUltimaAtualizacao = DateTime.Now;
            _context.Set<T>().Update(entity);
            return _context.SaveChanges() == 1;
        }

        public bool Apagar(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            entity.RegistroAtivo = false;
            entity.DataExclusao = DateTime.Now;
            _context.Set<T>().Update(entity);
            return _context.SaveChanges() == 1;
        }

        public T ObterPeloId(int id)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id && x.RegistroAtivo == true);
        }

        public List<T> ObterTodos()
        {
            return _context.Set<T>().AsNoTracking().Where(x => x.RegistroAtivo == true).ToList();
        }
    }
}