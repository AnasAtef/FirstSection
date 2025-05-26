using FirstSection.Contracts;
using FirstSection.Data;

namespace FirstSection.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(FitnessDbContext context) : base(context)
        {
        }
    }
}
