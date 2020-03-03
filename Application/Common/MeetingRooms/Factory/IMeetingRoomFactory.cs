using Domain.MeetingRooms;

namespace Application.Common.MeetingRooms.Factory
{
    public interface IMeetingRoomFactory
    {
        MeetingRoom Create(string name, string location, int size);
        MeetingRoom Update(MeetingRoom currentMeetingRoom, string newName, string newLocation, int newSize);

    }
}