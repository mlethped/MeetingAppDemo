using Application.MeetingRooms.Queries.GetMeetingRoomDetails;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MeetingRooms.Queries.GetMeetingRoomList.Tests
{
    [TestFixture]
    public class MeetingRoomListModelTests
    {
        private GetMeetingRoomListModel _model;

        private Guid Id = Guid.NewGuid();
        private string Name = "Room 1";
        private GetRoomLocationListModel RoomLocation = new GetRoomLocationListModel();
        private int Size = 8;

        [SetUp]
        public void Setup()
        {
            _model = new GetMeetingRoomListModel();
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
