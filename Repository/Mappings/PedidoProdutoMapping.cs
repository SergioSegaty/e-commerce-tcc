using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace PadawanStore.Infra.Data.Mappings
{
    public class PedidoProdutoMapping : BaseConfiguration<PedidoProduto>
    {
        public override void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {
            base.Configure(builder);

            builder.ToTable("pedidos_produtos");

            builder.Property(pp => pp.IdPedido)
                .HasColumnName("id_pedido");

            builder.Property(pp => pp.IdProduto)
                .HasColumnName("id_produto");

            builder
                .HasOne(p => p.Pedido)
                .WithMany(pp => pp.PedidoProduto)
                .HasForeignKey(p => p.IdPedido);

            builder
                .HasOne(p => p.Produto)
                .WithMany(pp => pp.PedidoProduto)
                .HasForeignKey(p => p.IdProduto);

            builder.HasData
            (
                new PedidoProduto
                {
                    Id = 1,
                    IdProduto = 1,
                    IdPedido = 1
                }
            );
        }
    }
}
