using System;

namespace TvMazeScrapper.Domain.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual Show Show { get; set; }
    }
}