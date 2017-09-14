using AutoMapper;
using JobBoard.AdminApi.Enums;
using JobBoard.Core;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobBoard.AdminApi.Controllers
{
    [Route("api")]
    public class StatsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("jobs/{jobId}/stats", Name = UriName.StatGet)]
        public async Task<IActionResult> Get(int jobId)
        {
            var stat = await _unitOfWork.Stats.GetStatByJobIdAsync(jobId);
            if (stat == null) return NotFound();
            return Ok(_mapper.Map<StatDto>(stat));
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody]IEnumerable<StatCreateDto> statsCreateDto)
        //{
        //    if (!ModelState.IsValid) return BadRequest();

        //    var stats = _mapper.Map<List<Stat>>(statsCreateDto);

        //    await _unitOfWork.Stats.AddAsync(stats);

        //    await _unitOfWork.CompleteAsync();

        //    return Ok();
        //}

        [HttpPost("stats")]
        public async Task<IActionResult> Post([FromBody]StatCreateDto statsCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var stat = _mapper.Map<Stat>(statsCreateDto);

            await _unitOfWork.Stats.AddAsync(stat);

            await _unitOfWork.CompleteAsync();

            var statDto = _mapper.Map<StatDto>(stat);

            var newUri = Url.Link(UriName.StatGet, new { jobId = stat.JobId });

            return Created(newUri, statDto);
        }

        [HttpPut("stats/{jobId}")]
        public async Task<IActionResult> Put(int jobId, [FromBody] StatUpdateDto statUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var stat = await _unitOfWork.Stats.GetStatByJobIdAsync(jobId);

            if (stat == null) return NotFound();

            _mapper.Map(statUpdateDto, stat);

            _unitOfWork.Stats.Edit(stat);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
