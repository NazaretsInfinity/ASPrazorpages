using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPrazorpages_3.Pages
{
    public class Person
    { 
        public required string Lastname { get; set; }
        public string? Firstname { get; set; }
    }

    public class FeaturesModel : PageModel
    {
       
        public int PageNumber {  get; set; }
        public string? SortMethod { get; set; }

        //---------------------------------------------//

        public string[] Names { get; set; } = new string[0];
        public Person Person { get; set; } = null!;

        public Person[] People { get; set; } = [];

        public Dictionary<string, string> Dictionary { get; set; } = new Dictionary<string, string>();

        public void OnGet(Dictionary<string,string> dictionary, Person[] people, Person person, string[] names, int pageNumber = 1, string? sortMethod = "Hey")
        {
            //after Features? to initialize we put parameter name from OnGet
            PageNumber = pageNumber;
            SortMethod = sortMethod;
            Names = names; // we can fill it in url like dat:
            // /Features?names[0]=Bob&names[1]=Alex (keep index consistent)
            // OR(same) : /Features?names=Tom&names=Bob&names=Alex
            // OR /Features?[0]=Bob&[1]=Alex&[2]=Tom

            Person = person;
            //Features?Firstname=Bob&Lastname=London

            People = people;
            //Feature?people[0].Firstname=Elijah&people[0].Lastname=Kamski

            Dictionary = dictionary;
            //Features?dictionary[Bread]=Хлеб&dictionary[Water]=Вода
        } 
    }
}
