using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace MongoHomeWork
{
    public class FinalExam_8
    {
        public async Task RunAsync()
        {
            var connectionString = "mongodb://192.168.0.13:27017";

            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");

            var animals = db.GetCollection<BsonDocument>("animals");

            var animal = new BsonDocument
                            {
                            {"animal", "monkey"}
                            };

            await animals.InsertOneAsync(animal);
            animal.Remove("animal");
            animal.Add("animal", "cat");
            await animals.InsertOneAsync(animal);
            animal.Remove("animal");
            animal.Add("animal", "lion");
            await animals.InsertOneAsync(animal);
        }
    }
}