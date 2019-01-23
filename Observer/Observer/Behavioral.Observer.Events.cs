using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Autofac;
using System.Runtime.Serialization;
//using DotNetDesignPatternDemos.Behavioral.Observer;
using ImpromptuInterface;
using JetBrains.Annotations;
//using MoreLinq;
using System;
using static  System.Console;

namespace DotNetDesignPatternDemos.Behavioral.Observer
{
  public class FallsIllEventArgs
  {
    public string Address;
  }

  public class Person
  {
    public void CatchACold()
    {
      FallsIll?.Invoke(this,
        new FallsIllEventArgs { Address = "123 London Road" });
    }

    public event EventHandler<FallsIllEventArgs> FallsIll;
  }

  public class Demo
  {
        //static void Main()
        //{
        //    var person = new Person();

        //    person.FallsIll += CallDoctor;

        //    person.CatchACold();
        //}

        private static void CallDoctor(object sender, FallsIllEventArgs eventArgs)
    {
      Console.WriteLine($"A doctor has been called to {eventArgs.Address}");
    }
  }
}