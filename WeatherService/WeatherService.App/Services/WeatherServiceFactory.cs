namespace WeatherService.App.Services;

public class WeatherServiceFactory
{
   /* private readonly string[] _random = {"Lisboa", "Porto", "Faro", "Aveiro", "Coimbra", "Braga", "Funchal", "Ponta Delgada", "Vila Real", "Viseu" };
    public Weather onGet(string region)
    {
        if (region == "Random")
        {

            return new RandomWeatherService().GetWeather(region);
        }
        else
        {
            return new WeatherStackService(region).GetWeather(region);
        }
    }*/

    static string[] cities = { "Lisboa", "Porto", "Faro" };
    private IConfiguration _configuration;

    public WeatherServiceFactory(IConfiguration configuration )
    {
        _configuration = configuration;
    }
    /* public IWeatherService CreateWeatherService(string city)
       {
           if (cities.Contains (city ))
           {
               return new RandomWeatherService();
           }
           else
           {
               return new WeatherStackService(_configuration);
           }
       }*/
    public IWeatherService CreateWeatherService(string city)
    {
        return cities.Contains(city)
            ? new RandomWeatherService()
            : new WeatherStackService(_configuration);
    }

}
