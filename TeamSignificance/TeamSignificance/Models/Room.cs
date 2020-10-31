using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeamSignificance.Models
{
    public class Room
    {
        public Room()
        {
            Users = new List<User>();
            Reports = new List<UserReport>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public User Admin { get; set; }
        public virtual ICollection<User> Users{ get; set; }
        public virtual ICollection<UserReport> Reports { get; set; }

        [NotMapped]
        public int Participants => Users.Count();
    }
}