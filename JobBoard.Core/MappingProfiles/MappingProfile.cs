using AutoMapper;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;
using System.Linq;

namespace JobBoard.Core.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Stat, StatDto>();
            CreateMap<StatCreateDto, Stat>();
            CreateMap<StatUpdateDto, Stat>();
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

            CreateMap<JobCreateDto, Job>()
                .ForMember(dest => dest.Occupations, opt => opt.MapFrom(src => src.SelectedOccupation.Select(jo => new JobOccupation { OccupationId = jo })));

            CreateMap<Job, JobCreateDto>()
                .ForMember(dest => dest.SelectedOccupation, opt => opt.MapFrom(src => src.Occupations.Select(f => f.OccupationId)));

            CreateMap<JobUpdateDto, Job>()
                .ForMember(v => v.Occupations, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                    // Remove unselected features
                    var removedFeatures = v.Occupations.Where(f => !vr.Occupations.Contains(f.OccupationId)).ToList();
                    foreach (var f in removedFeatures)
                        v.Occupations.Remove(f);

                    // AddAsync new features
                    var addedFeatures = vr.Occupations.Where(id => !v.Occupations.Any(f => f.OccupationId == id)).Select(id => new JobOccupation() { OccupationId = id }).ToList();
                    foreach (var f in addedFeatures)
                        v.Occupations.Add(f);
                });
        }
    }
}
