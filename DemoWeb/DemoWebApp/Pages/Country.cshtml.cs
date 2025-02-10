using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoWebApp.Pages;

public class CountryModel : PageModel
{
    public List<string> Countries { get; set; }
    public void OnGet()
    {
        Countries = new List<string>() { "Alaska", "IndonÚsia", "Us", "Brasil", "Coreia do Sul", "Portugal"};
    }


}
