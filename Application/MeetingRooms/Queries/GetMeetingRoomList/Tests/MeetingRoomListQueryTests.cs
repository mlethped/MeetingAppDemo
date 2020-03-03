using Application.Interfaces;
using Domain.MeetingRooms;
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

        private static Guid MeetingRoomId_01 = Guid.NewGuid();

        private static Guid MeetingRoomId_02 = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            var dbMock = new Mock<IDatabaseService>();
            _meetingRooms = GetDbSetMeetingRoomMock();

            dbMock.Setup(x => x.MeetingRooms).Returns(_meetingRooms.Object);
            _database = dbMock.Object;

            _model = new GetMeetingRoomListModel()
            {
                Id = MeetingRoomId_01,
                Name = "Meeting Room 1",
                Location = "Some Location",
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

        private static Mock<DbSet<MeetingRoom>> GetDbSetMeetingRoomMock()
        {
            var meetingRooms = new List<MeetingRoom>()
            {
                new MeetingRoom()
                {
                    Id = MeetingRoomId_01,
                    Name = "Some Name",
                    Location = "Location 1",
                    Size = 8
                },
                new MeetingRoom()
                {
                    Id = MeetingRoomId_02,
                    Name = "Some Name",
                    Location = "Location 2",
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
    }
}
