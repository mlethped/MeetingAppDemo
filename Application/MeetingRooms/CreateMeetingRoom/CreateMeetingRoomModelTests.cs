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
        private const string Location = "Some Location";
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
        public void SetAndGetLocation()
        {
            _model.Location = Location;

            Assert.AreEqual(Location, _model.Location);
        }

        [Test]
        public void SetAndGetSize()
        {
            _model.Size = Size;

            Assert.AreEqual(Size, _model.Size);
        }
    }
}
