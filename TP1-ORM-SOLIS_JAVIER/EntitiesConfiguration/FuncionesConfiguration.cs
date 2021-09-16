using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.EntitiesConfiguration
{
   public class FuncionesConfiguration : IEntityTypeConfiguration<Funciones>
   {
            public void Configure(EntityTypeBuilder<Funciones> builder)
            {
                builder.HasKey(c => c.FuncionId);
                builder.Property(c => c.FuncionId)
                       .ValueGeneratedOnAdd()
                       .IsRequired(true);

                builder.Property(c => c.PeliculaId)
                       .IsRequired(true);

                builder.Property(c => c.SalaId)
                       .IsRequired(true);

                builder.Property(c => c.Fecha)
                       .IsRequired(true);

                builder.Property(c => c.Horario)
                       .IsRequired(true);

            }
   }
}



