using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using MoreLinq;
using NUnit.Framework;
using static System.Console;

namespace Design_Patterns
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private static int instanceCount; //0
        public static int Count => instanceCount;


        public SingletonDatabase()
        {
            instanceCount++;
            WriteLine("Initializing database");

            //         capitals = File.ReadAllLines(Path.Combine(
            capitals = File.ReadAllLines(Path.Combine(
                    new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName ?? throw new InvalidOperationException(), 
                    "capitals.txt"))
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1)));
            //              list => int.Parse(list.ElementAt(1)));
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
        // This way creates the instance of a connection to the database even if not needed yet!
        //       private static SingletonDatabase instance = new SingletonDatabase();
        //        public static SingletonDatabase Instance => instance;

        private static Lazy<SingletonDatabase> instance =
            new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance => instance.Value;
    }

 //   public class SingletonRecordFinder
 //   {
 //       public int GetTotalPopulation(IEnumerable<string>names)
  //      {
  //          int result = 0;
  //          foreach (var name in names)
  //          {
  //              result += SingletonDatabase.Instance.GetPopulation(name);
  //              return result;
  //          }
            
 //       }
 //   }
    [TestFixture]
    public class SingletonTests
    {
    [Test]
    public void IsSingletonTest()
    {
        var db = SingletonDatabase.Instance;
        var db2 = SingletonDatabase.Instance;
        Assert.That(db, Is.SameAs(db2));
        Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
    }
 //       [Test]
 //       public void SingletonTotalPopulationTest()
 //       {
 //           var rf = new SingletonRecordFinder();
 //           var names = new[] {"London", "Rome"};
 //           int tp = rf.GetTotalPopulation(names);
 //           Assert.That(tp, Is.EqualTo(2213357 + 345590));
 //       }
    }
    static class Singleton
    {
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "London";
            WriteLine($"{city} has population {db.GetPopulation(city)}");
        }
    }
    }
