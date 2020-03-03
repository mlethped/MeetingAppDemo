namespace Application.MeetingRooms.DeleteMeetingRoom
{
    public interface IDeleteMeetingRoomCommand
    {
        void Execute(DeleteMeetingRoomModel model);
    }
}