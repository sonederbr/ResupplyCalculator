using ResupplyCalculator.Domain.Enums;
using ResupplyCalculator.Domain.Models.Starships;
using Xunit;

namespace ResupplyCalculator.Test.Domain
{
    public class ComsumableDomainTest
    {
        [Theory]
        [InlineData("1 Day", 1, EPeriod.Day)]
        [InlineData("1 Days", 1, EPeriod.Day)]
        [InlineData("1 days", 1, EPeriod.Day)]
        [InlineData("1 Week", 1, EPeriod.Week)]
        [InlineData("1 Weeks", 1, EPeriod.Week)]
        [InlineData("1 weeks", 1, EPeriod.Week)]
        [InlineData("1 Month", 1, EPeriod.Month)]
        [InlineData("1 Months", 1, EPeriod.Month)]
        [InlineData("1 months", 1, EPeriod.Month)]
        [InlineData("1 Year", 1, EPeriod.Year)]
        [InlineData("1 Years", 1, EPeriod.Year)]
        [InlineData("1 years", 1, EPeriod.Year)]
        [InlineData("2 xyz", 2, EPeriod.Unknown)]
        [InlineData("abc", 0, EPeriod.Unknown)]
        [InlineData("", 0, EPeriod.Unknown)]
        public void Should_Be_Convert_ComsumableApi_To_Enumerator_And_Quantity(string consumableApi, int expectedQuantity, EPeriod expectedPeriod)
        {
            var consumable = new Consumable(consumableApi);
            Assert.Equal(expectedQuantity, consumable.Quantity);
            Assert.Equal(expectedPeriod, consumable.Period);
        }

        [Theory]
        [InlineData("1 Day", 24)]
        [InlineData("2 Day", 48)]
        [InlineData("1 Week", 168)]
        [InlineData("2 Week", 336)]
        [InlineData("1 Month", 720)]
        [InlineData("2 Month", 1440)]
        [InlineData("1 Year", 8760)]
        [InlineData("2 Year", 17520)]
        [InlineData("1 abc", -1)]
        [InlineData("abc", -1)]
        [InlineData("", -1)]
        public void Should_Be_Calculate_Hours_Correctaly(string consumableApi, int expected)
        {
            var consumable = new Consumable(consumableApi);
            var totalHours = consumable.GetTotalHours();
            Assert.Equal(expected, totalHours);
        }
    }
}