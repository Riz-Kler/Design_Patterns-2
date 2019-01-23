using System;
using System.Reflection;

//To Demonstrate the Dynamoic Method Invocation wthout Paramter

namespace ReflectionDynamicMethodInvokeDemo1
{

    class MyClass
    {
        public void Display()
        {
            Console.WriteLine("Inside Display");
        }
    }
    class ReflectionDynamicMethodInvokeDemo1
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("ReflectionDynamicMethodInvokeDemo1.MyClass"); // set the type to the namespace and class name

            Object obj = Activator.CreateInstance(t); //If ths statement is commented then the object is not created

            MethodInfo m = t.GetMethod("Display");
            m.Invoke(obj, null); //Second paramter is null because there is no paramter in Method Display().
                                 //This goes inside Method Display() and outputs the line of text
        }
    }
}
