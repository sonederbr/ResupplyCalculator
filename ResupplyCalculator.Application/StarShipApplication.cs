using System;
using System.Linq;
using ResupplyCalculator.Domain.Interfaces;

namespace ResupplyCalculator.Application
{
    public class StarShipApplication : IStarShipApplication
    {
        private readonly IStarShipApiRepository _repository;

        public StarShipApplication(IStarShipApiRepository repository) =>
            _repository = repository;

        public void Run()
        {
            Console.WriteLine("Getting all Starships. Waiting a moment please.\n");
            var allStarShip = _repository.GetAll();
            if (allStarShip.Count() == 0)
            {
                Console.WriteLine("Error. Press enter to close...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Done.\n");

            Console.WriteLine("Input the distance for calculate supply:");
            if (long.TryParse(Console.ReadLine(), out long distanceMGLT))
            {
                foreach (var starship in allStarShip)
                {
                    var consumable = starship.CalculateConsumable(distanceMGLT);
                    var consumableVerified = consumable == -1 ? "Unknown" : consumable.ToString();
                    Console.WriteLine($"{starship.Name}: {consumableVerified}");
                }
                Console.WriteLine("\nDone.\nPress enter to close...");
            }
            else
                Console.WriteLine("Input MGLT must be only number.");

            Console.ReadLine();
        }
    }
}
