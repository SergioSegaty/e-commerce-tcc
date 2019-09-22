using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace PadawanStore.Infra.Data.Mappings
{
    class EnderecoMapping : BaseConfiguration<Endereco>
    {
        public override void Configure(EntityTypeBuilder<Endereco> builder)
        {
            base.Configure(builder);

            builder.ToTable("enderecos");

            builder.Property(e => e.CEP)
                .HasColumnName("cep")
                .HasColumnType("varchar(12)")
                .HasMaxLength(12)
                .IsRequired();

            builder.Property(e => e.Logradouro)
                .HasColumnName("logradouro")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(e => e.Bairro)
                .HasColumnName("bairros")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Numero)
                .HasColumnName("numero")
                .HasColumnType("varchar(10)")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasColumnName("complemento")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(c => c.IdCidade)
                .HasColumnName("id_cidade");

            builder.Property(u => u.IdUsuario)
                .HasColumnName("id_usuario");

            builder
                .HasOne(c => c.Cidade)
                .WithMany(c => c.Endereco)
                .HasForeignKey(c => c.IdCidade)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(c => c.Usuario)
                .WithMany(c => c.Endereco)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData
            (
                new Endereco
                {
                    Id = 1,
                    DataCriacao = DateTime.Now,
                    Bairro = "Severina Alves",
                    CEP = "89068-253",
                    Complemento = "Portão Colorido",
                    Logradouro = "Blumenau/SC",
                    Numero = "666",
                    IdCidade = 1,
                    IdUsuario = 1
                }
            );
        }
    }
}
