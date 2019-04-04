using System.Collections.Generic;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using TvMazeScrapper.Jobs.Jobs;

namespace TvMazeScrapper.Jobs.Controllers
{
    [Route("api/[controller]")]
    public class JobsController : Controller
    {
        [HttpGet]
        public async Task Get([FromQuery] int start, [FromQuery] int end)
        {
            BackgroundJob.Enqueue<GetRangedShowsJob>(e => e.Handle(start, end));
        }
        
    }
}