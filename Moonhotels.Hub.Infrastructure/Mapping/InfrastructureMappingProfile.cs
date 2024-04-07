using Moonhotels.Hub.Domain.Entities;
using Moonhotels.Hub.Domain.Models.Hub;
using Moonhotels.Hub.Domain.Models.HotelLegs;

namespace Moonhotels.Hub.Infrastructure.Mapping
{
    public static class InfrastructureMappingProfile
    {
        public static HotelLegsSearchRequest MapToHotelLegsRequest(HubSearchRequest hubSearchRequest)
        {
            return new HotelLegsSearchRequest
            {
                Hotel = hubSearchRequest.HotelId,
                CheckInDate = hubSearchRequest.CheckIn,
                NumberOfNights = (hubSearchRequest.CheckOut - hubSearchRequest.CheckIn).Days,
                Guests = hubSearchRequest.NumberOfGuests,
                Rooms = hubSearchRequest.NumberOfRooms,
                Currency = hubSearchRequest.Currency.ToString()
            };
        }

        public static HubSearchResponse MapToHubResponse(HotelLegsSearchResponse hotelLegsResponse)
        {
            return new HubSearchResponse
            {
                Rooms = hotelLegsResponse.Results.GroupBy(r => r.Room).Select(g => new Room
                {
                    RoomId = g.Key,
                    Rates = g.Select(result => new Rate
                    {
                        MealPlanId = result.Meal,
                        IsCancellable = result.CanCancel,
                        Price = result.Price
                    }).ToList()
                }).ToList()
            };

        }
    }
}
