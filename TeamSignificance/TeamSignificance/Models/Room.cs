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
        public int Id { get; set; }
        public string Name { get; set; }
        public User Admin { get; set; }
        public List<User> Users{ get; set; }
        public List<UserReport> Reports { get; set; }

        [NotMapped]
        public int Participants => Users.Count();
    }
}