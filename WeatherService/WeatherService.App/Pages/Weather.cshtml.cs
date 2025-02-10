namespace WeatherService.App.Pages;

public class WeatherModel : PageModel
{
    public Weather MyWeather { get; set; }
    private readonly WeatherServiceFactory _weatherFactory;
    public WeatherModel(WeatherServiceFactory weatherFactory)
    {
        _weatherFactory = weatherFactory;
    }

    public void OnGet(string city)
    {
        var weatherService = _weatherFactory.CreateWeatherService(city);
        MyWeather = weatherService.GetWeather(city);
    }
}