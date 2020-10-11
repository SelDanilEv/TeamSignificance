using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamSignificance.Models
{
    public class UserReport
    {
        public int Id { get; set; }
        public User From { get; set; }
        public List<Report> Reports { get; set; }
    }
}