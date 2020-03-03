using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MeetingRooms.Queries.GetMeetingRoomDetails.Tests
{
    [TestFixture]
    public class MeetingRoomListModelTests
    {
        private GetMeetingRoomDetailModel _model;

        private Guid Id = Guid.NewGuid();
        private string Name = "Room 1";
        private GetRoomLocationDetailModel RoomLocation = new GetRoomLocationDetailModel();
        private int Size = 8;

        [SetUp]
        public void Setup()
        {
            _model = new GetMeetingRoomDetailModel();
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
        public void SetAndGetRoomLocation()
        {
            _model.RoomLocation = RoomLocation;

            Assert.AreEqual(RoomLocation, _model.RoomLocation);
        }

        [Test]
        public void SetAndGetSize()
        {
            _model.Size = Size;

            Assert.AreEqual(Size, _model.Size);
        }
    }
}
