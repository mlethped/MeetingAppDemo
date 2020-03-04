using Application.Common.MeetingRooms.Factory;
using Application.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MeetingRooms.UpdateMeetingRoom
{
    public class UpdateMeetingRoomCommand : IUpdateMeetingRoomCommand
    {
        private readonly IDatabaseService _database;
        private readonly IMeetingRoomFactory _factory;

        public UpdateMeetingRoomCommand(
            IDatabaseService database,
            IMeetingRoomFactory factory)
        {
            _database = database;
            _factory = factory;
        }

        public void Execute(UpdateMeetingRoomModel model)
        {
            var currentMeetingRoom = _database.MeetingRooms.Single(x => x.Id == model.Id);

            var newName = model.Name;
            var newLocation = model.Location;
            var newSize = model.Size;

            var newMeetingRoom = _factory.Update(
                currentMeetingRoom: currentMeetingRoom,
                newLocation: newLocation,
                newName: newName,
                newSize: newSize);

            try
            {
                _database.MeetingRooms.Remove(currentMeetingRoom);
                _database.MeetingRooms.Add(newMeetingRoom);
                _database.Save();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, "Error occured while updating meeting room in database.");
                throw;
            }
        }
    }
}
