using FirstSection.Contracts;
using FirstSection.Data;
using FirstSection.Models.Training;

namespace FirstSection.Repository
{
    public class TrainingRepository : GenericRepository<Training>, ITrainingRepository
    {
        private readonly FitnessDbContext _context;

        public TrainingRepository(FitnessDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Training>> GetTrainingForFintnessCategory(int id)
        {
            return _context.Trainings.Where(c=>c.FitnessCategoryId == id).ToList();
        }
    }
}
