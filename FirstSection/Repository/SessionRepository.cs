using FirstSection.Contracts;
using FirstSection.Data;

namespace FirstSection.Repository
{
    public class SessionRepository:GenericRepository<Session>, ISessionRepository
    {
        private readonly FitnessDbContext _context;

        public SessionRepository(FitnessDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
