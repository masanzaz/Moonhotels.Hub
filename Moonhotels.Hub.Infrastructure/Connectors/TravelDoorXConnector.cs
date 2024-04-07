using Moonhotels.Hub.Domain.Interfaces;
using Moonhotels.Hub.Domain.Models.Hub;
using Moonhotels.Hub.Infrastructure.Mapping;
using Moonhotels.Hub.Infrastructure.ExternalApis;

namespace Moonhotels.Hub.Infrastructure.Connectors
{
    public class TravelDoorXConnector : ITravelDoorXConnector
    {
        private readonly ITravelDoorXApi _travelDoorXApi;

        public TravelDoorXConnector(ITravelDoorXApi travelDoorXApi)
        {
            _travelDoorXApi = travelDoorXApi;
        }

        public async Task<HubSearchResponse> SearchAsync(HubSearchRequest request)
        {
            var travelDoorXSearchRequest = InfrastructureMappingProfile.MapToTravelDoorXSearchRequest(request);
            var travelDoorXSearchResponse = await _travelDoorXApi.SearchAsync(travelDoorXSearchRequest);
            return InfrastructureMappingProfile.MapToHubResponse(travelDoorXSearchResponse);
        }
    }
}