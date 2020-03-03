using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MeetingRooms.UpdateMeetingRoom
{
    public class UpdateMeetingRoomModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Size { get; set; }
    }
}
