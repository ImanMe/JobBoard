using AutoMapper;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;

namespace JobBoard.Core.MappingProfiles
{
    public class SalaryTypeMappingProfile : Profile
    {
        public SalaryTypeMappingProfile()
        {
            CreateMap<SalaryType, SalaryTypeDto>();
        }
    }
}
