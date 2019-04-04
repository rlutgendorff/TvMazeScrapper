using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TvMazeScrapper.Domain.Context;
using TvMazeScrapper.Domain.Models;

namespace TvMazeScrapper.Business.MediatR.Commands.Shows
{
    public class AddShowCommand : IRequest
    {
        public string Name { get; set; }
        public List<AddShowCommandPerson> Cast { get; set; }
    }

    public class AddShowCommandPerson
    {
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
    }

    public class AddShowCommandHandler : IRequestHandler<AddShowCommand>
    {
        private readonly TvMazeContext _context;

        public AddShowCommandHandler(TvMazeContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddShowCommand request, CancellationToken cancellationToken)
        {
            await _context.Shows.AddAsync(new Show
            {
                Name = request.Name,
                Persons = request.Cast.Select(c=> new Person{
                    Name = c.Name,
                    BirthDate = c.Birthday
                    }).ToList()
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
