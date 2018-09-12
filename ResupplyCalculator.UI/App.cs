using System;
using Microsoft.Extensions.Options;
using ResupplyCalculator.Domain.Configuration;
using ResupplyCalculator.Domain.Interfaces;

namespace ResupplyCalculator.UI
{
    public class App
    {
        private readonly IStarShipApplication _application;
        private readonly AppSettings _config;

        public App(IStarShipApplication application,
            IOptions<AppSettings> config)
        {
            _application = application;
            _config = config.Value;
        }

        public void Run()
        {
            Console.WriteLine($"{_config.ConsoleName}. This is a console application for {_config.SwApiUrl}");
            _application.Run();
            Console.ReadKey();
        }
    }
}
