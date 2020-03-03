namespace Application.MeetingRooms.CreateMeetingRoom
{
    public interface ICreateMeetingRoomCommand
    {
        void Execute(CreateMeetingRoomModel model);
    }
}