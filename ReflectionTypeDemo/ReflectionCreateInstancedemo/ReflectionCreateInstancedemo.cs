using System;
using System.Reflection;
// To demonstrate the dynamic creation of instance

namespace ReflectionCreateInstanceDemo
{
    class MyClass
    {
        public static int x = 5;
        public MyClass()
        {
            Console.WriteLine("Inside MyClass Constructor");
            Console.WriteLine("x = " + x);
            x = 10;
        }
    }
    class ReflectionCreateInstanceDemo
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("ReflectionCreateInstanceDemo.MyClass"); // set the type to the namespace and class name

            Object obj = Activator.CreateInstance(t); //If ths statement is commented then the object is not created and the static value for 5 is returned.
            Console.WriteLine("x = " + MyClass.x);
        }
    }
}
