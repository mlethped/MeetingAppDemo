using Application.Common.MeetingRooms.Factory;
using Application.Interfaces;
using Domain.MeetingRooms;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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

        private static Guid MeetingRoomId = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            var dbMock = new Mock<IDatabaseService>();
            _meetingRooms = GetDbSetMeetingRoomMock();

            dbMock.Setup(x => x.MeetingRooms).Returns(_meetingRooms.Object);
            _database = dbMock.Object;

            _model = new GetMeetingRoomDetailModel()
            {
                Id = MeetingRoomId,
                Name = "Meeting Room 1",
                Location = "A Location",
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

        private static Mock<DbSet<MeetingRoom>> GetDbSetMeetingRoomMock()
        {
            var meetingRooms = new List<MeetingRoom>()
            {
                new MeetingRoom()
                {
                    Id = MeetingRoomId,
                    Name = "Some Name",
                    Location = "Some Location",
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
    }
}
