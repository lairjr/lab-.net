using MongoCRUD.Collections;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace MongoCRUD
{
    class Program
    {
        private static IDictionary<ProgramActions, Action> programActions = new Dictionary<ProgramActions, Action>();
        private static IMongoDatabase db;

        static void Main(string[] args)
        {
            SetupActions();

            SetupDatabase().Wait();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Chose your option:");
                foreach (var action in Enum.GetValues(typeof(ProgramActions)))
                {
                    Console.WriteLine(string.Format("{0}. {1}", (int)action, action.ToString()));
                }
                var command = (ProgramActions)Enum.Parse(typeof(ProgramActions), Console.ReadLine());
                programActions[command].Invoke();
            }
        }

        static async Task SetupDatabase()
        {
            var connectionString = "mongodb://192.168.0.14:27017";

            var client = new MongoClient(connectionString);

            db = client.GetDatabase("test");
        }

        static void SetupActions()
        {
            programActions.Add(ProgramActions.Exit, Exit);
            programActions.Add(ProgramActions.Update, Update);
            programActions.Add(ProgramActions.Insert, Insert);
            programActions.Add(ProgramActions.FindAll, FindAll);
            programActions.Add(ProgramActions.FindAllCursor, FindAllCursor);
            programActions.Add(ProgramActions.Filter, Filter);
            programActions.Add(ProgramActions.Project, Project);
            programActions.Add(ProgramActions.Remove, Remove);
        }

        private static void Exit()
        {
            System.Environment.Exit(0);
        }

        private static async void Update()
        {
            Console.Clear();

            var col = db.GetCollection<Person>("people");

            await col.UpdateOneAsync(p => p.Name == "Lair",
                Builders<Person>.Update.Set(p => p.Profession, "Developer"));
        }

        private static async void Insert()
        {
            var col = db.GetCollection<Person>("people");

            var doc = new Person()
            {
                Name = "Lair",
                Age = 26,
                Profession = "Software Developer"
            };

            await col.InsertOneAsync(doc);
        }

        private static async void Remove()
        {
            Console.Clear();

            var col = db.GetCollection<Person>("people");

            await col.DeleteOneAsync(p => p.Profession == "Developer");
        }

        private static async void FindAll()
        {
            Console.Clear();

            var col = db.GetCollection<BsonDocument>("people");

            var list = await col.Find(new BsonDocument()).ToListAsync();

            foreach (var doc in list)
            {
                Console.WriteLine(doc);
            }

            Console.ReadLine();
        }

        private static async void FindAllCursor()
        {
            Console.Clear();

            var col = db.GetCollection<BsonDocument>("people");

            using (var cursor = await col.Find(new BsonDocument()).ToCursorAsync())
            {
                while (await cursor.MoveNextAsync())
                {
                    foreach (var doc in cursor.Current)
                    {
                        Console.WriteLine(doc);
                    }
                }
            }
        }

        private static async void Filter()
        {
            Console.Clear();

            var col = db.GetCollection<Person>("people");

            var list = await col.Find(p => p.Age < 30).ToListAsync();

            foreach (var doc in list)
            {
                Console.WriteLine(doc.ToJson());
            }

            Console.ReadLine();
        }

        private static async void Project()
        {
            Console.Clear();

            var col = db.GetCollection<Person>("people");

            var list = await col.Find(p => p.Name.Equals("Lair"))
                .Project(p => new { p.Name, CalcAge = p.Age + 20 })
                .ToListAsync();

            foreach (var doc in list)
            {
                Console.WriteLine(doc.ToJson());
            }

            Console.ReadLine();
        }
    }
}
