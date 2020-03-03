using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MeetingRooms.Queries.GetMeetingRoomList
{
    public class GetRoomLocationListModel
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string RoomNumber { get; set; }
    }
}
