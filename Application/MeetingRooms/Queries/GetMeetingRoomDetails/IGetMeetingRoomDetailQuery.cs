using System;

namespace Application.MeetingRooms.Queries.GetMeetingRoomDetails
{
    public interface IGetMeetingRoomDetailQuery
    {
        GetMeetingRoomDetailModel Execute(Guid meetingRoomId);
    }
}