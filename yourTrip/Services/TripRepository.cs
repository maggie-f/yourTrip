using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yourTrip.Models;

namespace yourTrip.Services
{
    public class TripRepository
    {

        public IList<TripModels> Get(string userId)
        {
            using (var db = new ApplicationDbContext())
            {
                //var trips = from t in db.Trips
                //            where t.UserId.Equals(userId)
                //            select t;
                //trips.ToList();

                return db.Trips.Where(x => x.UserId == userId).ToList();
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
    }
}
