using Moonhotels.Hub.Domain.Interfaces;
using Moonhotels.Hub.Domain.Models.Hub;
using Moonhotels.Hub.Infrastructure.Mapping;
using Moonhotels.Hub.Infrastructure.ExternalApis;

namespace Moonhotels.Hub.Infrastructure.Connectors
{
    public class HotelLegsConnector : IHotelLegsConnector
    {
        private readonly IHotelLegsApi _hotelLegsApi;

        public HotelLegsConnector(IHotelLegsApi hotelLegsApi)
        {
            _hotelLegsApi = hotelLegsApi;
        }

        public async Task<HubSearchResponse> SearchAsync(HubSearchRequest request)
        {
            var hotelLegsRequest = InfrastructureMappingProfile.MapToHotelLegsRequest(request);
            var hotelLegsResponse = await _hotelLegsApi.SearchAsync(hotelLegsRequest);
            return InfrastructureMappingProfile.MapToHubResponse(hotelLegsResponse);
        }
    }
}