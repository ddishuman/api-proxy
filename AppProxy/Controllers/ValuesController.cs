using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppProxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Index()
        {
            return "value1";
        }

        [HttpGet]
        [Route("testget")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
