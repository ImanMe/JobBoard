using JobBoard.Core;
using JobBoard.Core.Repositories;
using System.Threading.Tasks;

namespace JobBoard.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ICountryRepository countries, JobBoardContext context, IStateRepository states, ICategoryRepository categories, IOccupationRepository occupations, IApplicantRepositroy applicants, IJobBoardRepository jobBoards, IJobRepository jobs, ISalaryTypeRepository salaryTypes, IEmploymentRepository employmentTypes)
        {
            _context = context;

            Countries = countries;
            States = states;
            Categories = categories;
            Occupations = occupations;
            Applicants = applicants;
            JobBoards = jobBoards;
            Jobs = jobs;
            SalaryTypes = salaryTypes;
            EmploymentTypes = employmentTypes;
        }

        private readonly JobBoardContext _context;
        public ICountryRepository Countries { get; }
        public IStateRepository States { get; }
        public ICategoryRepository Categories { get; }
        public IOccupationRepository Occupations { get; }
        public IApplicantRepositroy Applicants { get; }
        public IJobBoardRepository JobBoards { get; }
        public IJobRepository Jobs { get; }
        public ISalaryTypeRepository SalaryTypes { get; }
        public IEmploymentRepository EmploymentTypes { get; }

        public async Task<int> Complete()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
