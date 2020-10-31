using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamSignificance.Context;
using TeamSignificance.Models;

namespace TeamSignificance.Controllers
{
    public class HomeController : Controller
    {
        RoomContext db = new RoomContext();

        public ActionResult Index()
        {
            User user = Session["currentUser"] as User;
            return View(user);
        }

        public ActionResult Logout()
        {
            Session.Remove("currentUser");
            return RedirectToAction("Login","Start");
        }
    }
}