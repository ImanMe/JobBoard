using JobBoard.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.Core.Repositories
{
    public interface ISalaryTypeRepository
    {
        Task<IEnumerable<SalaryType>> GetSalaryTypesAsync();
    }
}
