using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MeetingRooms.CreateMeetingRoom
{
    public class CreateMeetingRoomModel
    {
        public string Name { get; set; }
        public Guid RoomLocationId { get; set; }
        public int Size { get; set; }
    }
}
