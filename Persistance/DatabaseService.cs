using Application.Interfaces;
using Domain.MeetingRooms;
using Persistance.MeetingRooms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Persistance
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public IDbSet<MeetingRoom> MeetingRooms { get; set; }

        public DatabaseService() 
            : base("MeetingApp")
        {
        }

        public void Save()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new MeetingRoomConfiguration());
        }
    }
}
