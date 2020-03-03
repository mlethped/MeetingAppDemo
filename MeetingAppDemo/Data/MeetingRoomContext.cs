using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.MeetingRooms;
using Microsoft.EntityFrameworkCore;

namespace MeetingAppDemo.Data
{
    public class MeetingRoomContext : DbContext
    {
        public MeetingRoomContext (DbContextOptions<MeetingRoomContext> options)
            : base(options)
        {
        }

        public DbSet<MeetingRoom> MeetingRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeetingRoom>().ToTable("MeetingRoom");
        }
    }
}
