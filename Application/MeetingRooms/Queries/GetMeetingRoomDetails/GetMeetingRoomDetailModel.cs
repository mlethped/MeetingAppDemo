using Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MeetingRooms.Queries.GetMeetingRoomDetails
{
    public class GetMeetingRoomDetailModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public GetRoomLocationDetailModel RoomLocation { get; set; }

        public int Size { get; set; }
    }
}
