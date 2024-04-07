using Moonhotels.Hub.Domain.Interfaces;
using Moonhotels.Hub.Domain.Models.TravelDoorX;

namespace Moonhotels.Hub.Infrastructure.ExternalApis
{
    internal class TravelDoorXApi : ITravelDoorXApi
    {
        private readonly IApiService _apiService;
        private const string path = "travelDoorXResponse.json";
        public TravelDoorXApi(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<TravelDoorXSearchResponse> SearchAsync(TravelDoorXSearchRequest request)
        {
            return await _apiService.SearchAsync<TravelDoorXSearchResponse>(path, request);
        }
    }
}