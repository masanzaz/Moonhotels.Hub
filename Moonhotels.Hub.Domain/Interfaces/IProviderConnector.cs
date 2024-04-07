
using Moonhotels.Hub.Domain.Models.Hub;

namespace Moonhotels.Hub.Domain.Interfaces
{
    public interface IProviderConnector
    {
        Task<HubSearchResponse> SearchAsync(HubSearchRequest request);
    }
}