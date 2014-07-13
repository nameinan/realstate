using System.Collections;
using System.Collections.Generic;

namespace mongohome.ui.Rental
{
    public class RentalList
    {

        public IEnumerable<Rental> Rentals { get; set; }
        public RentalsFilter Filters { get; set; }
    }
}