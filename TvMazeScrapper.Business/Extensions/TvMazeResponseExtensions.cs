using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TvMazeScrapper.Business.Connectors.TvMaze.Response;
using TvMazeScrapper.Business.MediatR.Commands.Shows;

namespace TvMazeScrapper.Business.Extensions
{
    public static class TvMazeResponseExtensions
    {
        public static AddShowCommand ToAddShowCommand(this TvMazeResponse response)
        {
            return new AddShowCommand
            {
                Name = response.name,
                Cast = response._embedded.cast.Select(c => new AddShowCommandPerson
                {
                    Name = c.person.name,
                    Birthday = c.person.birthday
                }).ToList()
            };
        }
    }
}
