using AutoMapper;
using FluentValidation.AspNetCore;
using JobBoard.Core;
using JobBoard.Core.Repositories;
using JobBoard.Core.Validations;
using JobBoard.Persistence;
using JobBoard.Persistence.DbInitializers;
using JobBoard.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobBoard.AdminApi.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();
            services.AddScoped<IApplicantRepositroy, ApplicantRepository>();
            services.AddScoped<ISalaryTypeRepository, SalaryTypeRepository>();
            services.AddScoped<IEmploymentRepository, EmploymentTypeRepository>();
            services.AddScoped<IJobBoardRepository, JobBoardRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobOccupationRepository, JobOccupationRepository>();
            services.AddScoped<IStatRepository, StatRepository>();
            services.AddTransient<JobBoardInitializer>();
            services.AddDbContext<JobBoardContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("JobBoardConnection")));
            services.AddAutoMapper();
            services.AddCors();
            services.AddMvc()
                .AddFluentValidation(fvc =>
                fvc.RegisterValidatorsFromAssemblyContaining<JobBoardCreateDtoValidator>());
            return services;
        }
    }
}
