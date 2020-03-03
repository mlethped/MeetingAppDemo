using Domain.MeetingRooms;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<MeetingRoom> MeetingRooms { get; set; }

        void Save();
    }
}
