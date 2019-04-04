using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TvMazeScrapper.Domain.Context
{
    public class TvMazeContextFactory : IDesignTimeDbContextFactory<TvMazeContext>
    {
        public TvMazeContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TvMazeContext>();

            builder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=TvMaze;User Id=TvMaze;Password=TvMaze;");

            return new TvMazeContext(builder.Options);
        }
    }
}
