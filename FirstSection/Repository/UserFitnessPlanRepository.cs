using FirstSection.Contracts;
using FirstSection.Data;

namespace FirstSection.Repository
{
    public class UserFitnessPlanRepository : GenericRepository<UserFitnessPlan>, IUserFitnessPlanRepository
    {
        private readonly FitnessDbContext _context;

        public UserFitnessPlanRepository(FitnessDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
