using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using Autofac;
//using Morelinq;
using NUnit.Framework;
using System.Threading.Tasks;
using static System.Console;

namespace DesPat_Decorator
{
    public interface IBird
    {
        void Fly();
      //  int Weight();
        int Weight { get; set; }
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            WriteLine($"Soaring in the sky with weight {Weight}");
        }
    }

    public interface ILizard
    {
        void Crawl();
  //      int Weight();
        int Weight { get; set; }
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }
        public void Crawl()
        {
            WriteLine($"Crawling in the dirt with weight {Weight}");
        }
    }

    public class Dragon : IBird, ILizard
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();
        private int weight;

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }

        public int Weight
        {
            get => weight;
            set
            {
                weight = value;
                bird.Weight = value;
                lizard.Weight = value;
            }

        }


        //       private Bird bird;           Dependency Injection Framework
        //       private Lizard lizard;

        //       public Dragon(Bird bird, Lizard lizard)
        //       {
        //           this.bird = bird ?? throw new ArgumentNullException(nameof(bird));
        //           this.lizard = lizard ?? throw new ArgumentNullException(nameof(lizard));
        //       }
    }
    static class MultipleInheritanceDecorator
    {
  /*      static void Main(string[] args)
        {
            var d = new Dragon();
            WriteLine("Enter the weight? ");
            string w = ReadLine();
            d.Weight = Convert.ToInt32(w);
            WriteLine("Enter a command Fly/Crawl? ");
             var i = ReadLine();
            if (i == "Fly")
            {
                d.Fly();
            }

            if (i == "Crawl")
            {
                d.Crawl();
            }

     

        }*/
    }
}
