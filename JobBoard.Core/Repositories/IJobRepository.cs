using JobBoard.Core.Models;
using System.Threading.Tasks;

namespace JobBoard.Core.Repositories
{
    public interface IJobRepository
    {
        Task<Job> GetJobAsync(long id);
        Task<QueryResult<Job>> GetJobsAsync(JobQuery queryObj);
        Task AddAsync(Job job);
        void Edit(Job job);
        void Delete(Job job);
    }
}
