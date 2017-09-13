using AutoMapper;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;

namespace JobBoard.Core.MappingProfiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName));
        }
    }
}
