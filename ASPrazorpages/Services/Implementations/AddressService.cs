
using ASPrazorpages.Models;

namespace ASPrazorpages.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly List<RestaurantAddresses> _restaurants;
        public AddressService()
        {
            _restaurants = new List<RestaurantAddresses>();
            for (int i = 0; i < 5; ++i)
            {
                RestaurantAddresses address = new RestaurantAddresses()
                {
                    City = $"cit",
                    Street = $"stret",
                    FacilityIndex = new Random().Next()
                };

                _restaurants.Add(address);
            }
        }

        public List<RestaurantAddresses> GetAllAdrresses()
        {
            return _restaurants;
        }
    }
}
