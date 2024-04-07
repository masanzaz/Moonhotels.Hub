using Moonhotels.Hub.Domain.Models.HotelLegs;
using Moonhotels.Hub.Domain.Interfaces;

namespace Moonhotels.Hub.Infrastructure.ExternalApis
{
    internal class HotelLegsApi : IHotelLegsApi
    {
        private readonly IApiService _apiService;
        private const string path = "hotelLegsResponse.json";

        public HotelLegsApi(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<HotelLegsSearchResponse> SearchAsync(HotelLegsSearchRequest request)
        {
            return await _apiService.SearchAsync<HotelLegsSearchResponse>(path, request);
        }
    }
}