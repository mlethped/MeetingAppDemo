using Domain.Common;
using System;

namespace Domain.MeetingRooms
{
    public class MeetingRoom : IEntity
    {
        /// <summary>
        /// Unique id for the location
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the meeting room
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The physical meeting room
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Size of the meeting room (how many participants is it equipped to hold)
        /// </summary>
        public int Size { get; set; }
    }
}
