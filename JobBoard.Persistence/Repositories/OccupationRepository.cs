using JobBoard.Core.Models;
using JobBoard.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.Persistence.Repositories
{
    public class OccupationRepository : IOccupationRepository
    {
        private readonly JobBoardContext _context;

        public OccupationRepository(JobBoardContext context)
        {
            _context = context;

            context.ChangeTracker.QueryTrackingBehavior
                = QueryTrackingBehavior.NoTracking;
        }

        public async Task<IEnumerable<Occupation>> GetOccupations()
        {
            return await _context.Occupations.ToListAsync();
        }
    }
}
