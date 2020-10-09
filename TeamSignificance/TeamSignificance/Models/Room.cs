using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamSignificance.Models
{
    public class Room
    {
        public Room()
        {
            Users = new List<User>();
        }

        public int Id { get; set; }
        [Required]
        [MinLength(6)]
        public string Name { get; set; }
        public List<User> Users { get; set; }

        public int RoomSize => Users.Count;

        public int GetCode => Math.Abs(Id.GetHashCode()+Name.GetHashCode()+Users.GetHashCode());
    }
}