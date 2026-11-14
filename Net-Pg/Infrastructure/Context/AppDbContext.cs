using Microsoft.EntityFrameworkCore;
using Net_Pg.Entities;

namespace Net_Pg.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura o Id (GUID) para ser gerado pelo Postgres se não for enviado pelo C#
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}
