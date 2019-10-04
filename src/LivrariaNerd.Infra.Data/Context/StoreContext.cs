using Microsoft.EntityFrameworkCore;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Domain.Identity;
using System;

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

            //Seed Usuario
            modelBuilder.Entity<Usuario>().HasData(
               new Usuario
               {
                   Id = 1,
                   NomeCompleto = "Guilherme",
                   Login = "guilherme",
                   Senha = "123",
                   RegistroAtivo = true,
               },
               new Usuario
               {
                   Id = 2,
                   NomeCompleto = "Pedro",
                   Login = "pedro",
                   Senha = "123",
                   RegistroAtivo = true,
                   DataCriacao = DateTime.Now
               }
             );

            //Seed Estado
            modelBuilder.Entity<Estado>().HasData(
                new Estado
                {
                    Id = 1,
                    Nome = "Santa Catarina",
                    Sigla = "SC",
                    RegistroAtivo = true,
                }
            );

            //Seed Cidade
            modelBuilder.Entity<Cidade>().HasData(

                new Cidade
                {
                    Id = 1,
                    IdEstado = 1,
                    Nome = "Blumenau",
                    RegistroAtivo = true,
                }
            );

            //Seed Categoria
            modelBuilder.Entity<Categoria>().HasData(

                new Categoria
                {
                    Id = 1,
                    DataCriacao = DateTime.Now,
                    RegistroAtivo = true,
                    Nome = "Tech"
                }
            );

            //Seed Produto
            modelBuilder.Entity<Produto>().HasData(

                new Produto
                {
                    Id = 1,
                    DataCriacao = DateTime.Now,
                    Nome = "Salazar Boneco",
                    IdCategoria = 1,
                    Descricao = "descricao top",
                    RegistroAtivo = true,
                    Preco = 1500,
                    ImagemCaminhoWwwroot = "/img/witcher_action_figure.jpg",
                    Cor = "Preto",
                    Peso = 1,
                }
            );

            //Seed Pedido
            modelBuilder.Entity<Pedido>().HasData(

                new Pedido
                {
                    Id = 1,
                    DataCriacao = DateTime.Now,
                    RegistroAtivo = true,
                    IdUsuario = 1,
                    PrecoTotal = 5250,
                    StatusDoPedido = "PAGO"
                },
                new Pedido
                {
                    Id = 2,
                    DataCriacao = DateTime.Now,
                    RegistroAtivo = true,
                    IdUsuario = 1,
                    PrecoTotal = 5250,
                    StatusDoPedido = "PAGO"
                }, new Pedido
                {
                    Id = 3,
                    DataCriacao = DateTime.Now,
                    RegistroAtivo = true,
                    IdUsuario = 1,
                    PrecoTotal = 5000,
                    StatusDoPedido = "PENDENTE"
                }
            );

            //Seed PedidoProduto
            modelBuilder.Entity<PedidoProduto>().HasData(
                new PedidoProduto
                {
                    Id = 1,
                    IdPedido = 1,
                    IdProduto = 1,
                    DataCriacao = DateTime.Now,
                    PrecoTotal = 5000,
                    Quantidade = 5,
                    RegistroAtivo = true
                }
            );

        }



    }
}