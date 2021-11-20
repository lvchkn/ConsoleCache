using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ConsoleCache.Cache;
using ConsoleCache.Commands;
using ConsoleCache.Parsers;
using ConsoleCache.Runners;
using System;
using ConsoleCache.Presentation;

namespace ConsoleCache.Configuration
{
    public static class DI
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void Configure()
        {
            var host = new HostBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.AddHttpClient()
                            .AddScoped<ICache, LruCache>()
                            .AddScoped<Printer>()
                            .AddScoped<GetCommand>()
                            .AddScoped<PutCommand>()
                            .AddScoped<PrintCommand>()
                            .AddScoped<CommandParser>()
                            .AddScoped<CommandLineEventsPublisher>();
                })
                .UseConsoleLifetime()
                .Build();

            ServiceProvider = host.Services;
        }
    }
}
