using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.EntitiesConfiguration
{
    
    public class SalasConfiguration : IEntityTypeConfiguration<Salas>
    {
        public void Configure(EntityTypeBuilder<Salas> builder)
        {
            builder.HasKey(c => c.SalaId);
            builder.Property(c => c.SalaId)
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(c => c.Capacidad)
                .IsRequired(true);


            builder.HasData(


                   new Salas { SalaId = 1, Capacidad = 50 },
                   new Salas { SalaId = 2, Capacidad = 100},
                   new Salas { SalaId = 3, Capacidad = 1}
                   
            );  


        }
        
    }

}
