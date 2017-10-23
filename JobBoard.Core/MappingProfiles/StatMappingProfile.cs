using AutoMapper;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;

namespace JobBoard.Core.MappingProfiles
{
    public class StatMappingProfile : Profile
    {
        public StatMappingProfile()
        {
            CreateMap<StatDto, Stat>();
            CreateMap<Stat, StatDto>();
            CreateMap<StatCreateDto, Stat>();
            CreateMap<StatUpdateDto, Stat>();
        }
    }
}
