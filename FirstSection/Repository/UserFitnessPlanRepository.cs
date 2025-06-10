using FirstSection.Contracts;
using FirstSection.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstSection.Repository
{
    public class UserFitnessPlanRepository : GenericRepository<UserFitnessPlan>, IUserFitnessPlanRepository
    {
        private readonly FitnessDbContext _context;

        public UserFitnessPlanRepository(FitnessDbContext context) : base(context)
        {
            this._context = context;
        }


        public async Task<List<UserFitnessPlan>> GetUserFitnessPlansAsync(Guid userId)
        {
            return await _context.UserFitnessPlans
                .Include(ufp => ufp.Training)
                    .ThenInclude(t => t.FitnessCategory)
                .Where(ufp => ufp.UserId == userId)
                .ToListAsync();
        }


    }
}
