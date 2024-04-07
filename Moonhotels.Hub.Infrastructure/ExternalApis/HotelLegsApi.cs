using Newtonsoft.Json;
using Moonhotels.Hub.Domain.Models.HotelLegs;

namespace Moonhotels.Hub.Infrastructure.ExternalApis
{
    internal class HotelLegsApi : IHotelLegsApi
    {
        // private readonly HttpClient _httpClient;

        public HotelLegsApi()
        {
        }

        public async Task<HotelLegsSearchResponse> SearchAsync(HotelLegsSearchRequest request)
        {
            return await GetMockResponseAsync();
        }

        private async Task<HotelLegsSearchResponse> GetMockResponseAsync()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MockData", "hotelLegsResponse.json");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Could not find file at path: {filePath}");
            }

            var json = await File.ReadAllTextAsync(filePath);
            var response = JsonConvert.DeserializeObject<HotelLegsSearchResponse>(json);

            return response ?? throw new InvalidOperationException("Deserialized response is null.");
        }
    }
}