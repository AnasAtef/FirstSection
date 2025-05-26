using FirstSection.Contracts;
using FirstSection.Data;

namespace FirstSection.Repository
{
    public class CardioTrainingRepository : GenericRepository<CardioTraining>, ICardioTrainingRepository
    {
        private readonly FitnessDbContext _context;

        public CardioTrainingRepository(FitnessDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
