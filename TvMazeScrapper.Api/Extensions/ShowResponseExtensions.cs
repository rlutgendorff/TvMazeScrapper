using System.Collections.Generic;
using System.Linq;
using TvMazeScrapper.Api.Views.Shows;
using TvMazeScrapper.Business.MediatR.Responses.Shows;

namespace TvMazeScrapper.Api.Extensions
{
    public static class ShowResponseExtensions
    {
        public static IEnumerable<ShowView> ToShowViews(this IEnumerable<ShowResponse> responses)
        {
            return responses.Select(r => r.ToShowView());
        }

        public static ShowView ToShowView(this ShowResponse response)
        {
            return new ShowView
            {
                Id = response.Id,
                Name = response.Name,
                Cast = response.Cast.Select(c => new PersonView
                {
                    Id = c.Id,
                    Name = c.Name,
                    Birthday = c.Birthday
                }).OrderByDescending(o => o.Birthday).ToList()
            };
        }
    }
}
