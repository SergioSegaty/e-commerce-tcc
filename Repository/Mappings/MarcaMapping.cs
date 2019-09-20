using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PadawanStore.Infra.Data.Mappings
{
    public class MarcaMapping : BaseConfiguration<Marca>
    {
        public override void Configure(EntityTypeBuilder<Marca> builder)
        {
            base.Configure(builder);

            builder.ToTable("marcas");

            builder.Property(m => m.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.HasData
            (
                new Marca
                {
                    Id = 1,
                    DataCriacao = DateTime.Now,
                    Nome = "Sony"
                },
                new Marca
                {
                    Id = 2,
                    DataCriacao = DateTime.Now,
                    Nome = "Microsoft"
                }
            );
        }
    }
}
