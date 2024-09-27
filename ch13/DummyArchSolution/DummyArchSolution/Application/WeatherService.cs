using System.Text.Json;
using WeatherRod.Models;
using WeatherRod.Shared;

namespace Application;
public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Result<Weather, string>> GetCurrentWeatherAsync(string location)
    {
        string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";
        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string jsonString = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<Weather>(jsonString);

            if (weatherData != null)
            {
                return weatherData;
            }
            else
            {

                return "Weather data not available";
            }
        }
        else
        {
            throw new Exception($"API request failed with status code: {response.StatusCode}");
        }
    }
}
