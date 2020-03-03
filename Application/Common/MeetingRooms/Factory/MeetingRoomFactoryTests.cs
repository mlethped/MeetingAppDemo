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

        private const string Name = "Meeting Room 1";
        private const string Location = "Some Location";
        private const int Size = 8;

        [SetUp]
        public void Setup()
        {
            _factory = new MeetingRoomFactory();
        }

        [Test]
        public void Create_CreateAndVerify()
        {
            var meetingRoom = _factory.Create(
                name: Name,
                location: Location,
                size: Size);

            Assert.IsNotNull(meetingRoom);
            Assert.AreEqual(Name, meetingRoom.Name);
            Assert.AreEqual(Location, meetingRoom.Location);
            Assert.AreEqual(Size, meetingRoom.Size);
        }

        [Test]
        public void Update_UpdateAndVerify()
        {
            var newName = "New Meeting Room";
            var newLocation = "New Location";
            var newSize = 9;

            var meetingRoom = _factory.Create(
                name: Name,
                location: Location,
                size: Size);

            var updatedMeetingRoom = _factory.Update(
                currentMeetingRoom: meetingRoom,
                newLocation: newLocation,
                newName: newName,
                newSize: newSize);

            Assert.IsNotNull(updatedMeetingRoom);
            Assert.AreEqual(meetingRoom, updatedMeetingRoom);
            Assert.AreEqual(newName, updatedMeetingRoom.Name);
            Assert.AreEqual(newLocation, updatedMeetingRoom.Location);
            Assert.AreEqual(newSize, updatedMeetingRoom.Size);
        }
    }
}
