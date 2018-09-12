using System;
using ResupplyCalculator.Domain.Enums;

namespace ResupplyCalculator.Domain.Models.Starships
{
    public class Starship
    {
        private const short ErrorNumber = -1;

        public Starship(string name, int mglt, string model, Consumable consumable)
        {
            Name = name;
            MGLT = mglt;
            Model = model;
            Consumable = consumable;
        }

        public string Name { get; private set; }
        public int MGLT { get; private set; }
        public string Model { get; set; }
        public Consumable Consumable { get; private set; }

        public long CalculateConsumable(long distanceMGLT)
        {
            if (Consumable.Period == EPeriod.Unknown || MGLT == 0)
                return ErrorNumber;
            
            return Math.Abs(distanceMGLT / (Consumable.GetTotalHours() * MGLT));
        }
    }
}