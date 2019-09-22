using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace PadawanStore.Infra.Data.Mappings
{
    public class PedidoMapping : BaseConfiguration<Pedido>
    {
        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            base.Configure(builder);

            builder.ToTable("pedidos");

            builder.Property(p => p.IdUsuario)
                .HasColumnName("id_usuario");

            builder
                .HasOne(u => u.Usuario)
                .WithMany(p => p.Pedido)
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData
            (
                new Pedido
                {
                    Id = 1,
                    DataCriacao = DateTime.Now,
                    IdUsuario = 1
                }
            );
        }
    }
}
