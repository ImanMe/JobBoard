using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.Core.Repositories
{
    public interface IJobBoardRepository
    {
        Task<IEnumerable<Models.JobBoard>> GetJobBoards();
        Task<Models.JobBoard> GetJobBoard(int id);
        void Add(Models.JobBoard jobBoard);
        void Edit(Models.JobBoard jobBoard);
        void Delete(Models.JobBoard jobBoard);
    }
}
