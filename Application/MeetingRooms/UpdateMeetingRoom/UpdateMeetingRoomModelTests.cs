using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MeetingRooms.UpdateMeetingRoom
{
    [TestFixture]
    public class UpdateMeetingRoomModelTests
    {
        private UpdateMeetingRoomModel _model;

        private Guid Id = Guid.NewGuid();
        private const string Name = "Meeting Room 1";
        private const int Size = 8;

        [SetUp]
        public void Setup()
        {
            _model = new UpdateMeetingRoomModel();
        }

        [Test]
        public void SetAndGetId()
        {
            _model.Id = Id;

            Assert.AreEqual(Id, _model.Id);
        }

        [Test]
        public void SetAndGetName()
        {
            _model.Name = Name;

            Assert.AreEqual(Name, _model.Name);
        }

        [Test]
        public void SetAndGetSize()
        {
            _model.Size = Size;

            Assert.AreEqual(Size, _model.Size);
        }
    }
}
