using Domain.Rooms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.MeetingRooms.Factory
{
    [TestFixture]
    public class MeetingRoomFactoryTests
    {
        private MeetingRoomFactory _factory;
        private RoomLocation _roomLocation;

        private const string Name = "Meeting Room 1";

        private const int Size = 8;

        [SetUp]
        public void Setup()
        {
            _factory = new MeetingRoomFactory();
            _roomLocation = new RoomLocation();
        }

        [Test]
        public void Create_CreateAndVerify()
        {
            var meetingRoom = _factory.Create(
                name: Name,
                roomLocation: _roomLocation,
                size: Size);

            Assert.IsNotNull(meetingRoom);
            Assert.AreEqual(Name, meetingRoom.Name);
            Assert.AreEqual(_roomLocation, meetingRoom.RoomLocation);
            Assert.AreEqual(Size, meetingRoom.Size);
        }

        [Test]
        public void Update_UpdateAndVerify()
        {
            var newName = "New Meeting Room";
            var newSize = 9;

            var meetingRoom = _factory.Create(
                name: Name,
                roomLocation: _roomLocation,
                size: Size);

            var updatedMeetingRoom = _factory.Update(
                currentMeetingRoom: meetingRoom,
                newName: newName,
                newSize: newSize);

            Assert.IsNotNull(updatedMeetingRoom);
            Assert.AreEqual(meetingRoom, updatedMeetingRoom);
            Assert.AreEqual(newName, updatedMeetingRoom.Name);
            Assert.AreEqual(_roomLocation, updatedMeetingRoom.RoomLocation);
            Assert.AreEqual(newSize, updatedMeetingRoom.Size);
        }
    }
}
