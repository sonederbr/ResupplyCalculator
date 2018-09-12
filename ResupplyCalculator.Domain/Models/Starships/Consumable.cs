using ResupplyCalculator.Domain.Enums;
using System;
using System.Linq;

namespace ResupplyCalculator.Domain.Models.Starships
{
    public class Consumable
    {
        private const short HoursDay = 24, ErrorNumber = -1;

        public Consumable(string consumableApi) =>
            SetConsumable(consumableApi);
        
        public int Quantity { get; private set; }
        public EPeriod Period { get; private set; }

        public int GetTotalHours() => 
            (Period != EPeriod.Unknown) ? (Quantity * HoursDay * (int)Period) : ErrorNumber;
        
        private void SetConsumable(string consumable)
        {
            const short lenghtArrayConsumable = 2;
            var consumableSplited = consumable.Split(" ");
            if (consumableSplited.Length != lenghtArrayConsumable)
            {
                Quantity = 0;
                Period = EPeriod.Unknown;
                return;
            }

            Quantity = Convert.ToInt32(consumableSplited[0]);
            var period = consumableSplited[1].ToLower();
            Period = Enum.GetValues(typeof(EPeriod)).Cast<EPeriod>()
                     .FirstOrDefault(x => period.Contains(x.ToString().ToLower()));
        }
    }
}
