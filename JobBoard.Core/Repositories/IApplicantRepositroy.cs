using JobBoard.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.Core.Repositories
{
    public interface IApplicantRepositroy
    {
        Task<IEnumerable<Applicant>> GetApplicantsAsync();
    }
}
