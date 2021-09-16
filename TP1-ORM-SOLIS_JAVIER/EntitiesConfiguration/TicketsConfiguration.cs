using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.EntitiesConfiguration
{
   public class TicketsConfiguration : IEntityTypeConfiguration<Tickets>
   {
            public void Configure(EntityTypeBuilder<Tickets> builder)
            {

                builder.HasKey(c => new { c.TicketId, c.FuncionId });

                builder.Property(c => c.TicketId)
                       .ValueGeneratedOnAdd()
                       .IsRequired(true);

                builder.Property(c => c.FuncionId)
                       .IsRequired(true);

                builder.Property(c => c.Usuario)
                       .HasMaxLength(50)
                       .IsRequired(true);

            }
   }
}



