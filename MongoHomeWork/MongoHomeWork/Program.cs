using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace MongoHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        private static async Task MainAsync(string[] args)
        {
            var connectionString = "mongodb://192.168.0.14:27017";

            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("students");

            var grades = db.GetCollection<BsonDocument>("grades");

            var homeworkStudents = await grades.Find(Builders<BsonDocument>.Filter.Eq("type", "homework"))
                .Sort(Builders<BsonDocument>.Sort.Ascending("student_id").Ascending("score")).ToListAsync();

            var temp = new BsonDocument();
            foreach (var student in homeworkStudents)
            {
                BsonValue tempId;

                if (temp.TryGetValue("student_id", out tempId))
                {
                    if (tempId == student["student_id"])
                    {
                        await grades.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("_id", temp["_id"]));
                    }
                }
                temp = student;
            }
        }

    }
}
