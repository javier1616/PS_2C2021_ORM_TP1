using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.EntitiesConfiguration
{
    
    public class TipoMercaderiaConfiguration : IEntityTypeConfiguration<TipoMercaderia>
    {
            public void Configure(EntityTypeBuilder<TipoMercaderia> builder)
            {
                builder.HasKey(c => c.TipoMercaderiaId);
                builder.Property(c => c.TipoMercaderiaId)
                    .ValueGeneratedOnAdd()
                    .IsRequired(true);

                builder.Property(c => c.Descripcion)
                       .IsRequired(true)
                       .HasMaxLength(50);

                builder.HasData(

                   new TipoMercaderia { TipoMercaderiaId = 1, Descripcion = "Entrada" },
                   new TipoMercaderia { TipoMercaderiaId = 2, Descripcion = "Minutas" },
                   new TipoMercaderia { TipoMercaderiaId = 3, Descripcion = "Pastas" },
                   new TipoMercaderia { TipoMercaderiaId = 4, Descripcion = "Parrilla" },
                   new TipoMercaderia { TipoMercaderiaId = 5, Descripcion = "Pizzas" },
                   new TipoMercaderia { TipoMercaderiaId = 6, Descripcion = "Sandwich" },
                   new TipoMercaderia { TipoMercaderiaId = 7, Descripcion = "Ensaladas" },
                   new TipoMercaderia { TipoMercaderiaId = 8, Descripcion = "Bebidas" },
                   new TipoMercaderia { TipoMercaderiaId = 9, Descripcion = "Cerveza Artesanal" },
                   new TipoMercaderia { TipoMercaderiaId = 10, Descripcion = "Postres" }

                    );  


            }
        
    }

}
