using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yourTrip.Models;

namespace yourTrip.Services
{
    public class TripRepository
    {

        internal IList<TripModels> Get(string userId, bool future)
        {
            using (var db = new ApplicationDbContext())
            {
                //var trips = from t in db.Trips
                //            where t.UserId.Equals(userId)
                //            select t;
                //trips.ToList();
                if(!future)
                    return db.Trips.Where(x => x.UserRefId == userId).Where(x => x.Departure < DateTime.UtcNow).ToList();

                return db.Trips.Where(x => x.UserRefId == userId).Where(x => x.Departure >= DateTime.UtcNow).ToList();
            }
        }

        internal void Create(TripModels model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Trips.Add(model);
                db.SaveChanges();
            }
        }

        internal TripModels Get(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Trips.First(x => x.Id == id);
            }
        }

        internal void Edit(TripModels model)
        {
            using(var db = new ApplicationDbContext())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        internal void Delete(int id)
        {
            using(var db = new ApplicationDbContext())
            {
                var trip = db.Trips.First(x => x.Id == id);
                db.Trips.Remove(trip);
                db.SaveChanges();
            }
        }

        internal TripModels GetNextTrip(string userId)
        {
            using(var db = new ApplicationDbContext())
            {
                TripModels trip = db.Trips.Where(x => x.UserRefId == userId).Where(x => x.Departure >= DateTime.UtcNow).OrderByDescending(x => x.Departure).FirstOrDefault();

                return trip;
            }
        }
    }
}
