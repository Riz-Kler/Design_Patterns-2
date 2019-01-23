using System;
using System.Reflection;

// To demonstrate getting method Parameter and return Value Information

namespace ReflectionParamRetValDemo
{
    class MyClass
    {
        public int data;
        public String name;

        public MyClass(int data, String name) { }
        public void Method1() { }
        public String Method2(int value) { return "XYZ"; }
        public int Method3(int value, String firstname) { return value; }
    }
    class ReflectionParamRetValueDemo
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("ReflectionParamRetValDemo.MyClass"); // set the type to the namespace and class name

            MethodInfo[] methods = t.GetMethods(); //gets all the methods using Parameter return Value in the namespace and class

            foreach (MethodInfo m in methods)
            {
                Console.WriteLine("Name : " + m.Name);
                Console.WriteLine("DeclaringType : " + m.DeclaringType);
                Console.WriteLine("MemberType : " + m.MemberType);

                ParameterInfo[] parameters = m.GetParameters();
                foreach(ParameterInfo p in parameters)
                {
                    Console.WriteLine("Parameter Name : " + p.Name);
                    Console.WriteLine("Type : " + p.ParameterType);
                }
                Console.WriteLine("ReturnType : " + m.ReturnType + "\n");
            }
        }
    }
}
