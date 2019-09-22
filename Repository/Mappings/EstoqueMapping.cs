using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace PadawanStore.Infra.Data.Mappings
{
    public class EstoqueMapping : BaseConfiguration<Estoque>
    {
        public override void Configure(EntityTypeBuilder<Estoque> builder)
        {
            base.Configure(builder);

            builder.ToTable("estoques");

            builder.Property(e => e.Quantidade)
                .HasColumnName("quantidade")
                .HasColumnType("int")
                .HasMaxLength(9999)
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.IdProduto)
                .HasColumnName("id_produto");

            builder
               .HasOne(p => p.Produto)
               .WithMany(e => e.Estoque)
               .HasForeignKey(p => p.IdProduto)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasData
            (
                new Estoque
                {
                    Id = 1,
                    DataCriacao = DateTime.Now,
                    Status = "Em Estoque",
                    Quantidade = 10,
                    IdProduto = 1
                }
            );
        }
    }
}
