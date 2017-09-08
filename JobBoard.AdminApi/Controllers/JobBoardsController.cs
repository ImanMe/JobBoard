using AutoMapper;
using JobBoard.AdminApi.Enums;
using JobBoard.Core;
using JobBoard.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.AdminApi.Controllers
{
    [Route("api/jobboards")]
    public class JobBoardsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobBoardsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var jobBoards = await _unitOfWork.JobBoards.GetJobBoards();

            return Ok(_mapper.Map<IEnumerable<JobBoardDto>>(jobBoards));
        }

        [HttpGet("{id}", Name = UriName.JobBoardGet)]
        public async Task<IActionResult> Get(int id)
        {
            var jobBoard = await _unitOfWork.JobBoards.GetJobBoard(id);

            return jobBoard != null
                ? (IActionResult)Ok(_mapper.Map<JobBoardDto>(jobBoard))
                : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]JobBoardCreateDto jobBoardCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var jobBoard = _mapper.Map<Core.Models.JobBoard>(jobBoardCreateDto);

            _unitOfWork.JobBoards.Add(jobBoard);

            await _unitOfWork.Complete();

            var newUri = Url.Link(UriName.JobBoardGet, new { id = jobBoard.Id });

            return Created(newUri, jobBoard);
        }
    }
}
