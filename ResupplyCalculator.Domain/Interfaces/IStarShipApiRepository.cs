using ResupplyCalculator.Domain.Models.Starships;
using System.Collections.Generic;

namespace ResupplyCalculator.Domain.Interfaces
{
    public interface IStarShipApiRepository
    {
        IEnumerable<Starship> GetAll();
    }
}
