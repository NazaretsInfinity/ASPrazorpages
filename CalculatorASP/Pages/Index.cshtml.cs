using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalculatorASP.Pages
{
    public class IndexModel : PageModel
    {
        public string? Result { get; private set; }
        public string? Error { get;  private set; }

        [BindProperty(Name ="a")]
        public decimal? FirstNumber {  get; set; }

        [BindProperty(Name ="b")]
        public decimal? SecondNumber { get; set; }

        [BindProperty(Name ="operation", SupportsGet = true)]
        public string? Operation { get; set; }


        public void OnPost()
        {
            if (FirstNumber == null)
            {
                Error = "Incorrect input: first number";
                return;
            }
            if(SecondNumber == null) 
            {
                Error = "Incorrect input: second number";
                return;
            }

            switch (Operation)
            {
                case "+": 
                    Result = $"{FirstNumber}+{SecondNumber} = {FirstNumber+SecondNumber}";
                    break;
                case "-":
                    Result = $"{FirstNumber}-{SecondNumber} = {FirstNumber - SecondNumber}";
                    return;
                case "*":
                    Result = $"{FirstNumber}*{SecondNumber} = {FirstNumber * SecondNumber}";
                    break;
                case "/":
                    if(SecondNumber == 0)
                    {
                        Error = "Can't divide by ZERO";
                        break;
                    }
                    Result = $"{FirstNumber}/{SecondNumber} = {FirstNumber / SecondNumber}";
                    break;
                default:
                    Error = "Incorrect operation";
                    break;
            }
        }
    }
}
