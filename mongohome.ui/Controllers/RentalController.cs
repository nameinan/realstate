using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using mongohome.ui.Models;
using mongohome.ui.Rental;

namespace mongohome.ui.Controllers
{
    public class RentalController : Controller
    {
        private readonly RealStateContext Context = new RealStateContext();

        public ActionResult Index(RentalsFilter filter)
        {
            /*
            var rentals = FilteRentals(filter)
                .SetSortOrder(SortBy<Rental.Rental>.Ascending(r=>r.Price));

            */

            IEnumerable<Rental.Rental> rentals = FilteRentals(filter);


            var rentalList = new RentalList
            {
                Filters = filter,
                Rentals = rentals
            };
            return View(rentalList);
        }

        private IEnumerable<Rental.Rental> FilteRentals(RentalsFilter filter)
        {
            //private MongoCursor<Rental.Rental> FilteRentals(RentalsFilter filter)
            //
            /*    if (!filter.PriceLimit.HasValue)
            {
                return Context.Rentals.FindAll();
            }
            IMongoQuery query = Query<Rental.Rental>.LTE(r => r.Price,filter.PriceLimit);
            return Context.Rentals.Find(query);*/


            IQueryable<Rental.Rental> rentals = Context.Rentals.AsQueryable().OrderBy(r => r.Price);

            if (filter.MinRoom.HasValue)
            {
                rentals = rentals.Where(r => r.NoOfRooms >= filter.MinRoom);
            }


            if (filter.PriceLimit.HasValue)
            {
                IMongoQuery query = Query<Rental.Rental>.LTE(r => r.Price, filter.PriceLimit);
                rentals = rentals.Where(r => query.Inject());
            }


            return rentals;
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
            Rental.Rental rental = GetRental(id);
            return View(rental);
        }


        [HttpPost]
        public ActionResult AdjustPrice(string id, AdjustPrice adjustPrice)
        {
            Rental.Rental rental = GetRental(id);
            rental.AdjustPrice(adjustPrice);
            Context.Rentals.Save(rental);
            return RedirectToAction("Index");
        }


        private Rental.Rental GetRental(string id)
        {
            Rental.Rental rental = Context.Rentals.FindOneById(new ObjectId(id));
            return rental;
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            Context.Rentals.Remove(Query.EQ("_id", new ObjectId(id)));
            return RedirectToAction("Index");
        }
    }
}