using System;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using TvMazeScrapper.Business.Connectors;
using TvMazeScrapper.Domain.Bootstrapper;

namespace TvMazeScrapper.Business.Bootstrapper
{
    public static class BusinessBootstrapper
    {
        public static IServiceCollection AddBusiness(this IServiceCollection service, IConfiguration configuration)
        {
            var config = configuration.GetSection("TvMaze")
                .Get<TvMazeConfiguration>();

            var policy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(response => (int)response.StatusCode == 429)
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(5),
                });

            service.AddTransient<ITvMazeConnector, TvMazeConnector>();
            service.AddHttpClient<ITvMazeConnector, TvMazeConnector>(client =>
            {
                client.BaseAddress = new Uri(config.Endpoint);
            }).AddPolicyHandler(policy);

            service.AddMediatR();

            service.AddDomain(configuration);

            return service;
        }
    }
}
