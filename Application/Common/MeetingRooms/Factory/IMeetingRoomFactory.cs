using Domain.MeetingRooms;
using Domain.Rooms;

namespace Application.Common.MeetingRooms.Factory
{
    public interface IMeetingRoomFactory
    {
        MeetingRoom Create(string name, RoomLocation roomLocation, int size);
        MeetingRoom Update(MeetingRoom currentMeetingRoom, string newName, int newSize);

    }
}