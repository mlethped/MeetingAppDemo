using Application.Interfaces;
using Application.Common.MeetingRooms.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serilog;

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
            var location = model.Location;
            var size = model.Size;

            var meetingRoom = _factory.Create(
                name: name,
                location: location,
                size: size);

            try
            {
                _database.MeetingRooms.Add(meetingRoom);
                _database.Save();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, "Error occured while adding meeting room to database");
                throw;
            }
        }
    }
}
