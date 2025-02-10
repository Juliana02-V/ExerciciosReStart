namespace WeatherService.App.Models;

public class Weather
{
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public double Temperature { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Example: "https://cdn.worldweatheronline.com/images/wsymbols01_png_64/wsymbol_0004_black_low_cloud.png"
    public string Icon { get; set; }
    public string Source { get; set; }
}
