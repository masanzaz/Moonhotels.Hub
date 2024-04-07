using Moonhotels.Hub.Application.Interfaces;
using Moonhotels.Hub.Domain.Entities;
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

            var consolidatedRooms = ConsolidateRooms(providerResponses);

            return new HubSearchResponse { Rooms = consolidatedRooms };
        }

        private List<Room> ConsolidateRooms(HubSearchResponse[] providerResponses)
        {
            var allRooms = providerResponses.SelectMany(response => response.Rooms);

            var consolidatedRooms = allRooms
                .GroupBy(room => room.RoomId)
                .Select(group =>
                {
                    var firstRoom = group.First();

                    var consolidatedRates = group
                        .SelectMany(room => room.Rates)
                        .GroupBy(rate => new { rate.MealPlanId, rate.IsCancellable })
                        .Select(rateGroup => rateGroup.OrderBy(rate => rate.Price).First())
                        .ToList();

                    return new Room
                    {
                        RoomId = firstRoom.RoomId,
                        Rates = consolidatedRates
                    };
                })
                .ToList();

            return consolidatedRooms;
        }
    }
}