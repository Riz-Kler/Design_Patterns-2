using System;
using System.Reflection;
// To demonstrate the dynamic creation of instance

namespace ReflectionConstructorCreateInstanceDemo
{ 
    class MyClass
    {
        public static int x = 5;
        public MyClass(String name)
        {
            Console.WriteLine("Constructor using String Parameter");
        }

        public MyClass(int data, String name)
        {
            Console.WriteLine("Constructor with int and String Parameter");
        }
    }
    class ReflectionConstructorCreateInstanceDemo
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("ReflectionConstructorCreateInstanceDemo.MyClass"); // set the type to the namespace and class name

            ConstructorInfo cons1 = t.GetConstructor(new[] { typeof(String) });    //The types of the constructor parameters decide which MyClass to use
            cons1.Invoke(new object[] { "Bangalore" });

            ConstructorInfo cons2 = t.GetConstructor(new[] { typeof(int), typeof(String) });    //The types of the constructor parameters decide which MyClass to use
            cons2.Invoke(new object[] {10,  "Bangalore" });
        }
    }
}
