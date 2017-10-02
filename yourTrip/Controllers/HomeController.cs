using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yourTrip.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Trip trip = new Trip();
            ViewBag.Description = trip.Description;
            ViewBag.Location = trip.Location;
            string dateFormat = ConfigurationManager.AppSettings["DateFormat"].ToString();
            ViewBag.Departure = trip.Departure.ToString(dateFormat);
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
    }
}