using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherService.App.Models.WeatherStack;

namespace WeatherService.App.Services;

public class WeatherStackService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "";
    private readonly string _apiKey = "";
    private string city;
    private IConfiguration configuration;

    public WeatherStackService(string city)
    {
        city = city;
    }

       public WeatherStackService(IConfiguration configuration)
    {
       
        _baseUrl = configuration.GetValue<string>("WeatherStack:BaseUrl");
        _apiKey = configuration.GetValue<string>("WeatherStack:ApiKey");

    }

    public Weather GetWeather(string region)
    {
        var endpoint = $"{_baseUrl}/current?access_key={_apiKey}&query={region ?? "New York"}";

        var client = new RestClient(endpoint);
        var request = new RestRequest("", Method.Get);

        var response = client.Execute<WeatherStackCurrent>(request);

        if (response.IsSuccessful == false)
        {
            throw new Exception("Failed to get weather data");
        }
        

        var json = response.Content;

        var data = response.Data;
                       

        return new Weather()
        {
            Temperature = data.Current.temperature,
            Icon = data.Current.weatherIcons.FirstOrDefault() ?? string.Empty,
            Country = data.Location.country,
            Name = data.Location.name,
            Region = data.Location.region,
            Lat = data.Location.lat,
            Lon = data.Location.lon,
            UpdatedAt = DateTime.Parse(data.Location.localtime),
            Source = "By Stack Service"
        };

        /*var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };*/


    }
}