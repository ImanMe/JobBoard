using AutoMapper;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.Core.MappingProfiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
