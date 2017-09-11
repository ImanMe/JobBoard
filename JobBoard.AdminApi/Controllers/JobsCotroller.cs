using AutoMapper;
using JobBoard.AdminApi.Enums;
using JobBoard.Core;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("{id}", Name = UriName.JobGet)]
        public async Task<IActionResult> Get(long id)
        {
            var job = await _unitOfWork.Jobs.GetJob(id);

            return job != null
                ? Ok(_mapper.Map<JobDto>(job))
                : (IActionResult)NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobFormDto jobFormDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var job = _mapper.Map<Job>(jobFormDto);

            _unitOfWork.Jobs.Add(job);

            await _unitOfWork.Complete();

            var listOfOccupations = jobFormDto.SelectedOccupation
                .Select(occupationId => new JobOccupationDto
                {
                    OccupationId = occupationId,
                    JobId = job.Id
                }).ToList();

            var jobOccupation = _mapper.Map<IEnumerable<JobOccupation>>(listOfOccupations);

            _unitOfWork.JobOccupations.Add(jobOccupation);

            await _unitOfWork.Complete();

            return Ok();
        }
    }
}
