using Domain.MeetingRooms;
using Domain.Rooms;
using System.Data.Entity;

namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<RoomLocation> RoomLocations { get; set; }

        IDbSet<MeetingRoom> MeetingRooms { get; set; }

        void Save();
    }
}
