using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;

namespace MongoHomeWork
{
    public class Homework3_1
    {
        public async Task RunAsync()
        {
            var connectionString = "mongodb://192.168.0.14:27017";

            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("school");

            var grades = db.GetCollection<BsonDocument>("students");

            var homeworkStudents = await grades.Find(new BsonDocument()).ToListAsync();

            foreach (var student in homeworkStudents)
            {
                var studentId = student["_id"];

                var scores = student.GetElement("scores").Value.AsBsonArray
                    .Where(s => s["type"] == "homework")
                    .OrderBy(s => s["score"]);

                for (var index = 1; index < scores.Count(); index++)
                {
                    await grades.FindOneAndUpdateAsync(Builders<BsonDocument>.Filter.Eq("_id", studentId),
                        Builders<BsonDocument>.Update.Pull("scores", scores.ElementAt(index - 1)));
                }
            }
        }
    }
}
