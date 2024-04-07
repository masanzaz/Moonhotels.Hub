
using Moonhotels.Hub.Domain.Models.TravelDoorX;

namespace Moonhotels.Hub.Infrastructure.ExternalApis
{
    public interface ITravelDoorXApi
    {
        Task<TravelDoorXSearchResponse> SearchAsync(TravelDoorXSearchRequest request);
    }
}