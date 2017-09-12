using AutoMapper;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;

namespace JobBoard.Core.MappingProfiles
{
    public class OccupationMappingProfile : Profile
    {
        public OccupationMappingProfile()
        {
            CreateMap<Occupation, OccupationDto>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OccupationName));
        }        
    }
}
