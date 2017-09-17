using AutoMapper;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;

namespace JobBoard.Core.MappingProfiles
{
    public class QueryResultMappingProfile : Profile
    {
        public QueryResultMappingProfile()
        {
            CreateMap(typeof(QueryResult<>), typeof(QueryResultDto<>));
        }
    }
}
