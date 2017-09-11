using JobBoard.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.Persistence.Repositories
{
    public class JobBoardRepository : IJobBoardRepository
    {
        private readonly JobBoardContext _context;

        public JobBoardRepository(JobBoardContext context)
        {
            _context = context;

            _context.ChangeTracker.QueryTrackingBehavior
                = QueryTrackingBehavior.NoTracking;
        }

        public async Task<IEnumerable<Core.Models.JobBoard>> GetJobBoards()
        {
            var jobBoards = await _context.JobBoards.ToListAsync();

            return jobBoards;
        }

        public async Task<Core.Models.JobBoard> GetJobBoard(int id)
        {
            var jobBoard = await _context.JobBoards.FindAsync(id);

            return jobBoard;
        }

        public void Add(Core.Models.JobBoard jobBoard)
        {
            _context.JobBoards.Add(jobBoard);
            _context.ChangeTracker.DetectChanges();
        }

        public void Delete(Core.Models.JobBoard jobBoard)
        {
            _context.Entry(jobBoard).State = EntityState.Deleted;
            _context.ChangeTracker.DetectChanges();
        }

        public void Edit(Core.Models.JobBoard jobBoard)
        {
            _context.Entry(jobBoard).State = EntityState.Modified;
            _context.ChangeTracker.DetectChanges();
        }
    }
}
