using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ResupplyCalculator.CrossCutting.Mapper.DtoToDomain;
using ResupplyCalculator.CrossCutting.Mapper.Dto;
using ResupplyCalculator.Domain.Configuration;
using ResupplyCalculator.Domain.Interfaces;
using ResupplyCalculator.Domain.Models.Starships;
using ResupplyCalculator.Infra.Data.Helper;
using System.Collections.Generic;

namespace ResupplyCalculator.Infra.Data.Repository
{
    public class StarShipApiRepository : BaseRestSharp, IStarShipApiRepository
    {
        public StarShipApiRepository(IOptions<AppSettings> config) : base(config) { }

        public IEnumerable<Starship> GetAll()
        {
            var starships = new List<Starship>();
            var starshipDto = new SwApiDto();
            var next = string.Empty;
            do
            {
                var response = Execute(next);
                var content = response.Content;

                if (!response.IsSuccessful) continue;

                starshipDto = JsonConvert.DeserializeObject<SwApiDto>(content);
                MapDtoToDomain.MapStarship(starshipDto.Results, starships);
                next = starshipDto.Next;

            } while (starships.Count < starshipDto.Count);

            
            return starships;
        }
    }
}