using AutoMapper;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;

namespace JobBoard.Core.MappingProfiles
{
    public class JobOccupationMappingProfile : Profile
    {
        public JobOccupationMappingProfile()
        {
            CreateMap<JobOccupation, JobOccupationDto>();
            CreateMap<JobOccupationDto, JobOccupation>();
        }
    }
}
