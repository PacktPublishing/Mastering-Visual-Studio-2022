using WeatherRod.Models;
using WeatherRod.Shared;

namespace Application;
public interface IWeatherService
{
    Task<Result<Weather, string>> GetCurrentWeatherAsync(string location);
}