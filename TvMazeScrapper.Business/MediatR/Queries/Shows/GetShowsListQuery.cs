using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TvMazeScrapper.Business.MediatR.Responses.Shows;
using TvMazeScrapper.Domain.Context;

namespace TvMazeScrapper.Business.MediatR.Queries.Shows
{
    public class GetShowsListQuery : IRequest<List<ShowResponse>>
    {
        public GetShowsListQuery(int page)
        {
            Page = page;
        }

        public int Page { get; }

        internal int Size => 10;
        internal int Skip => (Page * Size) - Page;
    }

    public class GetShowsListQueryHandler : IRequestHandler<GetShowsListQuery, List<ShowResponse>>
    {
        private readonly TvMazeContext _context;

        public GetShowsListQueryHandler(TvMazeContext context)
        {
            _context = context;
        }

        public async Task<List<ShowResponse>> Handle(GetShowsListQuery request, CancellationToken cancellationToken)
        {
            var result = 
                await _context.Shows
                    .Skip(request.Skip)
                    .Take(request.Size)
                    .Include(s => s.Persons)
                    .Select(s => new ShowResponse
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Cast = s.Persons.Select(p =>
                            new ShowCastResponse {Id = p.Id, Name = p.Name, Birthday = p.BirthDate}).ToList()
                    })
                    .ToListAsync(cancellationToken);

            return result;
        }
    }
}
