using AutoMapper;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;

namespace JobBoard.AdminApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<State, StateDto>();
            CreateMap<Core.Models.JobBoard, JobBoardDto>();
            CreateMap<Occupation, OccupationDto>();
            CreateMap<SalaryType, SalaryTypeDto>();
            CreateMap<Occupation, OccupationDto>();
            CreateMap<EmploymentType, EmploymentTypeDto>();
            CreateMap<JobBoardCreateDto, Core.Models.JobBoard>();
        }
    }
}
