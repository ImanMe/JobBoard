using AutoMapper;
using JobBoard.Core.DTOs;

namespace JobBoard.Core.MappingProfiles
{
    public class JobBoardMappingProfile : Profile
    {
        public JobBoardMappingProfile()
        {
            CreateMap<Models.JobBoard, JobBoardDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.JobBoardName));
            
            CreateMap<JobBoardCreateDto, Models.JobBoard>()
                .ForMember(dest => dest.JobBoardName, opt => opt.MapFrom(src => src.Name));

            CreateMap<JobBoardUpdateDto, Models.JobBoard>()
                .ForMember(dest => dest.JobBoardName, opt => opt.MapFrom(src => src.Name));
        }        
    }
}
