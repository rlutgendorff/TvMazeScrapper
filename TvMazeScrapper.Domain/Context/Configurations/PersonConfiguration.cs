using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TvMazeScrapper.Domain.Models;

namespace TvMazeScrapper.Domain.Context.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name)
                .HasMaxLength(255);
            builder
                .HasOne(b => b.Show)
                .WithMany(b => b.Persons);
        }
    }
}
