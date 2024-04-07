using Newtonsoft.Json;
using Moonhotels.Hub.Domain.Interfaces;

namespace Moonhotels.Hub.Infrastructure.ExternalApis
{
    public class ApiService : IApiService
    {
        public async Task<T> SearchAsync<T>(string path, object requestBody)
        {
            //Replace for http call
            return await GetMockResponseAsync<T>(path);
        }

        private async Task<T> GetMockResponseAsync<T>(string fileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MockData", fileName);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Could not find file at path: {filePath}");
            }

            var json = await File.ReadAllTextAsync(filePath);
            var response = JsonConvert.DeserializeObject<T>(json);

            return response ?? throw new InvalidOperationException("Deserialized response is null.");
        }
    }
}
