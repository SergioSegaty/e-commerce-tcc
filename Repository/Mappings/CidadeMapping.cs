using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace PadawanStore.Infra.Data.Mappings
{
    public class CidadeMapping : BaseConfiguration<Cidade>
    {
        public override void Configure(EntityTypeBuilder<Cidade> builder)
        {
            base.Configure(builder);

            builder.ToTable("cidades");

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.IdEstado)
                .HasColumnName("id_estado");


            builder
                .HasOne(c => c.Estado)
                .WithMany(c => c.Cidade)
                .HasForeignKey(c => c.IdEstado)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData
            (
                new Cidade
                {
                    Id = 1,
                    Nome = "Blumenau",
                    DataCriacao = DateTime.Now,
                    IdEstado = 1
                }
            );
        }
    }
}
