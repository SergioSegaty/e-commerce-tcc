using Microsoft.EntityFrameworkCore;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Domain.Identity;

namespace LivrariaNerd.Infra.Data.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasData(
               new Usuario
               {
                   Id = 1,
                   NomeCompleto = "Guilherme",
                   Login = "guilherme",
                   Senha = "123",
                   RegistroAtivo = true,
               }
            );

            modelBuilder.Entity<Estado>().HasData(
                new Estado
                {
                    Id = 1,
                    Nome = "Santa Catarina",
                    Sigla = "SC",
                    RegistroAtivo = true,
                }
            );

            modelBuilder.Entity<Cidade>().HasData(

                new Cidade
                {
                    Id = 1,
                    IdEstado = 1,
                    Nome = "Blumenau",
                    RegistroAtivo = true,
                }
            );

        }



    }
}