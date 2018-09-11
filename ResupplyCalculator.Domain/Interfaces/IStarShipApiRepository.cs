using System.Collections;
using System.Collections.Generic;
using ResupplyCalculator.Domain.Models.Starships;

namespace ResupplyCalculator.Domain.Interfaces
{
    public interface IStarShipApiRepository
    {
        ICollection<Starship> GetAll();
    }
}
