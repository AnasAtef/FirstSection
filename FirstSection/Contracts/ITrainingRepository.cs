using FirstSection.Data;

namespace FirstSection.Contracts
{
    public interface ITrainingRepository : IGenericRepository<Training>
    {
        public  Task<List<Training>> GetTrainingForFintnessCategory(int id);
    }
}
