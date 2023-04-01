using Microsoft.EntityFrameworkCore;

namespace Writer.API.Models
{
    public class WritersDbContext:DbContext
    {
        public DbSet<Writer> Writers { get; set; } // database e wrtier tablosunu oluşturacak.

        public WritersDbContext(DbContextOptions<WritersDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Writer>().ToTable("Writer");
        }
    }
}
