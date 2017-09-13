using JobBoard.Core.Models;
using JobBoard.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JobBoard.Persistence.Repositories
{
    public class JobOccupationRepository : IJobOccupationRepository
    {
        private readonly JobBoardContext _context;

        public JobOccupationRepository(JobBoardContext context)
        {
            _context = context;

            context.ChangeTracker.QueryTrackingBehavior
                = QueryTrackingBehavior.NoTracking;
        }

        public void Add(IEnumerable<JobOccupation> jobOccupation)
        {
            _context.AddRange(jobOccupation);
        }

        public void Delete(IEnumerable<JobOccupation> jobOccupations)
        {
            _context.RemoveRange(jobOccupations);
        }
    }
}
