using FirstSection.Contracts;
using FirstSection.Data;

namespace FirstSection.Repository
{
    public class FitnessCategoryRepository : GenericRepository<FitnessCategory>, IFitnessCategoryRepository
    {
        private readonly FitnessDbContext _context;

        public FitnessCategoryRepository(FitnessDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
