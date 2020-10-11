using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamSignificance.Models;

namespace TeamSignificance.Areas.test.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Dynamic()
        {
            Room room = new Room()
            {
                Id = (new Random()).Next(0, int.MaxValue),
                Name = "ASP labs d",
            };
            return View(room);
        }

        public ActionResult Static()
        {
            Room room = new Room()
            {
                Id = (new Random()).Next(0, int.MaxValue),
                Name = "ASP labs s",
            };
            return View(room);
        }
    }
}