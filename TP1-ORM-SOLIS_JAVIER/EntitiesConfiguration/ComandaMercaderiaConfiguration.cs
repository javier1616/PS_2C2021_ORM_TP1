using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.EntitiesConfiguration
{
   public class ComandaConfiguration : IEntityTypeConfiguration<Comanda>
   {
            public void Configure(EntityTypeBuilder<Comanda> builder)
            {
                builder.HasKey(c => c.ComandaId);
                builder.Property(c => c.ComandaId)
                       .ValueGeneratedOnAdd()
                       .IsRequired(true);

                builder.Property(c => c.FormaEntregaId)
                       .IsRequired(true);

                builder.Property(c => c.PrecioTotal)
                       .IsRequired(true);

                builder.Property(c => c.Fecha)
                       .IsRequired(true);

        }
   }
}



