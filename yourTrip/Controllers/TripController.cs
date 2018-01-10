using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yourTrip.Models;

namespace yourTrip.Controllers
{
    public class TripController : Controller
    {
        public ActionResult Index()
        {
            TripModels trip = new TripModels();
            trip = trip.GetTrip();

            ViewBag.Description = trip.Description;
            ViewBag.Location = trip.Location;
            string dateFormat = ConfigurationManager.AppSettings["DateFormat"].ToString(); 
            ViewBag.Departure = trip.Departure.ToString(dateFormat);

            return View();
        }
    }
}