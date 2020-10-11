using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamSignificance.Models
{
    public class Report
    {
        public int Id { get; set; }
        public User To { get; set; }
        public double Value { get; set; }
    }
}