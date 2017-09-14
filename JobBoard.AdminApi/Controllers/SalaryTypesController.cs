using AutoMapper;
using JobBoard.Core;
using JobBoard.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.AdminApi.Controllers
{
    [Route("api/salaryTypes")]
    public class SalaryTypesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SalaryTypesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ActionResult> Get()
        {
            var salaryTypes = await _unitOfWork.SalaryTypes.GetSalaryTypesAsync();

            return Ok(_mapper.Map<IEnumerable<SalaryTypeDto>>(salaryTypes));
        }
    }
}
