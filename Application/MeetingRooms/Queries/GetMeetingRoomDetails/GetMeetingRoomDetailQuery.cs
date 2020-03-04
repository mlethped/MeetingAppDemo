using Application.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MeetingRooms.Queries.GetMeetingRoomDetails
{
    public class GetMeetingRoomDetailQuery : IGetMeetingRoomDetailQuery
    {
        private readonly IDatabaseService _database;

        public GetMeetingRoomDetailQuery(IDatabaseService database)
        {
            _database = database;
        }

        public GetMeetingRoomDetailModel Execute(Guid meetingRoomId)
        {
            try
            {
                var meetingRoom = _database.MeetingRooms
                .Where(x => x.Id == meetingRoomId)
                .Select(x => new GetMeetingRoomDetailModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    Size = x.Size
                })
                .Single();

                return meetingRoom;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, $"Error occured while getting meeting room wíth id: {meetingRoomId} from database");
                throw;
            }
        }
    }
}
