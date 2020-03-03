using Application.Common.MeetingRooms.Factory;
using Application.Interfaces;
using Domain.MeetingRooms;
using Domain.Rooms;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Application.MeetingRooms.Queries.GetMeetingRoomDetails.Tests
{
    [TestFixture]
    public class MeetingRoomDetailQueryTests
    {
        private IDatabaseService _database;
        private GetMeetingRoomDetailModel _model;

        private Mock<DbSet<MeetingRoom>> _meetingRooms;
        private Mock<DbSet<RoomLocation>> _roomLocations;

        private static Guid MeetingRoomId = Guid.NewGuid();
        private static Guid RoomLocationId = Guid.NewGuid();

        private static RoomLocation RoomLocation = new RoomLocation()
        {
            Id = RoomLocationId,
            Address = "Some Address",
            Building = "Some Building",
            Floor = "Some Floor",
            RoomNumber = "Some Room Number"
        };

        [SetUp]
        public void Setup()
        {
            var dbMock = new Mock<IDatabaseService>();
            _meetingRooms = GetDbSetMeetingRoomMock();
            _roomLocations = GetDbSetRoomLocationMock();

            dbMock.Setup(x => x.MeetingRooms).Returns(_meetingRooms.Object);
            dbMock.Setup(x => x.RoomLocations).Returns(_roomLocations.Object);
            _database = dbMock.Object;

            _model = new GetMeetingRoomDetailModel()
            {
                Id = MeetingRoomId,
                Name = "Meeting Room 1",
                RoomLocation = new GetRoomLocationDetailModel()
                {
                    Id = RoomLocationId
                },
                Size = 8
            };
        }

        [Test]
        public void Execute_GetMeetingRoomDetails()
        {
            var command = new GetMeetingRoomDetailQuery(_database);

            var result = command.Execute(MeetingRoomId);

            Assert.IsNotNull(result);
            Assert.AreEqual(MeetingRoomId, result.Id);
        }

        [Test]
        public void Execute_GetMeetingRoomLocationDetails()
        {
            var command = new GetMeetingRoomDetailQuery(_database);

            var result = command.Execute(MeetingRoomId);

            Assert.IsNotNull(result.RoomLocation);
            Assert.AreEqual(RoomLocationId, result.RoomLocation.Id);
        }

        private static Mock<DbSet<MeetingRoom>> GetDbSetMeetingRoomMock()
        {
            var meetingRooms = new List<MeetingRoom>()
            {
                new MeetingRoom()
                {
                    Id = MeetingRoomId,
                    Name = "Some Name",
                    RoomLocation = RoomLocation,
                    Size = 8
                }
            }.AsQueryable();

            var meetingRoomMock = new Mock<DbSet<MeetingRoom>>();
            meetingRoomMock.As<IQueryable<MeetingRoom>>().Setup(m => m.Provider).Returns(meetingRooms.Provider);
            meetingRoomMock.As<IQueryable<MeetingRoom>>().Setup(m => m.Expression).Returns(meetingRooms.Expression);
            meetingRoomMock.As<IQueryable<MeetingRoom>>().Setup(m => m.ElementType).Returns(meetingRooms.ElementType);
            meetingRoomMock.As<IQueryable<MeetingRoom>>().Setup(m => m.GetEnumerator()).Returns(meetingRooms.GetEnumerator());
            return meetingRoomMock;
        }

        private static Mock<DbSet<RoomLocation>> GetDbSetRoomLocationMock()
        {
            var roomLocations = new List<RoomLocation>()
            {
                RoomLocation
            }.AsQueryable();

            var roomMock = new Mock<DbSet<RoomLocation>>();
            roomMock.As<IQueryable<RoomLocation>>().Setup(m => m.Provider).Returns(roomLocations.Provider);
            roomMock.As<IQueryable<RoomLocation>>().Setup(m => m.Expression).Returns(roomLocations.Expression);
            roomMock.As<IQueryable<RoomLocation>>().Setup(m => m.ElementType).Returns(roomLocations.ElementType);
            roomMock.As<IQueryable<RoomLocation>>().Setup(m => m.GetEnumerator()).Returns(roomLocations.GetEnumerator());
            return roomMock;
        }
    }
}
