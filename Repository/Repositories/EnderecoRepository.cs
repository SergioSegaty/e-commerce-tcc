using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly SistemaContext _context;

        public EnderecoRepository(SistemaContext context)
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
