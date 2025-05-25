using Microsoft.EntityFrameworkCore;
using FirstSection.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FirstSection.Data.configuration;
using FirstSection.Data.configurations;

namespace FirstSection.Data
{
    public class HotelListingDbContext : IdentityDbContext<APIUser>
    {
        public HotelListingDbContext(DbContextOptions<HotelListingDbContext>options): base (options)
        {
            
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FirstSection.Data.Hotel> Hotel { get; set; } = default!;
        
        protected override void OnModelCreating (ModelBuilder modelBuilder) 
        {
            base.OnModelCreating (modelBuilder);
            
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());

        }
    }
}
