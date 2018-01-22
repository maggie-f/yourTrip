using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yourTrip.Models;
using yourTrip.Services;

namespace yourTrip.Controllers
{
    public class TripController : Controller
    {

        private TripRepository _repo;

        public TripController()
        {
            _repo = new TripRepository();
        }
        // GET: Trip
        public ActionResult Index()
        {
            try
            {
                if (Request.IsAuthenticated)
                {
                    string userId = User.Identity.GetUserId();
                    var trips = _repo.Get(userId);

                    return View(trips);
                }
            }
            catch
            {
                //LOG
            }
            return View();
        }

        // GET: Trip/Details/5
        public ActionResult Details(int id)
        {
            var trips = _repo.Get(id);

            return View(trips);
        }

        // GET: Trip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trip/Create
        [HttpPost]
        public ActionResult Create(TripModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                    var currentUser = manager.FindById(User.Identity.GetUserId());
                    model.UserId = User.Identity.GetUserId();
                    _repo.Create(model);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                //Log
            }
            return View(model);
        }

        // GET: Trip/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                if(id > 0)
                {
                    var trip = _repo.Get(id);
                    return View(trip);
                }
            }
            catch
            {
                //Log
            }
            return View();
        }

        // POST: Trip/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TripModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var trip = _repo.Get(id);
                    _repo.Edit(model);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trip/Delete/5
        public ActionResult Delete(int id)
        {
            var trips = _repo.Get(id);

            return View(trips);
        }

        // POST: Trip/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TripModels model)
        {
            try
            {
                if (id > 0)
                {
                    _repo.Delete(id);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex) 
            {
                return View();
            }
        }
    }
}
