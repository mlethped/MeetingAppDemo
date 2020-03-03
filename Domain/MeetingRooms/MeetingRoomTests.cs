using NUnit.Framework;
using System;

namespace Domain.MeetingRooms
{
    [TestFixture]
    public class MeetingRoomTests
    {
        private MeetingRoom _meetingRoom;

        private Guid Id = Guid.NewGuid();
        private const string Name = "Room 1";
        private const string Location = "Some location";
        private const int Size = 8;

        [SetUp]
        public void Setup()
        {
            _meetingRoom = new MeetingRoom();
        }

        [Test]
        public void SetAndGetId()
        {
            _meetingRoom.Id = Id;

            Assert.AreEqual(Id, _meetingRoom.Id);
        }

        [Test]
        public void SetAndGetName()
        {
            _meetingRoom.Name = Name;

            Assert.AreEqual(Name, _meetingRoom.Name);
        }

        [Test]
        public void SetAndGetRoom()
        {
            _meetingRoom.Location = Location;

            Assert.AreEqual(Location, _meetingRoom.Location);
        }

        [Test]
        public void SetAndGetSize()
        {
            _meetingRoom.Size = Size;

            Assert.AreEqual(Size, _meetingRoom.Size);
        }
    }
}
