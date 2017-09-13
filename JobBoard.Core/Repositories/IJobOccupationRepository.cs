using JobBoard.Core.Models;
using System.Collections.Generic;

namespace JobBoard.Core.Repositories
{
    public interface IJobOccupationRepository
    {
        void Add(IEnumerable<JobOccupation> jobOccupation);
        void Delete(IEnumerable<JobOccupation> jobOccupations);
    }
}
