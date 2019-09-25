using Microsoft.EntityFrameworkCore;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Context;
using LivrariaNerd.Infra.Data.Interface;
using System.Collections.Generic;
using System.Linq;

namespace LivrariaNerd.Infra.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly StoreContext _context;

        public EnderecoRepository(StoreContext context)
        {
            _context = context;
        }

        public Endereco ObterPeloId(int id)
        {
            return _context.Enderecos
                .Include(x => x.Cidade)
                .Include(x => x.Usuario)
                .Where(x => x.RegistroAtivo && x.Id == id)
                .FirstOrDefault();
        }

        public List<Endereco> ObterTodosPelaCidade(int idCidade)
        {
            return _context.Enderecos
                .Include(x => x.Cidade)
                .Include(x => x.Usuario)
                .Where(x => x.RegistroAtivo && x.Id == idCidade)
                .ToList();
        }

        public List<Endereco> ObterTodosPeloUsuario(int idUsuario)
        {
            return _context.Enderecos
                .Include(x => x.Cidade)
                .Include(x => x.Usuario)
                .Where(x => x.RegistroAtivo && x.Id == idUsuario)
                .ToList();
        }
    }
}
