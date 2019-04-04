using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TvMazeScrapper.Domain.Context;

namespace TvMazeScrapper.Domain.Bootstrapper
{
    public static class DomainBootstrapper
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TvMazeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TvMazeContext")));



            return services;
        }

    }
}
