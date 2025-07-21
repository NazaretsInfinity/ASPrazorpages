using ASPrazorpages_2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPrazorpages_2.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly IGreetingService _greetingService;

        //public IndexModel(IGreetingService greetingService)
        //{
        //    _greetingService = greetingService;
        //}
        ////service imported!

        //public string? WelcomeMessage { get; set; }

        public void OnGet() //controller
        {
           //WelcomeMessage = _greetingService.GetWelcomeMessage();
        }

    }
}
