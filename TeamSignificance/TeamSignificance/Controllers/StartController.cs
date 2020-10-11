using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamSignificance.Context;
using TeamSignificance.Models;

namespace TeamSignificance.Controllers
{
    public class StartController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection user)
        {
            User u = new User()
            {
                Nickname = user["Nickname"],
                Password = user["Password"]
            };

            RoomContext db = new RoomContext();

            User targerUser = db.Users.FirstOrDefault(x => x.Nickname == u.Nickname);

            if (targerUser == null)
            {
                ModelState.AddModelError("Nickname", "This nickname isn't exist");
            }
            else
            {
                if (targerUser.Password != u.Password)
                {
                    ModelState.AddModelError("Password", "Wrong password");
                }
            }

            if (ModelState.IsValid)
            {
                if (u.Nickname.Length < 3)
                {
                    ModelState.AddModelError("Nickname", "Nickname too short");
                }
                if (u.Password.Length < 5)
                {
                    ModelState.AddModelError("Password", "Password too short");
                }
            }

            if (ModelState.IsValid)
            {
                Session["currentUser"] = targerUser;
                return RedirectToAction("Index","Home");
            }
            return View(user);

        }


        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(FormCollection user)
        {
            User u = new User()
            {
                Nickname = user["Nickname"],
                Password = user["Password"]
            };

            RoomContext db = new RoomContext();

            if (db.Users.Any(o => o.Nickname == u.Nickname))
            {
                ModelState.AddModelError("Nickname", "This nickname is already exist");
            }

            if (ModelState.IsValid)
            {
                if (u.Nickname.Length < 3)
                {
                    ModelState.AddModelError("Nickname", "Nickname too short");
                }
                if (u.Password.Length < 5)
                {
                    ModelState.AddModelError("Password", "Password too short");
                }
            }
            if (ModelState.IsValid)
            {
                if (user["Password"] != user["ConfirmPassword"])
                {
                    ModelState.AddModelError("ConfirmPassword", "Password not confirmed");
                }
            }

            //TODO: validation password

            if (ModelState.IsValid)
            {
                db.Users.Add(u);
                db.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(user);
        }
    }
}