using Application.MeetingRooms.CreateMeetingRoom;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateMeetingRoomCommand command = new CreateMeetingRoomCommand();

            command.Execute(new CreateMeetingRoomModel()
            {
                Name = "Console Test Name",
                Location = "Console Location Name",
                Size = 2
            });
        }
    }
}
