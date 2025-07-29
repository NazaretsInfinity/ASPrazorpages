using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CalculatorASP.Pages
{
    public class AuthData
    {
        [MinLength(3, ErrorMessage = "Имя должно содержать хотя бы 3 символа")]
        public required string FirstName { get; set; }
        public string? LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression("[\\+78]\\d{10}")]
        public required string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public required string Password {  get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))] 
        public required string ConfirmedPassword {  get; set; }
    }
    public class SignInModel : PageModel
    {
        [BindProperty]
        public AuthData? AuthData { get; set; }

        public string? Message { get; set; }
        public void OnGet()
        {
            Message = $"User {AuthData.FirstName} signed in";
        }
    }
}
