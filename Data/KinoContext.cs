using web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
    public class KinoContext : IdentityDbContext<ApplicationUser>
    {
        public KinoContext(DbContextOptions<KinoContext> options) : base(options)
        {
        }

        public DbSet<Film> Filmi { get; set; }
        public DbSet<Predstava> Predstave { get; set; }
        public DbSet<Dvorana> Dvorane { get; set; }
        public DbSet<Karta> Karte { get; set; }
        public DbSet<Sedez> Sedezi { get; set; }
        
    
     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Film>().ToTable("Film");
            modelBuilder.Entity<Predstava>().ToTable("Predstava");
            modelBuilder.Entity<Dvorana>().ToTable("Dvorana");
            modelBuilder.Entity<Karta>().ToTable("Karta");
            modelBuilder.Entity<Sedez>().ToTable("Sedez");
        }
    
       
    }
}