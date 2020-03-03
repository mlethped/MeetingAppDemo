using Application.Interfaces;
using Domain.MeetingRooms;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace Application.MeetingRooms.DeleteMeetingRoom
{
    [TestFixture]
    class DeleteMeetingRoomCommandTests
    {
        private Mock<IDatabaseService> _database;
        private DeleteMeetingRoomModel _model;

        private Mock<DbSet<MeetingRoom>> _meetingRooms;
        private static Guid MeetingRoomId = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            var dbMock = new Mock<IDatabaseService>();
            _meetingRooms = GetDbSetMeetingRoomMock();

            dbMock.Setup(x => x.MeetingRooms).Returns(_meetingRooms.Object);
            _database = dbMock;

            _model = new DeleteMeetingRoomModel()
            {
                Id = MeetingRoomId
            };
        }

        [Test]
        public void Execute_MeetingRoomIsDeletedFromDatabase()
        {
            var command = new DeleteMeetingRoomCommand(_database.Object);

            command.Execute(_model);

            _meetingRooms.Verify(x => x.Remove(It.IsAny<MeetingRoom>()), Times.Once);
        }

        [Test]
        public void Execute_DatabaseIsSavedWithChanges()
        {
            var command = new DeleteMeetingRoomCommand(_database.Object);

            command.Execute(_model);

            _database.Verify(x => x.Save(), Times.Once);
        }

        private static Mock<DbSet<MeetingRoom>> GetDbSetMeetingRoomMock()
        {
            var meetingRooms = new List<MeetingRoom>()
            {
                new MeetingRoom()
                {
                    Id = MeetingRoomId
                }
            }.AsQueryable();

            var meetingRoomMock = new Mock<DbSet<MeetingRoom>>();
            meetingRoomMock.As<IQueryable<MeetingRoom>>().Setup(m => m.Provider).Returns(meetingRooms.Provider);
            meetingRoomMock.As<IQueryable<MeetingRoom>>().Setup(m => m.Expression).Returns(meetingRooms.Expression);
            meetingRoomMock.As<IQueryable<MeetingRoom>>().Setup(m => m.ElementType).Returns(meetingRooms.ElementType);
            meetingRoomMock.As<IQueryable<MeetingRoom>>().Setup(m => m.GetEnumerator()).Returns(meetingRooms.GetEnumerator());
            return meetingRoomMock;
        }
    }
}
