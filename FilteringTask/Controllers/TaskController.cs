using Google.Api.Ads.AdWords.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FilteringTask.Controllers
{
    [Route("api/[controller]")]
   // [ApiController]
        

    public class TaskController : ControllerBase
    {

        [HttpGet]
        [ServiceFilter(typeof(AddResponseHeaderFilter))]
        public IActionResult index()
        {
            // Generate dummy values
         return Ok();
        }
    }
}
