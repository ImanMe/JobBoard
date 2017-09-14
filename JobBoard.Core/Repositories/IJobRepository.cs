using JobBoard.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.Core.Repositories
{
    public interface IJobRepository
    {
        Task<Job> GetJobAsync(long id);
        Task<IEnumerable<Job>> GetJobsAsync();
        Task AddAsync(Job job);
        void Edit(Job job);
    }
}
