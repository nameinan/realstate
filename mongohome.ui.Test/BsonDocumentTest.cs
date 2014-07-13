using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;


namespace mongohome.ui.Test
{
    
    [TestClass]
    public class BsonDocumentTests
    {
        public BsonDocumentTests()
        {

            JsonWriterSettings.Defaults.Indent = true;
        }

        [TestMethod]
        public void EmptyDocumentTest()
        {
            var bsonDocument = new BsonDocument();
            Console.WriteLine(bsonDocument.ToJson());

        }

        [TestMethod]
        public void AddAnElement()
        {

            var bsonDocument = new BsonDocument();
            bsonDocument.Add("firstname", new BsonString("Nameirakpam") );
            Console.WriteLine(bsonDocument.ToJson());
            
        }

        [TestMethod]
        public void AddAnElement_WithCollection()
        {

            var bsonDocument = new BsonDocument
            {
                {"name", new BsonString("Nameirakpam")},
                {"age", new BsonInt32(32)},
                {"IsAlive", true}
            };
            Console.WriteLine(bsonDocument.ToJson());
        }

        [TestMethod]
        public void AddBsonArray()
        {
            var person = new BsonDocument();
            person.Add("Name", new BsonString("Nameirakpam"));
            person.Add("address", new BsonArray(new[] {"Swapanalok","D-504","Pade Basti","Phursungi","Hadapsar"}));
            Console.WriteLine(person.ToJson());
        }



        [TestMethod]
        public void EmbeedeDocument()
        {
            var person = new BsonDocument();
            person.Add("Name", new BsonString("Nameirakpam"));
            person.Add("contact", new BsonDocument
            {
                {"email","nandailogic@gmail.com"},
                {"phone", new BsonString("9022566099")}
            });
            Console.WriteLine(person.ToJson());
        }

        [TestMethod]
        public void BsonConversion()
        {
            var person = new BsonDocument();
            person.Add("age", 54);
            
            Console.WriteLine(person["age"].ToDouble()+ 10);
            Console.WriteLine(person["age"].IsInt32);
            Console.WriteLine(person["age"].IsDouble);
        }

        [TestMethod]
        public void ToBson()
        {
            var person = new BsonDocument();
            person.Add("age", 54);

            var bson = person.ToBson();
            Console.WriteLine(BitConverter.ToString(bson));

            var deserialize = BsonSerializer.Deserialize<BsonDocument>(bson);
            Console.WriteLine(deserialize.ToJson());
        }
    }
}


     