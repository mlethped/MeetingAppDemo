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
            try
            {

            }
            catch (Exception e)
            {
                Log.Error(e, "some exception");
                throw;
            }

            var currentMeetingRoom = _database.MeetingRooms.Single(x => x.Id == model.Id);
            var newName = model.Name;
            var newSize = model.Size;

            var newMeetingRoom = _factory.Update(
                currentMeetingRoom: currentMeetingRoom,
                newName: newName,
                newSize: newSize);

            _database.MeetingRooms.Remove(currentMeetingRoom);
            _database.MeetingRooms.Add(newMeetingRoom);
            _database.Save();
        }
    }
}
