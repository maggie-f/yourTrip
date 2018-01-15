using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yourTrip.Models;

namespace yourTrip.Services
{
    public class TripRepository
    {

        public List<TripModels> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Trips.ToList();
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
