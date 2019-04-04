using System;

namespace TvMazeScrapper.Api.Views.Shows
{
    public class PersonView
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
    }
}