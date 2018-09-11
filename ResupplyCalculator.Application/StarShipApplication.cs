using ResupplyCalculator.Domain.Interfaces;

namespace ResupplyCalculator.Application
{
    public class StarShipApplication : IStarShipApplication
    {
        private readonly IStarShipApiRepository _repository;
        public StarShipApplication(IStarShipApiRepository repository)
        {
            _repository = repository;
        }

        public void Run()
        {
            var teste = _repository.GetAll();
        }
    }
}
