﻿using JobBoard.Core.Repositories;
using System.Threading.Tasks;

namespace JobBoard.Core
{
    public interface IUnitOfWork
    {
        ICountryRepository Countries { get; }
        IStateRepository States { get; }
        ICategoryRepository Categories { get; }
        IOccupationRepository Occupations { get; }
        IApplicantRepositroy Applicants { get; }
        IJobBoardRepository JobBoards { get; }
        IJobRepository Jobs { get; }
        ISalaryTypeRepository SalaryTypes { get; }
        IEmploymentRepository EmploymentTypes { get; }
        IJobOccupationRepository JobOccupations { get; }
        IStatRepository Stats { get; }

        Task<int> CompleteAsync();
    }
}
