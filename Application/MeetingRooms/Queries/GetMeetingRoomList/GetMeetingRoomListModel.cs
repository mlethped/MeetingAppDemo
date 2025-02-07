﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MeetingRooms.Queries.GetMeetingRoomList
{
    public class GetMeetingRoomListModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public int Size { get; set; }
    }
}
