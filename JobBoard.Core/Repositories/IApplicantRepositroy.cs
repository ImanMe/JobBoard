using JobBoard.Core.Models;
using System.Collections.Generic;

namespace JobBoard.Core.Repositories
{
    public interface IApplicantRepositroy
    {
        IEnumerable<Applicant> GetApplicants();
    }
}
