using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Autofac;
using System.Runtime.Serialization;
//using DotNetDesignPatternDemos.Behavioral.Observer;
using ImpromptuInterface;
using JetBrains.Annotations;
using MoreLinq;
using static System.Console;
using System.Runtime.ExceptionServices;

namespace Observer
{
    public class Person
    {
        public event EventHandler<FallsIllEventArgs> FallsIll;

        public class FallsIllEventArgs
       {
           public string Address;
       }


        public void CatchACold()
        {
           // The Dot creates Null Reference Exzception a ? allows Nulls
            // Initially use EventArgs.Empty
            // But then can Inherit from FallsIllEventArgs. this is you
            FallsIll?.Invoke(this, 
                new FallsIllEventArgs { Address = "123 London Road"}); // Synchronous Invoke Call but all Begin and End Invoke
        }
        
    }

    class Events
    {
        static void Main(string[] args)
        {
            var person = new Person();

            person.FallsIll += CallDoctor;  //Subscribe Listening for events

            person.CatchACold();

            person.FallsIll -= CallDoctor; // Unsubscribe NOT Listening for events. This method is not particularly stable
        }

        private static void CallDoctor(object sender, Person.FallsIllEventArgs e)
        {
            WriteLine("A Doctor has been called to {eventArgs.Address");
        }

//        private static void CallDoctor(object sender, FallsIllEventArgs eventArgs)
 //       {
  //         WriteLine("A Doctor has been called to {eventArgs.Address");
 //       }

        //   private static void CallDoctor(object sender, FallsIllEventArgs eventArgs)
 //       {
            
  //      }
    }
}
