using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.EntitiesConfiguration
{
   public class ComandaMercaderiaConfiguration : IEntityTypeConfiguration<ComandaMercaderia>
   {
            public void Configure(EntityTypeBuilder<ComandaMercaderia> builder)
            {
                builder.HasKey(c => c.ComandaMercaderiaId);
                builder.Property(c => c.ComandaMercaderiaId)
                       .ValueGeneratedOnAdd()
                       .IsRequired(true);

                builder.Property(c => c.MercaderiaId)
                       .IsRequired(true);

                builder.Property(c => c.ComandaId)
                       .IsRequired(true);

            }
   }
}



