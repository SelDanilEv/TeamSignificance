using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamSignificance.Models
{
    public class User
    {
        public User()
        {
            Rooms = new List<Room>();
        }

        public int Id { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}