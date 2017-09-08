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

            context.ChangeTracker.QueryTrackingBehavior
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
        }

        public void Delete(int id)
        {
            var jobBoard = _context.JobBoards.Find(id);
            _context.Entry(jobBoard).State = EntityState.Deleted;
        }

        public void Edit(int id)
        {
            var jobBoard = _context.JobBoards.Find(id);
            _context.Entry(jobBoard).State = EntityState.Modified;
        }
    }
}
