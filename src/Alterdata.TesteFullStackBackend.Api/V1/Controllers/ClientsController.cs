using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Alterdata.TesteFullStackBackend.Api.V1.Controllers
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClientsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
