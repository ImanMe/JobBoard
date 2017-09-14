using JobBoard.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Persistence.DbInitializers
{
    public class JobBoardInitializer
    {
        private readonly JobBoardContext _context;

        public JobBoardInitializer(JobBoardContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (!_context.Countries.Any())
            {
                // AddAsync Data
                _context.AddRange(_sampleCountries);
                await _context.SaveChangesAsync();
            }
        }

        private readonly List<Country> _sampleCountries = new List<Country>
        {
            new Country()
            {
                CountryName = "United States",
                CountryCode = "US",
                States = new List<State>
                {
                    new State()
                    {
                        StateName = "Arizona",
                        StateCode = "AR",

                    },
                    new State()
                    {
                        StateName = "Texas",
                        StateCode = "TX",

                    }
                }
            },
            new Country()
            {
                CountryName = "Canada",
                CountryCode = "CA",
                States = new List<State>
                {
                    new State()
                    {
                        StateName = "Ontario",
                        StateCode = "ON",

                    },
                    new State()
                    {
                        StateName = "Alberta",
                        StateCode = "AL",

                    }
                }
            },


        };


    }
}
