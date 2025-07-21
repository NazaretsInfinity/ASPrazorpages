namespace ASPrazorpages_2.Services
{
    public interface IGreetingService
    {
        string GetWelcomeMessage();
        string GetWelcomeMessage(TimeSpan span);
    }
}
