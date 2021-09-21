using Microsoft.EntityFrameworkCore;
using TP1_ORM_SOLIS_JAVIER.Entities;
using TP1_ORM_SOLIS_JAVIER.EntitiesConfiguration;


namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{ 
    
    public class Context : DbContext
    {
        public DbSet<Peliculas> Peliculas { get; set; }
        public DbSet<Salas> Salas { get; set; }
        public DbSet<Funciones> Funciones { get; set; }
        public DbSet<Tickets> Tickets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CineDB;Trusted_Connection=True;");
        }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Peliculas>(new PeliculasConfiguration());
            modelBuilder.ApplyConfiguration<Salas>(new SalasConfiguration());
            modelBuilder.ApplyConfiguration<Funciones>(new FuncionesConfiguration());
            modelBuilder.ApplyConfiguration<Tickets>(new TicketsConfiguration());
        }

    }
}
