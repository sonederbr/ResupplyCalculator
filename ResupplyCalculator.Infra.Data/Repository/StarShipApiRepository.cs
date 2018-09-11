using System.Collections.Generic;
using Microsoft.Extensions.Options;
using RestSharp;
using ResupplyCalculator.Domain.Configuration;
using ResupplyCalculator.Domain.Interfaces;
using ResupplyCalculator.Domain.Models.Starships;

namespace ResupplyCalculator.Infra.Data.Repository
{
    public class StarShipApiRepository : IStarShipApiRepository
    {
        private readonly AppSettings _config;

        public StarShipApiRepository(IOptions<AppSettings> config)
        {
            _config = config.Value;
        }

        public ICollection<Starship> GetAll()
        {
            IRestClient client = new RestClient(_config.SwApiUrl);
            IRestRequest request = new RestRequest(Method.GET) { RequestFormat =  DataFormat.Json };
            var result = client.Execute(request);
           
            return new List<Starship>();
        }
    }
}
