using AutoMapper;
using JobBoard.AdminApi.Enums;
using JobBoard.Core;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;
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

        [HttpGet("{id}", Name = UriName.JobGet)]
        public async Task<IActionResult> Get(long id)
        {
            var job = await _unitOfWork.Jobs.GetJob(id);

            return job != null
                ? Ok(_mapper.Map<JobDto>(job))
                : (IActionResult)NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobCreateDto jobCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var job = _mapper.Map<Job>(jobCreateDto);

            _unitOfWork.Jobs.Add(job);

            await _unitOfWork.Complete();

            var jobDto = _mapper.Map<JobDto>(job);

            var newUri = Url.Link(UriName.JobGet, new { id = job.Id });

            return Created(newUri, jobDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] JobUpdateDto jobUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var job = await _unitOfWork.Jobs.GetJob(id);

            if (job == null) return NotFound();

            _unitOfWork.JobOccupations.Delete(job.Occupations);

            await _unitOfWork.Complete();

            _mapper.Map(jobUpdateDto, job);

            _unitOfWork.Jobs.Edit(job);

            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}
