using Domain.MeetingRooms;

namespace Application.Common.MeetingRooms.Factory
{
    public class MeetingRoomFactory : IMeetingRoomFactory
    {
        public MeetingRoom Create(string name, string location, int size)
        {
            var meetingRoom = new MeetingRoom();
            meetingRoom.Name = name;
            meetingRoom.Location = location;
            meetingRoom.Size = size;

            return meetingRoom;
        }

        public MeetingRoom Update(MeetingRoom currentMeetingRoom, string newName, string newLocation, int newSize)
        {
            var newMeetingRoom = currentMeetingRoom;
            newMeetingRoom.Name = newName;
            newMeetingRoom.Location = newLocation;
            newMeetingRoom.Size = newSize;

            return newMeetingRoom;
        }
    }
}
