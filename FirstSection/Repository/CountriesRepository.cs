using FirstSection.Contracts;
using FirstSection.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstSection.Repository
{
    public class CountriesRepository:GenericRepository <Country>, ICountryRepository 
    {
        private readonly HotelListingDbContext _context;

        public CountriesRepository(HotelListingDbContext context):base(context)
        {
            this._context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels)
                .FirstOrDefaultAsync(q => q.CountryId == id);
        }
    }
}
