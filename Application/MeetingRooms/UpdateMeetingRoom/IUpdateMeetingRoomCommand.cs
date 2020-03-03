namespace Application.MeetingRooms.UpdateMeetingRoom
{
    public interface IUpdateMeetingRoomCommand
    {
        void Execute(UpdateMeetingRoomModel model);
    }
}