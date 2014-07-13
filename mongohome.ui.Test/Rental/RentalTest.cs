using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;

namespace mongohome.ui.Test
{

    [TestClass]
    public class RentalTest
    {

        [TestMethod]
        //methodname_scenerio_expectation
        public void ToDocument_RentalWithPrice_PriceRepresentedAsDouble()
        {
            var rental = new Rental.Rental();
            rental.Price = 1;

            var bsonDocument = rental.ToBsonDocument();
            Assert.AreEqual( BsonType.Double,bsonDocument["Price"].BsonType);

        }


        [TestMethod]
        public void ToDocument_RentalId_IdRepresentedAsObjectId()
        {
            var rental = new Rental.Rental();
            rental.Id = ObjectId.GenerateNewId().ToString();

            var bsonDocument = rental.ToBsonDocument();
            Assert.AreEqual(BsonType.ObjectId, bsonDocument["_id"].BsonType);

        }
    }
} 