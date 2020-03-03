using Domain.MeetingRooms;
using System.Data.Entity.ModelConfiguration;

namespace Persistance.MeetingRooms
{
    public class MeetingRoomConfiguration
           : EntityTypeConfiguration<MeetingRoom>
    {
        public MeetingRoomConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired();

            Property(p => p.Location)
                .IsRequired();

            Property(p => p.Size)
                .IsRequired();
        }
    }
}
