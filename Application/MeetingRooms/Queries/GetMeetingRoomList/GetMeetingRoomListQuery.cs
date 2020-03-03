using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MeetingRooms.Queries.GetMeetingRoomList
{
    public class GetMeetingRoomListQuery : IGetMeetingRoomListQuery
    {
        private readonly IDatabaseService _database;

        public GetMeetingRoomListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public IList<GetMeetingRoomListModel> Execute()
        {
            var meetingRooms = _database.MeetingRooms
                .Select(x => new GetMeetingRoomListModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    Size = x.Size
                });

            return meetingRooms.ToList();
        }
    }
}
