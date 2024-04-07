using MediatR;
using Moonhotels.Hub.Domain.Models.Hub;
using Moonhotels.Hub.Application.Interfaces;

namespace Moonhotels.Hub.Application.Features.SearchHotels.Queries
{
    public class SearchHotelsQuery : IRequest<HubSearchResponse>
    {
        public HubSearchRequest HubSearchRequest { get; }

        public SearchHotelsQuery(HubSearchRequest hubSearchRequest)
        {
            HubSearchRequest = hubSearchRequest;
        }
    }

    public class SearchHotelsQueryHandler : IRequestHandler<SearchHotelsQuery, HubSearchResponse>
    {
        private readonly ISearchService _searchService;

        public SearchHotelsQueryHandler(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<HubSearchResponse> Handle(SearchHotelsQuery request, CancellationToken cancellationToken)
        {
            return await _searchService.SearchAsync(request.HubSearchRequest);
        }
    }
}
