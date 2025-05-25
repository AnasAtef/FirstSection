using FirstSection.Data;

namespace FirstSection.Contracts
{
    public interface ICountryRepository : IGenericRepository<Country> 
    {
         Task<Country>GetDetails (int id);
    }
}
