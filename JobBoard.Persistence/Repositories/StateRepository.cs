using JobBoard.Core.Models;
using JobBoard.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Persistence.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly JobBoardContext _context;

        public StateRepository(JobBoardContext context)
        {
            _context = context;

            context.ChangeTracker.QueryTrackingBehavior
                = QueryTrackingBehavior.NoTracking;
        }

        public async Task<IEnumerable<State>> GetStatesById(int countryId)
        {
            var states = await _context.States
                .Where(s => s.CountryId == countryId)
                .OrderBy(s => s.StateName)
                .ToListAsync();

            return states;
        }
    }
}
