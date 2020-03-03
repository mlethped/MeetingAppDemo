using Application.Common.MeetingRooms.Factory;
using Application.Interfaces;
using Domain.MeetingRooms;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Application.MeetingRooms.UpdateMeetingRoom
{
    public class UpdateMeetingRoomCommandTests
    {
        private Mock<IDatabaseService> _database;
        private IMeetingRoomFactory _factory;
        private UpdateMeetingRoomModel _model;

        private Mock<DbSet<MeetingRoom>> _meetingRooms;

        private static Guid MeetingRoomId = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            var dbMock = new Mock<IDatabaseService>();
            _meetingRooms = GetDbSetMeetingRoomMock();

            dbMock.Setup(x => x.MeetingRooms).Returns(_meetingRooms.Object);
            _database = dbMock;

            var factoryMock = new Mock<IMeetingRoomFactory>();
            factoryMock.Setup(x => x.Update(It.IsAny<MeetingRoom>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns(new MeetingRoom());
            _factory = factoryMock.Object;

            _model = new UpdateMeetingRoomModel()
            {
                Name = "Meeting Room 1",
                Id = MeetingRoomId,
                Size = 8
            };
        }

        [Test]
        public void Execute_MeetingRoomIsUpdatedToDatabase()
        {
            var command = new UpdateMeetingRoomCommand(_database.Object, _factory);

            command.Execute(_model);

            _meetingRooms.Verify(x => x.Add(It.IsAny<MeetingRoom>()), Times.Once);
        }

        [Test]
        public void Execute_MeetingRoomChangesIsSavedToDatabase()
        {
            var command = new UpdateMeetingRoomCommand(_database.Object, _factory);

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
