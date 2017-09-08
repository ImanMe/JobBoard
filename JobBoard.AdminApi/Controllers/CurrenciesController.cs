using JobBoard.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.AdminApi.Controllers
{
    [Route("api/currencies")]
    public class CurrenciesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Currency.Types);
        }
    }
}
