using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public static class SeederSistemContext
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(

                new Categoria()
                {
                    Id = 1,
                    Nome = "Eletrônicos",
                    DataCriacao = DateTime.Now,
                    RegistroAtivo = true
                },
                new Categoria()
                {
                    Id = 2,
                    Nome = "Jogos de Tabuleiro",
                    DataCriacao = DateTime.Now,
                    RegistroAtivo = true
                }
            );

        }

    }
}
