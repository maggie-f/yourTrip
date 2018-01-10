using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yourTrip.Models
{
    public class TripModels
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Departure { get; set; }

        public TripModels() { }

        public TripModels GetTrip()
        {
            TripModels trip = new TripModels()
            {
                Id = 1,
                Description = "Mini Vacas Carmelita",
                Location = "Santiago, Chile",
                Departure = new DateTime(2017, 11, 24, 23, 35, 00)
            };

            return trip;
        }
    }
}