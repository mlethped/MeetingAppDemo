using Domain.MeetingRooms;
using Domain.Rooms;

namespace Application.Common.MeetingRooms.Factory
{
    public class MeetingRoomFactory : IMeetingRoomFactory
    {
        public MeetingRoom Create(string name, RoomLocation roomLocation, int size)
        {
            var meetingRoom = new MeetingRoom();
            meetingRoom.Name = name;
            meetingRoom.RoomLocation = roomLocation;
            meetingRoom.Size = size;

            return meetingRoom;
        }

        public MeetingRoom Update(MeetingRoom currentMeetingRoom, string newName, int newSize)
        {
            var newMeetingRoom = currentMeetingRoom;
            newMeetingRoom.Name = newName;
            newMeetingRoom.Size = newSize;

            return newMeetingRoom;
        }
    }
}
