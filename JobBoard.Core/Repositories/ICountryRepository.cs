using JobBoard.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.Core.Repositories
{
    public interface ICountryRepository
    {
        //IEnumerable<KeyValuePair<int, string>> GetCountries();
        Task<IEnumerable<Country>> GetCountries();
        Task<IEnumerable<Country>> GetCountriesWithStates();
        Task<Country> GetCountry(int id);
        void Add(Country country);
    }
}
