using AutoMapper;
using JobBoard.AdminApi.Enums;
using JobBoard.Core;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JobBoard.AdminApi.Controllers
{
    [Route("api/jobs")]
    [AllowAnonymous]
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
        public async Task<IActionResult> Get(JobQueryDto jobQueryDto)
        {
            var jobQuery = _mapper.Map<JobQuery>(jobQueryDto);
            var queryResult = await _unitOfWork.Jobs.GetJobsAsync(jobQuery);
            return Ok(_mapper.Map<QueryResultDto<JobDto>>(queryResult));

        }

        [HttpGet("{id}", Name = UriName.JobGet)]
        public async Task<IActionResult> Get(long id)
        {
            var job = await _unitOfWork.Jobs.GetJobAsync(id);

            return job != null
                ? Ok(_mapper.Map<JobDto>(job))
                : (IActionResult)NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobCreateDto jobCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var job = _mapper.Map<Job>(jobCreateDto);

            await _unitOfWork.Jobs.AddAsync(job);

            job.CreatedBy = "Iman";

            await _unitOfWork.CompleteAsync();

            var jobDto = _mapper.Map<JobDto>(job);

            var newUri = Url.Link(UriName.JobGet, new { id = job.Id });

            return Created(newUri, jobDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] JobUpdateDto jobUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var job = await _unitOfWork.Jobs.GetJobAsync(id);

            if (job == null) return NotFound();

            _unitOfWork.JobOccupations.Delete(job.Occupations);

            await _unitOfWork.CompleteAsync();

            _mapper.Map(jobUpdateDto, job);

            job.EditedBy = "Iman";

            job.EditedDate = DateTime.Now.Date;

            _unitOfWork.Jobs.Edit(job);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
