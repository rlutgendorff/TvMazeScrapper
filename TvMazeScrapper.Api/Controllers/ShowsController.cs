using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TvMazeScrapper.Api.Extensions;
using TvMazeScrapper.Api.Views.Shows;
using TvMazeScrapper.Business.MediatR.Queries.Shows;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TvMazeScrapper.Api.Controllers
{
    [Route("api/[controller]")]
    public class ShowsController : Controller
    {
        private readonly IMediator _mediator;

        public ShowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<List<ShowView>>> Get([FromQuery] int page)
        {
            var result = await _mediator.Send(new GetShowsListQuery(page));

            return Ok(result.ToShowViews());
        }
    }
}
