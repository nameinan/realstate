using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace mongohome.ui.Test
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
        public List<string> Address= new List<string>();
        public Contact Contat;

        [BsonIgnore]
        public string IgnoreMe { get; set; }
        [BsonElement("New")]
        public string Old { get; set; }


    }

    public class Contact
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    
}