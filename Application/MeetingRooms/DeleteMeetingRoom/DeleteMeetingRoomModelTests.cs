using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MeetingRooms.DeleteMeetingRoom
{
    [TestFixture]
    class DeleteMeetingRoomModelTests
    {
        private DeleteMeetingRoomModel _model;

        private Guid Id = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            _model = new DeleteMeetingRoomModel();
        }

        [Test]
        public void SetAndGetId()
        {
            _model.Id = Id;

            Assert.AreEqual(Id, _model.Id);
        }
    }
}
