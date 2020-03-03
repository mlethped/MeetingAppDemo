using Application.Common.MeetingRooms.Factory;
using Application.Interfaces;
using Domain.MeetingRooms;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.MeetingRooms.CreateMeetingRoom
{
    [TestFixture]
    public class CreateMeetingRoomCommandTests
    {
        private Mock<IDatabaseService> _database;
        private IMeetingRoomFactory _factory;
        private CreateMeetingRoomModel _model;

        private Mock<DbSet<MeetingRoom>> _meetingRooms;

        [SetUp]
        public void Setup()
        {
            var dbMock = new Mock<IDatabaseService>();
            _meetingRooms = GetDbSetMeetingRoomMock();

            dbMock.Setup(x => x.MeetingRooms).Returns(_meetingRooms.Object);
            _database = dbMock;

            var factoryMock = new Mock<IMeetingRoomFactory>();
            factoryMock.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns(new MeetingRoom());
            _factory = factoryMock.Object;

            _model = new CreateMeetingRoomModel()
            {
                Name = "Meeting Room 1",
                Location = "Some Location",
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

        private static Mock<DbSet<MeetingRoom>> GetDbSetMeetingRoomMock()
        {
            var meetingRoomMock = new Mock<DbSet<MeetingRoom>>();
            meetingRoomMock.Setup(x => x.Add(It.IsAny<MeetingRoom>())).Verifiable();
            return meetingRoomMock;
        }
    }
}
