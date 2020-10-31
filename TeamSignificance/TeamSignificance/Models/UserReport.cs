using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamSignificance.Models
{
    public class UserReport
    {
        public UserReport()
        {
            Reports = new List<Report>();
        }


        public int Id { get; set; }
        public User From { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}