using JobBoard.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.Core.Repositories
{
    public interface IJobRepository
    {
        Task<Job> GetJob(long id);
        Task<IEnumerable<Job>> GetJobs();
    }
}
