using System.Collections.Generic;

namespace ResupplyCalculator.CrossCutting.Mapper.Dto
{
    public class SwApiDto
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public IEnumerable<StarshipDto> Results { get; set; }
    }
}
