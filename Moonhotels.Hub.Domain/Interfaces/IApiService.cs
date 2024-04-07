
namespace Moonhotels.Hub.Domain.Interfaces
{
    public interface IApiService
    {
        Task<T> SearchAsync<T>(string path, object requestBody);
    }
}