using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using mongohome.ui.Models;
using mongohome.ui.Rental;

namespace mongohome.ui.Controllers
{
    public class RentalController : Controller
    {
        

        RealStateContext Context=new RealStateContext();
        public ActionResult Index( RentalsFilter filter)
        {
            var rentals = FilteRentals(filter)
                .SetSortOrder(SortBy<Rental.Rental>.Ascending(r=>r.Price));
            var rentalList = new RentalList
            {
               Filters = filter,
               Rentals= rentals
              
            
            };
            return View(rentalList);
        }

        private MongoCursor<Rental.Rental> FilteRentals(RentalsFilter filter)
        {
            if (!filter.PriceLimit.HasValue)
            {
                return Context.Rentals.FindAll();
            }
            IMongoQuery query = Query<Rental.Rental>.LTE(r => r.Price,filter.PriceLimit);
            return Context.Rentals.Find(query);
        }

        public ActionResult Post()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Post(PostRental postRental)
        {
            var rental = new Rental.Rental(postRental);
            Context.Rentals.Insert(rental);
            return RedirectToAction("Index");
        }

        
        public ActionResult AdjustPrice(string id)
        {
            var rental = GetRental(id);
            return View(rental);
        }

        

        [HttpPost]
        public ActionResult AdjustPrice(string id, AdjustPrice adjustPrice)
        {
            var rental = GetRental(id);
            rental.AdjustPrice(adjustPrice);
            Context.Rentals.Save(rental);
            return RedirectToAction("Index");
        }


        private Rental.Rental GetRental(string id)
        {
            var rental = Context.Rentals.FindOneById(new ObjectId(id));
           return rental;
        }
    }
}