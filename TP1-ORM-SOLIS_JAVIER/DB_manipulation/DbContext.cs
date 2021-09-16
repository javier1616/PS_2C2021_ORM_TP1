
using Microsoft.EntityFrameworkCore;
using TP1_ORM_SOLIS_JAVIER.Entities;
using TP1_ORM_SOLIS_JAVIER.EntitiesConfiguration;


namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{ 
    
    public class Context : DbContext
    {

        public DbSet<Mercaderia> Mercaderia { get; set; }
        public DbSet<TipoMercaderia> TipoMercaderia { get; set; }
        public DbSet<ComandaMercaderia> ComandaMercaderia { get; set; }
        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<FormaEntrega> FormaEntrega { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=RestauranteDB;Trusted_Connection=True;");
        }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration<TipoMercaderia>(new TipoMercaderiaConfiguration());
            modelBuilder.ApplyConfiguration<Mercaderia>(new MercaderiaConfiguration());
            modelBuilder.ApplyConfiguration<ComandaMercaderia>(new ComandaMercaderiaConfiguration());
            modelBuilder.ApplyConfiguration<Comanda>(new ComandaConfiguration());
            modelBuilder.ApplyConfiguration<FormaEntrega>(new FormaEntregaConfiguration());

        }

    }
}
