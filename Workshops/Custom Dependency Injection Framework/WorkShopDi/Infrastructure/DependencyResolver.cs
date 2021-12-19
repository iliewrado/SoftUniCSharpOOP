using Microsoft.Extensions.DependencyInjection;
using System;
using WorkShopDi.Contracts;
using WorkShopDi.Core;
using WorkShopDi.Services;

namespace WorkShopDi.Infrastructure
{
    public static class DependencyResolver
    {
        public static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddTransient<IReader, ConsoleReader>()
                .AddTransient<IConsoleWriter, ConsoleWriter>()
                .AddTransient<IFileWriter, FileWriter>()
                .AddTransient<Engine>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
