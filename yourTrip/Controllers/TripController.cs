using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yourTrip.Controllers
{
    public class TripController : Controller
    {
        // GET: Trip
        public ActionResult Index()
        {
            Trip trip = new Trip();
            ViewBag.Description = trip.Description;
            ViewBag.Location = trip.Location;
            string dateFormat = ConfigurationManager.AppSettings["DateFormat"].ToString(); 
            ViewBag.Departure = trip.Departure.ToString(dateFormat);
            return View();
        }
    }

    public class Trip
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Departure { get; set; }

        public Trip()
        {
            Id = 1;
            Description = "Mini Vacas Carmelita";
            Location = "Santiago de Chile";
            Departure = new DateTime(2017, 11, 24, 23, 35, 00);
        }
    }
}