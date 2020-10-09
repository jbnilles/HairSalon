using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models
{
  public class HairSalonContext : DbContext
  {
     public DbSet<Stylist> Cuisines { get; set; }
     public DbSet<Client> Reviews { get; set; }
    // public DbSet<Restaurant> Restaurants { get; set; }
    
    public HairSalonContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}