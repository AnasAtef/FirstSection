using Microsoft.EntityFrameworkCore;

namespace FirstSection.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions<HotelListingDbContext>options): base (options)
        {
            
        }
        public DbSet<Country> Countries { get; set; }
    }
}
