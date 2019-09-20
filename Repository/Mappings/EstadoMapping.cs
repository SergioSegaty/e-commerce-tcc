using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace PadawanStore.Infra.Data.Mappings
{
    public class EstadoMapping : BaseConfiguration<Estado>
    {
        public override void Configure(EntityTypeBuilder<Estado> builder)
        {
            base.Configure(builder);

            builder.ToTable("estados");

            builder.Property(e => e.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(19)")
                .HasMaxLength(19)
                .IsRequired();

            builder.Property(e => e.Sigla)
                .HasColumnName("sigla")
                .HasColumnType("varchar(2)")
                .HasMaxLength(2)
                .IsRequired();

            builder.HasData
            (
                new Estado
                {
                    Id = 1,
                    DataCriacao = DateTime.Now,
                    Nome = "Santa Catarina",
                    Sigla = "SC"
                }
            );
        }
    }
}
