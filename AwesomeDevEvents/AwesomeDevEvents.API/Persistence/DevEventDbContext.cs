﻿using AwesomeDevEvents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeDevEvents.API.Persistence
{
    public class DevEventDbContext : DbContext
    {
        public DevEventDbContext(DbContextOptions<DevEventDbContext> options) : base(options)
        {
            
        }

        public DbSet<DevEvent> DevEvents { get; set; }
        public DbSet<DevEventSpeaker> DevEventSpeakers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DevEvent>(e =>
            {
                e.HasKey(e => e.Id);

                e.Property(de => de.Title).IsRequired(false);

                e.Property(de => de.Description)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");

                e.Property(de => de.StartDate)
                    .HasColumnName("Start_Date");

                e.Property(de => de.EndDate)
                    .HasColumnName("End_Data");

                e.HasMany(de => de.Speakers)
                    .WithOne()
                    .HasForeignKey(s => s.DevEventId);
            });

            builder.Entity<DevEventSpeaker>(e =>
            {
                e.HasKey(e => e.Id);
            });
        }

    }
}
