using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamSignificance.Models;

namespace TeamSignificance.Controllers
{
    public class HomeController : Controller
    {
        #region Temp
        Storage storage = Storage.GetStorage();
        #endregion

        #region Standart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #endregion

        #region My tasks
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

        public ActionResult List()
        {
            return View(storage.Rooms);
        }
        #endregion

        #region with read/write actions
        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create(FormCollection collection)
        {
            if(collection.Count == 0)
            {
                return View();
            }
            try
            {
                Room room = new Room()
                {
                    Id = (new Random()).Next(0, int.MaxValue),
                    Name = collection["Name"],
                    Users = new List<User>()
                };
                storage.Rooms.Add(room);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}