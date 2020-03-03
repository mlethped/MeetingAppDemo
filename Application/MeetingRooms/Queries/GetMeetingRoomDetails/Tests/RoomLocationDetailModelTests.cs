using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MeetingRooms.Queries.GetMeetingRoomDetails.Tests
{
    [TestFixture]
    public class RoomLocationListModelTests
    {
        private GetRoomLocationDetailModel _model;

        private Guid Id = Guid.NewGuid();
        private string Address = "Some address";
        private string Building = "Some building";
        private string Floor = "Some floor";
        private string RoomNumber = "Some room number";

        [SetUp]
        public void Setup()
        {
            _model = new GetRoomLocationDetailModel();
        }

        [Test]
        public void SetAndGetId()
        {
            _model.Id = Id;

            Assert.AreEqual(Id, _model.Id);
        }

        [Test]
        public void SetAndGetAddress()
        {
            _model.Address = Address;

            Assert.AreEqual(Address, _model.Address);
        }

        [Test]
        public void SetAndGetBuilding()
        {
            _model.Building = Building;

            Assert.AreEqual(Building, _model.Building);
        }

        [Test]
        public void SetAndGetFloor()
        {
            _model.Floor = Floor;

            Assert.AreEqual(Floor, _model.Floor);
        }

        [Test]
        public void SetAndGetRoomNumber()
        {
            _model.RoomNumber = RoomNumber;

            Assert.AreEqual(RoomNumber, _model.RoomNumber);
        }
    }
}
