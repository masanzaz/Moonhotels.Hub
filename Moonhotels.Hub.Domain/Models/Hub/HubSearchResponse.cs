
using Moonhotels.Hub.Domain.Entities;

namespace Moonhotels.Hub.Domain.Models.Hub
{
    public class HubSearchResponse
    {
        public List<Room> Rooms { get; set; } = new();
    }
}