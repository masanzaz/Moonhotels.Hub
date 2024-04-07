
namespace Moonhotels.Hub.Domain.Models.HotelLegs
{
    public class HotelLegsResult
    {
        public int Room { get; set; }
        public int Meal { get; set; }
        public bool CanCancel { get; set; }
        public decimal Price { get; set; }
    }
}