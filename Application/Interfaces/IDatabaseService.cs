using Domain.MeetingRooms;
using System.Data.Entity;

namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<MeetingRoom> MeetingRooms { get; set; }

        void Save();
    }
}
