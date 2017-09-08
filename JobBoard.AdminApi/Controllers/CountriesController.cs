using AutoMapper;
using JobBoard.Core;
using JobBoard.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.AdminApi.Controllers
{
    [Route("api/countries")]
    public class CountriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(bool includeStates)
        {
            var countries = includeStates
                ? await _unitOfWork.Countries.GetCountriesWithStates()
                : await _unitOfWork.Countries.GetCountries();

            return Ok(_mapper.Map<IEnumerable<CountryDto>>(countries));
        }
    }
}
