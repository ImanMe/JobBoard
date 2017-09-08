using JobBoard.Core.Models;
using JobBoard.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JobBoard.Persistence.Repositories
{
    public class ApplicantRepository : IApplicantRepositroy
    {
        private readonly JobBoardContext _context;

        public ApplicantRepository(JobBoardContext context)
        {
            _context = context;

            context.ChangeTracker.QueryTrackingBehavior
                = QueryTrackingBehavior.NoTracking;
        }

        public IEnumerable<Applicant> GetApplicants()
        {
            return _context.Applicants.ToList();
        }
    }
}
