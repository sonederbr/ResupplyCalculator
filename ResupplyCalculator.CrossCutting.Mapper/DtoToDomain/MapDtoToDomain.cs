using System.Collections.Generic;
using ResupplyCalculator.CrossCutting.Mapper.Dto;
using ResupplyCalculator.Domain.Models.Starships;

namespace ResupplyCalculator.CrossCutting.Mapper.DtoToDomain
{
    public static class MapDtoToDomain
    {
        public static void MapStarship(IEnumerable<StarshipDto> starshipDto, List<Starship> starships)
        {
            foreach (var dto in starshipDto)
            {
                int.TryParse(dto.MGLT, out var mGLT);
                starships.Add(new Starship(
                    dto.Name, mGLT, dto.Model, new Consumable(dto.Consumables))
                );
            }
        }
    }
}
