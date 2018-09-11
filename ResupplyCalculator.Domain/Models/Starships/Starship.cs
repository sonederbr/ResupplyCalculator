using System;
using System.Reflection.Metadata.Ecma335;

namespace ResupplyCalculator.Domain.Models.Starships
{
    public class Starship
    {
        public string MGLT { get; private set; }
        public string CargoCapacity { get; private set; }
        public string Consumables { get; private set; }
        public string CostInCredits { get; set; }
        public DateTime Created { get; set; }
        public string Crew { get; set; }
        public DateTime Edited { get; set; }
        public string HyperdriveRating { get; set; }
        public string Length { get; set; }
        public string Manufacturer { get; set; }
        public string MaxAtmospheringSpeed { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Passengers { get; set; }
        public string StarshipClass { get; set; }
        public string Url { get; set; }

        public long CalculateConsumable(long distance)
        {
            return 10;
        }
    }
}