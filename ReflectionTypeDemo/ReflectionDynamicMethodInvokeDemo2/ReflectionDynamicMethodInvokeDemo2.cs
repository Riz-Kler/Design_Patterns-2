using System;
using System.Reflection;

//To Demonstrate the Dynamoic Method Invocation with Paramters

namespace ReflectionDynamicMethodInvokeDemo2
{

    class MyClass
    {
        public void Display1(int data)
        {
            Console.WriteLine("Inside Display1()");
        }

        public void Display2(int data, String name)
        {
            Console.WriteLine("Inside Display2()");
        }
    }
    class ReflectionDynamicMethodInvokeDemo2
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("ReflectionDynamicMethodInvokeDemo2.MyClass"); // set the type to the namespace and class name. Passing Reflection as a message

            Object obj = Activator.CreateInstance(t);                            //If ths statement is commented then the object is not created

            MethodInfo m = t.GetMethod("Display1", new[] { typeof(int) });       //It gets the Display1 name form the MethodInfo in Reflection
            m.Invoke(obj, new Object[] { 10 });                                  //Second paramter is not null because there is is a paramter in Method Display1().
                                                                                 //This goes inside Method Display1() and outputs the line of text
            m = t.GetMethod("Display2", new[] { typeof(int), typeof(String) });                  //It gets the Display2 name form the MethodInfo in Reflection
            m.Invoke(obj, new Object[] { 10, "Manchester" });                   //Second paramter is not null because there is are paramters in Method Display2().
                                                                                 //This goes inside Method Display2() and outputs the line of text
        }
    }
}
