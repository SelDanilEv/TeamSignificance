using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamSignificance.Models;

namespace TeamSignificance.Context
{
    public class RoomContext :DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<UserReport> UserReports { get; set; }
    }
}