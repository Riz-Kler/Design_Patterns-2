using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Autofac;
using MoreLinq;
using NUnit.Framework;
using static System.Console;

namespace DesPat_Decorator
{
    public interface IShape
    {
        string AsString();
    }

    public class Circle
    {
        private float radius;

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public void Resize(float factor)
        {
            radius *= factor;
        }
    }

    public class Square : IShape
    {
        private float side;

        public Square(float side)
        {
            this.side = side;
        }
        public string AsString() => $"A square with side {side}";
    }

    static class DynamicDecoratorComposition
    {
        static void Main(string[] args)
        {
            var square = new Square(1.23f);
            WriteLine(square.AsString());
        }
    }
}
