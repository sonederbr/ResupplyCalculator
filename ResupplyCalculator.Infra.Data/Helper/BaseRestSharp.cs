using Microsoft.Extensions.Options;
using RestSharp;
using ResupplyCalculator.Domain.Configuration;
using ResupplyCalculator.Domain.Interfaces;

namespace ResupplyCalculator.Infra.Data.Helper
{
    public abstract class BaseRestSharp : IBaseRestSharp
    {
        private readonly AppSettings _config;

        protected BaseRestSharp(IOptions<AppSettings> config)
        {
            _config = config.Value;
        }

        public IRestResponse Execute(string resource = "")
        {
            resource = resource == string.Empty ? _config.SwApiUrl : resource;
            IRestClient client = new RestClient(resource);
            IRestRequest request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };
            return client.Execute(request);
        }
    }
}
