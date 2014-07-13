using MongoDB.Driver;
using mongohome.ui.Properties;

namespace mongohome.ui.Controllers
{
    public class RealStateContext
    {
        public MongoDatabase MongoDatabase;

        public RealStateContext()
        {
            {
                var mongoClient = new MongoClient(Settings.Default.RealStateConnection);
                var server = mongoClient.GetServer();
                MongoDatabase = server.GetDatabase(Settings.Default.RealStateDatabaseName);
            }
        }


        public MongoCollection<Rental.Rental> Rentals {
            get { return  MongoDatabase.GetCollection<Rental.Rental>("rentals"); }
        }
    }
}