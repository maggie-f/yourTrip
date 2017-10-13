using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Instagram;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace yourTrip.Controllers
{
    public class TripController : Controller
    {
        // GET: Trip
        public ActionResult Index(string code)
        {
            var instagram = InstagramService.CreateFromAccessToken(code);
            var media = instagram.Tags.GetRecentMedia("messi");
            return View(media);

            
            //Trip trip = new Trip();
            //ViewBag.Description = trip.Description;
            //ViewBag.Location = trip.Location;
            //string dateFormat = ConfigurationManager.AppSettings["DateFormat"].ToString(); 
            //ViewBag.Departure = trip.Departure.ToString(dateFormat);

            ////Obtener valores de https://api.instagram.com/v1/tags/{tag-name}?access_token=ACCESS-TOKEN
            ////EJEMPLO https://www.instagram.com/developer/endpoints/tags/#get_tags

            //return View();
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