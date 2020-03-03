using Application.Interfaces;
using Application.Common.MeetingRooms.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MeetingRooms.CreateMeetingRoom
{
    public class CreateMeetingRoomCommand : ICreateMeetingRoomCommand
    {
        private readonly IDatabaseService _database;
        private readonly IMeetingRoomFactory _factory;

        public CreateMeetingRoomCommand(
            IDatabaseService database,
            IMeetingRoomFactory factory)
        {
            _database = database;
            _factory = factory;
        }

        public void Execute(CreateMeetingRoomModel model)
        {
            var name = model.Name;
            var roomLocation = _database.RoomLocations.Single(x => x.Id == model.RoomLocationId);
            var size = model.Size;

            var meetingRoom = _factory.Create(
                name: name,
                roomLocation: roomLocation,
                size: size);

            _database.MeetingRooms.Add(meetingRoom);
            _database.Save();
        }
    }
}
