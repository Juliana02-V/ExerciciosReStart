using WeatherService.App.Models;

namespace WeatherService.App.Services;

public interface IWeatherService
{
    Weather GetWeather(string region);
}