using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MeetingRooms.CreateMeetingRoom
{
    [TestFixture]
    public class CreateMeetingRoomModelTests
    {
        private CreateMeetingRoomModel _model;

        private const string Name = "Meeting Room 1";
        private Guid RoomLocationId = Guid.NewGuid();
        private const int Size = 8;

        [SetUp]
        public void Setup()
        {
            _model = new CreateMeetingRoomModel();
        }

        [Test]
        public void SetAndGetName()
        {
            _model.Name = Name;

            Assert.AreEqual(Name, _model.Name);
        }

        [Test]
        public void SetAndGetRoomLocationId()
        {
            _model.RoomLocationId = RoomLocationId;

            Assert.AreEqual(RoomLocationId, _model.RoomLocationId);
        }

        [Test]
        public void SetAndGetSize()
        {
            _model.Size = Size;

            Assert.AreEqual(Size, _model.Size);
        }
    }
}
