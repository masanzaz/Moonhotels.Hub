using Moonhotels.Hub.Domain.Models.Hub;

namespace Moonhotels.Hub.Application.Interfaces
{
    public interface ISearchService
    {
        Task<HubSearchResponse> SearchAsync(HubSearchRequest requestDto);
    }
}
