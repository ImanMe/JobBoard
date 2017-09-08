using JobBoard.Core;
using JobBoard.Core.DTOs;
using JobBoard.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.AdminApi.Controllers
{
    [Route("api/jobs")]
    public class JobsCotroller : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobsCotroller(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var jobs = await _unitOfWork.Jobs.GetJobs();
            var x = jobs.Select(Factory);
            return Ok(x);
        }

        [HttpGet("{id}", Name = "JobGet")]
        public IActionResult Get(int id)
        {
            var country = _unitOfWork.Countries.GetCountry(id);

            return country != null ? (IActionResult)Ok(country) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Country model)
        {
            _unitOfWork.Countries.Add(model);

            if (await _unitOfWork.Complete() <= 0) return BadRequest();

            var newUri = Url.Link("JobGet", new { id = model.Id });

            return Created(newUri, model);
        }

        public static JobDto Factory(Job job)
        {
            return new JobDto()
            {
                Id = job.Id,
                Title = job.Title,
                Country = job.Country.CountryCode
            };
        }
    }
}
