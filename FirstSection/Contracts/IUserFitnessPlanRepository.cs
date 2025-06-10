using FirstSection.Data;

namespace FirstSection.Contracts
{
    public interface IUserFitnessPlanRepository:IGenericRepository<UserFitnessPlan>
    {
        public  Task<List<UserFitnessPlan>> GetUserFitnessPlansAsync(Guid userId);
    }
}
