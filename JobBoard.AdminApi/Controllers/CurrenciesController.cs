using JobBoard.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.AdminApi.Controllers
{
    [AllowAnonymous]
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
