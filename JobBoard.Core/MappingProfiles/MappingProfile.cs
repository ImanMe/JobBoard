using AutoMapper;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;

namespace JobBoard.Core.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<State, StateDto>();
            CreateMap<Models.JobBoard, JobBoardDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.JobBoardName));
            CreateMap<SalaryType, SalaryTypeDto>();
            CreateMap<JobBoardCreateDto, Models.JobBoard>()
                .ForMember(dest => dest.JobBoardName, opt => opt.MapFrom(src => src.Name));
            CreateMap<JobBoardUpdateDto, Models.JobBoard>()
                .ForMember(dest => dest.JobBoardName, opt => opt.MapFrom(src => src.Name));
            CreateMap<EmploymentType, EmploymentTypeDto>();
            CreateMap<Occupation, OccupationDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OccupationName));
            CreateMap<JobOccupation, JobOccupationDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Job, JobDto>()
                .ForMember(dest => dest.JobBoard, opt => opt.MapFrom(src => src.JobBoard.JobBoardName))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.EmploymentType, opt => opt.MapFrom(src => src.EmploymentType.Name))
                .ForMember(dest => dest.SalaryType, opt => opt.MapFrom(src => src.SalaryType.Name))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.CountryCode))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State.StateName))
                .ForMember(dest => dest.ActivationDate,
                    opt => opt.MapFrom(src => src.ActivationDate.ToShortDateString()))
                .ForMember(dest => dest.CreatedDate,
                    opt => opt.MapFrom(src => src.CreatedDate.ToShortDateString()))
                .ForMember(dest => dest.ExpirationDate,
                    opt => opt.MapFrom(src => src.ExpirationDate.ToShortDateString()))
                .ForMember(dest => dest.EditedDate, opt => opt.ResolveUsing(src =>
                {
                    var dt = src.EditedDate;
                    return dt?.ToShortDateString();
                }));
            CreateMap<JobOccupationDto, JobOccupation>();
            CreateMap<JobFormDto, Job>();
        }
    }
}
