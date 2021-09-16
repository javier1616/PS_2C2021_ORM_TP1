using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.EntitiesConfiguration
{
   public class MercaderiaConfiguration : IEntityTypeConfiguration<Mercaderia>
   {
            public void Configure(EntityTypeBuilder<Mercaderia> builder)
            {
                builder.HasKey(c => c.MercaderiaId);
                builder.Property(c => c.MercaderiaId)
                       .ValueGeneratedOnAdd()
                       .IsRequired(true);

                builder.Property(c => c.Nombre)
                       .HasMaxLength(50) 
                       .IsRequired(true);

                builder.Property(c => c.TipoMercaderiaId)
                       .IsRequired(true);

                builder.Property(c => c.Precio)
                       .IsRequired(true);

                builder.Property(c => c.Ingredientes)
                       .HasMaxLength(255)
                       .IsRequired(true);

                builder.Property(c => c.Preparacion)
                       .HasMaxLength(255)
                       .IsRequired(true);

                builder.Property(c => c.Imagen)
                       .HasMaxLength(255)
                       .IsRequired(true);

            }
   }
}



