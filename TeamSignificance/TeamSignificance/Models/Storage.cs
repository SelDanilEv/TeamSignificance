using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamSignificance.Models
{
    public class Storage
    {
        private Storage()
        {
            Rooms = new List<Room>();
        }

        private static Storage _storage;

        public static Storage GetStorage()
        {
            if (_storage == null)
            {
                _storage = new Storage();
            }
            return _storage;
        }

        public List<Room> Rooms { get; set; }
    }
}