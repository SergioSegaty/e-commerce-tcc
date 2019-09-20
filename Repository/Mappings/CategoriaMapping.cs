using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace PadawanStore.Infra.Data.Mappings
{
    public class CategoriaMapping : BaseConfiguration<Categoria>
    {
        public override void Configure(EntityTypeBuilder<Categoria> builder)
        {
            base.Configure(builder);

            builder.ToTable("categorias");

            builder.Property(e => e.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData
            (
                new Categoria
                {
                    Id = 1,
                    Nome = "Eletronicos",
                    DataCriacao = DateTime.Now
                }
            );
        }
    }
}
