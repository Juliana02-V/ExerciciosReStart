using Microsoft.AspNetCore.Mvc;

namespace WeatherService.App.Pages;

public class WeatherFormModel : PageModel
{
    public Weather MyWeather { get; set; }

    private readonly IWeatherService _weatherService;

    [BindProperty]
    public string City { get; set; }
    public string Message { get;set; }

    public WeatherFormModel(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public void OnGet( )
    {
      

    }
    public void OnPost()
    {
        MyWeather = _weatherService.GetWeather(City);   
    }


   /* public RedirectToPageResult OnPost()
    {
        WeatherStackService weatherStackService = new WeatherStackService(City);

        return RedirectToPage("Weather", new { city = City });

    */


}
