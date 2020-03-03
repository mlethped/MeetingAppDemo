using System;
using System.Collections.Generic;

namespace Application.MeetingRooms.Queries.GetMeetingRoomList
{
    public interface IGetMeetingRoomListQuery
    {
        IList<GetMeetingRoomListModel> Execute();
    }
}