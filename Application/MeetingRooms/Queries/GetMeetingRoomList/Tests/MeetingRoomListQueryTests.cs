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

namespace Application.MeetingRooms.Queries.GetMeetingRoomList.Tests
{
    [TestFixture]
    public class MeetingRoomListQueryTests
    {
        private IDatabaseService _database;
        private GetMeetingRoomListModel _model;

        private Mock<DbSet<MeetingRoom>> _meetingRooms;
        private Mock<DbSet<RoomLocation>> _roomLocations;

        private static Guid MeetingRoomId_01 = Guid.NewGuid();
        private static Guid RoomLocationId_01 = Guid.NewGuid();

        private static Guid MeetingRoomId_02 = Guid.NewGuid();
        private static Guid RoomLocationId_02 = Guid.NewGuid();

        private static RoomLocation RoomLocation01 = new RoomLocation()
        {
            Id = RoomLocationId_01,
            Address = "Some Address",
            Building = "Some Building",
            Floor = "Some Floor",
            RoomNumber = "Some Room Number"
        };
        private static RoomLocation RoomLocation02 = new RoomLocation()
        {
            Id = RoomLocationId_02,
            Address = "Some Other Address",
            Building = "Some Other Building",
            Floor = "Some Other Floor",
            RoomNumber = "Some Other Room Number"
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

            _model = new GetMeetingRoomListModel()
            {
                Id = MeetingRoomId_01,
                Name = "Meeting Room 1",
                RoomLocation = new GetRoomLocationListModel()
                {
                    Id = RoomLocationId_01
                },
                Size = 8
            };
        }

        [Test]
        public void Execute_GetMeetingRoomList()
        {
            var command = new GetMeetingRoomListQuery(_database);

            var result = command.Execute();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(MeetingRoomId_01, result.First().Id);
            Assert.AreEqual(MeetingRoomId_02, result.Last().Id);
        }

        [Test]
        public void Execute_GetMeetingRoomLocationWithList()
        {
            var command = new GetMeetingRoomListQuery(_database);

            var result = command.Execute();
            var roomLocation01 = result.First().RoomLocation;
            var roomLocation02 = result.Last().RoomLocation;

            Assert.IsNotNull(roomLocation01);
            Assert.IsNotNull(roomLocation02);
            Assert.AreEqual(RoomLocationId_01, roomLocation01.Id);
            Assert.AreEqual(RoomLocationId_02, roomLocation02.Id);
        }

        private static Mock<DbSet<MeetingRoom>> GetDbSetMeetingRoomMock()
        {
            var meetingRooms = new List<MeetingRoom>()
            {
                new MeetingRoom()
                {
                    Id = MeetingRoomId_01,
                    Name = "Some Name",
                    RoomLocation = RoomLocation01,
                    Size = 8
                },
                new MeetingRoom()
                {
                    Id = MeetingRoomId_02,
                    Name = "Some Name",
                    RoomLocation = RoomLocation02,
                    Size = 12
                },
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
                RoomLocation01,
                RoomLocation02
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
