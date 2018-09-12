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
            Console.WriteLine("Input the MGLT distance for calculate supply:"); 
            if (long.TryParse(Console.ReadLine(), out var distanceMGLT))
                CalculateDistance(distanceMGLT);
            else
                InputDistance();

            Console.ReadLine();
        }

        private void InputDistance()
        {
            Console.WriteLine("MGLT distance must be only number.");
            Console.WriteLine("Input the MGLT distance for calculate supply:"); 
            if (long.TryParse(Console.ReadLine(), out var distanceMGLT))
                CalculateDistance(distanceMGLT);
            else
                InputDistance();
        }

        private void CalculateDistance(long distanceMGLT)
        {
            Console.WriteLine("Getting all Starships. Waiting a moment please.\n");
            var allStarShip = _repository.GetAll();
            if (!allStarShip.Any())
            {
                Console.WriteLine("Error getting Starships. Press enter to close...\n");
                Console.ReadLine();
                return;
            }

            foreach (var starship in allStarShip)
            {
                var consumable = starship.CalculateConsumable(distanceMGLT);
                var consumableVerified = consumable == -1 ? "Unknown" : consumable.ToString();
                Console.WriteLine($"{starship.Name}: {consumableVerified}");
            }
            Console.WriteLine("\nDone.\nPress enter to close...");
        }
    }
}
