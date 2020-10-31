using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamSignificance.Models;

namespace TeamSignificance.Context
{
    public class RoomContext : DbContext
    {
        public RoomContext() : base() { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<UserReport> UserReports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                        .HasMany<Room>(s => s.Rooms)
                        .WithMany(c => c.Users)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("UserRefId");
                            cs.MapRightKey("RoomRefId");
                            cs.ToTable("UserRoom");
                        });

        }
    }
}