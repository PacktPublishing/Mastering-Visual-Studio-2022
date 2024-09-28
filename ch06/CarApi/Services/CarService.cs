using CarApi.Data.Entities;
using CarApi.Repositories;

namespace CarApi.Services
{
    public class CarService(CarRepository _carRepository)
    {
        public async Task<Car> Insert(Car car)

        {
            var newId = await _carRepository.UpsertAsync(car);

            if (newId > 0)

            {
                car.Id = newId;
            }
            else
            {
                throw new Exception("Failed to insert car");
            }

            return car;

        }
    }
}
