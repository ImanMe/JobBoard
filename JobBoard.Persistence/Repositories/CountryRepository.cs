using JobBoard.Core.Models;
using JobBoard.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Persistence.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly JobBoardContext _context;

        public CountryRepository(JobBoardContext context)
        {
            _context = context;

            context.ChangeTracker.QueryTrackingBehavior
                = QueryTrackingBehavior.NoTracking;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            var countries = await _context.Countries
                .OrderBy(c => c.CountryName)
               .ToListAsync();

            return countries;
        }

        public async Task<IEnumerable<Country>> GetCountriesWithStates()
        {
            var countries = await _context.Countries
                .Include(c => c.States)
                .ToListAsync();

            return countries;
        }

        public async Task<Country> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            return country;
        }


        public void Add(Country country)
        {
            _context.Countries.Add(country);
        }

        public void Delete(int id)
        {
            var country = _context.Countries.Find(id);
            _context.Entry(country).State = EntityState.Deleted;

        }

        public void Edit(int id)
        {
            var country = _context.Countries.Find(id);
            _context.Entry(country).State = EntityState.Modified;

        }
    }
}
