namespace ASPrazorpages_2.Services.implementations
{
    public class GreetingService : IGreetingService
    {
        public string GetWelcomeMessage(TimeSpan timeSpan)
        {
            if (timeSpan >= TimeSpan.FromHours(5) & timeSpan < TimeSpan.FromHours(12))
                return "Good morning!";
            if (timeSpan >= TimeSpan.FromHours(12) & timeSpan < TimeSpan.FromHours(18))
                return "Good day!";
            if (timeSpan >= TimeSpan.FromHours(18) & timeSpan < TimeSpan.FromHours(24))
                return "Good evenig!";

            return "Good night!";

        }

        public string GetWelcomeMessage()
        {
           return GetWelcomeMessage(DateTime.Now.TimeOfDay);
        }
    }
}
