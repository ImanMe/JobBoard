using JobBoard.Core.Models;
using JobBoard.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.Persistence.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly JobBoardContext _context;

        public JobRepository(JobBoardContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Job>> GetJobs()
        {
            var jobs = await _context.Jobs
                .Include(j => j.Country)
                .ToListAsync();

            return jobs;
        }
    }
}
