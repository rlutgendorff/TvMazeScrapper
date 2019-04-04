using System.Collections.Generic;

namespace TvMazeScrapper.Domain.Models
{
    public class Show
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
