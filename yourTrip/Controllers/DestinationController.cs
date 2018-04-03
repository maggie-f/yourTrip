using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yourTrip.Models;
using yourTrip.Services;

namespace yourTrip.Controllers
{
    public class DestinationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private DestinationRepository _repo;

        public DestinationController()
        {
            _repo = new DestinationRepository();
        }

        // GET: Destination
        public ActionResult Index()
        {
            var destinationModels = db.DestinationModels.Include(d => d.Trip);
            return View(destinationModels.ToList());
        }

        // GET: Destination/View/5
        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IList<DestinationModels> destinations = _repo.GetDestinations(Convert.ToInt32(id.ToString()));
            ViewBag.Trip = id;
            ViewBag.HasDestinations = destinations != null && destinations.Count() > 0 ? 1 : 0;
            return View(destinations);
        }

        // GET: Destination/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DestinationModels destinationModels = db.DestinationModels.Find(id);
            if (destinationModels == null)
            {
                return HttpNotFound();
            }
            return View(destinationModels);
        }

        // GET: Destination/Create
        public ActionResult Create()
        {
            ViewBag.TripRefId = new SelectList(db.Trips, "Id", "Name");
            return View();
        }

        // POST: Destination/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Destination,Latitud,Longitud,Zoom,PlaceId,Arrival,Leave,TripRefId")] DestinationModels destinationModels)
        {
            try
            {
                destinationModels.UserId = GetUserId();
                destinationModels.Created = DateTime.UtcNow;
                destinationModels.Modified = DateTime.UtcNow;
                db.DestinationModels.Add(destinationModels);
                db.SaveChanges();
                return RedirectToAction("View", new { @id = destinationModels.TripRefId });
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Trip");
            }
        }

        // GET: Destination/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DestinationModels destinationModels = db.DestinationModels.Find(id);
            if (destinationModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.TripRefId = new SelectList(db.Trips, "Id", "Name", destinationModels.TripRefId);
            return View(destinationModels);
        }

        // POST: Destination/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Destination,Latitud,Longitud,Zoom,PlaceId,Arrival,Leave,Created,Modified,UserId,TripRefId")] DestinationModels destinationModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destinationModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TripRefId = new SelectList(db.Trips, "Id", "Name", destinationModels.TripRefId);
            return View(destinationModels);
        }

        // GET: Destination/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DestinationModels destinationModels = db.DestinationModels.Find(id);
            if (destinationModels == null)
            {
                return HttpNotFound();
            }
            return View(destinationModels);
        }

        // POST: Destination/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DestinationModels destinationModels = db.DestinationModels.Find(id);
            db.DestinationModels.Remove(destinationModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private string GetUserId()
        {
            return User.Identity.GetUserId();
        }
    }
}
