using AutoMapper;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;

namespace JobBoard.Core.MappingProfiles
{
    public class JobQueryMappingProfile : Profile
    {
        public JobQueryMappingProfile()
        {
            CreateMap<JobQueryDto, JobQuery>();
        }
    }
}
