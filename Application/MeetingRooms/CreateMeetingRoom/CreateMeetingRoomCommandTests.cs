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

namespace Application.MeetingRooms.CreateMeetingRoom
{
    [TestFixture]
    public class CreateMeetingRoomCommandTests
    {
        private Mock<IDatabaseService> _database;
        private IMeetingRoomFactory _factory;
        private CreateMeetingRoomModel _model;

        private Mock<IDbSet<MeetingRoom>> _meetingRooms;

        private static Guid RoomLocationId = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            var dbMock = new Mock<IDatabaseService>();
            _meetingRooms = GetDbSetMeetingRoomMock();
            DbSet<RoomLocation> roomLocations = GetDbSetRoomLocationMock().Object;

            dbMock.Setup(x => x.MeetingRooms).Returns(_meetingRooms.Object);
            dbMock.Setup(x => x.RoomLocations).Returns(roomLocations);
            _database = dbMock;

            var factoryMock = new Mock<IMeetingRoomFactory>();
            factoryMock.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<RoomLocation>(), It.IsAny<int>()))
                .Returns(new MeetingRoom());
            _factory = factoryMock.Object;

            _model = new CreateMeetingRoomModel()
            {
                Name = "Meeting Room 1",
                RoomLocationId = RoomLocationId,
                Size = 8
            };
        }

        [Test]
        public void Execute_MeetingRoomIsAddedToDatabase()
        {
            var command = new CreateMeetingRoomCommand(_database.Object, _factory);

            command.Execute(_model);

            _meetingRooms.Verify(x => x.Add(It.IsAny<MeetingRoom>()), Times.Once);
        }

        [Test]
        public void Execute_MeetingRoomIsSavedToDatabase()
        {
            var command = new CreateMeetingRoomCommand(_database.Object, _factory);

            command.Execute(_model);

            _database.Verify(x => x.Save(), Times.Once);
        }

        private static Mock<IDbSet<MeetingRoom>> GetDbSetMeetingRoomMock()
        {
            var meetingRoomMock = new Mock<IDbSet<MeetingRoom>>();
            meetingRoomMock.Setup(x => x.Add(It.IsAny<MeetingRoom>())).Verifiable();
            return meetingRoomMock;
        }

        private static Mock<DbSet<RoomLocation>> GetDbSetRoomLocationMock()
        {
            var roomLocations = new List<RoomLocation>()
            {
                new RoomLocation()
                {
                    Id = RoomLocationId
                }
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
