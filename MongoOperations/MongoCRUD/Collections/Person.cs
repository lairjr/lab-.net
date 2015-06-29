using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoCRUD.Collections
{
    public class Person
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int   Age { get; set; }
        public string Profession { get; set; }
        //public IEnumerable<string> Colors { get; set; }
        //public IEnumerable<Pet> Pets { get; set; }
        //public BsonDocument ExtraElements { get; set; }
    }

    public class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
