using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yourTrip.Models;
using yourTrip.Services;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;

namespace yourTrip.Controllers
{
    public class TripController : Controller
    {
        static HttpClient client = new HttpClient();        

        private TripRepository _repo;

        public TripController()
        {
            _repo = new TripRepository();
        }

        // GET: Trip
        public ActionResult Index(bool future = true)
        {
            try
            {
                ViewBag.IsFuture = future ? "1" : "0";
                if (Request.IsAuthenticated)
                {
                    IList<TripModels> trips = _repo.Get(GetUserId(), future);
                    TripModels trip = _repo.GetNextTrip(GetUserId());
                    if (trip != null && trip.Id > 0)
                        ViewBag.Date = trip.Departure.ToString("yyyy/MM/dd");

                    return View(trips);
                }
            }
            catch(Exception ex)
            {
                //LOG
            }
            return View();
        }

        // GET: Trip/Details/5
        public ActionResult Details(int id)
        {
            TripModels trip = _repo.Get(id);
            ViewBag.Trip = trip;
            ViewBag.Date = trip.Departure.ToString("yyyy/MM/dd");

            return View(trip);
        }

        // GET: Trip/Create
        public ActionResult Create()
        {
            ViewBag.HasErrors = false;
            ViewBag.Trip = _repo.GetNextTrip(GetUserId());
            return View();
        }

        // POST: Trip/Create
        [HttpPost]
        public ActionResult Create(TripModels model)
        {
            ViewBag.HasErrors = false;
            try
            {
                //TODO: Chequear porque el model.isValid no funciona y hacer que funcione =)
                model.UserRefId = GetUserId();
                //TODO: convertir la fecha a UTCs
                model.UserRefId = GetUserId();
                model.Departure = DateTime.UtcNow;
                model.Return = DateTime.UtcNow;
                model.Created = DateTime.UtcNow;
                model.Modified = DateTime.UtcNow;

                _repo.Create(model);
                return RedirectToAction("Index", "Destination", model.Id);
            }
            catch(Exception ex)
            {
                //Log
                ViewBag.InnerException = ex.Message;
                ViewBag.HasErrors = true;
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

        private string GetUserId()
        {
            return User.Identity.GetUserId();
        }
    }
}
