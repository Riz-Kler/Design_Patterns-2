using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Autofac;
//using MoreLinq;
using NUnit.Framework;
using static System.Console;


namespace Design_Patterns2
{
    public class GraphicObject
    {
        public virtual string Name { get; set; } = "Group";
        public string Colour;

        private Lazy<List<GraphicObject>> children = new Lazy<List<GraphicObject>>();
        public List<GraphicObject> Children => children.Value;

        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth))
                .Append(string.IsNullOrWhiteSpace(Colour) ? string.Empty : $"{Colour} ")
                .AppendLine(Name);
            foreach (var child in Children)
            {
                child.Print(sb, depth+1);
            }

        }
        public override string ToString()
        {
            //      return base.ToString();

            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }
    }

    public class Circle : GraphicObject
    {
        //     public override string Name { get; set; }
        public override string Name => "Circle";
    }

    public class Square : GraphicObject
    {
        public override string Name => "Square";
    }
    class Composite
    {
        static void Main(string[] args)
        {
            var drawing = new GraphicObject {Name = "My Drawing"};
            drawing.Children.Add(new Square {Colour = "Red"});
            drawing.Children.Add(new Circle {Colour = "Yellow" });

            var group = new GraphicObject();
            group.Children.Add(new Square{Colour="Blue"});
            group.Children.Add(new Circle {Colour = "Blue" });
            drawing.Children.Add(group);

            WriteLine(drawing);
        }
    }
}
