using System.Threading.Tasks;
using MediatR;
using TvMazeScrapper.Business.Connectors;
using TvMazeScrapper.Business.Extensions;

namespace TvMazeScrapper.Jobs.Jobs
{
    public class GetSpecificShowsJob
    {
        private readonly ITvMazeConnector _connector;
        private readonly IMediator _mediator;

        public GetSpecificShowsJob(ITvMazeConnector connector, IMediator mediator)
        {
            _connector = connector;
            _mediator = mediator;
        }

        public async Task Handle(int id)
        {
            var result = await _connector.GetShow(id);

            if (result != null)
            {
                await _mediator.Send(result.ToAddShowCommand());
            }

        }
    }
}
