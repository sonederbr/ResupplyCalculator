using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResupplyCalculator.Application;
using ResupplyCalculator.Domain.Configuration;
using ResupplyCalculator.Domain.Interfaces;
using ResupplyCalculator.Infra.Data.Helper;
using ResupplyCalculator.Infra.Data.Repository;
using System;
using System.IO;

namespace ResupplyCalculator.Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app-settings.json", false)
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<AppSettings>(configuration.GetSection("Configuration"));
            ConfigureConsole(configuration);
            
            serviceCollection.AddSingleton<IStarShipApplication, StarShipApplication>();
            serviceCollection.AddSingleton<IStarShipApiRepository, StarShipApiRepository>();

            return serviceCollection;
        }

        private static void ConfigureConsole(IConfigurationRoot configuration)
        {
            Console.Title = configuration.GetSection("Configuration:ConsoleName").Value;
        }
    }
}
