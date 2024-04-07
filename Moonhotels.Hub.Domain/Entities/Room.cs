namespace Moonhotels.Hub.Domain.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public List<Rate> Rates { get; set; } = new();
    }
}