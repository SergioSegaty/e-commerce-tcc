using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PadawanStore.Domain.Entities;
using PadawanStore.Domain.Identity;

namespace PadawanStore.Infra.Data.Context
{
    public class StoreContext : IdentityDbContext<
        Usuario,
        Privilegio,
        int>
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioPrivilegio>(userRole =>
                {
                    userRole.HasKey(ur => new { ur.IdUsuario, ur.IdPrivilegio });

                    userRole.HasOne(ur => ur.Privilegio)
                    .WithMany(r => r.UsuarioPrivilegios)
                    .HasForeignKey(ur => ur.IdPrivilegio)
                    .IsRequired();

                    userRole.HasOne(ur => ur.Usuario)
                    .WithMany(r => r.UsuarioPrivilegios)
                    .HasForeignKey(ur => ur.IdUsuario)
                    .IsRequired();
                }
            );


        }
    }
}