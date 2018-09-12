using ResupplyCalculator.Domain.Models.Starships;
using Xunit;

namespace ResupplyCalculator.Test.Domain
{
    public class StarshipDomainTest
    {
        [Theory]
        [InlineData("Executor", 1000000, "6 Year", 40, 0)]
        [InlineData("Sentinel-class landing craft", 1000000, "1 Month", 70, 19)]
        [InlineData("Death Star", 1000000, "3 Years", 10, 3)]
        [InlineData("Millennium Falcon", 1000000, "2 Month", 75, 9)]
        [InlineData("Y-wing", 1000000, "1 Week", 80, 74)]
        [InlineData("X-wing", 1000000, "1 Weeks", 100, 59)]
        [InlineData("TIE Advanced x1", 1000000, "5 Day", 105, 79)]
        [InlineData("Slave 1", 1000000, "1 Months", 70, 19)]
        [InlineData("Republic Cruiser", 1000000, "xyz", 0, -1)]
        [InlineData("Naboo fighter", 1000000, "7 Days", 0, -1)]
        [InlineData("Naboo Royal Starship", 1000000, "abc", 0, -1)]
        [InlineData("Naboo Royal Starship", 0, "7 Days", 20, 0)]
        public void Should_Be_Calculate_Comsumable(string name, long distance, string consumableApi, int MGLT,
            long expected)
        {
            var consumable = new Consumable(consumableApi);
            var starship = new Starship(name, MGLT, string.Empty, consumable);

            var result = starship.CalculateConsumable(distance);

            Assert.Equal(result, expected);
        }
    }
}