using AutoMapper;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.Core.MappingProfiles
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Country, CountryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CountryName))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.CountryCode));
        }
    }
}
