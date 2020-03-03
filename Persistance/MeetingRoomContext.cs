﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.MeetingRooms;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class MeetingRoomContext : DbContext, IDatabaseService
    {
        public MeetingRoomContext(DbContextOptions<MeetingRoomContext> options)
            : base(options)
        {
        }

        public void Save()
        {
            SaveChanges();
        }

        public DbSet<MeetingRoom> MeetingRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeetingRoom>().ToTable("MeetingRoom")
                .HasKey(p => p.Id);
        }
    }
}
