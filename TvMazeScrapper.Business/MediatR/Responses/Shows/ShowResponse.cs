using System;
using System.Collections.Generic;

namespace TvMazeScrapper.Business.MediatR.Responses.Shows
{
    public class ShowResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ShowCastResponse> Cast { get; set; }
    }

    public class ShowCastResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
