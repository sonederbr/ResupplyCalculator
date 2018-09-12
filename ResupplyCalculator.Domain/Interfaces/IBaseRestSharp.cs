using RestSharp;

namespace ResupplyCalculator.Domain.Interfaces
{
    public interface IBaseRestSharp
    {
        IRestResponse Execute(string endpoint = "");
    }
}
