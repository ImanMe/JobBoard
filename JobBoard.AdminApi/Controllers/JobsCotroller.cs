using AutoMapper;
using JobBoard.Core;
using JobBoard.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.AdminApi.Controllers
{
    [Route("api/jobs")]
    public class JobsCotroller : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobsCotroller(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var jobs = await _unitOfWork.Jobs.GetJobs();
            return Ok(_mapper.Map<IEnumerable<JobDto>>(jobs));
        }

        [HttpGet("{id}", Name = "JobGet")]
        public async Task<IActionResult> Get(long id)
        {
            var job = await _unitOfWork.Jobs.GetJob(id);

            return job != null
                ? Ok(_mapper.Map<JobDto>(job))
                : (IActionResult)NotFound();
        }
    }
}
