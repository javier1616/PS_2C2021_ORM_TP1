using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.EntitiesConfiguration
{
    
    public class FormaEntregaConfiguration : IEntityTypeConfiguration<FormaEntrega>
    {
            public void Configure(EntityTypeBuilder<FormaEntrega> builder)
            {
                builder.HasKey(c => c.FormaEntregaId);
                builder.Property(c => c.FormaEntregaId)
                    .ValueGeneratedOnAdd()
                    .IsRequired(true);

                builder.Property(c => c.Descripcion)
                       .IsRequired(true)
                       .HasMaxLength(50);

                builder.HasData(
                    
                    new FormaEntrega { FormaEntregaId = 1, Descripcion = "Salon" },
                    new FormaEntrega { FormaEntregaId = 2, Descripcion = "Delivery" },
                    new FormaEntrega { FormaEntregaId = 3, Descripcion = "Pedidos Ya" }

                );


            }
        
    }

}
