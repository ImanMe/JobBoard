using JobBoard.Core.Models;
using System.Threading.Tasks;

namespace JobBoard.Core.Repositories
{
    public interface IStatRepository
    {
        Task<Stat> GetStat(int jobId);
        //Task AddAsync(IEnumerable<Stat> stats);
        Task AddAsync(Stat stat);
        void Edit(Stat stat);
    }
}
