using Application.Interfaces;
using Domain.MeetingRooms;
using Persistance.MeetingRooms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Persistance
{
    public class DatabaseService : System.Data.Entity.DbContext, IDatabaseService
    {
        public System.Data.Entity.DbSet<MeetingRoom> MeetingRooms { get; set; }
        Microsoft.EntityFrameworkCore.DbSet<MeetingRoom> IDatabaseService.MeetingRooms { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
