using System;

// To demonstrate getting the type

namespace ReflectionTypeDemo
{
    class MyClass
    {
    }
    class ReflectionTypeDemo
    {
        static void Main(string[] args)
        {
            // C# type of operator
            Type t1 = typeof(MyClass);
            Console.WriteLine("Type is : " + t1.FullName); //fully qualified name

            // System.Object GetType() method
            System.Object myClassObj = new MyClass();
            Type t2 = myClassObj.GetType();
            Console.WriteLine("Type is : " + t2.FullName);

            // System.Type GetType() method this is passing the message as a parameter
            Type t3 = System.Type.GetType("ReflectionTypeDemo.MyClass");
            Console.WriteLine("Type is : " + t3.FullName);
        }
    }
}
