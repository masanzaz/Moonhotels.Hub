using Moonhotels.Hub.Application.Interfaces;
using Moonhotels.Hub.Domain.Interfaces;
using Moonhotels.Hub.Domain.Models.Hub;

namespace Moonhotels.Hub.Application.Services
{
    public class SearchService : ISearchService
    {
        private readonly IEnumerable<IProviderConnector> _providerConnectors;

        public SearchService(IEnumerable<IProviderConnector> providerConnectors)
        {
            _providerConnectors = providerConnectors;
        }

        public async Task<HubSearchResponse> SearchAsync(HubSearchRequest searchRequest)
        {
            var providerTasks = _providerConnectors.Select(connector => connector.SearchAsync(searchRequest));
            var providerResponses = await Task.WhenAll(providerTasks);

            var hubSearchResponse = new HubSearchResponse();
            foreach (var providerResponse in providerResponses)
            {
                hubSearchResponse.Rooms.AddRange(providerResponse.Rooms);
            }

            return hubSearchResponse;
        }
    }
}