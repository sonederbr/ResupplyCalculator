using Microsoft.Extensions.DependencyInjection;
using ResupplyCalculator.Infra.CrossCutting.IoC;

namespace ResupplyCalculator.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            NativeInjector.ConfigureServices(serviceCollection);

            // add app
            serviceCollection.AddTransient<App>();
            
            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // run app
            serviceProvider.GetService<App>().Run();
        }
    }
}
