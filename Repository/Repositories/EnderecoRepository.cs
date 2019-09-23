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
