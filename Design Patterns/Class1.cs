using System;

namespace Coding.Exercise
{
    public static class ExtensionMethods
    {
    public static T DeepCopy<T>(this T self)
    {
        var stream = new MemoryStream();
        var formatter = new BinaryFormatter();
        formatter.Serialize(stream, self);
        stream.Seek(0, SeekOrigin.Begin);
        object copy = formatter.Deserialize(stream);
        stream.Close();
        return (T)copy;
    }

    }

    [Serializable]
    public class Point
    {
        public Point()
        {

        }
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    
        
           public Point DeepCopy()
           {
               return new Point(X, Y);
           }
    }

    [Serializable]
    public class Line
    {
        public Line()
        {

        }
        public Point Start, End;

        public Line(Point start, Point finish)
        {
            Start = start;
            Finish = finish;
        }

        public Line DeepCopy()
        {
            return new Line(Start.DeepCopy(), Finish.DeepCopy());
        }
    }
}

//      public Person DeepCopy()
//      {
//           return new Person(Names, Address.DeepCopy());
//       }



//public Address DeepCopy()
//      {
//          return new Address(StreetName, HouseNumber);
//     }