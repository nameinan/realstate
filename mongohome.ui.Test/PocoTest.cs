using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Bson.IO;

namespace mongohome.ui.Test
{

    [TestClass]
    public class PocoTest
    {
        public PocoTest()
        {
            JsonWriterSettings.Defaults.Indent = true;
        }

        [TestMethod]
        public void Automatic()
        {
            var person = new Person
            {
                Age = 31,
                Name = "Nandakumar"
            };
            person.Contat = new Contact
            {
               Email = "nandailogic@gmail.com",
               Phone = "9022366099"
            };
            

            person.Address.Add("Swapanalok D-504");
            person.Address.Add("Phursungi, Kale Padal");
            Console.WriteLine(person.ToJson());

        }



        [TestMethod]
        public void SerializationAttribute()
        {
            var person = new Person
            {
                Age = 31,
                Name = "Nandakumar"
            };
            person.Contat = new Contact
            {
                Email = "nandailogic@gmail.com",
                Phone = "9022366099"
            };


            person.Address.Add("Swapanalok D-504");
            person.Address.Add("Phursungi, Kale Padal");
            Console.WriteLine(person.ToJson());

        }
    }
}