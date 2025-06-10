using FirstSection.Data;
using FirstSection.Models.Session;
using FirstSection.Models.SessionTraining;

namespace FirstSection.Contracts
{
    public interface ISessionTrainingRepository : IGenericRepository<SessionTraining>
    {
        public Task<List<Session>> GetSessionTrainingGetAll(Guid Id);
    }
}
