using Application.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MeetingRooms.DeleteMeetingRoom
{
    public class DeleteMeetingRoomCommand : IDeleteMeetingRoomCommand
    {
        private readonly IDatabaseService _database;

        public DeleteMeetingRoomCommand(IDatabaseService database)
        {
            _database = database;
        }

        public void Execute(DeleteMeetingRoomModel model)
        {
            var meetingRoom = _database.MeetingRooms.Single(x => x.Id == model.Id);

            try
            {
                _database.MeetingRooms.Remove(meetingRoom);
                _database.Save();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, "Error occured while deleting meeting room from database");
                throw;
            }
        }
    }
}
