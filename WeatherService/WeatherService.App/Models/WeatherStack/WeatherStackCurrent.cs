using System.Text.Json.Serialization;

namespace WeatherService.App.Models.WeatherStack;

public class WeatherStackCurrent
{
    public Current Current { get; set; }
    public Location Location { get; set; }
    public Request Request { get; set; }
}

public class Current
{
    public double temperature { get; set; }

    [JsonPropertyName("weather_icons")]
    public string[] weatherIcons { get; set; }


}

public class Location
{
    public string country { get; set; }
    public string name { get; set; }
    public string region { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public string localtime { get; set; }

}


public class Request
{
    public string query { get; set; }  
    public string languange { get; set; }
}