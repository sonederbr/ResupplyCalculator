using System.Net;
using Moq;
using RestSharp;
using ResupplyCalculator.Domain.Configuration;
using ResupplyCalculator.Domain.Interfaces;
using ResupplyCalculator.Infra.Data.Repository;
using Xunit;

namespace ResupplyCalculator.Test.Repository
{
    public class StarshipRepositoryTest
    {
        private readonly AppSettings _settingsMock;
        private Mock<IBaseRestSharp> _baseRestSharp;
        private IRestResponse _restResponse;

        public StarshipRepositoryTest()
        {
            _settingsMock = new AppSettings() { SwApiUrl = "https://swapi.co/api/starships", ConsoleName = "Test" };
        }

        [Fact]
        public void Test1()
        {
            _restResponse = new RestResponse
            {
                StatusCode = HttpStatusCode.OK,
                Content = ResponseStub.GetStarShips()
            };
            _baseRestSharp = new Mock<IBaseRestSharp>();
            _baseRestSharp.Setup(s => s.Execute(It.IsAny<string>())).Returns(_restResponse);
            
            //_baseRestSharp
            
            
            //var repository = new StarShipApiRepository(null);
            //repository.GetAll();



        }

        //Repository
        //StarShipApiRepository

        //Domain
        //Starship
        //Consumable

        //Application
        //??
    }
}
