namespace WeatherService.App.Services;

public class RandomWeatherService : IWeatherService
{
    private readonly Random _rnd = new();

    public Weather GetWeather(string region)
    {
        return new Weather
        {
            Lat = _rnd.NextDouble() * 180 - 90,
            Lon = _rnd.NextDouble() * 360 - 180,
            Country = "Random Country",
            Region = region,
            Temperature = _rnd.NextDouble() * 100,
            UpdatedAt = DateTime.UtcNow.AddMinutes(-_rnd.Next(100)),
            Icon = "https://cdn.worldweatheronline.com/images/wsymbols01_png_64/wsymbol_0004_black_low_cloud.png",
            Source = "Random"
        };
    }
}
