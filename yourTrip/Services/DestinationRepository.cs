using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yourTrip.Models;

namespace yourTrip.Services
{
    public class DestinationRepository
    {
        internal IList<DestinationModels> GetDestinations(int idTrip)
        {
            using(var db = new ApplicationDbContext())
            {
                IEnumerable<DestinationModels> destinations = db.DestinationModels.Where(x => x.TripRefId == idTrip);
                return destinations.ToList();
            }
        }
    }
}