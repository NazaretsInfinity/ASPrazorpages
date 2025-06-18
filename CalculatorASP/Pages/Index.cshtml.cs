using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalculatorASP.Pages
{
    public class IndexModel : PageModel
    {
        public string? Result { get; private set; }
        public string? Error { get;  private set; }

        public void OnPost(decimal? a, decimal? b, string? operation)
        {
            if (a == null)
            {
                Error = "Incorrect input: first number";
                return;
            }
            if(b == null) 
            {
                Error = "Incorrect input: second number";
                return;
            }

            switch (operation)
            {
                case "+": 
                    Result = $"{a}+{b} = {a+b}";
                    break;
                case "-":
                    Result = $"{a}-{b} = {a - b}";
                    return;
                case "*":
                    Result = $"{a}*{b} = {a * b}";
                    break;
                case "/":
                    if(b == 0)
                    {
                        Error = "Can't divide by ZERO";
                        break;
                    }
                    Result = $"{a}/{b} = {a / b}";
                    break;
                default:
                    Error = "Incorrect operation";
                    break;
            }
        }
    }
}
