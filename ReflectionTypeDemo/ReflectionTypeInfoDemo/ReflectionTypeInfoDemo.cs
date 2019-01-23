using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//To demonstrate getting Type Information

namespace ReflectionTypeInfoDemo
{
    class MyClass
    {
    }
    class ReflectionTypeInfoDemo
    {
  
        static void Main(string[] args)
        {
            Type t = typeof(MyClass);

            Console.WriteLine("Name : " + t.Name);
            Console.WriteLine("FullName : " + t.FullName);
            Console.WriteLine("Namespace : " + t.Namespace);
            Console.WriteLine("BaseType : " + t.BaseType);
            Console.WriteLine("Assembly : " + t.Assembly);
            Console.WriteLine("IsClass : " + t.IsClass);
        }
    }
}
