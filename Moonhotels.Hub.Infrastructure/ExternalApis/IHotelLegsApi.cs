
using Moonhotels.Hub.Domain.Models.HotelLegs;

namespace Moonhotels.Hub.Infrastructure.ExternalApis
{
    public interface IHotelLegsApi
    {
        Task<HotelLegsSearchResponse> SearchAsync(HotelLegsSearchRequest request);
    }
}