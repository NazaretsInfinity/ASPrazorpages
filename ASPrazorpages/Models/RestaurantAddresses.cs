namespace ASPrazorpages.Models
{
    public class RestaurantAddresses
    {
        public required string City {  get; set; }
        public required string Street { get; set; }
        public required int FacilityIndex {  get; set; }
        string? Mail { get; set; }
        string? Number { get; set; }

    }
}
