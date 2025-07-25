using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPrazorpages_3.Pages
{
    public class FeedbackModel : PageModel
    {
        public string? Message { get; set; }
        public void OnPost(string? FirstName, string? LastName, string? Text)
        {
            if(FirstName !=null)
            {
                Message = $"Thanks, {FirstName}, for the feedback! Go fuck yourself";
            }
        }
    }
}
