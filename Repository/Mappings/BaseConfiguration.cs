using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace PadawanStore.Infra.Data.Mappings
{
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : Base
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(b => b.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired(true);

            builder.Property(b => b.DataCriacao)
                .HasColumnType("datetime2")
                .HasColumnName("data_criacao")
                .IsRequired(true);

            builder.Property(b => b.DataUltimaAtualizacao)
                .HasColumnType("datetime2")
                .HasColumnName("data_ultima_atualizacao")
                .IsRequired(false);

            builder.Property(b => b.DataExclusao)
                .HasColumnType("datetime2")
                .HasColumnName("data_exclusao")
                .IsRequired(false);

            builder.Property(b => b.RegistroAtivo)
                .HasColumnType("bit")
                .HasColumnName("registro_ativo")
                .HasDefaultValue(true)
                .IsRequired(true);
        }
    }
}
