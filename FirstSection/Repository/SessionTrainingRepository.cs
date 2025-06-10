using FirstSection.Contracts;
using FirstSection.Data;
using FirstSection.Models.Session;
using FirstSection.Models.SessionTraining;
using Microsoft.EntityFrameworkCore;

namespace FirstSection.Repository
{
    public class SessionTrainingRepository : GenericRepository<SessionTraining>, ISessionTrainingRepository
    {
        private readonly FitnessDbContext _context;

        public SessionTrainingRepository(FitnessDbContext context) : base(context)
        {
            this._context = context;
        }

        public Task<List<Session>> GetSessionTrainingGetAll(Guid Id)
        {
            return _context.SessionTraining.Where(c => c.TrainingId == Id).Include(c => c.Session).Select(
                c => c.Session).ToListAsync();
        }
    }
}
