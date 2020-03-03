using Application.Interfaces;
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
            var meetingRoom = _database.MeetingRooms
                .Where(x => x.Id == meetingRoomId)
                .Select(x => new GetMeetingRoomDetailModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    RoomLocation = _database.RoomLocations
                                .Where(p => p.Id == x.RoomLocation.Id)
                                .Select(p => new GetRoomLocationDetailModel()
                                {
                                    Id = p.Id,
                                    Address = p.Address,
                                    Building = p.Building,
                                    Floor = p.Floor,
                                    RoomNumber = p.RoomNumber
                                }).Single(),
                    Size = x.Size
                })
                .Single();

            return meetingRoom;
        }
    }
}
