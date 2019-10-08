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

            #region Seed Usuario
            modelBuilder.Entity<Usuario>().HasData(
               new Usuario
               {
                   Id = 1,
                   NomeCompleto = "Guilherme",
                   Login = "guilherme",
                   Senha = "123",
                   RegistroAtivo = true,
                   DataCriacao = DateTime.Now
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
            #endregion

            #region Seed Estado
            modelBuilder.Entity<Estado>().HasData(
                new Estado
                {
                    Id = 1,
                    Nome = "Santa Catarina",
                    Sigla = "SC",
                    RegistroAtivo = true,
                    DataCriacao = DateTime.Now
                },
                new Estado
                {
                    Id = 2  ,
                    Nome = "São Paulo",
                    Sigla = "SP",
                    RegistroAtivo = true,
                    DataCriacao = DateTime.Now
                },
                new Estado
                {
                    Id = 3,
                    Nome = "Rio Grande Do Sul",
                    Sigla = "RS",
                    RegistroAtivo = true,
                    DataCriacao = DateTime.Now
                }
            );
            #endregion

            #region Seed Cidade
            modelBuilder.Entity<Cidade>().HasData(
                new Cidade
                {
                    Id = 1,
                    IdEstado = 1,
                    Nome = "Blumenau",
                    RegistroAtivo = true,
                    DataCriacao = DateTime.Now
                },
                new Cidade
                {
                    Id = 2,
                    IdEstado = 1,
                    Nome = "Florianópolis",
                    RegistroAtivo = true,
                    DataCriacao = DateTime.Now
                },
                new Cidade
                {
                    Id = 3,
                    IdEstado = 2,
                    Nome = "São Paulo",
                    RegistroAtivo = true,
                },
                new Cidade
                {
                    Id = 4,
                    IdEstado = 2,
                    Nome = "Osasco",
                    RegistroAtivo = true,
                    DataCriacao = DateTime.Now
                },
                new Cidade
                {
                    Id = 5,
                    IdEstado = 3,
                    Nome = "Porto Alegre",
                    RegistroAtivo = true,
                    DataCriacao = DateTime.Now
                },
                new Cidade
                {
                    Id = 6,
                    IdEstado = 3,
                    Nome = "Gramado",
                    RegistroAtivo = true,
                    DataCriacao = DateTime.Now
                }
            );
            #endregion

            #region Seed Categoria
            modelBuilder.Entity<Categoria>().HasData(

                new Categoria
                {
                    Id = 1,
                    DataCriacao = DateTime.Now,
                    RegistroAtivo = true,
                    Nome = "Action Figure"
                },
                new Categoria
                {
                    Id = 2,
                    DataCriacao = DateTime.Now,
                    RegistroAtivo = true,
                    Nome = "Livros"
                }
            );
            #endregion

            #region Seed Produto
            modelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                    Id = 1,
                    DataCriacao = DateTime.Now,
                    Nome = "Geralt de Rivia",
                    IdCategoria = 1,
                    Descricao = "descricao top",
                    RegistroAtivo = true,
                    Preco = 1500,
                    ImagemCaminhoWwwroot = "/img/witcher_action_figure.jpg",
                    Cor = "Preto",
                    Peso = 1,
                },
                new Produto
                {
                    Id = 2,
                    DataCriacao = DateTime.Now,
                    Nome = "Batman",
                    IdCategoria = 1,
                    Descricao = "descricao top",
                    RegistroAtivo = true,
                    Preco = 2300,
                    ImagemCaminhoWwwroot = "/img/Produtos/Batman-Arkham-Knight.png",
                    Cor = "Preto",
                    Peso = 1,
                },
                new Produto
                {
                    Id = 3,
                    DataCriacao = DateTime.Now,
                    Nome = "Poison Ivy",
                    IdCategoria = 1,
                    Descricao = "descricao top",
                    RegistroAtivo = true,
                    Preco = 1500,
                    ImagemCaminhoWwwroot = "/img/Produtos/Poison-Ivy.png",
                    Cor = "Preto",
                    Peso = 1,
                },
                new Produto
                {
                    Id = 4,
                    DataCriacao = DateTime.Now,
                    Nome = "Nier Automata",
                    IdCategoria = 1,
                    Descricao = "descricao top",
                    RegistroAtivo = true,
                    Preco = 1500,
                    ImagemCaminhoWwwroot = "/img/Produtos/Nier-Automata.png",
                    Cor = "Preto",
                    Peso = 1,
                }
            );
            #endregion

            #region Seed Pedido
            modelBuilder.Entity<Pedido>().HasData(
                new Pedido
                {
                    Id = 1,
                    DataCriacao = DateTime.Now,
                    RegistroAtivo = true,
                    IdUsuario = 1,
                    PrecoTotal = 5250,
                    StatusDoPedido = "PAGO",
                },
                new Pedido
                {
                    Id = 2,
                    DataCriacao = DateTime.Now,
                    RegistroAtivo = true,
                    IdUsuario = 1,
                    PrecoTotal = 5250,
                    StatusDoPedido = "PAGO"
                }, 
                new Pedido
                {
                    Id = 3,
                    DataCriacao = DateTime.Now,
                    RegistroAtivo = true,
                    IdUsuario = 1,
                    PrecoTotal = 5000,
                    StatusDoPedido = "PENDENTE"
                }
            );
            #endregion

            #region PedidoProduto
            modelBuilder.Entity<PedidoProduto>().HasData(
                new PedidoProduto
                {
                    Id = 1,
                    IdPedido = 1,
                    IdProduto = 1,
                    DataCriacao = DateTime.Now,
                    PrecoTotal = 5000,
                    Quantidade = 5,
                    RegistroAtivo = true,
                }
            );
            #endregion

            #region Seed Estoque
            modelBuilder.Entity<Estoque>().HasData(
                new Estoque
                {
                    Id = 1,
                    DataCriacao = DateTime.Now,
                    IdProduto = 1,
                    Quantidade = 1,
                    RegistroAtivo = true,
                    Status = "Em Estoque",
                },
                new Estoque
                {
                    Id = 2,
                    DataCriacao = DateTime.Now,
                    IdProduto = 2,
                    Quantidade = 1,
                    RegistroAtivo = true,
                    Status = "Em Estoque",
                },
                new Estoque
                {
                    Id = 3,
                    DataCriacao = DateTime.Now,
                    IdProduto = 3,
                    Quantidade = 1,
                    RegistroAtivo = true,
                    Status = "Em Estoque",
                }, new Estoque
                {
                    Id = 4,
                    DataCriacao = DateTime.Now,
                    IdProduto = 4,
                    Quantidade = 1,
                    RegistroAtivo = true,
                    Status = "Em Estoque",
                }
            );
            #endregion

        }



    }
}