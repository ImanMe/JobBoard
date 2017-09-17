using AutoMapper;
using JobBoard.Core;
using JobBoard.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.AdminApi.Controllers
{
    [Route("api/countries")]
    [AllowAnonymous]
    public class StatesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{countryId}/states")]
        public async Task<IActionResult> Get(int countryId)
        {
            var country = await _unitOfWork.Countries.GetCountryAsync(countryId);
            if (country == null)
                return NotFound($"Country with the Id: {countryId} is not found");

            var states = await _unitOfWork.States.GetStatesByCountryIdAsync(countryId);

            return states != null
                ? (IActionResult)Ok(_mapper.Map<IEnumerable<StateDto>>(states))
                : BadRequest();
        }
    }
}
