using FirstSection.Contracts;
using FirstSection.Data;

namespace FirstSection.Repository
{
    public class StrengthTrainingRepository : GenericRepository<StrengthTraining>, IStrengthTrainingRepository
    {
        private readonly FitnessDbContext _context;

        public StrengthTrainingRepository(FitnessDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
