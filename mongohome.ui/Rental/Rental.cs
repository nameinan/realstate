using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using mongohome.ui.Models;

namespace mongohome.ui.Rental
{
    public class   Rental
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public int NoOfRooms { get; set; }
        public List<string> Address = new List<string>();

        [BsonRepresentation(BsonType.Double)]
        public decimal Price { get; set; }

        


        public List<PriceAdjustment> Adjustments= new List<PriceAdjustment>();



        public Rental()
        {
        }

        public Rental(PostRental postRental)
        {
            Description = postRental.Description;
            NoOfRooms = postRental.NoOfRooms;
            Price = postRental.Price;
            Address = (postRental.Address ?? string.Empty).Split('\n').ToList();

        }

        public void AdjustPrice(AdjustPrice adjustPrice)
        {
            var priceAdjustment = new PriceAdjustment(adjustPrice,Price);
            Adjustments.Add(priceAdjustment);
            Price = adjustPrice.NewPrice;

        }
    }
}