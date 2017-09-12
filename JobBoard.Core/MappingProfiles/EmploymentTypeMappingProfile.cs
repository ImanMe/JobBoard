using AutoMapper;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;

namespace JobBoard.Core.MappingProfiles
{
    public class EmploymentTypeMappingProfile : Profile
    {
        public EmploymentTypeMappingProfile()
        {
            CreateMap<EmploymentType, EmploymentTypeDto>();
        }
    }
}
