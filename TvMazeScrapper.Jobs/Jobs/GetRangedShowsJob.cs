using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;

namespace TvMazeScrapper.Jobs.Jobs
{
    public class GetRangedShowsJob
    {
        public async Task Handle(int start, int end)
        {
            var current = start;

            while (current <= end)
            {
                BackgroundJob.Enqueue<GetSpecificShowsJob>(j => j.Handle(current));

                current++;
            }
        }
    }
}
