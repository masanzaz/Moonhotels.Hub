namespace Moonhotels.Hub.Domain.Models.HotelLegs
{
    public class HotelLegsSearchResponse
    {
        public List<HotelLegsResult> Results { get; set; } = new();
    }
}