using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.EntitiesConfiguration
{
    
    public class PeliculasConfiguration : IEntityTypeConfiguration<Peliculas>
    {
            public void Configure(EntityTypeBuilder<Peliculas> builder)
            {
                builder.HasKey(c => c.PeliculaId);
                builder.Property(c => c.PeliculaId)
                    .ValueGeneratedOnAdd()
                    .IsRequired(true);

                builder.Property(c => c.Titulo)
                       .IsRequired(true)
                       .HasMaxLength(50);

                builder.Property(c => c.Poster)
                       .IsRequired(true)
                       .HasMaxLength(255);

                builder.Property(c => c.Sinopsis)
                       .IsRequired(true)
                       .HasMaxLength(255);

                builder.Property(c => c.Trailer)
                       .IsRequired(true)
                       .HasMaxLength(255);

                builder.HasData(
  
                   new Peliculas {
                       PeliculaId = 1,
                       Titulo = "Jurasic Park",
                       Poster ="URL_Poster.png",
                       Sinopsis ="Accidentes en un parque de atracciones con dinosaurios",
                       Trailer ="URL_trailer.mp4"
                       },

                   new Peliculas
                   {
                       PeliculaId = 2,
                       Titulo = "Indiana Jones y la Ultima Cruzada",
                       Poster = "URL_Poster.png",
                       Sinopsis = "Un cazarrecompensas intenta encontrar el santo grial",
                       Trailer = "URL_trailer.mp4"
                   },

                   new Peliculas
                   {
                       PeliculaId = 3,
                       Titulo = "Rapido y Furioso 25: Carreras marcianas",
                       Poster = "URL_Poster.png",
                       Sinopsis = "Mas carreras, mas explosiones, mas velocidad. Ahora con naves espaciales",
                       Trailer = "URL_trailer.mp4"
                   }

                   
                );  


            }
        
    }

}
